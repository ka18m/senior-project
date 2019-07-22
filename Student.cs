using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senior_Project
{
    class Student
    {
        //Internal data model for students

        //string sql = "CREATE TABLE students (id INT, fname VARCHAR(20), lname VARCHAR(20), startingLvl VARCHAR(1), currentLvl VARCHAR(1), goalLvl VARCHAR(1)";
        int id;
        string fname, lname;
        char startingLvl, currentLvl, goalLvl;

        public Student()
        {
            id = 0;
            fname = "";
            lname = "";
            startingLvl = 'a';
            currentLvl = 'a';
            goalLvl = 'a';
        }

        public Student(int n_id, string n_fname, string n_lname, char n_currentLvl)
        {
            id = n_id;
            fname = n_fname;
            lname = n_lname;
            startingLvl = 'a';
            currentLvl = n_currentLvl;
            goalLvl = 'a';
        }

        public Student(int n_id, string n_fname, string n_lname, char n_startingLvl, char n_currentLvl, char n_goalLvl)
        {
            id = n_id;
            fname = n_fname;
            lname = n_lname;
            startingLvl = n_startingLvl;
            currentLvl = n_currentLvl;
            goalLvl = n_goalLvl;
        }

        public string[] ToArray()
        {
               string[] temp = { getID().ToString(), getFirstName(), getLastName(), getStartLevel().ToString(), getCurrentLevel().ToString(), getGoalLevel().ToString() };
               return temp;
        }

        int getID()
        {
            return id;
        }

        string getFirstName()
        {
            return fname;
        }

        string getLastName()
        {
            return lname;
        }

        char getStartLevel()
        {
            return startingLvl;
        }

        char getCurrentLevel()
        {
            return currentLvl;
        }
        
        char getGoalLevel()
        {
            return goalLvl;
        }

    }
}
