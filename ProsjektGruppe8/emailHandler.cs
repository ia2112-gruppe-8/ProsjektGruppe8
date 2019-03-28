using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProsjektGruppe8
{
    class emailHandler
    {
        private string password;
        string senderMail = "ia2112gruppe8@gmail.com";
        //string Recipient { get; set; }

        public emailHandler()
        {
            password = FileHandler.ReadFromFile("passord.txt");
            //Recipient = recipient;
        }
        public void SendMail(string recipient,string subject,string message)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential(senderMail, password);
                    // send the email
                    smtp.Send(senderMail, recipient, subject, message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void SendAlarmMail(string recipient, AlarmType type)
        {
            string melding;
            switch (type)
            {
                case AlarmType.Temp:
                    melding = "Du har en alarm på temperatur, sjekk systemet ASAP";
                    break;
                case AlarmType.Movement:
                    melding = "Du har en alarm på becegelse, sjekk systemet ASAP";
                    break;
                case AlarmType.Fire:
                    melding = "Du har en alarm på bevegelse, sjekk systemet ASAP";
                    break;
                case AlarmType.Batteri:
                    melding = "Du har en alarm på batteri, sjekk systemet ASAP";
                    break;
                case AlarmType.Com:
                    melding = "Du har en alarm på kommunikasjon, sjekk systemet ASAP";
                    break;
                default:
                    melding = "Du har en alarm på ukjent, sjekk systemet eller kontakt leverandør";
                    break;
            }
            this.SendMail(recipient, (type.ToString() + " alarm"), melding);
        }
        //private string ReadFromFile(string filename)
        //{
        //    string text;
        //    var filestream = new FileStream(filename, FileMode.Open, FileAccess.Read);
        //    StreamReader sr = new StreamReader(filestream);
        //    text = sr.ReadToEnd();
        //    sr.Close();
        //    return text;
        //}
    }
}
