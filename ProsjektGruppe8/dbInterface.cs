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
    public class dbInterface
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
        public DataTable activeAlarmsInDT(string query)
        {
            try
            {
                SqlDataAdapter sda;
                DataTable dt;
                con.Open();
                sda = new SqlDataAdapter(query, con);
                dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return null;
            }
            
        }
        public void kvitterAlarmer()
        {
            try
            {
                SqlCommand sql = new SqlCommand("dbo.kvitterAlarmer", con);
                sql.CommandType = CommandType.StoredProcedure;
                con.Open();
                sql.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
        public void insertAlarms(int type, int value, bool active, int lowLimit, int HighLimit)
        {
            try
            {

                SqlCommand sql = new SqlCommand("dbo.insertAlarms", con);
                sql.CommandType = CommandType.StoredProcedure;
                con.Open();
                sql.Parameters.Add(new SqlParameter("@type", type));
                sql.Parameters.Add(new SqlParameter("@time", DateTime.Now));
                sql.Parameters.Add(new SqlParameter("@value", value));
                sql.Parameters.Add(new SqlParameter("@active", active));
                sql.Parameters.Add(new SqlParameter("@Llimit", lowLimit));
                sql.Parameters.Add(new SqlParameter("@Hlimit", HighLimit));
                sql.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void addSubscriber(string name, string email,int phoneNmbr,int alarmtype)
        {
            try
            {

                SqlCommand sql = new SqlCommand("dbo.AddSubscriber", con);
                sql.CommandType = CommandType.StoredProcedure;
                con.Open();
                sql.Parameters.Add(new SqlParameter("@Navn", name));
                sql.Parameters.Add(new SqlParameter("@Mail", email));
                sql.Parameters.Add(new SqlParameter("@Nummer", phoneNmbr));
                sql.Parameters.Add(new SqlParameter("@Alarmtype", alarmtype));
                sql.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void deleteSubscriber(string email)
        {
            try
            {

                SqlCommand sql = new SqlCommand("dbo.DeleteSubscriber", con);
                sql.CommandType = CommandType.StoredProcedure;
                con.Open();
                sql.Parameters.Add(new SqlParameter("@Mail", email));
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
            string tablename = "TempMålinger";
            string query = $"SELECT * FROM {tablename} ORDER BY Tidsrom ASC";
            string conTest = ConfigurationManager.ConnectionStrings["conProsjekt"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(conTest);
                SqlCommand sql = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read() == true)
                {
                    valueX = Convert.ToDateTime(dr[0]);
                    valueY = Convert.ToInt32(dr[1]);
                    chart.Series["Temperatur"].Points.AddXY(valueX, valueY);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public void namesToCombobox(ComboBox box)
        {
            try
            {
                string query = "SELECT [E-Mail] FROM Abonnenter";
                SqlCommand sql = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read()==true)
                {
                    query = dr[0].ToString();
                    box.Items.Add(query);
                }
                con.Close();
                box.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public List<string> getEmail(int alarmType)
        {
            List<string> email = new List<string>();
            try
            {
                string query = $"SELECT [E-Mail] FROM Subscriptions Where Alarmtype = {alarmType}";
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

