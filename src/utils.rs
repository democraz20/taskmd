// use crossterm::event::{Event, KeyCode, KeyEvent};
use crossterm::terminal;
// use crossterm::{terminal::{EnterAlternateScreen, LeaveAlternateScreen}};
// use crossterm::event;
use crossterm::execute;
// use crossterm::Result;
use crossterm::cursor::MoveTo;
use crossterm::style::Stylize;

use std::io;
// use std::process;
use std::io::Write;
use std::io::stdout;


// use std::time::Duration;

pub fn clear_screen_alternate() {
    print!("{esc}[2J{esc}[1;1H", esc = 27 as char); //for use within alternate screen
}
pub fn print_item(index: usize, items: &Vec<String>){
    println!();
    // let item = vec!["item_1", "item_2", "item_3", "item_4", "item_5"];
    for(ind, ele) in items.iter().enumerate() {
        // let ind = usize_to_u16(ind);
        if ind+1 == index {
            println!("      {} < \r", ele.clone().green());
        } else {
            println!("      {} \r", ele);
        }
        // print!(" ({}, {}) " , ele, ind)
    }
    println!("\r");
}

pub fn format_text_input(input: String) -> String {
    /*supposed to be cross platform windows and unix
    unix only has a \n after a terminal line input
    windows uses \r\n 
    this function is supposed to take in any text and 
    prettyfy it to normal 1 line str */
    let mut char_vec: Vec<char> = input.chars().collect();

    //char_vec maybe empty, need fix
    if char_vec[char_vec.len()-1] == '\n' {
        char_vec.remove(char_vec.len()-1);
        // char_vec.remove(char_vec.len()-1);
    }
    if char_vec[char_vec.len()-1] == '\r' {
        char_vec.remove(char_vec.len()-1);
    }
    // char_vec.join();
    let joined: String = char_vec.iter().collect();
    joined
}

