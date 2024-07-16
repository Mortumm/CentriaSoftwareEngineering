use rand::Rng;
use std::fs::File;
use std::io::{BufWriter, Write};

const NUM_ROWS: usize = 1_000_000;
const NUM_STATIONS: usize = 10_000;

fn main() {
    let file = File::create("measurements.txt").unwrap();
    let mut writer = BufWriter::new(file);
    let mut rng = rand::thread_rng();

    for _ in 0..NUM_ROWS {
        let station = format!("S{:04}", rng.gen_range(0..NUM_STATIONS));
        let temperature = rng.gen_range(-99.9..99.9);
        writeln!(writer, "{};{:.1}", station, temperature).unwrap();
    }

    writer.flush().unwrap();
}
