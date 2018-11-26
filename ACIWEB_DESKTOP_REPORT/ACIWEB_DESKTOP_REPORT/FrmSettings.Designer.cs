namespace ACIWEB_DESKTOP_REPORT
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.tabSetting = new System.Windows.Forms.TabControl();
            this.tabAciSet = new System.Windows.Forms.TabPage();
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
            this.tabSageDb = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridPre = new System.Windows.Forms.DataGridView();
            this.SageURL = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textDirectorySage = new System.Windows.Forms.TextBox();
            this.btnSageConn = new System.Windows.Forms.Button();
            this.settingsPanel.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.tabAciSet.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabSageDb.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPre)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsPanel
            // 
            this.settingsPanel.Controls.Add(this.tabSetting);
            this.settingsPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(598, 428);
            this.settingsPanel.TabIndex = 0;
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.tabAciSet);
            this.tabSetting.Controls.Add(this.tabSageDb);
            this.tabSetting.Location = new System.Drawing.Point(0, 0);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.SelectedIndex = 0;
            this.tabSetting.Size = new System.Drawing.Size(598, 428);
            this.tabSetting.TabIndex = 0;
            // 
            // tabAciSet
            // 
            this.tabAciSet.Controls.Add(this.groupBox6);
            this.tabAciSet.Controls.Add(this.groupBox2);
            this.tabAciSet.Controls.Add(this.btnSave);
            this.tabAciSet.Location = new System.Drawing.Point(4, 25);
            this.tabAciSet.Name = "tabAciSet";
            this.tabAciSet.Padding = new System.Windows.Forms.Padding(3);
            this.tabAciSet.Size = new System.Drawing.Size(590, 399);
            this.tabAciSet.TabIndex = 0;
            this.tabAciSet.Text = "Aciweb DB";
            this.tabAciSet.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtIdComp);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.comboComp);
            this.groupBox6.Controls.Add(this.txtNameComp);
            this.groupBox6.Controls.Add(this.btnSaveComp);
            this.groupBox6.Location = new System.Drawing.Point(7, 157);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(441, 71);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ID Compañia";
            // 
            // txtIdComp
            // 
            this.txtIdComp.Location = new System.Drawing.Point(132, 45);
            this.txtIdComp.Name = "txtIdComp";
            this.txtIdComp.ReadOnly = true;
            this.txtIdComp.Size = new System.Drawing.Size(32, 21);
            this.txtIdComp.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Current Company";
            // 
            // comboComp
            // 
            this.comboComp.FormattingEnabled = true;
            this.comboComp.Location = new System.Drawing.Point(49, 15);
            this.comboComp.Name = "comboComp";
            this.comboComp.Size = new System.Drawing.Size(237, 24);
            this.comboComp.TabIndex = 10;
            // 
            // txtNameComp
            // 
            this.txtNameComp.Location = new System.Drawing.Point(170, 45);
            this.txtNameComp.Name = "txtNameComp";
            this.txtNameComp.ReadOnly = true;
            this.txtNameComp.Size = new System.Drawing.Size(133, 21);
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
            this.groupBox2.Location = new System.Drawing.Point(6, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 136);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mysql Parameters";
            // 
            // textHostname
            // 
            this.textHostname.Location = new System.Drawing.Point(102, 19);
            this.textHostname.Name = "textHostname";
            this.textHostname.Size = new System.Drawing.Size(159, 21);
            this.textHostname.TabIndex = 0;
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(34, 104);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(57, 16);
            this.lblDbName.TabIndex = 8;
            this.lblDbName.Text = "DB name";
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(102, 45);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(159, 21);
            this.textUser.TabIndex = 1;
            // 
            // textBD
            // 
            this.textBD.Location = new System.Drawing.Point(102, 97);
            this.textBD.Name = "textBD";
            this.textBD.Size = new System.Drawing.Size(159, 21);
            this.textBD.TabIndex = 7;
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(102, 71);
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '*';
            this.textPass.Size = new System.Drawing.Size(159, 21);
            this.textPass.TabIndex = 2;
            this.textPass.UseSystemPasswordChar = true;
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(34, 26);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(63, 16);
            this.lblHost.TabIndex = 3;
            this.lblHost.Text = "Hostname";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(34, 78);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(59, 16);
            this.lblPass.TabIndex = 5;
            this.lblPass.Text = "Password";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(34, 52);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(30, 16);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "User";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(308, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Connect/Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabSageDb
            // 
            this.tabSageDb.Controls.Add(this.groupBox5);
            this.tabSageDb.Location = new System.Drawing.Point(4, 25);
            this.tabSageDb.Name = "tabSageDb";
            this.tabSageDb.Padding = new System.Windows.Forms.Padding(3);
            this.tabSageDb.Size = new System.Drawing.Size(562, 330);
            this.tabSageDb.TabIndex = 1;
            this.tabSageDb.Text = "Sage DB";
            this.tabSageDb.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBox1);
            this.groupBox5.Controls.Add(this.dataGridPre);
            this.groupBox5.Controls.Add(this.SageURL);
            this.groupBox5.Controls.Add(this.btnSearch);
            this.groupBox5.Controls.Add(this.textDirectorySage);
            this.groupBox5.Controls.Add(this.btnSageConn);
            this.groupBox5.Location = new System.Drawing.Point(0, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(559, 324);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Sage Parameters";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(78, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridPre
            // 
            this.dataGridPre.AllowUserToAddRows = false;
            this.dataGridPre.AllowUserToDeleteRows = false;
            this.dataGridPre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPre.Location = new System.Drawing.Point(7, 52);
            this.dataGridPre.Name = "dataGridPre";
            this.dataGridPre.ReadOnly = true;
            this.dataGridPre.Size = new System.Drawing.Size(490, 193);
            this.dataGridPre.TabIndex = 15;
            // 
            // SageURL
            // 
            this.SageURL.AutoSize = true;
            this.SageURL.Location = new System.Drawing.Point(27, 23);
            this.SageURL.Name = "SageURL";
            this.SageURL.Size = new System.Drawing.Size(55, 16);
            this.SageURL.TabIndex = 14;
            this.SageURL.Text = "Directory";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(469, 17);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 25);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textDirectorySage
            // 
            this.textDirectorySage.Location = new System.Drawing.Point(97, 19);
            this.textDirectorySage.Name = "textDirectorySage";
            this.textDirectorySage.Size = new System.Drawing.Size(373, 21);
            this.textDirectorySage.TabIndex = 12;
            // 
            // btnSageConn
            // 
            this.btnSageConn.Location = new System.Drawing.Point(394, 259);
            this.btnSageConn.Name = "btnSageConn";
            this.btnSageConn.Size = new System.Drawing.Size(92, 23);
            this.btnSageConn.TabIndex = 6;
            this.btnSageConn.Text = "Test/Save";
            this.btnSageConn.UseVisualStyleBackColor = true;
            this.btnSageConn.Click += new System.EventHandler(this.btnSageConn_Click);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 428);
            this.Controls.Add(this.settingsPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmSettings";
            this.Text = "FrmSettings";
            this.settingsPanel.ResumeLayout(false);
            this.tabSetting.ResumeLayout(false);
            this.tabAciSet.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabSageDb.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.TabControl tabSetting;
        private System.Windows.Forms.TabPage tabAciSet;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtIdComp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboComp;
        private System.Windows.Forms.TextBox txtNameComp;
        private System.Windows.Forms.Button btnSaveComp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textHostname;
        private System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.TextBox textBD;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabSageDb;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridPre;
        private System.Windows.Forms.Label SageURL;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox textDirectorySage;
        private System.Windows.Forms.Button btnSageConn;
    }
}