use crossterm::event::{Event, KeyCode, KeyEvent};
use crossterm::{event, terminal};
use crossterm::{terminal::{EnterAlternateScreen, LeaveAlternateScreen}};
use crossterm::execute;
// use crossterm::Result;

// use crossterm::style::Stylize;

// use std::io;
// use std::process;
// use std::io::Write;
use std::io::stdout;
use std::time::Duration;

pub mod utils;

struct CleanUp;

impl Drop for CleanUp {
    fn drop(&mut self) {
        terminal::disable_raw_mode().expect("Unable to disable raw mode")
    }
}

/*
TODO
put in alternate screen
actually doing the visuals
*/
#[allow(unused_must_use)]
fn main() -> crossterm::Result<()> {
    execute!(stdout(), EnterAlternateScreen);
    utils::clear_screen_alternate();
    start()?;
    // println!("Exiting Program \r");
    terminal::disable_raw_mode()?;
    execute!(stdout(), LeaveAlternateScreen);

    // process::exit(1);
    Ok(())
}

#[allow(unused_must_use)]
fn start() -> crossterm::Result<()> {
    let _clean_up = CleanUp;
    let mut index: u32 = 1;
    let mut items = vec![
        String::from("item_1"),
        String::from("item_2"),
        String::from("item_3")
    ];
    let index_limit = items.len(); let index_limit = index_limit as u32;
    println!(" -- STARTED -- ");
    utils::print_item(index as usize, &mut items);
    // println!("Recording Key Started"); 
    utils::clear_screen_alternate();
    loop {    
        terminal::enable_raw_mode()?;
        loop {
            if event::poll(Duration::from_millis(1000))? {
                if let Event::Key(event) = event::read()? {
                    //THIS IS A FUCKING MESS
                    match event {
                        KeyEvent {
                            code: KeyCode::Char('q'),
                            modifiers: event::KeyModifiers::CONTROL, /* modify */
                        } => {
                            return Ok(());
                        },
                        KeyEvent {
                            code: KeyCode::Enter,
                            modifiers: event::KeyModifiers::NONE,
                        } => {},
                        KeyEvent {
                            code: KeyCode::Right,
                            modifiers: event::KeyModifiers::NONE
                        } => {  
                            if index < index_limit {
                                index += 1;
                            }
                        },
                        KeyEvent {
                            code: KeyCode::Left,
                            modifiers: event::KeyModifiers::NONE
                        } => { 
                            if index > 1 {
                                index -=1 ;
                            }
                        },
                        KeyEvent {
                            code: KeyCode::Down,
                            modifiers: event::KeyModifiers::NONE
                        } => {  
                            if index < index_limit {
                                index += 1;
                            }
                        },
                        KeyEvent {
                            code: KeyCode::Up,
                            modifiers: event::KeyModifiers::NONE
                        } => { 
                            if index > 1 {
                                index -=1 ;
                            }
                        },
                        KeyEvent {
                            code: KeyCode::Char('e'),
                            modifiers: event::KeyModifiers::NONE
                        } => {
                            // items[index as usize] = text_input_raw();
                            let new_message = utils::text_input_raw(index, items[index as usize].chars().count());
                            items[(index as usize)-1] = new_message;
                        }

                        _ => {/*empty, others keys are left useless*/},
                    }
                    utils::clear_screen_alternate();
                    if event.code == KeyCode::Right || event.code == KeyCode::Left || event.code == KeyCode::Up || event.code == KeyCode::Down{
                        println!("{:?}, index : {} \r", event, index);
                        utils::print_item(index as usize, &mut items);
                    }
                    // println!("{:?}, index : {} \r", event, index);
                };
            } else {
                //lL
                // println!("No input yet\r");}
            } 
            // println!("end");
        
        }
        // terminal::disable_raw_mode()?;
        // print!(">>>");
        // let mut input = String::new();
        // io::stdout().flush().unwrap();
        // io::stdin()
        //     .read_line(&mut input)
        //     .expect("unable to read line");
        // println!("input : {}", input);
    }
}
