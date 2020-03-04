namespace AciSapLibrary
{
    partial class FrmSapRep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSapRep));
            this.chkOnlyDS = new System.Windows.Forms.CheckBox();
            this.cmbFileType = new System.Windows.Forms.ComboBox();
            this.chkExport = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxRepType = new System.Windows.Forms.ComboBox();
            this.btnSapQuery = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkOnlyDS
            // 
            this.chkOnlyDS.AutoSize = true;
            this.chkOnlyDS.Location = new System.Drawing.Point(16, 90);
            this.chkOnlyDS.Name = "chkOnlyDS";
            this.chkOnlyDS.Size = new System.Drawing.Size(131, 17);
            this.chkOnlyDS.TabIndex = 35;
            this.chkOnlyDS.Text = "Only show datasource";
            this.chkOnlyDS.UseVisualStyleBackColor = true;
            // 
            // cmbFileType
            // 
            this.cmbFileType.AutoCompleteCustomSource.AddRange(new string[] {
            "txt",
            "csv"});
            this.cmbFileType.FormattingEnabled = true;
            this.cmbFileType.Items.AddRange(new object[] {
            "csv",
            "txt"});
            this.cmbFileType.Location = new System.Drawing.Point(85, 63);
            this.cmbFileType.Name = "cmbFileType";
            this.cmbFileType.Size = new System.Drawing.Size(58, 21);
            this.cmbFileType.TabIndex = 34;
            // 
            // chkExport
            // 
            this.chkExport.AutoSize = true;
            this.chkExport.Location = new System.Drawing.Point(16, 66);
            this.chkExport.Name = "chkExport";
            this.chkExport.Size = new System.Drawing.Size(71, 17);
            this.chkExport.TabIndex = 33;
            this.chkExport.Text = "Export to ";
            this.chkExport.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxRepType);
            this.groupBox3.Controls.Add(this.btnSapQuery);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 48);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report template";
            // 
            // comboBoxRepType
            // 
            this.comboBoxRepType.FormattingEnabled = true;
            this.comboBoxRepType.Location = new System.Drawing.Point(9, 19);
            this.comboBoxRepType.Name = "comboBoxRepType";
            this.comboBoxRepType.Size = new System.Drawing.Size(162, 21);
            this.comboBoxRepType.TabIndex = 13;
            // 
            // btnSapQuery
            // 
            this.btnSapQuery.Location = new System.Drawing.Point(242, 16);
            this.btnSapQuery.Name = "btnSapQuery";
            this.btnSapQuery.Size = new System.Drawing.Size(75, 23);
            this.btnSapQuery.TabIndex = 12;
            this.btnSapQuery.Text = "Query";
            this.btnSapQuery.UseVisualStyleBackColor = true;
            this.btnSapQuery.Click += new System.EventHandler(this.btnSapQuery_Click);
            // 
            // FrmSapRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 146);
            this.Controls.Add(this.chkOnlyDS);
            this.Controls.Add(this.cmbFileType);
            this.Controls.Add(this.chkExport);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSapRep";
            this.Text = "SAP Report";
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkOnlyDS;
        private System.Windows.Forms.ComboBox cmbFileType;
        private System.Windows.Forms.CheckBox chkExport;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ComboBox comboBoxRepType;
        private System.Windows.Forms.Button btnSapQuery;
    }
}