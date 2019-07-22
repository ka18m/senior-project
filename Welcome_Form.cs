using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Senior_Project
{
    public partial class Welcome_Form : Form
    {
          public Welcome_Form()
          {
               InitializeComponent();
               Program.student_counter = Database_Interface.QueryNumStudents();
          }

          private void Create_Button_Click(object sender, EventArgs e) //go to manage class room form
          {
               Application.Run(new Class_Form());
          }

          private void Import_Button_Click(object sender, EventArgs e)
          {

          }
     }
}
