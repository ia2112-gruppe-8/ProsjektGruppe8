namespace ProsjektGruppe8
{
    partial class alterSubscriberForm
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
            this.btnAlterSubscriber = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEmails = new System.Windows.Forms.ComboBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAlterSubscriber
            // 
            this.btnAlterSubscriber.Location = new System.Drawing.Point(12, 126);
            this.btnAlterSubscriber.Name = "btnAlterSubscriber";
            this.btnAlterSubscriber.Size = new System.Drawing.Size(100, 23);
            this.btnAlterSubscriber.TabIndex = 13;
            this.btnAlterSubscriber.Text = "Endre";
            this.btnAlterSubscriber.UseVisualStyleBackColor = true;
            this.btnAlterSubscriber.Click += new System.EventHandler(this.btnAlterSubscriber_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nåværende Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nummer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Navn";
            // 
            // cboEmails
            // 
            this.cboEmails.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboEmails.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEmails.FormattingEnabled = true;
            this.cboEmails.Location = new System.Drawing.Point(201, 22);
            this.cboEmails.Name = "cboEmails";
            this.cboEmails.Size = new System.Drawing.Size(154, 21);
            this.cboEmails.TabIndex = 12;
            this.cboEmails.SelectedIndexChanged += new System.EventHandler(this.cboEmails_SelectedIndexChanged);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(12, 100);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(154, 20);
            this.txtNumber.TabIndex = 11;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(12, 61);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(154, 20);
            this.txtMail.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 20);
            this.txtName.TabIndex = 5;
            // 
            // alterSubscriberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 161);
            this.Controls.Add(this.btnAlterSubscriber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEmails);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtName);
            this.Name = "alterSubscriberForm";
            this.Text = "alterSubscriberForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAlterSubscriber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEmails;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtName;
    }
}