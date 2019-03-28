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
    public partial class AddSubscriberForm : Form
    {
        dbInterface dbi;
        public AddSubscriberForm(dbInterface db)
        {
            InitializeComponent();
            dbi = db;

        }
        private void btnAddSubscriber_Click(object sender, EventArgs e)
        {
            string name, mail;
            int number, alarmtype;
            name = txtName.Text;
            mail = txtMail.Text;
            number = Convert.ToInt32(txtNumber.Text);
            alarmtype = cboAlarmType.SelectedIndex;
            dbi.addSubscriber(name, mail, number, alarmtype);
            this.Close();
        }
    }
}
