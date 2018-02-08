namespace ISPCollection
{
    partial class frmInit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInit));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBoxRepType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateCollectOf = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateRepFrom = new System.Windows.Forms.DateTimePicker();
            this.dateRepTo = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDateFrom = new System.Windows.Forms.TextBox();
            this.dateInvFrom = new System.Windows.Forms.DateTimePicker();
            this.dateInvTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblDbName = new System.Windows.Forms.Label();
            this.textBD = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.textPass = new System.Windows.Forms.TextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.textHostname = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkedListReport = new System.Windows.Forms.CheckedListBox();
            this.btnDesigner = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.tabPrincipal.Size = new System.Drawing.Size(338, 246);
            this.tabPrincipal.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnQuery);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(330, 220);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Report Filter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBoxRepType);
            this.groupBox5.Location = new System.Drawing.Point(167, 104);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(154, 54);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Report Type";
            // 
            // comboBoxRepType
            // 
            this.comboBoxRepType.FormattingEnabled = true;
            this.comboBoxRepType.Location = new System.Drawing.Point(9, 19);
            this.comboBoxRepType.Name = "comboBoxRepType";
            this.comboBoxRepType.Size = new System.Drawing.Size(132, 21);
            this.comboBoxRepType.TabIndex = 13;
            this.comboBoxRepType.SelectedIndexChanged += new System.EventHandler(this.comboBoxRepType_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateCollectOf);
            this.groupBox3.Location = new System.Drawing.Point(10, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 55);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Collection of";
            // 
            // dateCollectOf
            // 
            this.dateCollectOf.AllowDrop = true;
            this.dateCollectOf.CustomFormat = "yyyy-MM-dd";
            this.dateCollectOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCollectOf.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateCollectOf.Location = new System.Drawing.Point(47, 20);
            this.dateCollectOf.MinDate = new System.DateTime(1930, 1, 1, 0, 0, 0, 0);
            this.dateCollectOf.Name = "dateCollectOf";
            this.dateCollectOf.Size = new System.Drawing.Size(93, 20);
            this.dateCollectOf.TabIndex = 17;
            this.dateCollectOf.Value = new System.DateTime(2018, 1, 7, 14, 53, 37, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.dateRepFrom);
            this.groupBox2.Controls.Add(this.dateRepTo);
            this.groupBox2.Location = new System.Drawing.Point(167, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 95);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Receipts Date Range";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(6, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(35, 13);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = "From";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 13);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "To";
            // 
            // dateRepFrom
            // 
            this.dateRepFrom.AllowDrop = true;
            this.dateRepFrom.CustomFormat = "yyyy-MM-dd";
            this.dateRepFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateRepFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateRepFrom.Location = new System.Drawing.Point(47, 31);
            this.dateRepFrom.Name = "dateRepFrom";
            this.dateRepFrom.Size = new System.Drawing.Size(94, 20);
            this.dateRepFrom.TabIndex = 13;
            this.dateRepFrom.Value = new System.DateTime(2018, 1, 7, 14, 53, 17, 0);
            this.dateRepFrom.ValueChanged += new System.EventHandler(this.dateRepFrom_ValueChanged);
            // 
            // dateRepTo
            // 
            this.dateRepTo.AllowDrop = true;
            this.dateRepTo.CustomFormat = "yyyy-MM-dd";
            this.dateRepTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateRepTo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateRepTo.Location = new System.Drawing.Point(47, 66);
            this.dateRepTo.MinDate = new System.DateTime(1930, 1, 1, 0, 0, 0, 0);
            this.dateRepTo.Name = "dateRepTo";
            this.dateRepTo.Size = new System.Drawing.Size(93, 20);
            this.dateRepTo.TabIndex = 14;
            this.dateRepTo.Value = new System.DateTime(2018, 1, 7, 14, 53, 37, 0);
            this.dateRepTo.ValueChanged += new System.EventHandler(this.dateRepTo_ValueChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDateFrom);
            this.groupBox1.Controls.Add(this.dateInvFrom);
            this.groupBox1.Controls.Add(this.dateInvTo);
            this.groupBox1.Controls.Add(this.lblDateTo);
            this.groupBox1.Location = new System.Drawing.Point(10, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 96);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoices  Date Range";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(6, 29);
            this.lblDateFrom.Margin = new System.Windows.Forms.Padding(0);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(35, 13);
            this.lblDateFrom.TabIndex = 2;
            this.lblDateFrom.Text = "From";
            // 
            // dateInvFrom
            // 
            this.dateInvFrom.AllowDrop = true;
            this.dateInvFrom.CustomFormat = "yyyy-MM-dd";
            this.dateInvFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateInvFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateInvFrom.Location = new System.Drawing.Point(47, 29);
            this.dateInvFrom.Name = "dateInvFrom";
            this.dateInvFrom.Size = new System.Drawing.Size(94, 20);
            this.dateInvFrom.TabIndex = 0;
            this.dateInvFrom.Value = new System.DateTime(2018, 1, 7, 14, 53, 17, 0);
            this.dateInvFrom.ValueChanged += new System.EventHandler(this.dateInvFrom_ValueChanged);
            // 
            // dateInvTo
            // 
            this.dateInvTo.AllowDrop = true;
            this.dateInvTo.CustomFormat = "yyyy-MM-dd";
            this.dateInvTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateInvTo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateInvTo.Location = new System.Drawing.Point(47, 67);
            this.dateInvTo.MinDate = new System.DateTime(1930, 1, 1, 0, 0, 0, 0);
            this.dateInvTo.Name = "dateInvTo";
            this.dateInvTo.Size = new System.Drawing.Size(96, 20);
            this.dateInvTo.TabIndex = 1;
            this.dateInvTo.Value = new System.DateTime(2018, 1, 7, 14, 53, 37, 0);
            this.dateInvTo.ValueChanged += new System.EventHandler(this.dateInvTo_ValueChanged);
            // 
            // lblDateTo
            // 
            this.lblDateTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(6, 67);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(35, 13);
            this.lblDateTo.TabIndex = 3;
            this.lblDateTo.Text = "To";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(244, 177);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 12;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(330, 220);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DB Connection";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(16, 106);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(51, 13);
            this.lblDbName.TabIndex = 8;
            this.lblDbName.Text = "DB name";
            // 
            // textBD
            // 
            this.textBD.Location = new System.Drawing.Point(84, 99);
            this.textBD.Name = "textBD";
            this.textBD.Size = new System.Drawing.Size(159, 20);
            this.textBD.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(230, 165);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(16, 80);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(53, 13);
            this.lblPass.TabIndex = 5;
            this.lblPass.Text = "Password";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(16, 52);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "User";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(16, 26);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(55, 13);
            this.lblHost.TabIndex = 3;
            this.lblHost.Text = "Hostname";
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(84, 73);
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '*';
            this.textPass.Size = new System.Drawing.Size(159, 20);
            this.textPass.TabIndex = 2;
            this.textPass.UseSystemPasswordChar = true;
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(84, 45);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(159, 20);
            this.textUser.TabIndex = 1;
            // 
            // textHostname
            // 
            this.textHostname.Location = new System.Drawing.Point(84, 19);
            this.textHostname.Name = "textHostname";
            this.textHostname.Size = new System.Drawing.Size(159, 20);
            this.textHostname.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.btnDelete);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.btnDesigner);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(330, 220);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Report Designer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(252, 75);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkedListReport);
            this.groupBox4.Location = new System.Drawing.Point(3, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(241, 194);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Reports templates";
            // 
            // checkedListReport
            // 
            this.checkedListReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListReport.CheckOnClick = true;
            this.checkedListReport.FormattingEnabled = true;
            this.checkedListReport.Location = new System.Drawing.Point(6, 21);
            this.checkedListReport.Name = "checkedListReport";
            this.checkedListReport.Size = new System.Drawing.Size(229, 165);
            this.checkedListReport.TabIndex = 20;
            this.checkedListReport.SelectedIndexChanged += new System.EventHandler(this.checkedListReport_SelectedIndexChanged);
            // 
            // btnDesigner
            // 
            this.btnDesigner.Location = new System.Drawing.Point(252, 17);
            this.btnDesigner.Name = "btnDesigner";
            this.btnDesigner.Size = new System.Drawing.Size(75, 23);
            this.btnDesigner.TabIndex = 24;
            this.btnDesigner.Text = "Edit/Create";
            this.btnDesigner.UseVisualStyleBackColor = true;
            this.btnDesigner.Click += new System.EventHandler(this.btnDesigner_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 225);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(335, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textHostname);
            this.groupBox6.Controls.Add(this.btnSave);
            this.groupBox6.Controls.Add(this.lblDbName);
            this.groupBox6.Controls.Add(this.textUser);
            this.groupBox6.Controls.Add(this.textBD);
            this.groupBox6.Controls.Add(this.lblHost);
            this.groupBox6.Controls.Add(this.lblUser);
            this.groupBox6.Controls.Add(this.lblPass);
            this.groupBox6.Controls.Add(this.textPass);
            this.groupBox6.Location = new System.Drawing.Point(10, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(311, 194);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            // 
            // frmInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 247);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInit";
            this.Text = "Collection Report";
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
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
        private System.Windows.Forms.DateTimePicker dateInvFrom;
        private System.Windows.Forms.DateTimePicker dateInvTo;
        private System.Windows.Forms.TextBox lblDateTo;
        private System.Windows.Forms.TextBox lblDateFrom;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DateTimePicker dateRepTo;
        private System.Windows.Forms.DateTimePicker dateRepFrom;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dateCollectOf;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBoxRepType;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox checkedListReport;
        private System.Windows.Forms.Button btnDesigner;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}

