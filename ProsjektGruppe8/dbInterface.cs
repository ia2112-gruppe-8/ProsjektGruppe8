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
        string conTest = ConfigurationManager.ConnectionStrings["conProsjekt"].ConnectionString;//Connection stringen
        private static SqlConnection con;
        public dbInterface()
        {
            con = new SqlConnection(conTest);
        }

        public void viewInDataGrid(DataGridView gridView, string query)//Metode for å vise noe i en datagridview, du må sende med egen query
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
        public DataTable queryToDataTable(string query)//Returnerer resultatet fra en spørring til en DataTable
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
        public void kvitterAlarmer()//Stored procedure for å kvittere alle alarmer
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
        public void logTemp(int temp)//Bruker en stored procedure for å logge temperaturen
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
        public void insertAlarms(int type, int value, bool active, int lowLimit, int HighLimit)//Logger alarm
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
        public void addSubscriber(string name, string email,int phoneNmbr,int alarmtype)//Legger til en abbonent i databasen
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
        public void alterSubscriber(string name, string newEmail, string oldEmail, int phoneNmbr)//Endrer dataene til en abbonent i databasen
        {
            
            try
            {
                
                SqlCommand sql = new SqlCommand("dbo.updtAbbonenter", con);
                sql.CommandType = CommandType.StoredProcedure;
                con.Open();
                sql.Parameters.Add(new SqlParameter("@name", name));
                sql.Parameters.Add(new SqlParameter("@oldMail", oldEmail));
                sql.Parameters.Add(new SqlParameter("@newMail", newEmail));
                if (phoneNmbr == 0)
                {
                    sql.Parameters.Add(new SqlParameter("@number", DBNull.Value));
                }
                else
                {
                sql.Parameters.Add(new SqlParameter("@number", phoneNmbr));
                }
                sql.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void createSubscription(string email, int alarmtype)//Lager et abbonement på en alarmtype
        {
            try
            {

                SqlCommand sql = new SqlCommand("dbo.createSubscription", con);
                sql.CommandType = CommandType.StoredProcedure;
                con.Open();
                sql.Parameters.Add(new SqlParameter("@mail", email));
                sql.Parameters.Add(new SqlParameter("@type", alarmtype));
                sql.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public void deleteSubscriber(string email)//Sletter en abbonent og abbonementer fra databasen
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
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        static public void LoadTempValuesInChart(Chart chart)//Metode for å laste temp verdiene i Chart formen
        {
            DateTime valueX;
            int valueY;
            string tablename = "TempMålinger";
            string query = $"SELECT * FROM {tablename} ORDER BY Tidsrom ASC";
            string conTest = ConfigurationManager.ConnectionStrings["conProsjekt"].ConnectionString;
            try
            {
                //SqlConnection con = new SqlConnection(conTest);
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
                con.Close();
                MessageBox.Show(ex.Message);

            }
            
        }
        public void namesToCombobox(ComboBox box)//Laster alle emailer fra databasen til en combobox
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
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public List<string> getEmail(int alarmType)//Henter mailene til alle som abbonerer på en alarmtype og returnerer en LIST 
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
                con.Close();
                MessageBox.Show(ex.Message);
            }
            return email;
        }
    }
}

