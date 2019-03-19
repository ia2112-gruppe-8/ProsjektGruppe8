using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProsjektGruppe8
{
    class dbInterface
    {
        string conTest = ConfigurationManager.ConnectionStrings["conProsjekt"].ConnectionString;
        SqlConnection con;
        public dbInterface()
        {
            con = new SqlConnection(conTest);
        }
        public void viewInDataGrid(DataGridView gridView, string query)
        {
            try
            {
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
        public void logTemp(int temp)
        {
            try
            {
                
                SqlCommand sql = new SqlCommand("dbo.insertTemp", con);
                sql.CommandType = CommandType.StoredProcedure;
                con.Open();
                sql.Parameters.Add(new SqlParameter("@temp", temp));
                sql.Parameters.Add(new SqlParameter("@dato", DateTime.Now));
                sql.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        static public void LoadTempValuesInChart(Chart chart)
        {
            DateTime valueX;
            int valueY;
            string query = "SELECT * FROM Temperaturmålinger ORDER BY dato ASC";
            string conTest = ConfigurationManager.ConnectionStrings["conProsjekt"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(conTest);
                SqlCommand sql = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read() == true)
                {
                    valueX = Convert.ToDateTime(dr[1]);
                    valueY = Convert.ToInt32(dr[0]);
                    chart.Series["Temperatur"].Points.AddXY(valueX, valueY);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public List<string> getEmail()
        {
            List<string> email = new List<string>();
            try
            {
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

