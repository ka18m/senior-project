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
               List<Student> all_students = Database_Interface.QueryAll();
               //MessageBox.Show(Convert.ToString(all_students[0]));
               for(int i = 0; i < Program.student_counter; i++)
               {
                    string[] student = all_students.ElementAt(i).ToArray();
                    StudentPanel.Rows.Add(student);
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
               IO.Import();
          }

          private void Export_One_Click(object sender, EventArgs e)
          {
               List<Student> student = new List<Student>();
               //TODO: figure out how to "select" students 
               IO.StudentsToFile(student);
          }

          private void Export_All_Click(object sender, EventArgs e)
          {
               IO.StudentsToFile(Database_Interface.QueryAll());  //figure out why filename is student name repeated, not separate files
          }

          private void Delete_One_Click(object sender, EventArgs e)
          {

          }

          private void Delete_All_Click(object sender, EventArgs e)
          {

          }

          private void Home_Click(object sender, EventArgs e)
          {
               //TODO: close current form and open main menu
          }

          private void Save_Click(object sender, EventArgs e)
          {
               //TODO: add students from upsert_stack  -> upsert based on id
               //TODO: delete students from delete_stack
          }

          private void Clear_TextBoxes()
          {
               cf_fname.Clear();
               cf_lname.Clear();
               cf_o_rdglvl.Clear();
               cf_cur_rdglvl.Clear();
               cf_goal_rdglvl.Clear();
          }

          private void StudentPanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {
               int row = e.RowIndex;
               cf_fname.Text = StudentPanel.Rows[row].Cells[1].Value.ToString();
               cf_lname.Text = StudentPanel.Rows[row].Cells[2].Value.ToString();
               cf_o_rdglvl.Text = StudentPanel.Rows[row].Cells[3].Value.ToString();
               cf_cur_rdglvl.Text = StudentPanel.Rows[row].Cells[4].Value.ToString();
               cf_goal_rdglvl.Text = StudentPanel.Rows[row].Cells[5].Value.ToString();
          }

     }
}
