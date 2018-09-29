namespace ACIWEB_DESKTOP_REPORT
{
    partial class FrmInit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInit));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkRepD = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxRepType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDateFrom = new System.Windows.Forms.TextBox();
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtIdComp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboComp = new System.Windows.Forms.ComboBox();
            this.txtNameComp = new System.Windows.Forms.TextBox();
            this.btnSaveComp = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textHostname = new System.Windows.Forms.TextBox();
            this.lblDbName = new System.Windows.Forms.Label();
            this.textUser = new System.Windows.Forms.TextBox();
            this.textBD = new System.Windows.Forms.TextBox();
            this.textPass = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkedListReport = new System.Windows.Forms.CheckedListBox();
            this.btnDesigner = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.AccessibleName = "";
            this.tabPrincipal.Controls.Add(this.tabPage1);
            this.tabPrincipal.Controls.Add(this.tabPage2);
            this.tabPrincipal.Controls.Add(this.tabPage3);
            this.tabPrincipal.Location = new System.Drawing.Point(-2, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(565, 272);
            this.tabPrincipal.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(557, 246);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Report Filter";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkRepD);
            this.groupBox4.Location = new System.Drawing.Point(7, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(211, 137);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Report Type";
            // 
            // chkRepD
            // 
            this.chkRepD.AutoSize = true;
            this.chkRepD.Location = new System.Drawing.Point(10, 26);
            this.chkRepD.Name = "chkRepD";
            this.chkRepD.Size = new System.Drawing.Size(94, 17);
            this.chkRepD.TabIndex = 0;
            this.chkRepD.Text = "Reporte Diario";
            this.chkRepD.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxRepType);
            this.groupBox3.Location = new System.Drawing.Point(233, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 48);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Template";
            // 
            // comboBoxRepType
            // 
            this.comboBoxRepType.FormattingEnabled = true;
            this.comboBoxRepType.Location = new System.Drawing.Point(9, 19);
            this.comboBoxRepType.Name = "comboBoxRepType";
            this.comboBoxRepType.Size = new System.Drawing.Size(162, 21);
            this.comboBoxRepType.TabIndex = 13;
            this.comboBoxRepType.SelectedIndexChanged += new System.EventHandler(this.comboBoxRepType_SelectedIndexChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDateFrom);
            this.groupBox1.Controls.Add(this.dateTimeFrom);
            this.groupBox1.Controls.Add(this.lblDateTo);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.dateTimeTo);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 74);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Range";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(9, 28);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(35, 20);
            this.lblDateFrom.TabIndex = 2;
            this.lblDateFrom.Text = "From";
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.AllowDrop = true;
            this.dateTimeFrom.CustomFormat = "yyyy-MM-dd";
            this.dateTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimeFrom.Location = new System.Drawing.Point(50, 28);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(121, 20);
            this.dateTimeFrom.TabIndex = 0;
            this.dateTimeFrom.Value = new System.DateTime(2018, 1, 7, 14, 53, 17, 0);
            this.dateTimeFrom.ValueChanged += new System.EventHandler(this.dateTimeFrom_ValueChanged);
            // 
            // lblDateTo
            // 
            this.lblDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(177, 28);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(35, 20);
            this.lblDateTo.TabIndex = 3;
            this.lblDateTo.Text = "To";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(453, 29);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 12;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.AllowDrop = true;
            this.dateTimeTo.CustomFormat = "yyyy-MM-dd";
            this.dateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeTo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimeTo.Location = new System.Drawing.Point(218, 28);
            this.dateTimeTo.MinDate = new System.DateTime(1930, 1, 1, 0, 0, 0, 0);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(121, 20);
            this.dateTimeTo.TabIndex = 1;
            this.dateTimeTo.Value = new System.DateTime(2018, 1, 7, 14, 53, 37, 0);
            this.dateTimeTo.ValueChanged += new System.EventHandler(this.dateTimeTo_ValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(557, 246);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DB Connection";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtIdComp);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.comboComp);
            this.groupBox6.Controls.Add(this.txtNameComp);
            this.groupBox6.Controls.Add(this.btnSaveComp);
            this.groupBox6.Location = new System.Drawing.Point(7, 148);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(441, 71);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ID Compañia";
            // 
            // txtIdComp
            // 
            this.txtIdComp.Location = new System.Drawing.Point(114, 45);
            this.txtIdComp.Name = "txtIdComp";
            this.txtIdComp.ReadOnly = true;
            this.txtIdComp.Size = new System.Drawing.Size(32, 20);
            this.txtIdComp.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Current Company";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboComp
            // 
            this.comboComp.FormattingEnabled = true;
            this.comboComp.Location = new System.Drawing.Point(49, 15);
            this.comboComp.Name = "comboComp";
            this.comboComp.Size = new System.Drawing.Size(237, 21);
            this.comboComp.TabIndex = 10;
            this.comboComp.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtNameComp
            // 
            this.txtNameComp.Location = new System.Drawing.Point(153, 45);
            this.txtNameComp.Name = "txtNameComp";
            this.txtNameComp.ReadOnly = true;
            this.txtNameComp.Size = new System.Drawing.Size(133, 20);
            this.txtNameComp.TabIndex = 9;
            // 
            // btnSaveComp
            // 
            this.btnSaveComp.Location = new System.Drawing.Point(316, 15);
            this.btnSaveComp.Name = "btnSaveComp";
            this.btnSaveComp.Size = new System.Drawing.Size(92, 23);
            this.btnSaveComp.TabIndex = 12;
            this.btnSaveComp.Text = "Save Company";
            this.btnSaveComp.UseVisualStyleBackColor = true;
            this.btnSaveComp.Click += new System.EventHandler(this.btnSaveComp_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textHostname);
            this.groupBox2.Controls.Add(this.lblDbName);
            this.groupBox2.Controls.Add(this.textUser);
            this.groupBox2.Controls.Add(this.textBD);
            this.groupBox2.Controls.Add(this.textPass);
            this.groupBox2.Controls.Add(this.lblHost);
            this.groupBox2.Controls.Add(this.lblPass);
            this.groupBox2.Controls.Add(this.lblUser);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 136);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mysql Parameters";
            // 
            // textHostname
            // 
            this.textHostname.Location = new System.Drawing.Point(102, 19);
            this.textHostname.Name = "textHostname";
            this.textHostname.Size = new System.Drawing.Size(159, 20);
            this.textHostname.TabIndex = 0;
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(34, 104);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(51, 13);
            this.lblDbName.TabIndex = 8;
            this.lblDbName.Text = "DB name";
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(102, 45);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(159, 20);
            this.textUser.TabIndex = 1;
            // 
            // textBD
            // 
            this.textBD.Location = new System.Drawing.Point(102, 97);
            this.textBD.Name = "textBD";
            this.textBD.Size = new System.Drawing.Size(159, 20);
            this.textBD.TabIndex = 7;
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(102, 71);
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '*';
            this.textPass.Size = new System.Drawing.Size(159, 20);
            this.textPass.TabIndex = 2;
            this.textPass.UseSystemPasswordChar = true;
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(34, 26);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(55, 13);
            this.lblHost.TabIndex = 3;
            this.lblHost.Text = "Hostname";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(34, 78);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(53, 13);
            this.lblPass.TabIndex = 5;
            this.lblPass.Text = "Password";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(34, 52);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "User";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(308, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Connect/Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.btnDelete);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.btnDesigner);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(557, 246);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Report Designer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(308, 74);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkedListReport);
            this.groupBox5.Location = new System.Drawing.Point(7, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(286, 179);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Reports templates";
            // 
            // checkedListReport
            // 
            this.checkedListReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListReport.CheckOnClick = true;
            this.checkedListReport.FormattingEnabled = true;
            this.checkedListReport.Location = new System.Drawing.Point(6, 21);
            this.checkedListReport.Name = "checkedListReport";
            this.checkedListReport.Size = new System.Drawing.Size(274, 150);
            this.checkedListReport.TabIndex = 20;
            this.checkedListReport.SelectedIndexChanged += new System.EventHandler(this.checkedListReport_SelectedIndexChanged);
            // 
            // btnDesigner
            // 
            this.btnDesigner.Location = new System.Drawing.Point(308, 16);
            this.btnDesigner.Name = "btnDesigner";
            this.btnDesigner.Size = new System.Drawing.Size(75, 23);
            this.btnDesigner.TabIndex = 19;
            this.btnDesigner.Text = "Edit/Create";
            this.btnDesigner.UseVisualStyleBackColor = true;
            this.btnDesigner.Click += new System.EventHandler(this.btnDesigner_Click_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 275);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(563, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // FrmInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 297);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInit";
            this.Text = "Aciweb Desktop Report v1.0.0.5";
            this.Load += new System.EventHandler(this.FrmInit_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.TextBox textHostname;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.TextBox textBD;
        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private System.Windows.Forms.DateTimePicker dateTimeTo;
        private System.Windows.Forms.TextBox lblDateTo;
        private System.Windows.Forms.TextBox lblDateFrom;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox comboBoxRepType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckedListBox checkedListReport;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnDesigner;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkRepD;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox comboComp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameComp;
        private System.Windows.Forms.Button btnSaveComp;
        private System.Windows.Forms.TextBox txtIdComp;
    }
}

