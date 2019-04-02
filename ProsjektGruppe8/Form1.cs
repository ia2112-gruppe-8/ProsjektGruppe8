using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace ProsjektGruppe8
{
    public partial class Form1 : Form
    {
        #region Variabler
        string[] values;//0 = temp, 1 = movement, 2 = fire
        string tmrUpdateFile = "tmrUpdate.txt";
        string tmrLogFile = "tmrLog.txt";
        List<string> emails = new List<string>();
        #endregion
        #region Objekter
        BatteryStatus batt;
        dbInterface dbi = new dbInterface();
        AlarmWatcher temp = new AlarmWatcher(0, 30, AlarmType.Temp);
        AlarmWatcher move = new AlarmWatcher(0, 2, AlarmType.Movement);
        AlarmWatcher fire = new AlarmWatcher(0, 2, AlarmType.Fire);
        AlarmWatcher charge = new AlarmWatcher(25, 100, AlarmType.Batteri);
        AlarmWatcher pluggedIn = new AlarmWatcher(0, 2, AlarmType.Batteri);
        emailHandler mail = new emailHandler();
        SpeechSynthesizer speak = new SpeechSynthesizer();
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
            temp.alarmTriggered += new EventHandler(tempTrigg);
            fire.alarmTriggered += new EventHandler(fireTrigg);
            move.alarmTriggered += new EventHandler(moveTrigg);
            charge.alarmTriggered += new EventHandler(chargeTrigg);
            pluggedIn.alarmTriggered += new EventHandler(pluggedInTrigg);
            initTimers();

        }
        private void initTimers()
        {
            tmrLog.Interval = Convert.ToInt32(FileHandler.ReadFromFile(tmrLogFile));
            tmrUpdate.Interval = Convert.ToInt32(FileHandler.ReadFromFile(tmrUpdateFile));
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
            tmrLog.Stop();
            dbi.insertAlarms(((int)AlarmType.Com), 0, true, 0, 1);
        }
        #region AlarmEventHandlers
        private void tempTrigg(object kilde,EventArgs e)
        {
            AlarmMailHandler(temp.Type);
            dbi.insertAlarms(((int)temp.Type), Convert.ToInt32(values[0]), true, temp.LowLimit, temp.HighLimit);
            speak.SpeakAsync("ALARM! ALARM! AN ALARM HAS BEEN TRIGGERED!");
            
        }
        private void fireTrigg(object kilde, EventArgs e)
        {
            AlarmMailHandler(fire.Type);
            dbi.insertAlarms(((int)fire.Type), Convert.ToInt32(values[2]), true, fire.LowLimit, fire.HighLimit);
            speak.SpeakAsync("ALARM! ALARM! AN ALARM HAS BEEN TRIGGERED!");
        }
        private void moveTrigg(object kilde, EventArgs e)
        {
            AlarmMailHandler(move.Type);
            dbi.insertAlarms(((int)move.Type), Convert.ToInt32(values[1]), true, move.LowLimit, move.HighLimit);
            speak.SpeakAsync("ALARM! ALARM! AN ALARM HAS BEEN TRIGGERED!");
        }
        private void chargeTrigg(object kilde, EventArgs e)
        {
            AlarmMailHandler(charge.Type);
            dbi.insertAlarms(((int)charge.Type), ((int)SystemInformation.PowerStatus.BatteryLifePercent * 100), true, charge.LowLimit, charge.HighLimit);
            speak.SpeakAsync("ALARM! ALARM! AN ALARM HAS BEEN TRIGGERED!");
        }
        private void pluggedInTrigg(object kilde, EventArgs e)
        {
            AlarmMailHandler(pluggedIn.Type);
            dbi.insertAlarms(((int)pluggedIn.Type), ((int)SystemInformation.PowerStatus.PowerLineStatus), true, pluggedIn.LowLimit, pluggedIn.HighLimit);
            speak.SpeakAsync("ALARM! ALARM! AN ALARM HAS BEEN TRIGGERED!");
        }
        #endregion
        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            batt.indicateBattery();
            values = com.getValues();
            if (tmrUpdate.Enabled)
            {

            temp.updateAlarm(Convert.ToInt32(values[0]));
            move.updateAlarm(Convert.ToInt32(values[1]));
            fire.updateAlarm(Convert.ToInt32(values[2]));
                
            dbi.viewInDataGrid(dgvActiveAlarms, "SELECT * FROM Alarmer ORDER BY[aktiv\\ikke aktiv] DESC, Tidsrom DESC");
            }
            textBox1.Text = values[0];
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            
        }
        private void AlarmMailHandler(AlarmType type)
        {
            int alarmType = ((int)type);
            emails = dbi.getEmail(alarmType);
            foreach (string x in emails)
            {
                mail.SendAlarmMail(x, type);
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            com.OpenCom();
            tmrUpdate.Start();
            tmrLog.Start();
        }

        private void tmrLog_Tick(object sender, EventArgs e)
        {
            dbi.logTemp(Convert.ToInt32(values[0]));
        }

        private void leseintervallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm settings = new settingsForm(tmrUpdateFile, tmrUpdate);
            settings.ShowDialog();
        }

        private void tsmLogInterval_Click(object sender, EventArgs e)
        {
            settingsForm settings = new settingsForm(tmrLogFile, tmrLog);
            settings.ShowDialog();
        }

        private void tsmShowChart_Click(object sender, EventArgs e)
        {
            chartForm chrt = new chartForm();
            chrt.Show();
        }

        

        private void tsmDeleteSubscriber_Click(object sender, EventArgs e)
        {
            deleteSubscriberForm form = new deleteSubscriberForm(dbi);
            form.ShowDialog();
        }

        private void btnAcknowlege_Click(object sender, EventArgs e)
        {
            dbi.kvitterAlarmer();
        }

        private void tsmCreatePdf_Click(object sender, EventArgs e)
        {
            xportPdfForm pdfForm = new xportPdfForm(dbi,mail);
            pdfForm.ShowDialog();
        }

        private void tsmCreateSubscription_Click(object sender, EventArgs e)
        {
            createSubscriptionForm csf = new createSubscriptionForm(dbi);
            csf.ShowDialog();
        }

        private void tsmAlterSubscriber_Click(object sender, EventArgs e)
        {
            alterSubscriberForm alterSubscriberForm = new alterSubscriberForm(dbi);
            alterSubscriberForm.ShowDialog();
        }

        private void tsmAddSubscriber_Click(object sender, EventArgs e)
        {
            AddSubscriberForm addSubscriber = new AddSubscriberForm(dbi);
            addSubscriber.ShowDialog();
        }
    }
}
