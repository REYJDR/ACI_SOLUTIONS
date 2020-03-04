namespace SFTPLibrary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogs));
            this.txtBoxProgress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBoxProgress
            // 
            this.txtBoxProgress.Location = new System.Drawing.Point(1, 1);
            this.txtBoxProgress.Multiline = true;
            this.txtBoxProgress.Name = "txtBoxProgress";
            this.txtBoxProgress.ReadOnly = true;
            this.txtBoxProgress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxProgress.Size = new System.Drawing.Size(601, 257);
            this.txtBoxProgress.TabIndex = 1;
            // 
            // FrmLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 260);
            this.Controls.Add(this.txtBoxProgress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogs";
            this.Text = "SFTP Logs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxProgress;
    }
}