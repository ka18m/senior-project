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

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);






               //string filename = "startup.txt";
               //if (!System.IO.File.Exists(filename))
               //{
               //    System.IO.File.WriteAllText(filename, "1");
                     Database_Interface.CreateDB();
               //    Application.Run(new Welcome_Form());
               //}
               //else
               //{
               //    Application.Run(new App());
               //}
               student_counter = Database_Interface.QueryNumStudents();


               //--------------------------------------------//
               //Debug -> choose to run one form or the other |
               //--------------------------------------------//

               //Application.Run(new App());
               Application.Run(new Class_Form());
          }
    }
}
