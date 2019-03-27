using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Senior_Project
{
    class ModelView
    {

        //Populate the student 
        public static void PopulateStudents()
        {
            //Get number of students
            //form.numberOfStudents
            //Generate form with that number of boxes for inputting student data
            //form.boxes that ask for names, current reading level and goal reading level
            //Verify data

            //Create connection
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=Students.sqlite;Version=3;");
            m_dbConnection.Open();

            //Read all data into database -> model.inputData

            //Close connection
            m_dbConnection.Close(); 
        }

        //Populate profile
        public static void PopulateProfile()
        {
            
        }
    }
}
