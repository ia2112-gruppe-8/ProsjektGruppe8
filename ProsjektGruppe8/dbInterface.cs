using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProsjektGruppe8
{
    class dbInterface
    {
        public dbInterface()
        {

        }
        public List<string> getEmail(string cons)
        {
            List<string> email = new List<string>();
            try
            {

                SqlConnection con = new SqlConnection(cons);
                string query = "SELECT email FROM Kunder";
                SqlCommand sql = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read() == true)
                {
                    query = dr[0].ToString();
                    email.Add(query);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return email;
        }
    }
}
}
