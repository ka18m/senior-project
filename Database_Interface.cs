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


               string sql;

               //Create student table
               
               sql = "CREATE TABLE IF NOT EXISTS students (id INT, fname VARCHAR(20), lname VARCHAR(20), startingLvl VARCHAR(1), currentLvl VARCHAR(1), goalLvl VARCHAR(1))";

               //Execute sql command on server -> load command
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

               //Execute command 
               command.ExecuteNonQuery();

               //Add example student to table 
               AddStudent("Example", "Student", 'A', 'C', 'E');

               m_dbConnection.Close();



               m_dbConnection.Open();
               //Create notes table

               sql = "CREATE TABLE IF NOT EXISTS notes (id INT, student_id INT, date VARCHAR(10), note VARCHAR(500))";
                    
               //Execute sql command on server -> load command
               command = new SQLiteCommand(sql, m_dbConnection);

               //Execute command 
               command.ExecuteNonQuery();

               //Add example note to table
               AddNote(1,  "Example note. You can post up to 500 characters");
               

               m_dbConnection.Close();
          }

          //Add one student to the database
          /*
          *  inputs: 
          *  output: true if successful, else false
          * 
          */
          public static bool AddStudent(string firstName, string lastName, char startingLevel, char currentLevel, char goalLevel)  
          {
               bool wasOpen = false;

               if(m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               SQLiteCommand sql = m_dbConnection.CreateCommand();
               sql.CommandText = "INSERT INTO students ( id, fname, lname, startingLvl, currentLvl, goalLvl) VALUES (@ID, @FNAME, @LNAME, @SLVL, @CLVL, @GLVL);";
               sql.Parameters.Add("@ID", System.Data.DbType.Int32).Value = Student.Generate_Student_ID();
               sql.Parameters.Add("@FNAME", System.Data.DbType.String).Value = firstName;
               sql.Parameters.Add("@LNAME", System.Data.DbType.String).Value = lastName;
               sql.Parameters.Add("@SLVL", System.Data.DbType.String).Value = startingLevel;
               sql.Parameters.Add("@CLVL", System.Data.DbType.String).Value = currentLevel;
               sql.Parameters.Add("@GLVL", System.Data.DbType.String).Value = goalLevel;
               sql.ExecuteNonQuery();

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }

               return true;
          }

          //Add multiple students
          public static void AddStudents(List<Student> students)
          {
               foreach(Student s in students)
               {
                    AddStudent(s.getFirstName(), s.getLastName(), s.getStartLevel(), s.getCurrentLevel(), s.getGoalLevel());
               }
          }

          //Delete one student
          public static void DeleteStudent(int id)
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               string sql = "DELETE FROM students WHERE id = " + id;
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
               command.ExecuteNonQuery();

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }

               Program.student_counter -= 1;
          }

          //Delete tables
          public static void DeleteAllStudents(List<Student> students)
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               //Drop Students table
               string sql = "DROP Table 'students'";
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
               command.ExecuteNonQuery();
               command.Dispose(); //free memory

               //Drop notes table
               sql = "DROP Table 'notes'";
               command = new SQLiteCommand(sql, m_dbConnection);
               command.ExecuteNonQuery();

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }

               Program.student_counter = 0;
          }

          //Query all students
          public static List<Student> QueryAllStudents() 
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               //Use SQL to query by reading level
               string sql = "SELECT * FROM students";
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
               SQLiteDataReader reader = command.ExecuteReader(); //Returns all students info

               //Parse data and create temp student models
               List<Student> students_arr = new List<Student>();
               while (reader.Read())
               {
                    Student temp = new Student(Convert.ToInt32(reader["id"]), reader["fname"].ToString(), reader["lname"].ToString(), Convert.ToChar(reader["startingLvl"]), Convert.ToChar(reader["currentLvl"]), Convert.ToChar(reader["goalLvl"]));
                    students_arr.Add(temp);
               }

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }

               //Return student array
               return students_arr;
          }

          //Query student names
          public static List<string> QueryStudentNames()
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               //Use SQL to query by reading level
               string sql = "SELECT fname, lname FROM students";
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
               SQLiteDataReader reader = command.ExecuteReader(); //Returns all student names

               //Parse data and create list
               List<string> names = new List<string>();
               while (reader.Read())
               {
                    string temp = reader["fname"].ToString() + " " + reader["lname"].ToString();
                    names.Add(temp);
               }

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }

               return names;
          }

          //Query students of a certain reading level
          public static List<Student> QueryReadingLevel(char readingLevel)
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               //Use SQL to query by reading level
               string sql = "SELECT id, fname, lname FROM students WHERE currentLvl = " + readingLevel;
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
           
               SQLiteDataReader reader = command.ExecuteReader(); //Returns all students of that reading level

               //Parse data and create temp student models
               List<Student> students_arr = new List<Student>();
               while (reader.Read())
               {
                    Student temp = new Student((int)reader["id"], reader["fname"].ToString(), reader["lname"].ToString(), readingLevel);
                    students_arr.Add(temp);
               }

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }

               //Return student array
               return students_arr;
          }

          //Query the number of students in the class
          public static int QueryNumStudents()  //count number of students stored in db
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               //Use SQL to query by reading level
               string sql = "SELECT COUNT(id) FROM students";
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
               SQLiteDataReader reader = command.ExecuteReader();

               //Get returned count from reader
               int count = Convert.ToInt32(reader[0]);

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }

               return count;
          }

          //Add new note
          public static void AddNote(int student_id, string note)
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               SQLiteCommand sql = m_dbConnection.CreateCommand();
               sql.CommandText = "INSERT INTO notes (id, student_id, date, note) VALUES (@ID, @STUDENT_ID, @DATE, @NOTE);";
               sql.Parameters.Add("@ID", System.Data.DbType.Int32).Value = Note.Generate_Note_ID();
               sql.Parameters.Add("@STUDENT_ID", System.Data.DbType.Int32).Value = student_id;
               sql.Parameters.Add("@DATE", System.Data.DbType.String).Value = DateTime.Now.ToString("MM.dd.yyyy");
               sql.Parameters.Add("@NOTE", System.Data.DbType.String).Value = note;
               sql.ExecuteNonQuery();

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }
          }

          //Update note
          public static void UpdateNote(int note_id, string note)
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               SQLiteCommand sql = m_dbConnection.CreateCommand();
               sql.CommandText = "UPDATE notes SET note = @NOTE WHERE id = @ID";
               sql.Parameters.Add("@ID", System.Data.DbType.Int32).Value = note_id;
               sql.Parameters.Add("@NOTE", System.Data.DbType.String).Value = note;
               sql.ExecuteNonQuery();

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }
          }

          //Query total number of notes
          public static int QueryNumNotes()
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               //Use SQL to query by reading level
               string sql = "SELECT COUNT(id) FROM notes";
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
               SQLiteDataReader reader = command.ExecuteReader();

               //Get returned count from reader
               int count = Convert.ToInt32(reader[0]);

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }

               return count;
          }

          //Query notes under a student name
          public static List<Note> QueryNote(int id)
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               //Use SQL to query by reading level
               string sql = "SELECT * FROM notes WHERE student_id =" + id;
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
               SQLiteDataReader reader = command.ExecuteReader();

               //Get notes from reader
               List<Note> notes = new List<Note>();
               while (reader.Read())
               {
                    Note temp = new Note();
                    temp.id = Convert.ToInt32(reader[0]);
                    temp.student_id = Convert.ToInt32(reader[1]);
                    temp.date = Convert.ToString(reader[2]);
                    temp.note = Convert.ToString(reader[3]);
                    notes.Add(temp);
               }
               
               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }

               return notes;
          }

          //Query student id from name
          public static int QueryID(string firstname, string lastname)
          {
               int id;
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               //Use SQL to query by reading level
               string sql = "SELECT id FROM students WHERE fname = '" + firstname + "' AND lname = '" + lastname + "'";
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
               SQLiteDataReader reader = command.ExecuteReader();

               //Get id from reader
               reader.Read();
               id = Convert.ToInt32(reader[0]);

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }

               return id;
          }

          //Delete note
          public static void DeleteNote(int id)
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               SQLiteCommand sql = m_dbConnection.CreateCommand();
               sql.CommandText = "DELETE FROM notes WHERE id = @ID";
               sql.Parameters.Add("@ID", System.Data.DbType.Int32).Value = id;
               sql.ExecuteNonQuery();

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }
          }
     }
}
