using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senior_Project
{
     class Note
     {
          //Properties
          public int id;
          public int student_id;
          public string date;
          public string note;
          public string category; 

          public static int Generate_Note_ID()
          {
               Program.note_counter += 1;
               return Program.note_counter;
          }
     }
}
