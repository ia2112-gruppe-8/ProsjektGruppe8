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
        public Form1()
        {
            InitializeComponent();
            indicateBattery(txtBatteryStatus);
        }

        private void tmrUpdateBattery_Tick(object sender, EventArgs e)
        {
            indicateBattery(txtBatteryStatus);
        }
        
        string getChargingStatus()
        {
            string chargingStatus;

            switch (SystemInformation.PowerStatus.PowerLineStatus)
            {
                case PowerLineStatus.Offline:
                    chargingStatus = "Lader IKKE";
                    break;
                case PowerLineStatus.Online:
                    chargingStatus = "Lader";
                    break;
                default:
                    chargingStatus = "Ukjent";
                    break;
            }
            return chargingStatus;
        }
        void indicateBattery(TextBox box)
        {
            int batteryPercent = Convert.ToInt32(SystemInformation.PowerStatus.BatteryLifePercent * 100);
            string chargingStatus = getChargingStatus();

            box.Text = $"{batteryPercent}% {chargingStatus}";

            if (batteryPercent <= 25)
            {
                box.BackColor = Color.Red;
                box.ForeColor = Color.White;
            }
            else box.BackColor = Color.Green;
        }
    }
}
