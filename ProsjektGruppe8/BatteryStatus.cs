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
        public BatteryStatus(TextBox box)//test comment for git
        {
            text = box;
        }

        private string getChargingStatus()
        {
            string chargingStatus;

            switch (SystemInformation.PowerStatus.PowerLineStatus)//En property som finnes i .NET biblioteket som forteller oss om pcen er plugget inn
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
            int batteryPercent = Convert.ToInt32(SystemInformation.PowerStatus.BatteryLifePercent * 100);//Bruker en property i .NET som gir oss en verdi på batterinivået i prosent
            string chargingStatus = getChargingStatus();

            text.Text = $"{batteryPercent}% {chargingStatus}";

            if (batteryPercent <= 25)//Gjør tekstboksen rød hvis batterinivået er under 25%
            {

                text.BackColor = Color.Red;
                text.ForeColor = Color.White;
            }
            else text.BackColor = Color.Green;
        }
        public int getBatteryPercent()
        {
            return Convert.ToInt32(SystemInformation.PowerStatus.BatteryLifePercent * 100);
        }
        public int getPowerLineStatusInt()
        {
            return ((int)SystemInformation.PowerStatus.PowerLineStatus);//Offline = 0, Online = 1;
        }
    }
}
