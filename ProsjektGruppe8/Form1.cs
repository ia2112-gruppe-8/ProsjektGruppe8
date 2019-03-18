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
    public partial class Form1 : Form
    {
        BatteryStatus batt;
        static dbInterface dbi = new dbInterface(); 
        public Form1()
        {
            InitializeComponent();
            batt = new BatteryStatus(txtBatteryStatus);
            batt.indicateBattery();
        }
        
        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            batt.indicateBattery();
            //dbi.viewInDataGrid(dgvActiveAlarms, "SELECT * FROM Kunder");
        }
    }
}
