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
    public partial class settingsForm : Form
    {
        string filename;
        Timer tmr;
        public settingsForm(string filename, Timer tmr)
        {
            InitializeComponent();
            this.filename = filename;
            this.Text = filename;
            this.tmr = tmr;
        }
        void UpdateInterval()
        {
            FileHandler.WriteIntervalToFile(Convert.ToInt32(txtInterval.Text), filename);//Poller arduino 2 ganger pr sekund
            tmr.Interval = Convert.ToInt32(FileHandler.ReadFromFile(filename));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateInterval();
            this.Close();
        }
    }
}
