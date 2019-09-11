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
     public partial class Conference_Form : Form
     {
          public Conference_Form()
          {
               InitializeComponent();

               //Load ComboBox
               List<string> names = Database_Interface.Query_Student_Names();
               foreach (string name in names)
               student_select.Items.Add(name);
          }

          private int current_student_id; //Changes when selection changes

          private void Home_Button_Click(object sender, EventArgs e)
          {
               this.Close();
          }

          private void Student_Select_SelectedIndexChanged(object sender, EventArgs e)
          {
               //Query notes db for dates & notes under selected name
               string name = Convert.ToString(student_select.SelectedItem);  //Get name of student from combobox
               string[] fullname = name.Split(' ');

               //MessageBox.Show(fullname[0] + " " + fullname[1]);
               current_student_id = Database_Interface.Query_ID(fullname[0], fullname[1]);
               Refresh_Notes();

          }

          private void Add_Note_Click(object sender, EventArgs e)
          {
               using(New_Note_Form new_note = new New_Note_Form())
               {
                    if(new_note.ShowDialog() == DialogResult.OK)
                    {
                         Database_Interface.Add_Note(current_student_id, new_note.Note, new Conference_Types(new_note.Category).Type);
                    }
               }
               Refresh_Notes();
          }

          private void Refresh_Notes()
          {
               notes.Items.Clear();
               List<Note> student_notes = Database_Interface.Query_Note(current_student_id);

               //Display in listview
               foreach (Note n in student_notes)
               {
                    ListViewItem item = new ListViewItem(new string[] { Convert.ToString(n.id), Convert.ToString(n.student_id), n.date, n.note });
                    notes.Items.Add(item);
               }
          }

          private void Edit_Note_Click(object sender, EventArgs e)
          {
               //If nothing selected, pop-up message
              if(notes.SelectedItems.Count == 0)
               {
                    MessageBox.Show("Please select a note to edit");
                    return;
               }
               Note edit_note = new Note();
               ListViewItem item = notes.SelectedItems[0];
               edit_note.id = Convert.ToInt32(item.SubItems[0].Text);
               edit_note.student_id = Convert.ToInt32(item.SubItems[1].Text);
               edit_note.date = item.SubItems[2].Text;
               edit_note.note = item.SubItems[3].Text;
               edit_note.category = item.SubItems[4].Text;

               using (New_Note_Form edit = new New_Note_Form())
               {
                    edit.Note = edit_note.note;
                    if (edit.ShowDialog() == DialogResult.OK)
                    {
                         Database_Interface.Update_Note(edit_note.id, edit.Note, new Conference_Types(edit.Category).Type);
                    }

               }
               Refresh_Notes();
                    
          }

          private void Delete_Note_Click(object sender, EventArgs e)
          {
               //If nothing selected, pop-up message
               if (notes.SelectedItems.Count == 0)
               {
                    MessageBox.Show("Please select a note to delete");
                    return;
               }

               Note edit_note = new Note();
               ListViewItem item = notes.SelectedItems[0];
               edit_note.id = Convert.ToInt32(item.SubItems[0].Text);
               edit_note.student_id = Convert.ToInt32(item.SubItems[1].Text);
               edit_note.date = item.SubItems[2].Text;
               edit_note.note = item.SubItems[3].Text;
               edit_note.category = item.SubItems[4].Text;

               Database_Interface.Delete_Note(edit_note.id);

               Refresh_Notes();
          }
     }
}
