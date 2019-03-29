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
    public partial class createSubscriptionForm : Form
    {
        dbInterface db;
        public createSubscriptionForm(dbInterface dbi)
        {
            InitializeComponent();
            db = dbi;
            db.namesToCombobox(cboEmails);
            cboAlarmType.DataSource = Enum.GetValues(typeof(AlarmType));
        }

        private void btnAddSubscriptions_Click(object sender, EventArgs e)
        {
            db.createSubscription(cboEmails.Text, cboAlarmType.SelectedIndex);
        }

       
    }
}
