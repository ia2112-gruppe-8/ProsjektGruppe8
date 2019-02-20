using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProsjektGruppe8
{
    class BatteryStatus
    {
        TextBox text;
        public BatteryStatus(TextBox box)
        {
            text = box;
        }

        private string getChargingStatus()
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
        public void indicateBattery()
        {
            int batteryPercent = Convert.ToInt32(SystemInformation.PowerStatus.BatteryLifePercent * 100);
            string chargingStatus = getChargingStatus();

            text.Text = $"{batteryPercent}% {chargingStatus}";

            if (batteryPercent <= 25)
            {

                text.BackColor = Color.Red;
                text.ForeColor = Color.White;
                MessageBox.Show("Batterinivå 25%", "Lav Batterispenning", MessageBoxButtons.OK);
            }
            else text.BackColor = Color.Green;
        }
    }
}
