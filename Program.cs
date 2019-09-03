using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senior_Project
{
    static class Program
    {
          /// <summary>
          /// The main entry point for the application.
          /// </summary>

          public static int student_counter;
          public static int note_counter;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

               string filename = "startup.txt";
               if (!System.IO.File.Exists(filename))
               {
                    System.IO.File.WriteAllText(filename, "1");
                    System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\HomeroomHelper");
                    Database_Interface.CreateDB();
                    student_counter = 0;
                    note_counter = 0;
                    Application.Run(new Welcome_Form());
               }
               else
               {
                    student_counter = Database_Interface.QueryNumStudents();
                    note_counter = Database_Interface.QueryNumNotes();
                    Application.Run(new App());
               }



               //--------------------------------------------//
               //Debug -> choose to run one form or the other |
               //--------------------------------------------//

               //Application.Run(new App());
               //Application.Run(new App());
          }
    }
}
