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
    public partial class xportPdfForm : Form
    {
        emailHandler mail;
        dbInterface db;
        public xportPdfForm(dbInterface dbInterface, emailHandler mail)
        {
            InitializeComponent();
            db = dbInterface;
            this.mail = mail;
            db.namesToCombobox(cboEmails);
            
        }

        private void cbSendEmail_CheckedChanged(object sender, EventArgs e)
        {
            cboEmails.Enabled = cbSendEmail.Checked;
            checkBoxTest();
            
        }
        private void checkBoxTest()
        {
            if (cbOpenFile.Checked == false && cbSendEmail.Checked == false)
            {
                btnXportPdf.Enabled = false;
            }
            else
            {
                btnXportPdf.Enabled = true;
            }
        }
        private void btnXportPdf_Click(object sender, EventArgs e)
        {
            
            DataTable dt = db.activeAlarmsInDT("SELECT Alarmtype, Tidsrom, [Verdi\\temperatur] FROM Alarmer WHERE[aktiv\\ikke aktiv] = 1 Order by Tidsrom desc");
            pdfHandler handler = new pdfHandler(dt);
            handler.CreateDocument(cbOpenFile.Checked);
            if (cbSendEmail.Checked)
            {
            mail.SendMailAttatchment(cboEmails.Text, "Rapport", "Vedlagt ligger rapport med aktive alarmer", handler.filename);

            }
        }

        private void cbOpenFile_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxTest();
        }
    }
}
