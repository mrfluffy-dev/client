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

        string con = @"Server=FIRST\SPARTA; Initial Catalog= dbClient; Integrated Security=true;";

        public DataTable getStudents()
        {
            string query = @"SELECT * FROM tbClient";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            return dt;
        }

        /*public bool Create(Student person)
        {
            try
            {
                SqlConnection cons = new SqlConnection(con);
                cons.Open();
                string query = $"INSERT INTO tbClient(sID,sName,sSurname, courseID) VALUES({person.S_ID}, '{person.Name}', '{person.Surname}', '{person.CourseID}')";
                SqlCommand cmd = new SqlCommand(query, cons);
                cmd.ExecuteNonQuery();
                cons.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }*/
    }
}
