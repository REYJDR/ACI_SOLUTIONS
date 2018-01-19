namespace CollectionISP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInit));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dateRepTo = new System.Windows.Forms.DateTimePicker();
            this.dateRepFrom = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.lblDateTo = new System.Windows.Forms.TextBox();
            this.lblDateFrom = new System.Windows.Forms.TextBox();
            this.dateInvTo = new System.Windows.Forms.DateTimePicker();
            this.dateInvFrom = new System.Windows.Forms.DateTimePicker();
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateCollectOf = new System.Windows.Forms.DateTimePicker();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.tabPrincipal.Location = new System.Drawing.Point(-2, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(338, 246);
            this.tabPrincipal.TabIndex = 1;
            // 
            // tabPage1
            // 
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
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "To";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(6, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(35, 20);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = "From";
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
            // lblDateTo
            // 
            this.lblDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(6, 67);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(35, 20);
            this.lblDateTo.TabIndex = 3;
            this.lblDateTo.Text = "To";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(6, 29);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(35, 20);
            this.lblDateFrom.TabIndex = 2;
            this.lblDateFrom.Text = "From";
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblDbName);
            this.tabPage2.Controls.Add(this.textBD);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.lblPass);
            this.tabPage2.Controls.Add(this.lblUser);
            this.tabPage2.Controls.Add(this.lblHost);
            this.tabPage2.Controls.Add(this.textPass);
            this.tabPage2.Controls.Add(this.textUser);
            this.tabPage2.Controls.Add(this.textHostname);
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
            this.lblDbName.Location = new System.Drawing.Point(20, 109);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(51, 13);
            this.lblDbName.TabIndex = 8;
            this.lblDbName.Text = "DB name";
            // 
            // textBD
            // 
            this.textBD.Location = new System.Drawing.Point(88, 102);
            this.textBD.Name = "textBD";
            this.textBD.Size = new System.Drawing.Size(159, 20);
            this.textBD.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(249, 177);
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
            this.lblPass.Location = new System.Drawing.Point(20, 83);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(53, 13);
            this.lblPass.TabIndex = 5;
            this.lblPass.Text = "Password";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(20, 57);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "User";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(20, 31);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(55, 13);
            this.lblHost.TabIndex = 3;
            this.lblHost.Text = "Hostname";
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(88, 76);
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '*';
            this.textPass.Size = new System.Drawing.Size(159, 20);
            this.textPass.TabIndex = 2;
            this.textPass.UseSystemPasswordChar = true;
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(88, 50);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(159, 20);
            this.textUser.TabIndex = 1;
            // 
            // textHostname
            // 
            this.textHostname.Location = new System.Drawing.Point(88, 24);
            this.textHostname.Name = "textHostname";
            this.textHostname.Size = new System.Drawing.Size(159, 20);
            this.textHostname.TabIndex = 0;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Collection of";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateCollectOf);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(10, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 62);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            // 
            // dateCollectOf
            // 
            this.dateCollectOf.AllowDrop = true;
            this.dateCollectOf.CustomFormat = "yyyy-MM-dd";
            this.dateCollectOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCollectOf.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateCollectOf.Location = new System.Drawing.Point(9, 35);
            this.dateCollectOf.MinDate = new System.DateTime(1930, 1, 1, 0, 0, 0, 0);
            this.dateCollectOf.Name = "dateCollectOf";
            this.dateCollectOf.Size = new System.Drawing.Size(93, 20);
            this.dateCollectOf.TabIndex = 17;
            this.dateCollectOf.Value = new System.DateTime(2018, 1, 7, 14, 53, 37, 0);
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
            this.Load += new System.EventHandler(this.FrmInit_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.Label label1;
    }
}

