using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Senior_Project
{
    class Model
    {
        //Add one student to the database
        public bool AddStudent(SQLiteConnection m_dbConnection, int id, string firstName, string lastName, char currentLevel, char goalLevel)  
        {
            //TODO: validate inputs



            //Create and execute sql
            string sql = "insert into student (id, fname, lname, startingLvl, goalLvl) values (";
            sql += id + ", " + firstName + ", " + lastName + ", " + currentLevel + ", " + goalLevel + ")";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            return true;
        }
    }
}
