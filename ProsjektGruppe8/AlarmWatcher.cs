using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsjektGruppe8
{
    class AlarmWatcher
    {
        public int LowLimit { get; set; }
        public int HighLimit { get; set; }
        public AlarmType Type { get; set; }
        private bool AlarmLastScan;
        bool AlarmBit, limitBit;
        public event EventHandler alarmTriggered;
        private DateTime lastAlarmTime;

        public AlarmWatcher(int lowLimit, int highLimit, AlarmType type)
        {
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Type = type;
            
        }
        public void updateAlarm(int value)
        {
            if (checkLimits(value))
            {
                limitBit = true;//Verdien er utenfor alarmgrenser
                AlarmBit = sendAlarm();//Hvis rising edge detection er false så sender vi ikke alarm
                if (AlarmBit)
                {
                    if ((DateTime.Now-lastAlarmTime).TotalSeconds > 45)//Liten tidsforsinkelse for å fjerne flere alarmer ved "hoppende" alarmverdi
                    {
                    lastAlarmTime = DateTime.Now;
                    alarmTriggered(this, new EventArgs());

                    }
                }
            }
            else
            {
                AlarmBit = false;
                limitBit = false;
            }
            AlarmLastScan = limitBit;

        }
        private bool checkLimits(int value)
        {
            return (value <= LowLimit || value >= HighLimit);
        }
        private bool sendAlarm()// Rising edge detection
        {
            return (limitBit == true && AlarmLastScan == false);//Hvis verdien er utenfor alarmgrensene og de var innenfor grensene siste scan returner true
        }

    }
    public enum AlarmType//Alarmtype enum
    {
        Temp,
        Movement,
        Fire,
        Batteri,
        Com
    }
}
