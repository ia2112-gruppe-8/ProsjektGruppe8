using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProsjektGruppe8
{
    class dbInterface
    {
        string conTest = ConfigurationManager.ConnectionStrings["conProsjekt"].ConnectionString;
        public dbInterface()
        {

        }
        public void viewInDataGrid(DataGridView gridView, string query)
        {
            try
            {
                SqlConnection con = new SqlConnection(conTest);
                SqlDataAdapter sda;
                DataTable dt;
                con.Open();
                sda = new SqlDataAdapter(query, con);
                dt = new DataTable();
                sda.Fill(dt);
                gridView.DataSource = dt;
                con.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            

        }
        public List<string> getEmail()
        {
            List<string> email = new List<string>();
            try
            {

                SqlConnection con = new SqlConnection(conTest);
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

