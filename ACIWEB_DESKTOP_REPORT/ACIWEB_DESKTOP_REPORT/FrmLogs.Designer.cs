namespace ACIWEB_DESKTOP_REPORT
{
    partial class FrmLogs
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
            this.txtBoxProgress = new System.Windows.Forms.TextBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoxProgress
            // 
            this.txtBoxProgress.Location = new System.Drawing.Point(12, 34);
            this.txtBoxProgress.Multiline = true;
            this.txtBoxProgress.Name = "txtBoxProgress";
            this.txtBoxProgress.ReadOnly = true;
            this.txtBoxProgress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxProgress.Size = new System.Drawing.Size(672, 257);
            this.txtBoxProgress.TabIndex = 0;
            // 
            // picClose
            // 
            this.picClose.Image = global::ACIWEB_DESKTOP_REPORT.Properties.Resources.close_fa;
            this.picClose.Location = new System.Drawing.Point(665, 9);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(19, 19);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 2;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "SFTP Transfer logs";
            // 
            // FrmLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 303);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.txtBoxProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmProgress";
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxProgress;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Label label1;
    }
}