namespace PickingList
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
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxRepType = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.comboBoxTo = new System.Windows.Forms.ComboBox();
            this.comboBoxFrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRefTo = new System.Windows.Forms.TextBox();
            this.lblRefFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.TextBox();
            this.lblDateFrom = new System.Windows.Forms.TextBox();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
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
            this.dbQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbQueryBindingSource)).BeginInit();
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
            this.tabPrincipal.Size = new System.Drawing.Size(402, 246);
            this.tabPrincipal.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.comboBoxRepType);
            this.tabPage1.Controls.Add(this.btnQuery);
            this.tabPage1.Controls.Add(this.comboBoxTo);
            this.tabPage1.Controls.Add(this.comboBoxFrom);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lblRefTo);
            this.tabPage1.Controls.Add(this.lblRefFrom);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblDateTo);
            this.tabPage1.Controls.Add(this.lblDateFrom);
            this.tabPage1.Controls.Add(this.dateTimeTo);
            this.tabPage1.Controls.Add(this.dateTimeFrom);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(394, 220);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Report Filter";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Report Type";
            // 
            // comboBoxRepType
            // 
            this.comboBoxRepType.FormattingEnabled = true;
            this.comboBoxRepType.Items.AddRange(new object[] {
            "Delivery",
            "Sales"});
            this.comboBoxRepType.Location = new System.Drawing.Point(51, 184);
            this.comboBoxRepType.Name = "comboBoxRepType";
            this.comboBoxRepType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRepType.TabIndex = 13;
            this.comboBoxRepType.SelectedIndexChanged += new System.EventHandler(this.comboBoxRepType_SelectedIndexChanged_1);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(276, 184);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 12;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // comboBoxTo
            // 
            this.comboBoxTo.FormattingEnabled = true;
            this.comboBoxTo.Location = new System.Drawing.Point(230, 120);
            this.comboBoxTo.Name = "comboBoxTo";
            this.comboBoxTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBoxTo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTo.TabIndex = 11;
            // 
            // comboBoxFrom
            // 
            this.comboBoxFrom.FormattingEnabled = true;
            this.comboBoxFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxFrom.Location = new System.Drawing.Point(51, 121);
            this.comboBoxFrom.Name = "comboBoxFrom";
            this.comboBoxFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBoxFrom.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFrom.TabIndex = 10;
            this.comboBoxFrom.SelectedIndexChanged += new System.EventHandler(this.comboBoxFrom_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Invoice #";
            // 
            // lblRefTo
            // 
            this.lblRefTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefTo.Location = new System.Drawing.Point(189, 121);
            this.lblRefTo.Name = "lblRefTo";
            this.lblRefTo.Size = new System.Drawing.Size(35, 20);
            this.lblRefTo.TabIndex = 6;
            this.lblRefTo.Text = "To";
            // 
            // lblRefFrom
            // 
            this.lblRefFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefFrom.Location = new System.Drawing.Point(10, 121);
            this.lblRefFrom.Name = "lblRefFrom";
            this.lblRefFrom.Size = new System.Drawing.Size(35, 20);
            this.lblRefFrom.TabIndex = 5;
            this.lblRefFrom.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Invoice Date Range";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblDateTo
            // 
            this.lblDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(189, 48);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(35, 20);
            this.lblDateTo.TabIndex = 3;
            this.lblDateTo.Text = "To";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(10, 48);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(35, 20);
            this.lblDateFrom.TabIndex = 2;
            this.lblDateFrom.Text = "From";
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.AllowDrop = true;
            this.dateTimeTo.CustomFormat = "yyyy-MM-dd";
            this.dateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeTo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimeTo.Location = new System.Drawing.Point(246, 48);
            this.dateTimeTo.MinDate = new System.DateTime(1930, 1, 1, 0, 0, 0, 0);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(93, 20);
            this.dateTimeTo.TabIndex = 1;
            this.dateTimeTo.Value = new System.DateTime(2018, 1, 7, 14, 53, 37, 0);
            this.dateTimeTo.ValueChanged += new System.EventHandler(this.dateTimeTo_ValueChanged);
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.AllowDrop = true;
            this.dateTimeFrom.CustomFormat = "yyyy-MM-dd";
            this.dateTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimeFrom.Location = new System.Drawing.Point(73, 48);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(94, 20);
            this.dateTimeFrom.TabIndex = 0;
            this.dateTimeFrom.Value = new System.DateTime(2018, 1, 7, 14, 53, 17, 0);
            this.dateTimeFrom.ValueChanged += new System.EventHandler(this.dateTimeFrom_ValueChanged);
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
            this.tabPage2.Size = new System.Drawing.Size(394, 220);
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
            this.btnSave.Location = new System.Drawing.Point(312, 133);
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
            // dbQueryBindingSource
            // 
            this.dbQueryBindingSource.DataSource = typeof(PickingList.DbQuery);
            // 
            // FrmInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 247);
            this.Controls.Add(this.tabPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInit";
            this.Text = "Picking List";
            this.Load += new System.EventHandler(this.FrmInit_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbQueryBindingSource)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TextBox lblRefTo;
        private System.Windows.Forms.TextBox lblRefFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTo;
        private System.Windows.Forms.ComboBox comboBoxFrom;
        private System.Windows.Forms.Button btnQuery;

        private System.Windows.Forms.BindingSource dbQueryBindingSource;
        private System.Windows.Forms.ComboBox comboBoxRepType;
        private System.Windows.Forms.Label label3;

       

    }
}

