namespace CollectionISP
{
    partial class frmDataGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataGrid));
            this.dataGridPre = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPre)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPre
            // 
            this.dataGridPre.AllowUserToAddRows = false;
            this.dataGridPre.AllowUserToDeleteRows = false;
            this.dataGridPre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPre.Location = new System.Drawing.Point(1, 1);
            this.dataGridPre.Name = "dataGridPre";
            this.dataGridPre.ReadOnly = true;
            this.dataGridPre.Size = new System.Drawing.Size(942, 538);
            this.dataGridPre.TabIndex = 0;
            // 
            // frmDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(945, 541);
            this.Controls.Add(this.dataGridPre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDataGrid";
            this.Text = "Collection data source";
            this.Load += new System.EventHandler(this.frmDataGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPre;
    }
}