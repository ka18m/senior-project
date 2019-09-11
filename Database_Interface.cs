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

          public static void Create_DB()
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
               Add_Student("Example", "Student", 'A', 'C', 'E');

               Program.student_counter = Query_Num_Students();

               m_dbConnection.Close();



               m_dbConnection.Open();
               //Create notes table

               sql = "CREATE TABLE IF NOT EXISTS notes (id INT, student_id INT, date VARCHAR(10), note VARCHAR(500), category VARCHAR(30))";
                    
               //Execute sql command on server -> load command
               command = new SQLiteCommand(sql, m_dbConnection);

               //Execute command 
               command.ExecuteNonQuery();

               //Add example note to table
               Add_Note(1,  "Example note. You can post up to 500 characters", "Demonstration");
               

               m_dbConnection.Close();
          }

          public static void Update_Student(Student student)
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               SQLiteCommand sql = m_dbConnection.CreateCommand();
               sql.CommandText = "UPDATE students SET startingLvl = @SLVL, currentLvl = @CLVL, goalLvl = @GLVL WHERE id = @ID";
               sql.Parameters.Add("@ID", System.Data.DbType.Int32).Value = student.ID;
               sql.Parameters.Add("@SLVL", System.Data.DbType.String).Value = student.StartLevel;
               sql.Parameters.Add("@CLVL", System.Data.DbType.String).Value = student.CurrentLevel;
               sql.Parameters.Add("@GLVL", System.Data.DbType.String).Value = student.GoalLevel;
               sql.ExecuteNonQuery();

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }
          }

          //Add one student to the database
          /*
          *  inputs: 
          *  output: true if successful, else false
          * 
          */
          public static void Add_Student(string firstName, string lastName, char startingLevel, char currentLevel, char goalLevel)  
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

          }
          public static void Add_Student(Student student)
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               SQLiteCommand sql = m_dbConnection.CreateCommand();
               sql.CommandText = "INSERT INTO students ( id, fname, lname, startingLvl, currentLvl, goalLvl) VALUES (@ID, @FNAME, @LNAME, @SLVL, @CLVL, @GLVL);";
               sql.Parameters.Add("@ID", System.Data.DbType.Int32).Value = Student.Generate_Student_ID();
               sql.Parameters.Add("@FNAME", System.Data.DbType.String).Value = student.FirstName;
               sql.Parameters.Add("@LNAME", System.Data.DbType.String).Value = student.LastName;
               sql.Parameters.Add("@SLVL", System.Data.DbType.String).Value = student.StartLevel;
               sql.Parameters.Add("@CLVL", System.Data.DbType.String).Value = student.CurrentLevel;
               sql.Parameters.Add("@GLVL", System.Data.DbType.String).Value = student.GoalLevel;
               sql.ExecuteNonQuery();

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }
          }

          //Deletes all notes associated with a student id
          public static void Delete_Notes(int student_id)
          {
               int note_count = Query_Num_Notes(student_id); //Get number of notes before deleting them

               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               string sql = "DELETE FROM notes WHERE student_id = " + student_id;
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
               command.ExecuteNonQuery();

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }

               Program.note_counter -= note_count;
          }

          //Add multiple students
          public static void Add_Students(List<Student> students)
          {
               foreach(Student s in students)
               {
                    Add_Student(s.FirstName, s.LastName, s.StartLevel, s.CurrentLevel, s.GoalLevel);
               }
          }

          //Delete one student
          public static void Delete_Student(int id)
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

               Program.student_counter = Query_Num_Students();
          }

          //Delete tables
          public static void Delete_All_Students()
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

               //Reset DB
               Create_DB();
          }

          //Query all students
          public static List<Student> Query_All_Students() 
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
          public static List<string> Query_Student_Names()
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

          //Query one student
          public static Boolean Query_Student_Exist(string firstname, string lastname)
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               //Use SQL to query by reading level
               string sql = "SELECT * FROM students WHERE fname = '" + firstname + "' AND lname = '" + lastname + "'";
               SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
               SQLiteDataReader reader = command.ExecuteReader(); //Returns all student names

               //Parse data and create list
               bool doesExist = false;
               if (reader.HasRows) { doesExist = true; }             

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }

               return doesExist;
          }

          //Query students of a certain reading level
          public static List<Student> Query_Reading_Level(char readingLevel)
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
          public static int Query_Num_Students()  //count number of students stored in db
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
          public static void Add_Note(int student_id, string note, string category)
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               SQLiteCommand sql = m_dbConnection.CreateCommand();
               sql.CommandText = "INSERT INTO notes (id, student_id, date, note) VALUES (@ID, @STUDENT_ID, @DATE, @NOTE, @CAT);";
               sql.Parameters.Add("@ID", System.Data.DbType.Int32).Value = Note.Generate_Note_ID();
               sql.Parameters.Add("@STUDENT_ID", System.Data.DbType.Int32).Value = student_id;
               sql.Parameters.Add("@DATE", System.Data.DbType.String).Value = DateTime.Now.ToString("MM.dd.yyyy");
               sql.Parameters.Add("@NOTE", System.Data.DbType.String).Value = note;
               sql.Parameters.Add("@CAT", System.Data.DbType.String).Value = category;
               sql.ExecuteNonQuery();

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }
          }

          //Update note
          public static void Update_Note(int note_id, string note, string category)
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               SQLiteCommand sql = m_dbConnection.CreateCommand();
               sql.CommandText = "UPDATE notes SET note = @NOTE, category = @CAT, date = @DATE WHERE id = @ID";
               sql.Parameters.Add("@ID", System.Data.DbType.Int32).Value = note_id;
               sql.Parameters.Add("@NOTE", System.Data.DbType.String).Value = note;
               sql.Parameters.Add("@CAT", System.Data.DbType.String).Value = category;
               sql.Parameters.Add("@DATE", System.Data.DbType.String).Value = DateTime.Now.ToString("MM.dd.yyyy");
               sql.ExecuteNonQuery();

               if (wasOpen == false)
               {
                    m_dbConnection.Close();
               }
          }

          //Query total number of notes
          public static int Query_Num_Notes()
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
          public static int Query_Num_Notes(int id)
          {
               bool wasOpen = false;

               if (m_dbConnection.State == System.Data.ConnectionState.Closed)
               {
                    m_dbConnection.Open();
                    wasOpen = true;
               }

               //Use SQL to query by reading level
               string sql = "SELECT COUNT(id) FROM notes WHERE student_id=" + id;
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
          public static List<Note> Query_Note(int id)
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
          public static int Query_ID(string firstname, string lastname)
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
          public static void Delete_Note(int id)
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
