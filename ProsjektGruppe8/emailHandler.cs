using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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
        public void SendMail(string recipient)
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
                smtp.Send(senderMail, recipient, "Test", "Test mail er test");

            }
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
