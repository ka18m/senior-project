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
     public partial class New_Note_Form : Form
     {
          public New_Note_Form()
          {
               InitializeComponent();
               Populate_Table();
          }

          public string Note
          {
               set { textbox_note.Text = value; }
               get { return textbox_note.Text; }
          }

          public int Category
          {
               set { Types.SelectedIndex = value; }
               get { return Types.SelectedIndex; }
          }

          private void Populate_Table()
          {
               //Headers (Row 0, Cols 0-3)
               type_title.Text = "Type of Conference";
               Note_Panel.Controls.Add(type_title, 0, 0);

               description_title.Text = "Description";
               Note_Panel.Controls.Add(description_title, 1, 0);

               usage_title.Text = "When to Use";
               Note_Panel.Controls.Add(usage_title, 2, 0);

               example_title.Text = "Examples";
               Note_Panel.Controls.Add(example_title, 3, 0);


               //Populate combobox
               for(int i = 0; i <= 5; i++)
               {
                    Types.Items.Add(new Conference_Types(i).Type);
               }
               Note_Panel.Controls.Add(Types, 0, 1);

               description_label.Text = " ";
               usage_label.Text = " ";
               example_label.Text = " ";
          }

          private void Cancel_Click(object sender, EventArgs e)
          {
               this.Close();
          }

          private void New_Note_Click(object sender, EventArgs e)
          {
               DialogResult = DialogResult.OK;
          }

          private void Types_SelectedIndexChanged(object sender, EventArgs e) 
          {
               int new_id = Types.SelectedIndex;
               description_label.Text = new Conference_Types(new_id).Blurb;
               usage_label.Text = new Conference_Types(new_id).Usage;
               example_label.Text = new Conference_Types(new_id).Example;
          }
     }
}
