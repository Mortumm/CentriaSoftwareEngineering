use std::fs;
use std::io::Read;
use std::path::PathBuf;

use pulldown_cmark::{Event, Parser, Tag};

fn main() -> Result<(), Box<dyn std::error::Error>> {
    // Parse command line arguments
    let mut args = std::env::args().skip(1);
    let input_dir = match args.next() {
        Some(path) => PathBuf::from(path),
        None => return Err(From::from("Missing input directory argument")),
    };
    let output_dir = match args.next() {
        Some(path) => PathBuf::from(path),
        None => return Err(From::from("Missing output directory argument")),
    };

    // Create output directory if it doesn't exist
    fs::create_dir_all(&output_dir)?;

    // Loop through files in input directory
    for entry in fs::read_dir(input_dir)? {
        let entry = entry?;
        let path = entry.path();

        // Check for .html files
        if !path.is_file() || path.extension().unwrap().to_str().unwrap() != "html" {
            continue;
        }

        // Read file content
        let mut content = String::new();
        let mut file = fs::File::open(&path)?;
        file.read_to_string(&mut content)?;

        // Convert HTML to Markdown
        let markdown = convert_html_to_markdown(&content)?;

        // Generate filename and path
        let filename = generate_filename(&content)?;
        let output_path = output_dir.join(filename);

        // Write markdown content to file
        fs::write(output_path, markdown)?;

        println!("Converted: {} -> {}", path.display(), output_path.display());
    }

    Ok(())
}

fn convert_html_to_markdown(html: &str) -> Result<String, Box<dyn std::error::Error>> {
    let mut markdown = String::new();
    let mut title: Option<String> = None;
    let mut date: Option<String> = None;

    let mut events = Parser::new(html).into_offset_iter().peekable();
    while let Some((event, _)) = events.next() {
        match event {
            Event::Text(text) => markdown.push_str(&text),
            Event::Html(tag) => match tag {
                Tag::Heading(level) => {
                    if level == 1 {
                        let mut heading_text = String::new();
                        while let Some((next_event, _)) = events.peek() {
                            match next_event {
                                Event::Text(text) => {
                                    heading_text.push_str(text);
                                }
                                _ => {}
                            }
                            if let Some(next_offset) = events.peek().map(|(_, o)| *o) {
                                if next_offset > events.offset() {
                                    break;
                                }
                            } else {
                                break;
                            }
                            events.next();
                        }
                        title = Some(heading_text.trim().to_owned());
                    }
                }
                Tag::Html(attrs) => {
                    for (key, value) in attrs {
                        if key.to_lowercase() == "pubdate" {
                            date = Some(value.to_string());
                            break;
                        }
                    }
                }
                _ => {} // Ignore other tags for now
            },
            _ => {} // Ignore other events
        }
    }

    // Handle missing title or date
    let title = title.ok_or_else(|| From::from("Missing title in HTML"))?;
    let date = date.ok_or_else(|| From::from("Missing date in HTML"))?;

    // Generate markdown frontmatter and content
    let content = format!(
        "---\nlayout: \ntitle: {}\ndate: {}\ncategory: \n  - \"Mortumm\"\n---\n{}\n",
        title, date, markdown
    );

    Ok(content)
}

fn generate_filename(content: &str) -> Result<String, Box<dyn std::error::Error>> {
    let mut words = content.split_whitespace();
    let first_three_words = words.take(3).collect::<Vec<_>>().join("-");

    if first_three_words.is_empty() {
        return Err(From::from("Empty content, cannot generate filename"));
    }

    Ok(format!("{}.md", first_three_words))
}
