// use std::fs::File;
use std::fs;
// use std::io::ErrorKind;

pub fn index_tasks() -> Vec<String>{
    let contents = fs::read_to_string("TASK.md").expect("Unable to read file");
    let contents = contents.split("\n");
    //LITERAL LIFE SAVER
    let mut contents: Vec<String> = contents.map(String::from).collect::<Vec<_>>();
    for i in 0..7 {
        contents.remove(0);
    }
    for i in 0..2 {
        contents.remove(contents.len()-1);
    }
    //trim array
    contents
}