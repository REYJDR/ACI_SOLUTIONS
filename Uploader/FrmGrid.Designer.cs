namespace UPLOADER
{
    partial class FrmGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGrid));
            this.dataGridTbl = new System.Windows.Forms.DataGridView();
            this.frmInitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCargar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmInitBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTbl
            // 
            this.dataGridTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTbl.Location = new System.Drawing.Point(1, 34);
            this.dataGridTbl.Name = "dataGridTbl";
            this.dataGridTbl.Size = new System.Drawing.Size(978, 490);
            this.dataGridTbl.TabIndex = 0;
            // 
            // frmInitBindingSource
            // 
            this.frmInitBindingSource.DataSource = typeof(UPLOADER.FrmInit);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(12, 5);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 1;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // FrmGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 526);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.dataGridTbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGrid";
            this.Text = "Datos a importar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmInitBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridTbl;
        private System.Windows.Forms.BindingSource frmInitBindingSource;
        private System.Windows.Forms.Button btnCargar;
    }
}