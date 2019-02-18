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
            this.tmrUpdateBattery = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtBatteryStatus
            // 
            this.txtBatteryStatus.Location = new System.Drawing.Point(593, 418);
            this.txtBatteryStatus.Name = "txtBatteryStatus";
            this.txtBatteryStatus.ReadOnly = true;
            this.txtBatteryStatus.Size = new System.Drawing.Size(195, 20);
            this.txtBatteryStatus.TabIndex = 0;
            this.txtBatteryStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tmrUpdateBattery
            // 
            this.tmrUpdateBattery.Enabled = true;
            this.tmrUpdateBattery.Interval = 60000;
            this.tmrUpdateBattery.Tick += new System.EventHandler(this.tmrUpdateBattery_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtBatteryStatus);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBatteryStatus;
        private System.Windows.Forms.Timer tmrUpdateBattery;
    }
}

