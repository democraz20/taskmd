use crossterm::event::{Event, KeyCode, KeyEvent};
use crossterm::{event, terminal};
use crossterm::{terminal::{EnterAlternateScreen, LeaveAlternateScreen}};
use crossterm::execute;
use crossterm::cursor;
// use crossterm::Result;

// use crossterm::style::Stylize;

// use std::io;
// use std::process;
// use std::io::Write;
use std::io::stdout;
use std::time::Duration;

use crate::utils::file_manipulation::file_manipulation;
use crate::utils::tools::tools;
use crate::utils::ops::ops;
pub mod utils;

// pub mod utils;
// pub mod file_manipulation;
// pub mod ops;

struct CleanUp;

impl Drop for CleanUp {
    fn drop(&mut self) {
        terminal::disable_raw_mode().expect("Unable to disable raw mode")
    }
}

fn main() -> crossterm::Result<()> {
    execute!(stdout(), EnterAlternateScreen)?;
    // terminal::enable_raw_mode()?;
    // utils::clear_screen_alternate();
    /* start here */
    start()?;
    terminal::disable_raw_mode()?;
    execute!(stdout(), LeaveAlternateScreen)?;
    Ok(())
}

fn start() -> crossterm::Result<()> {
    let _clean_up = CleanUp;
    let mut index = 1;
    loop {
        terminal::enable_raw_mode()?;
        // utils::clear_screen_alternate();
        tools::clear_screen_alternate();
        loop {
            if event::poll(Duration::from_millis(1000))? {
                if let Event::Key(event) = event::read()? {
                    let mut contents = file_manipulation::index_tasks();
                    let index_limit = contents.len();
                    match event {
                        KeyEvent {
                            code: KeyCode::Char('q'), modifiers: event::KeyModifiers::CONTROL
                        } => { return Ok(()) }
                        KeyEvent{
                            code: KeyCode::Char('e'), modifiers: event::KeyModifiers::NONE
                        } => {
                            execute!(stdout(), cursor::Show)?;
                            let current_item = &contents[index-1];
                            let s = current_item.split(" ");
                            let mut _vec: Vec<String> = s.map(String::from).collect::<Vec<_>>();
                            let ele = _vec.get(2).expect("");
                            let mut index_status = false;
                            let mut t: String = "".to_string();
                            if ele == "[" {
                                index_status = false;
                                t = " - [ ] ".to_string();
                            } else if ele == "[x]" {
                                index_status = true;
                                t = " - [x] ".to_string();
                            }
                            //to check for the original value, check from before edit is called
                            let temp_contents_item = ops::edit(index, contents[index-1].clone());
                            contents[index-1] = temp_contents_item; 
                            
                            // ops::print_item(index, &contents);
                            file_manipulation::write_to_file_edit(&contents, index, index_status);
                            // utils::log("wrote to file\n");
                            contents[index-1] = t+&contents[index-1];
                            ops::print_item(index, &contents)
                        }
                        KeyEvent{
                            code: KeyCode::Char('a'), modifiers: event::KeyModifiers::NONE
                        } => {
                            contents.push(" - [ ] New Task".to_string());
                            file_manipulation::write_to_file(&contents);
                            ops::print_item(index, &contents);
                        },


                        //navigation
                        //dont mess with
                        KeyEvent {
                            code: KeyCode::Right, modifiers: event::KeyModifiers::NONE
                        } => {  if index < index_limit {index += 1;}},
                        KeyEvent {
                            code: KeyCode::Left, modifiers: event::KeyModifiers::NONE
                        } => { if index > 1 {index -=1 ;}},
                        KeyEvent {
                            code: KeyCode::Down, modifiers: event::KeyModifiers::NONE
                        } => {  if index < index_limit {index += 1;}},
                        KeyEvent {
                            code: KeyCode::Up, modifiers: event::KeyModifiers::NONE
                        } => { if index > 1 {index -=1 ;}},
                        _ => {/*default*/}
                    }
                    if event.code == KeyCode::Right || event.code == KeyCode::Left || event.code == KeyCode::Up || event.code == KeyCode::Down
                    {
                        // println!("{:?}, index : {} \r", event, index);
                        ops::print_item(index as usize, &contents);
                    }
                    execute!(stdout(), cursor::Hide)?;
                    // ops::print_item(index, &contents);
                }
            }
        }
    }
}