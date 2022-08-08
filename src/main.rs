use crossterm::event::{Event, KeyCode, KeyEvent};
use crossterm::{event, terminal};
use crossterm::{terminal::{EnterAlternateScreen, LeaveAlternateScreen}};
use crossterm::execute;
use crossterm::cursor;

use std::io::stdout;
use std::time::Duration;

use crate::utils::file_manipulation::file_manipulation;
use crate::utils::tools::tools;
use crate::utils::ops::ops;
pub mod utils;

struct CleanUp;

impl Drop for CleanUp {
    fn drop(&mut self) {
        terminal::disable_raw_mode().expect("Unable to disable raw mode")
    }
}

fn main() -> crossterm::Result<()> {
    execute!(stdout(), EnterAlternateScreen)?;
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
                            let temp_contents_item = ops::edit(index, contents[index-1].len());
                            contents[index-1] = temp_contents_item; 
                            
                            file_manipulation::write_to_file_edit(&contents, index, index_status);
                            contents[index-1] = t+&contents[index-1];
                            ops::print_item(index, &contents)
                        }
                        //add command
                        KeyEvent{
                            code: KeyCode::Char('a'), modifiers: event::KeyModifiers::NONE
                        } => {
                            contents.push(" - [ ] New Task".to_string());
                            index = contents.len();
                            ops::print_item(index, &contents);
                            let temp_contents_item = ops::edit(index, contents[index-1].len());
                            contents[index-1] = " - [ ] ".to_string()+&temp_contents_item;
                            file_manipulation::write_to_file(&contents);
                            ops::print_item(index, &contents);
                        },
                        //delete command
                        KeyEvent {
                            code: KeyCode::Char('d'), modifiers: event::KeyModifiers::NONE
                        } => {
                            contents.remove(index-1);
                            file_manipulation::write_to_file(&contents);
                            index -= 1;
                            ops::print_item(index, &contents);
                        },
                        //toggle command
                        KeyEvent {
                            code: KeyCode::Char('t'), modifiers: event::KeyModifiers::NONE
                        } => {
                            let contents_item: String = contents[index-1].clone();
                            let s = contents_item.split(" ");
                            let mut vec: Vec<String> = s.map(String::from).collect::<Vec<_>>();
                            let ele = vec.get(2).expect("");
                            if ele == "[" {
                                for _ in 0..4 {
                                    vec.remove(0);
                                }
                                let mut joined = vec.join(" ");
                                joined = " - [x] ".to_string()+&joined;
                                contents[index-1] = joined;
                            } else if ele == "[x]" {
                                for _ in 0..3{
                                    vec.remove(0);
                                }
                                let mut joined = vec.join(" ");
                                joined = " - [ ] ".to_string()+&joined;
                                contents[index-1] = joined;
                            }
                            file_manipulation::write_to_file(&contents);
                            ops::print_item(index, &contents)
                        }


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

                        //moving tasks
                        KeyEvent {
                            code: KeyCode::Down, modifiers: event::KeyModifiers::SHIFT
                        } => {
                            if index != contents.len(){
                                let a = contents[index-1].clone();
                                let b = contents[index].clone();
    
                                contents[index] = a;
                                contents[index-1] = b;
                            }
                            file_manipulation::write_to_file(&contents);
                        }
                        KeyEvent {
                            code: KeyCode::Up, modifiers: event::KeyModifiers::SHIFT
                        } => {
                            if index != 1{
                                let a = contents[index-2].clone();
                                let b = contents[index-1].clone();

                                contents[index-1] = a;
                                contents[index-2] = b;
                            }
                            file_manipulation::write_to_file(&contents);
                        },
                        _ => {/*default*/}
                    }
                    if event.code == KeyCode::Right || event.code == KeyCode::Left || event.code == KeyCode::Up || event.code == KeyCode::Down
                    {
                        ops::print_item(index as usize, &contents);
                    }
                    execute!(stdout(), cursor::Hide)?;
                }
            }
        }
    }
}