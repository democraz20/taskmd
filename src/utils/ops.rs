pub mod ops{
    use crossterm::terminal;
    use crossterm::style::Stylize;
    use crossterm::execute;
    use crossterm::cursor::MoveTo;
    use crossterm::cursor;
    
    use std::io;
    use std::io::Write;
    use std::io::stdout;

    use crate::utils::tools::tools::*;
    pub fn print_item(index: usize, items: &Vec<String>){
        clear_screen_alternate();
        print!("\n\n");
        for (ind, ele) in items.iter().enumerate() {
            let element = ele.clone();
            let s = element.split(" ");
            let mut vec: Vec<String> = s.map(String::from).collect::<Vec<_>>();
            let mut selected_status: bool = false;
            if vec[2] == "[" {
                for _ in 0..4 {
                    vec.remove(0);
                }
                selected_status = false;
            } else if vec[2] == "[x]" {
                for _ in 0..3 {
                    vec.remove(0);
                }
                selected_status = true;
            }
            let contents_final = vec.join(" ");
            if ind+1 == index {
                print!("    > ");
                if !selected_status {
                    print!("{} ", "x".red());
                } else {
                    print!("{} ", "✓".green());
                }
                print!("{}\r", contents_final.green());
                println!();
            } else {
                print!("      ");
                if !selected_status {
                    print!("{} ", "x".red());
                } else {
                    print!("{} ", "✓".green());
                }
                print!("{}\r", contents_final);
                println!();
            }
        }
    }

    #[allow(unused_must_use)]
    pub fn edit(index: usize, item_to_edit: usize) -> String{
        execute!(stdout(), cursor::Show);
        execute!(stdout(), MoveTo(8, (index as u16)+1));
        for _ in 0..item_to_edit {
            print!(" ");
        }
        execute!(stdout(), MoveTo(8, (index as u16)+1));
        match terminal::disable_raw_mode() {
            Ok(_) => {
                let mut input = String::new();
                io::stdout().flush().unwrap();
                io::stdin()
                    .read_line(&mut input)
                    .expect("unable to read line");  
                terminal::enable_raw_mode();
                format_text_input(input)
            }
            Err(e) => {panic!("Error!: {}", e);}
        }
    }
}