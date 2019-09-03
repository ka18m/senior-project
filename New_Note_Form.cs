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
          }

          public string Note
          {
               set { textbox_note.Text = value; }
               get { return textbox_note.Text; }
          }

          private void Cancel_Click(object sender, EventArgs e)
          {
               this.Close();
          }

          private void New_Note_Click(object sender, EventArgs e)
          {
               DialogResult = DialogResult.OK;
          }
     }
}
