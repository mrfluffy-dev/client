using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FinalPojectPRG282
{
    class DataHandler
    {
        public DataHandler() { }

        string con = @"Server=FIRST\SPARTA; Initial Catalog= dbStudents; Integrated Security=true;";

        public DataTable getStudents()
        {
            string query = @"SELECT * FROM tbStudent";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            return dt;
        }

        public bool Create(Student person)
        {
            try
            {
                SqlConnection cons = new SqlConnection(con);
                cons.Open();
                string query = $"INSERT INTO tbStudent(StudentNum,StudentName,StudentSurname, StudentDOB, StudentGender, StudentPhone, StudentAddress, StudentModule) VALUES({person.StudentNumber1}, '{person.StudentName1}', '{person.StudentSurname1}', '{person.DOB1}', '{person.StudentGender1}', '{person.StudentPhone1}', '{person.StudentAddres1}', '{person.StudentModule1}')";
                SqlCommand cmd = new SqlCommand(query, cons);
                cmd.ExecuteNonQuery();
                cons.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Update(Student person)
        {
            try
            {
                SqlConnection cons = new SqlConnection(con);
                cons.Open();
                string query = $"UPDATE tbStudent SET StudentName = '{person.StudentName1}', StudentSurname = '{person.StudentSurname1}', StudentDOB = '{person.DOB1}', StudentGender = '{person.StudentGender1}', StudentPhone = '{person.StudentPhone1}', StudentAddress = '{person.StudentAddres1}', StudentModule = '{person.StudentModule1}'WHERE StudentNum = '{person.StudentNumber1}'";
                SqlCommand cmd = new SqlCommand(query, cons);
                cmd.ExecuteNonQuery();
                cons.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public DataTable Search(int sNum)
        {
            DataTable table = new DataTable();
            string query = $"SELECT * FROM tbStudent WHERE StudentNum = '{sNum}'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(table);
            return table;
        }

        public bool Delete(int sNum)
        {
            try
            {
                SqlConnection cons = new SqlConnection(con);
                cons.Open();
                string query = $"DELETE FROM tbStudent WHERE StudentNum = '{sNum}'";
                SqlCommand cmd = new SqlCommand(query, cons);
                cmd.ExecuteNonQuery();
                cons.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
