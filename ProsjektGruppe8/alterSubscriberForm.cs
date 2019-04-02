using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProsjektGruppe8
{
    public partial class alterSubscriberForm : Form
    {
        dbInterface dbi;
        public alterSubscriberForm(dbInterface db)
        {
            InitializeComponent();
            dbi = db;
            dbi.namesToCombobox(cboEmails);
        }

        

        private void btnAlterSubscriber_Click(object sender, EventArgs e)
        {
            string name, newMail,oldMail;
            int number;
            bool isNumber;
            name = txtName.Text;
            newMail = txtMail.Text;
            oldMail = cboEmails.Text;
            isNumber = int.TryParse(txtNumber.Text,out number);
            if (!isNumber)
            {
                number = 0;
            }
            
            dbi.alterSubscriber(name, newMail,oldMail, number);
        }

        private void cboEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt;
            dt = dbi.queryToDataTable($"SELECT * FROM Abonnenter Where [E-Mail] = '{cboEmails.Text}'");
            txtName.Text = dt.Rows[0][0].ToString();
            txtMail.Text = dt.Rows[0][1].ToString();
            txtNumber.Text = dt.Rows[0][2].ToString();
        }
    }
}
