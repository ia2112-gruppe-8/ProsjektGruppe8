namespace ProsjektGruppe8
{
    partial class xportPdfForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboEmails = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSendEmail = new System.Windows.Forms.CheckBox();
            this.cbOpenFile = new System.Windows.Forms.CheckBox();
            this.btnXportPdf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboEmails
            // 
            this.cboEmails.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboEmails.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEmails.Enabled = false;
            this.cboEmails.FormattingEnabled = true;
            this.cboEmails.Location = new System.Drawing.Point(110, 44);
            this.cboEmails.Name = "cboEmails";
            this.cboEmails.Size = new System.Drawing.Size(165, 21);
            this.cboEmails.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mottaker";
            // 
            // cbSendEmail
            // 
            this.cbSendEmail.AutoSize = true;
            this.cbSendEmail.Location = new System.Drawing.Point(15, 46);
            this.cbSendEmail.Name = "cbSendEmail";
            this.cbSendEmail.Size = new System.Drawing.Size(89, 17);
            this.cbSendEmail.TabIndex = 2;
            this.cbSendEmail.Text = "Send På Mail";
            this.cbSendEmail.UseVisualStyleBackColor = true;
            this.cbSendEmail.CheckedChanged += new System.EventHandler(this.cbSendEmail_CheckedChanged);
            // 
            // cbOpenFile
            // 
            this.cbOpenFile.AutoSize = true;
            this.cbOpenFile.Location = new System.Drawing.Point(15, 25);
            this.cbOpenFile.Name = "cbOpenFile";
            this.cbOpenFile.Size = new System.Drawing.Size(76, 17);
            this.cbOpenFile.TabIndex = 3;
            this.cbOpenFile.Text = "Åpne Filen";
            this.cbOpenFile.UseVisualStyleBackColor = true;
            this.cbOpenFile.CheckedChanged += new System.EventHandler(this.cbOpenFile_CheckedChanged);
            // 
            // btnXportPdf
            // 
            this.btnXportPdf.Enabled = false;
            this.btnXportPdf.Location = new System.Drawing.Point(15, 71);
            this.btnXportPdf.Name = "btnXportPdf";
            this.btnXportPdf.Size = new System.Drawing.Size(260, 23);
            this.btnXportPdf.TabIndex = 4;
            this.btnXportPdf.Text = "Åpne/Send PDF";
            this.btnXportPdf.UseVisualStyleBackColor = true;
            this.btnXportPdf.Click += new System.EventHandler(this.btnXportPdf_Click);
            // 
            // xportPdfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 98);
            this.Controls.Add(this.btnXportPdf);
            this.Controls.Add(this.cbOpenFile);
            this.Controls.Add(this.cbSendEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEmails);
            this.MaximumSize = new System.Drawing.Size(303, 137);
            this.MinimumSize = new System.Drawing.Size(303, 137);
            this.Name = "xportPdfForm";
            this.Text = "xportPdfForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEmails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbSendEmail;
        private System.Windows.Forms.CheckBox cbOpenFile;
        private System.Windows.Forms.Button btnXportPdf;
    }
}