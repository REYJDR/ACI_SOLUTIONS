namespace ACIWEB_DESKTOP_REPORT
{
    partial class FrmReportFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportFilter));
            this.selectOptionsPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectOptionsPanel2 = new System.Windows.Forms.Panel();
            this.panelBar = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // selectOptionsPanel
            // 
            this.selectOptionsPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.selectOptionsPanel.Location = new System.Drawing.Point(6, 21);
            this.selectOptionsPanel.Name = "selectOptionsPanel";
            this.selectOptionsPanel.Size = new System.Drawing.Size(121, 33);
            this.selectOptionsPanel.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.selectOptionsPanel2);
            this.groupBox1.Controls.Add(this.selectOptionsPanel);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("SAPGUI-Belize-Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 156);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // selectOptionsPanel2
            // 
            this.selectOptionsPanel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.selectOptionsPanel2.Location = new System.Drawing.Point(124, 21);
            this.selectOptionsPanel2.Name = "selectOptionsPanel2";
            this.selectOptionsPanel2.Size = new System.Drawing.Size(132, 33);
            this.selectOptionsPanel2.TabIndex = 5;
            // 
            // panelBar
            // 
            this.panelBar.AutoSize = true;
            this.panelBar.Controls.Add(this.picClose);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelBar.Location = new System.Drawing.Point(0, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(265, 0);
            this.panelBar.TabIndex = 9;
            // 
            // picClose
            // 
            this.picClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.picClose.Image = global::ACIWEB_DESKTOP_REPORT.Properties.Resources.close_fa;
            this.picClose.Location = new System.Drawing.Point(246, 0);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(19, 0);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 7;
            this.picClose.TabStop = false;
            // 
            // FrmReportFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(265, 150);
            this.Controls.Add(this.panelBar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReportFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selection Options";
            this.groupBox1.ResumeLayout(false);
            this.panelBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Panel selectOptionsPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Panel selectOptionsPanel2;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.PictureBox picClose;
    }
}