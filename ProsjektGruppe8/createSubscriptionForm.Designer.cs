namespace ProsjektGruppe8
{
    partial class createSubscriptionForm
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
            this.btnAddSubscriptions = new System.Windows.Forms.Button();
            this.cboAlarmType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboEmails
            // 
            this.cboEmails.FormattingEnabled = true;
            this.cboEmails.Location = new System.Drawing.Point(12, 25);
            this.cboEmails.Name = "cboEmails";
            this.cboEmails.Size = new System.Drawing.Size(160, 21);
            this.cboEmails.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Abbonenter";
            // 
            // btnAddSubscriptions
            // 
            this.btnAddSubscriptions.Location = new System.Drawing.Point(12, 92);
            this.btnAddSubscriptions.Name = "btnAddSubscriptions";
            this.btnAddSubscriptions.Size = new System.Drawing.Size(160, 23);
            this.btnAddSubscriptions.TabIndex = 7;
            this.btnAddSubscriptions.Text = "Legg til abbonementer";
            this.btnAddSubscriptions.UseVisualStyleBackColor = true;
            this.btnAddSubscriptions.Click += new System.EventHandler(this.btnAddSubscriptions_Click);
            // 
            // cboAlarmType
            // 
            this.cboAlarmType.FormattingEnabled = true;
            this.cboAlarmType.Location = new System.Drawing.Point(12, 65);
            this.cboAlarmType.Name = "cboAlarmType";
            this.cboAlarmType.Size = new System.Drawing.Size(160, 21);
            this.cboAlarmType.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Alarmtype";
            // 
            // createSubscriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 125);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboAlarmType);
            this.Controls.Add(this.btnAddSubscriptions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEmails);
            this.MaximumSize = new System.Drawing.Size(200, 164);
            this.MinimumSize = new System.Drawing.Size(200, 164);
            this.Name = "createSubscriptionForm";
            this.Text = "createSubscriptionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEmails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddSubscriptions;
        private System.Windows.Forms.ComboBox cboAlarmType;
        private System.Windows.Forms.Label label2;
    }
}