namespace PastDue
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataGrid));
            this.dataGridPre = new System.Windows.Forms.DataGridView();
            this.btnProc = new System.Windows.Forms.Button();
            this.chkSelAll = new System.Windows.Forms.CheckBox();
            this.SelChkBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPre)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPre
            // 
            this.dataGridPre.AllowUserToAddRows = false;
            this.dataGridPre.AllowUserToDeleteRows = false;
            this.dataGridPre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelChkBox});
            this.dataGridPre.Location = new System.Drawing.Point(5, 12);
            this.dataGridPre.Name = "dataGridPre";
            this.dataGridPre.ReadOnly = true;
            this.dataGridPre.Size = new System.Drawing.Size(478, 200);
            this.dataGridPre.TabIndex = 0;
            // 
            // btnProc
            // 
            this.btnProc.Location = new System.Drawing.Point(398, 219);
            this.btnProc.Name = "btnProc";
            this.btnProc.Size = new System.Drawing.Size(75, 23);
            this.btnProc.TabIndex = 1;
            this.btnProc.Text = "Process";
            this.btnProc.UseVisualStyleBackColor = true;
            this.btnProc.Click += new System.EventHandler(this.btnProc_Click);
            // 
            // chkSelAll
            // 
            this.chkSelAll.AutoSize = true;
            this.chkSelAll.Location = new System.Drawing.Point(13, 223);
            this.chkSelAll.Name = "chkSelAll";
            this.chkSelAll.Size = new System.Drawing.Size(70, 17);
            this.chkSelAll.TabIndex = 2;
            this.chkSelAll.Text = "Select All";
            this.chkSelAll.UseVisualStyleBackColor = true;
            this.chkSelAll.CheckedChanged += new System.EventHandler(this.chkSelAll_CheckedChanged);
            // 
            // SelChkBox
            // 
            this.SelChkBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.NullValue = false;
            this.SelChkBox.DefaultCellStyle = dataGridViewCellStyle1;
            this.SelChkBox.HeaderText = "Selection";
            this.SelChkBox.Name = "SelChkBox";
            this.SelChkBox.ReadOnly = true;
            this.SelChkBox.Width = 57;
            // 
            // frmDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(485, 258);
            this.Controls.Add(this.chkSelAll);
            this.Controls.Add(this.btnProc);
            this.Controls.Add(this.dataGridPre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDataGrid";
            this.Text = "Picking List Sales Order";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPre;
        private System.Windows.Forms.Button btnProc;
        private System.Windows.Forms.CheckBox chkSelAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelChkBox;
    }
}