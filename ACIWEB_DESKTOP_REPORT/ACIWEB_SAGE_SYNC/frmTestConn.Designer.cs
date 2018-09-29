namespace ACIWEB_SAGE_SYNC
{
    partial class frmTestConn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestConn));
            this.dataGridTest = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTest)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTest
            // 
            this.dataGridTest.AllowUserToAddRows = false;
            this.dataGridTest.AllowUserToDeleteRows = false;
            this.dataGridTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTest.Location = new System.Drawing.Point(-3, -3);
            this.dataGridTest.Name = "dataGridTest";
            this.dataGridTest.ReadOnly = true;
            this.dataGridTest.Size = new System.Drawing.Size(357, 250);
            this.dataGridTest.TabIndex = 0;
            // 
            // frmTestConn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 245);
            this.Controls.Add(this.dataGridTest);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTestConn";
            this.Text = "Connection Test";
            this.Load += new System.EventHandler(this.frmTestConn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridTest;
    }
}