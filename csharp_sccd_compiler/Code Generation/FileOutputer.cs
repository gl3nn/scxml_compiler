using System;
using System.IO;
using System.Linq;

namespace csharp_sccd_compiler
{
    public class FileOutputer
    {
        int             indent_level = 0;
        int             nr_of_indent_chars = 4;
        char            ident_char = ' ';
        bool            first_write = true;
        StreamWriter    output_file;

        public FileOutputer(string output_file_path)
        {
            output_file = new StreamWriter(output_file_path);
        }

        public void write(string text = "")
        {
            if (this.first_write)
            {
                this.first_write = false;
                this.output_file.Write(text.PadLeft(this.indent_level * this.nr_of_indent_chars, this.ident_char));
            }
            else
            {
                this.output_file.WriteLine();
                this.output_file.Write(text.PadLeft(this.indent_level * this.nr_of_indent_chars, this.ident_char));
            }
        }

        public void extendWrite(string text = "")
        {
            this.output_file.Write(text);            
        }

        public void indent()
        {
            this.indent_level += 1;
        }

        public void dedent()
        {
            this.indent_level -= 1;
        }

        public void close()
        {
            this.output_file.Close();
        }
    }
}

