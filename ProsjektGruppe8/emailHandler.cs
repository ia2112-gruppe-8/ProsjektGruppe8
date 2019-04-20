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
    public class emailHandler:IKravInterface
    {
        private string password;
        string senderMail = "ia2112gruppe8@gmail.com";//mailen til gruppe
        public string Filename { get; set; }
        //string Recipient { get; set; }

        public emailHandler()
        {
            password = FileHandler.ReadFromFile("passord.txt");//Laster passord fra en tekstfil
            //Recipient = recipient;
        }
        public void SendMail(string recipient,string subject,string message)//Sender en mail uten vedlegg
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
        public void SendMailAttatchment(string recipient, string subject, string message, string filename)//Sender en mail med vedlegg
        {
            Filename = filename;
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
                    MailMessage mail = new MailMessage(senderMail, recipient,subject,message);
                    mail.Attachments.Add(new Attachment(Filename));
                    smtp.Send(mail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void SendAlarmMail(string recipient, AlarmType type)//Send alarm mailen med en tekst for hver alarm
        {
            string melding;
            switch (type)
            {
                case AlarmType.Temp:
                    melding = "Du har en alarm på temperatur, sjekk systemet ASAP";
                    break;
                case AlarmType.Movement:
                    melding = "Du har en alarm på bevegelse, sjekk systemet ASAP";
                    break;
                case AlarmType.Fire:
                    melding = "Du har en alarm på brann, sjekk systemet ASAP";
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
