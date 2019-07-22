using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Senior_Project
{
    static class Database_Interface
    {
        static SQLiteConnection m_dbConnection= new SQLiteConnection(@"URI=file: D:\Senior Project\Senior_Project\bin\Debug\Students.sqlite;Version=3;");

          public static void CreateDB()
          {
               SQLiteConnection.CreateFile("Students.sqlite"); //Create database

               //Create connection
               m_dbConnection.Open();

               //Create a table
               string sql = "CREATE TABLE IF NOT EXISTS students (id INT, fname VARCHAR(20), lname VARCHAR(20), startingLvl VARCHAR(1), currentLvl VARCHAR(1), goalLvl VARCHAR(1))";

               //Execute sql command on server -> load command
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

               //Execute command (no turning back!)
               command.ExecuteNonQuery();

               //Add example student to table 
               AddStudent(1, "Example", "Student", 'C', 'E');

               m_dbConnection.Close();
          }

        //Add one student to the database
        /*
         *  inputs: 
         *  output: true if successful, else false
         * 
         */
        public static bool AddStudent(int id, string firstName, string lastName, char currentLevel, char goalLevel)  
        {
               //TODO: validate inputs
            bool wasOpen = false;

            if(m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               SQLiteCommand sql = m_dbConnection.CreateCommand();
               sql.CommandText = "INSERT INTO students ( id, fname, lname, startingLvl, currentLvl, goalLvl) VALUES (@ID, @FNAME, @LNAME, @CLVL, @CLVL, @GLVL);";
               sql.Parameters.Add("@ID", System.Data.DbType.Int32).Value = id;
               sql.Parameters.Add("@FNAME", System.Data.DbType.String).Value = firstName;
               sql.Parameters.Add("@LNAME", System.Data.DbType.String).Value = lastName;
               sql.Parameters.Add("@CLVL", System.Data.DbType.String).Value = currentLevel;
               sql.Parameters.Add("@GLVL", System.Data.DbType.String).Value = goalLevel;

               sql.ExecuteNonQuery();

                if(wasOpen == false)
                    {
                         m_dbConnection.Close();
                    }


                 return true;
        }

        //Query all students
        public static Student[] QueryAll() //TODO: Make this return a string array instead (overloaded function? would need new parameters)
        {
            m_dbConnection.Open();

            //Use SQL to query by reading level
            string sql = "SELECT * FROM students";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader(); //Returns all students info

            //Parse data and create temp student models
            Student[] students_arr = new Student[30];
            int count = 0;
            while (reader.Read() && count < 30)
            {
                Student temp = new Student(Convert.ToInt32(reader["id"]), reader["fname"].ToString(), reader["lname"].ToString(), Convert.ToChar(reader["startingLvl"]), Convert.ToChar(reader["currentLvl"]), Convert.ToChar(reader["goalLvl"]));
                students_arr[count] = temp;
                count++;
            }

            m_dbConnection.Close();

            //Return student array
            return students_arr;
        }

        //Query students of a certain reading level
        public static Student[] QueryReadingLevel(char readingLevel)
        {
            m_dbConnection.Open();

            //Use SQL to query by reading level
            string sql = "SELECT id, fname, lname FROM students WHERE currentLvl = " + readingLevel;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
           
            SQLiteDataReader reader = command.ExecuteReader(); //Returns all students of that reading level

            //Parse data and create temp student models
            Student[] students_arr = new Student[30];
            int count = 0;
            while (reader.Read() && count < 30)
            {
                Student temp = new Student((int)reader["id"], reader["fname"].ToString(), reader["lname"].ToString(), readingLevel);
                students_arr[count] = temp;
                count++;
            }

            m_dbConnection.Close();

            //Return student array
            return students_arr;
        }

        public static int QueryNumStudents()  //count number of students stored in db
        {
               m_dbConnection.Open();

               //Use SQL to query by reading level
               string sql = "SELECT COUNT(id) FROM students";
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
               SQLiteDataReader reader = command.ExecuteReader();

               //Get returned count from reader
               int count = Convert.ToInt32(reader[0]);

               m_dbConnection.Close();
               return count;
        }
}
    }
