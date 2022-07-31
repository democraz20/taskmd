pub mod ops{
    use crossterm::terminal;
    use crossterm::style::Stylize;
    use crossterm::execute;
    // use crossterm::Result;
    use crossterm::cursor::MoveTo;
    
    use std::io;
    // use std::process;
    use std::io::Write;
    use std::io::stdout;

    use crate::utils::tools::tools::*;
    pub fn print_item(index: usize, items: &Vec<String>){
        clear_screen_alternate();
        // print!("{esc}[2J{esc}[1;1H", esc = 27 as char);
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
            // if ind+1 == index {
            //     println!("    > {}\r", ele.clone().green());
            // } else {
            //     println!("      {}\r", ele);
            // }
        }
        // println!("\r");
        // utils::clear_screen_alternate();
    }

    #[allow(unused_must_use)]
    pub fn edit(index: usize, item_to_edit: String) -> String{
        execute!(stdout(), MoveTo(8, (index as u16)+1));
        for _ in 0..item_to_edit.len()+7 {
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
                // input = format_text_input(input);
                terminal::enable_raw_mode();
                // format_text_input(String::from(" - [ ] ")+&input)
                format_text_input(input)
            }
            Err(e) => {panic!("Error!: {}", e);}
        }
    }
}