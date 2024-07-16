use std::collections::HashMap;
use std::fs::File;
use std::io::{BufRead, BufReader};
use std::sync::{Arc, Mutex};
use std::thread;

struct StationData {
    min: f32,
    max: f32,
    sum: f64,
    count: u32,
}

fn main() {
    let file = File::open("/measurements/measurements.txt").unwrap();
    let reader = BufReader::with_capacity(1024 * 1024, file);
    let lines = reader.lines();

    let chunk_size = 1_000_000; // Adjust based on your system
    let num_threads = 10; // Adjust based on your CPU cores

    let results = Arc::new(Mutex::new(HashMap::<String, StationData>::new()));

    thread::scope(|s| {
        let mut handles = Vec::new();
        for _ in 0..num_threads {
            let results = Arc::clone(&results);
            let handle = s.spawn(move || {
                let mut local_results = HashMap::new();
                for line in lines.take(chunk_size) {
                    if let Ok(line) = line {
                        let parts: Vec<&str> = line.split(';').collect();
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
    for (station, data) in final_results.iter() {
        println!(
            "{}: min={:.1}, max={:.1}, avg={:.1}",
            station,
            data.min,
            data.max,
            data.sum / data.count as f64
        );
    }
}
