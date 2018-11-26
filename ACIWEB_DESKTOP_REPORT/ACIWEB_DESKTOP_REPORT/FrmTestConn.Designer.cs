namespace ACIWEB_DESKTOP_REPORT
{
    partial class FrmTestConn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTestConn));
            this.dataGridTest = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbltestConn = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTest)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTest
            // 
            this.dataGridTest.AllowUserToAddRows = false;
            this.dataGridTest.AllowUserToDeleteRows = false;
            this.dataGridTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridTest.Location = new System.Drawing.Point(0, 0);
            this.dataGridTest.Name = "dataGridTest";
            this.dataGridTest.ReadOnly = true;
            this.dataGridTest.Size = new System.Drawing.Size(352, 245);
            this.dataGridTest.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picClose);
            this.panel1.Controls.Add(this.lbltestConn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 25);
            this.panel1.TabIndex = 1;
            // 
            // lbltestConn
            // 
            this.lbltestConn.AutoSize = true;
            this.lbltestConn.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltestConn.Location = new System.Drawing.Point(3, 6);
            this.lbltestConn.Name = "lbltestConn";
            this.lbltestConn.Size = new System.Drawing.Size(126, 16);
            this.lbltestConn.TabIndex = 0;
            this.lbltestConn.Text = "Sage Connection Test";
            // 
            // picClose
            // 
            this.picClose.Image = global::ACIWEB_DESKTOP_REPORT.Properties.Resources.close_fa;
            this.picClose.Location = new System.Drawing.Point(330, 3);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(19, 19);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 2;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // FrmTestConn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 245);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTestConn";
            this.Text = "Connection Test";
            this.Load += new System.EventHandler(this.frmTestConn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTest)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridTest;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltestConn;
        private System.Windows.Forms.PictureBox picClose;
    }
}