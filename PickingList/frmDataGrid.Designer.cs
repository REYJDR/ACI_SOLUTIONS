namespace PickingList
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
            this.btnProc = new System.Windows.Forms.Button();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPre)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPre
            // 
            this.dataGridPre.AllowUserToAddRows = false;
            this.dataGridPre.AllowUserToDeleteRows = false;
            this.dataGridPre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dataGridPre.Location = new System.Drawing.Point(5, 12);
            this.dataGridPre.Name = "dataGridPre";
            this.dataGridPre.ReadOnly = true;
            this.dataGridPre.Size = new System.Drawing.Size(478, 200);
            this.dataGridPre.TabIndex = 0;
            // 
            // btnProc
            // 
            this.btnProc.Location = new System.Drawing.Point(355, 218);
            this.btnProc.Name = "btnProc";
            this.btnProc.Size = new System.Drawing.Size(75, 23);
            this.btnProc.TabIndex = 1;
            this.btnProc.Text = "Process";
            this.btnProc.UseVisualStyleBackColor = true;
            this.btnProc.Click += new System.EventHandler(this.btnProc_Click);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            // 
            // frmDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(485, 258);
            this.Controls.Add(this.btnProc);
            this.Controls.Add(this.dataGridPre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDataGrid";
            this.Text = "Picking List Sales Order";
            this.Load += new System.EventHandler(this.frmDataGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPre;
        private System.Windows.Forms.Button btnProc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
    }
}