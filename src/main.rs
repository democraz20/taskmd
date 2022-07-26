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
pub mod file_manipulation;

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
        utils::clear_screen_alternate();
        loop {
            let mut contents = file_manipulation::index_tasks();
            let index_limit = contents.len();
            if event::poll(Duration::from_millis(1000))? {
                if let Event::Key(event) = event::read()? {
                    match event {
                        KeyEvent {
                            code: KeyCode::Char('q'), modifiers: event::KeyModifiers::CONTROL
                        } => { return Ok(()) }
                        KeyEvent {
                            code: KeyCode::Char('p'), modifiers: event::KeyModifiers::NONE
                        } => {
                            file_manipulation::write(contents);
                            println!("Wrote to file\r\n");
                        }
                        _ => {/*default*/}
                    }
                }
            }
        }
    }

}