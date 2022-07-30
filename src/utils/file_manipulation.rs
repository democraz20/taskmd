// use std::fs::File;

// use std::io::ErrorKind;

pub mod file_manipulation{    
    use std::fs;
    use std::fs::OpenOptions;
    use std::io::Write;
    // use crate::utils::tools::tools;

    pub fn index_tasks() -> Vec<String> {
        let contents = fs::read_to_string("TASK.md").expect("Unable to read file");
        let contents = contents.split("\n");
        //LITERAL LIFE SAVER
        let mut contents: Vec<String> = contents.map(String::from).collect::<Vec<_>>();
        for _ in 0..7 {
            contents.remove(0);
        }
        for _ in 0..2 {
            contents.remove(contents.len() - 1);
        }
        //trim array
        contents
    }

    pub fn write_to_file(tasks: &Vec<String>, edit_index: usize, edit_status: bool) {
        let error_mes = "could not write to file";
        let mut file = OpenOptions::new()
            .read(true)
            .write(true)
            .create(true)
            .truncate(true)
            .open("TASK.md")
            .unwrap();

        //its gotta be like that
        file.write_all(
            b"<!-- this file was generated with TASKmd 
git repository : https://github.com/democraz20/taskmd
! DO NOT EDIT THIS FILE MANUALLY !
-->

# Tasks \n\n").expect(error_mes);
        // file.write_all(b"# Tasks\n\n").expect(error_mes);
        
        for (ind, ele) in tasks.iter().enumerate() {
            if ind == edit_index-1 {
                if !edit_status { //false
                    file.write_all(b" - [ ] ").expect(error_mes);
                    file.write_all(ele.as_bytes()).expect(error_mes);
                } else {
                    file.write_all(b" - [x] ").expect(error_mes);
                    file.write_all(ele.as_bytes()).expect(error_mes);
                }
                // file.write_all(ele.as_bytes()).expect(error_mes);
            }
            else {
                file.write_all(ele.as_bytes()).expect(error_mes);
            }
            file.write_all(b"\n").expect(error_mes);        
        }
        file.write_all(b"\n> Made with [TASKmd](https://github.com/democraz20/taskmd)").expect(error_mes);
        // file.write_all(b"test");
    }
}