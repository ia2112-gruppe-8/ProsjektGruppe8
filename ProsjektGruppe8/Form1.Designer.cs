namespace ProsjektGruppe8
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.txtBatteryStatus = new System.Windows.Forms.TextBox();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.dgvActiveAlarms = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveAlarms)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBatteryStatus
            // 
            this.txtBatteryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatteryStatus.Location = new System.Drawing.Point(593, 418);
            this.txtBatteryStatus.MaximumSize = new System.Drawing.Size(195, 20);
            this.txtBatteryStatus.Name = "txtBatteryStatus";
            this.txtBatteryStatus.ReadOnly = true;
            this.txtBatteryStatus.Size = new System.Drawing.Size(195, 20);
            this.txtBatteryStatus.TabIndex = 0;
            this.txtBatteryStatus.TabStop = false;
            this.txtBatteryStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            this.tmrUpdate.Interval = 500;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // dgvActiveAlarms
            // 
            this.dgvActiveAlarms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvActiveAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveAlarms.Location = new System.Drawing.Point(12, 12);
            this.dgvActiveAlarms.Name = "dgvActiveAlarms";
            this.dgvActiveAlarms.Size = new System.Drawing.Size(776, 210);
            this.dgvActiveAlarms.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvActiveAlarms);
            this.Controls.Add(this.txtBatteryStatus);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveAlarms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBatteryStatus;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.DataGridView dgvActiveAlarms;
    }
}

