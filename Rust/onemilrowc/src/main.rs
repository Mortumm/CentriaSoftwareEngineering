use std::collections::HashMap;
use std::fs::File;
use std::io::{BufRead, BufReader, Seek, SeekFrom, Write};
use std::sync::{Arc, Mutex};
use std::thread;

struct StationData {
    min: f32,
    max: f32,
    sum: f64,
    count: u32,
}

fn main() {
    let file = Arc::new(Mutex::new(File::open("measurements.txt").unwrap()));
    let file_size = file.lock().unwrap().metadata().unwrap().len();

    let num_threads = 10; // Adjust based on your available cores
    let chunk_size = file_size / num_threads as u64;

    let results = Arc::new(Mutex::new(HashMap::<String, StationData>::new()));

    thread::scope(|s| {
        let mut handles = Vec::new();
        for i in 0..num_threads {
            let file = Arc::clone(&file);
            let results = Arc::clone(&results);
            let handle = s.spawn(move || {
                let mut local_results = HashMap::new();
                let mut file = file.lock().unwrap();
                let start = i as u64 * chunk_size;
                let end = if i == num_threads - 1 {
                    file_size
                } else {
                    (i + 1) as u64 * chunk_size
                };

                file.seek(SeekFrom::Start(start)).unwrap();
                let mut reader = BufReader::new(file.try_clone().unwrap());
                let mut buffer = String::new();

                while reader.stream_position().unwrap() < end {
                    buffer.clear();
                    if reader.read_line(&mut buffer).unwrap() == 0 {
                        break;
                    }
                    let parts: Vec<&str> = buffer.trim().split(';').collect();
                    if parts.len() == 2 {
                        let station = parts[0].to_string();
                        let temperature: f32 = parts[1].parse().unwrap();
                        let entry = local_results.entry(station).or_insert(StationData {
                            min: temperature,
                            max: temperature,
                            sum: temperature as f64,
                            count: 1,
                        });
                        entry.min = entry.min.min(temperature);
                        entry.max = entry.max.max(temperature);
                        entry.sum += temperature as f64;
                        entry.count += 1;
                    }
                }

                let mut global_results = results.lock().unwrap();
                for (station, data) in local_results {
                    let entry = global_results.entry(station).or_insert(StationData {
                        min: f32::MAX,
                        max: f32::MIN,
                        sum: 0.0,
                        count: 0,
                    });
                    entry.min = entry.min.min(data.min);
                    entry.max = entry.max.max(data.max);
                    entry.sum += data.sum;
                    entry.count += data.count;
                }
            });
            handles.push(handle);
        }

        for handle in handles {
            handle.join().unwrap();
        }
    });

    let final_results = results.lock().unwrap();

    let mut output_file = File::create("results.txt").expect("Failed to create output file");

    for (station, data) in final_results.iter() {
        let output_line = format!(
            "{}: min={:.1}, max={:.1}, avg={:.1}\n",
            station,
            data.min,
            data.max,
            data.sum / data.count as f64
        );

        output_file
            .write_all(output_line.as_bytes())
            .expect("Failed to write to output file");
    }

    println!("Results have been written to results.txt");
}
