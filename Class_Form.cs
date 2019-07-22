using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senior_Project
{
     public partial class Class_Form : Form
     {
          public Class_Form()
          {
               InitializeComponent();
               PopulateDataGridView();
          }

          Stack<Student> upsert_stack = new Stack<Student>();
          Stack<Student> delete_stack = new Stack<Student>();

          private void PopulateDataGridView()
          {
               Student[] all_students = Database_Interface.QueryAll();
               MessageBox.Show(Convert.ToString(all_students[0]));
               for(int i = 0; i < Program.student_counter; i++)
               {
                    string[] temp = {Convert.ToString(all_students[0]), Convert.ToString(all_students[1]), Convert.ToString(all_students[2]), Convert.ToString(all_students[3]), Convert.ToString(all_students[4]), Convert.ToString(all_students[5])};
                    StudentPanel.Rows.Add(temp);
               }
          }

          private void New_Student_Click(object sender, EventArgs e) //creates Student object, adds to upsert_stack and adds to listbox
          {
               int temp_id = 123;
               Student new_student = new Student(temp_id, cf_fname.Text, cf_lname.Text, cf_o_rdglvl.Text.ToCharArray()[0], cf_cur_rdglvl.Text.ToCharArray()[0], cf_goal_rdglvl.Text.ToCharArray()[0]);
               StudentPanel.Rows.Add(new_student.ToArray());
               upsert_stack.Push(new_student); //Save obj to be saved to db
               Clear_TextBoxes();
          }

          private void Import_Student_Click(object sender, EventArgs e)
          {

          }

          private void Export_One_Click(object sender, EventArgs e)
          {

          }

          private void Export_All_Click(object sender, EventArgs e)
          {

          }

          private void Delete_One_Click(object sender, EventArgs e)
          {

          }

          private void Delete_All_Click(object sender, EventArgs e)
          {

          }

          private void Home_Click(object sender, EventArgs e)
          {
               //close current form and open main menu
          }

          private void Save_Click(object sender, EventArgs e)
          {
               //add students from upsert_stack
               //delete students from delete_stack
          }

          private void Clear_TextBoxes()
          {
               cf_fname.Clear();
               cf_lname.Clear();
               cf_o_rdglvl.Clear();
               cf_cur_rdglvl.Clear();
               cf_goal_rdglvl.Clear();
          }
     }
}
