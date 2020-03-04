namespace AciSapLibrary
{
    partial class FrmDesignerSap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDesignerSap));
            this.cmbBapiSelect = new System.Windows.Forms.ComboBox();
            this.btnSapDEdit = new System.Windows.Forms.Button();
            this.btnSapDFrsh = new System.Windows.Forms.Button();
            this.btnSapDDel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListReportSap = new System.Windows.Forms.CheckedListBox();
            this.btnSapDNew = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBapiSelect
            // 
            this.cmbBapiSelect.FormattingEnabled = true;
            this.cmbBapiSelect.Location = new System.Drawing.Point(2, 2);
            this.cmbBapiSelect.Name = "cmbBapiSelect";
            this.cmbBapiSelect.Size = new System.Drawing.Size(162, 21);
            this.cmbBapiSelect.TabIndex = 52;
            this.cmbBapiSelect.SelectedIndexChanged += new System.EventHandler(this.cmbBapiSelect_SelectedIndexChanged);
            // 
            // btnSapDEdit
            // 
            this.btnSapDEdit.Location = new System.Drawing.Point(362, 52);
            this.btnSapDEdit.Name = "btnSapDEdit";
            this.btnSapDEdit.Size = new System.Drawing.Size(75, 23);
            this.btnSapDEdit.TabIndex = 51;
            this.btnSapDEdit.Text = "Edit";
            this.btnSapDEdit.UseVisualStyleBackColor = true;
            this.btnSapDEdit.Click += new System.EventHandler(this.btnSapDEdit_Click);
            // 
            // btnSapDFrsh
            // 
            this.btnSapDFrsh.Location = new System.Drawing.Point(362, 110);
            this.btnSapDFrsh.Name = "btnSapDFrsh";
            this.btnSapDFrsh.Size = new System.Drawing.Size(75, 23);
            this.btnSapDFrsh.TabIndex = 50;
            this.btnSapDFrsh.Text = "Refresh";
            this.btnSapDFrsh.UseVisualStyleBackColor = true;
            this.btnSapDFrsh.Click += new System.EventHandler(this.btnSapDFrsh_Click);
            // 
            // btnSapDDel
            // 
            this.btnSapDDel.Location = new System.Drawing.Point(362, 81);
            this.btnSapDDel.Name = "btnSapDDel";
            this.btnSapDDel.Size = new System.Drawing.Size(75, 23);
            this.btnSapDDel.TabIndex = 49;
            this.btnSapDDel.Text = "Delete";
            this.btnSapDDel.UseVisualStyleBackColor = true;
            this.btnSapDDel.Click += new System.EventHandler(this.btnSapDDel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListReportSap);
            this.groupBox1.Location = new System.Drawing.Point(2, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 274);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reports templates";
            // 
            // checkedListReportSap
            // 
            this.checkedListReportSap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListReportSap.CheckOnClick = true;
            this.checkedListReportSap.FormattingEnabled = true;
            this.checkedListReportSap.Location = new System.Drawing.Point(6, 21);
            this.checkedListReportSap.Name = "checkedListReportSap";
            this.checkedListReportSap.Size = new System.Drawing.Size(342, 240);
            this.checkedListReportSap.TabIndex = 20;
            // 
            // btnSapDNew
            // 
            this.btnSapDNew.Location = new System.Drawing.Point(170, 2);
            this.btnSapDNew.Name = "btnSapDNew";
            this.btnSapDNew.Size = new System.Drawing.Size(75, 23);
            this.btnSapDNew.TabIndex = 47;
            this.btnSapDNew.Text = "New ";
            this.btnSapDNew.UseVisualStyleBackColor = true;
            this.btnSapDNew.Click += new System.EventHandler(this.btnSapDNew_Click);
            // 
            // FrmDesignerSap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 300);
            this.Controls.Add(this.cmbBapiSelect);
            this.Controls.Add(this.btnSapDEdit);
            this.Controls.Add(this.btnSapDFrsh);
            this.Controls.Add(this.btnSapDDel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSapDNew);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDesignerSap";
            this.Text = "Report Designer";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cmbBapiSelect;
        private System.Windows.Forms.Button btnSapDEdit;
        private System.Windows.Forms.Button btnSapDFrsh;
        private System.Windows.Forms.Button btnSapDDel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox checkedListReportSap;
        private System.Windows.Forms.Button btnSapDNew;
    }
}