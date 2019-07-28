using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Senior_Project
{
     static class IO
     {
          //open dialog for import
          public static void Import()
          {
               string[] filepaths;

               OpenFileDialog dialog = new OpenFileDialog();
               dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\HomeroomHelper";
               dialog.Multiselect = true;

               if (dialog.ShowDialog() == DialogResult.OK)
               {
                    filepaths = dialog.FileNames;
                    List<Student> imports = new List<Student>();
                    foreach (string file in filepaths)
                    {
                         List<Student> one = IO.FileToStudents(file);   //Each file should have about 30 kids max, so limited time complexity
                         foreach (Student s in one)
                         {
                              imports.Add(s);
                         }
                    }
                    Database_Interface.AddStudents(imports);
               }
          }

          //from csv file to Student array
          public static List<Student> FileToStudents (string filename)
          {
               List<Student> temp = new List<Student>();

               List<string[]> strings = FileToStrings(filename);

               foreach(string[] line in strings)
               {
                    temp.Add(new Student(new List<string>(line)));
               }

               return temp;
          }

          //from csv file to string array
          public static List<string[]> FileToStrings (string filename)
          {
               List<string[]> temp = new List<string[]>();

               StreamReader reader = new StreamReader(filename);

               while (!reader.EndOfStream)
               {
                    string line = reader.ReadLine();  //get line
                    string[] values = line.Split(','); //delimit by comma

                    temp.Add(values);
               }

               return temp;
          }

          //from string array to csv file
          //TODO: is this function needed?

          //from Student array to csv file
          public static void StudentsToFile (List<Student> students)
          {
               string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\HomeroomHelper\";
               foreach (Student s in students)
               {
                    path += s.getFirstName() + s.getLastName() + ".csv";
                    StreamWriter writer = new StreamWriter(path);

                    string line = "";
                    line += s.getID() + ',';
                    line += s.getFirstName() + ',';
                    line += s.getLastName() + ',';
                    line += s.getStartLevel() + ',';
                    line += s.getCurrentLevel() + ',';
                    line += s.getGoalLevel();

                    writer.Write(line);

               }
          }
     }
}
