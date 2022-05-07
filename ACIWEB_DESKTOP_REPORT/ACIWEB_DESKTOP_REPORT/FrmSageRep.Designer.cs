namespace ACIWEB_DESKTOP_REPORT
{
    partial class FrmSageRep
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkExcel = new System.Windows.Forms.CheckBox();
            this.chkOnlyDS = new System.Windows.Forms.CheckBox();
            this.cmbFileType = new System.Windows.Forms.ComboBox();
            this.chkExport = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxRepType = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chkRepD = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.chkExcel);
            this.panel1.Controls.Add(this.chkOnlyDS);
            this.panel1.Controls.Add(this.cmbFileType);
            this.panel1.Controls.Add(this.chkExport);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 429);
            this.panel1.TabIndex = 5;
            // 
            // chkExcel
            // 
            this.chkExcel.AutoSize = true;
            this.chkExcel.Location = new System.Drawing.Point(11, 112);
            this.chkExcel.Name = "chkExcel";
            this.chkExcel.Size = new System.Drawing.Size(92, 17);
            this.chkExcel.TabIndex = 31;
            this.chkExcel.Text = "Open in Excel";
            this.chkExcel.UseVisualStyleBackColor = true;
            this.chkExcel.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // chkOnlyDS
            // 
            this.chkOnlyDS.AutoSize = true;
            this.chkOnlyDS.Location = new System.Drawing.Point(11, 89);
            this.chkOnlyDS.Name = "chkOnlyDS";
            this.chkOnlyDS.Size = new System.Drawing.Size(131, 17);
            this.chkOnlyDS.TabIndex = 30;
            this.chkOnlyDS.Text = "Only show datasource";
            this.chkOnlyDS.UseVisualStyleBackColor = true;
            this.chkOnlyDS.CheckedChanged += new System.EventHandler(this.chkOnlyDS_CheckedChanged);
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
            this.cmbFileType.Location = new System.Drawing.Point(80, 64);
            this.cmbFileType.Name = "cmbFileType";
            this.cmbFileType.Size = new System.Drawing.Size(58, 21);
            this.cmbFileType.TabIndex = 29;
            // 
            // chkExport
            // 
            this.chkExport.AutoSize = true;
            this.chkExport.Location = new System.Drawing.Point(11, 66);
            this.chkExport.Name = "chkExport";
            this.chkExport.Size = new System.Drawing.Size(68, 17);
            this.chkExport.TabIndex = 21;
            this.chkExport.Text = "Export to";
            this.chkExport.UseVisualStyleBackColor = true;
            this.chkExport.CheckedChanged += new System.EventHandler(this.chkExport_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxRepType);
            this.groupBox3.Controls.Add(this.btnQuery);
            this.groupBox3.Location = new System.Drawing.Point(11, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(339, 48);
            this.groupBox3.TabIndex = 20;
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
            this.comboBoxRepType.SelectedIndexChanged += new System.EventHandler(this.comboBoxRepType_SelectedIndexChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(232, 17);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 12;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // chkRepD
            // 
            this.chkRepD.Location = new System.Drawing.Point(0, 0);
            this.chkRepD.Name = "chkRepD";
            this.chkRepD.Size = new System.Drawing.Size(104, 24);
            this.chkRepD.TabIndex = 4;
            // 
            // FrmSageRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 428);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkRepD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSageRep";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ComboBox comboBoxRepType;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox chkRepD;
        private System.Windows.Forms.CheckBox chkExport;
        private System.Windows.Forms.ComboBox cmbFileType;
        private System.Windows.Forms.CheckBox chkOnlyDS;
        private System.Windows.Forms.CheckBox chkExcel;
    }
}