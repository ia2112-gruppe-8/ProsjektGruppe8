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
    public partial class deleteSubscriberForm : Form
    {
        dbInterface dbi;
        public deleteSubscriberForm(dbInterface db)
        {
            InitializeComponent();
            dbi = db;
            dbi.namesToCombobox(cboCustomerMail);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string subscriber = cboCustomerMail.Text;
            dbi.deleteSubscriber(subscriber);
            this.Close();
        }
    }
}
