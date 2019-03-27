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
            SQLiteConnection.CreateFile("Students.sqlite"); //Create database
            
            //Create connection
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=Students.sqlite;Version=3;");
            m_dbConnection.Open();

            //Create a table
            string sql = "CREATE TABLE student (id INT, fname VARCHAR(20), lname VARCHAR(20), startingLvl VARCHAR(1), goalLvl VARCHAR(1)";

                //Execute sql command on server -> load command
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                //Execute command (no turning back!)
                command.ExecuteNonQuery();

            m_dbConnection.Close();
        }

        private void Create_Button_Click(object sender, EventArgs e)
        {
            ModelView.PopulateStudents();
        }


    }
}
