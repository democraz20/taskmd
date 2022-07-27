use crossterm::terminal;
use crossterm::style::Stylize;
use crossterm::execute;
// use crossterm::Result;
use crossterm::cursor::MoveTo;

use std::io;
// use std::process;
use std::io::Write;
use std::io::stdout;



// use crate utils;

pub fn print_item(index: usize, items: &Vec<String>){
    // print!("{esc}[2J{esc}[1;1H", esc = 27 as char);
    print!("\n\n");
    for (ind, ele) in items.iter().enumerate() {
        if ind+1 == index {
            println!("    > {}\r", ele.clone().green());
        } else {
            println!("      {}\r", ele);
        }
    }
    // println!("\r");
    // utils::clear_screen_alternate();
}

#[allow(unused_must_use)]
pub fn edit(index: usize, item_to_edit: String) -> String{
    execute!(stdout(), MoveTo(6, (index as u16)+2));
    for _ in 0..item_to_edit.len()+7 {
        print!(" ");
    }
    execute!(stdout(), MoveTo(6, (index as u16)+2));
    match terminal::disable_raw_mode() {
        Ok(_) => {
            let mut input = String::new();
            io::stdout().flush().unwrap();
            io::stdin()
                .read_line(&mut input)
                .expect("unable to read line");  
            // input = format_text_input(input);
            terminal::enable_raw_mode();
            input
        }
        Err(e) => {panic!("Error!: {}", e);}
    }
}