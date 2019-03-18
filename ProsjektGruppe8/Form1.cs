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
        #region Variabler
        string[] values;//0 = temp, 1 = movement, 2 = fire
        #endregion
        #region Objekter
        BatteryStatus batt;
        dbInterface dbi = new dbInterface();
        AlarmWatcher temp = new AlarmWatcher(0, 35, AlarmType.Temp);
        AlarmWatcher move = new AlarmWatcher(0, 1, AlarmType.Movement);
        AlarmWatcher fire = new AlarmWatcher(0, 35, AlarmType.Temp);
        ArduinoCom com;

        #endregion
        public Form1()
        {
            InitializeComponent();
            batt = new BatteryStatus(txtBatteryStatus);
            batt.indicateBattery();
            com = new ArduinoCom(9600, cboComPorts);
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            com.usbTimeout += new EventHandler(usbTimeout);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (com != null && com.IsOpen)
            {
                com.Close();
            }
        }
        private void usbTimeout(object kilde, EventArgs e)
        {
            tmrUpdate.Stop();
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            //batt.indicateBattery();
            values = com.getValues();

            //dbi.viewInDataGrid(dgvActiveAlarms, "SELECT * FROM Kunder");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            dbi.logTemp(Convert.ToInt32(values[0]));
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            com.OpenCom();
            tmrUpdate.Start();
        }
    }
}
