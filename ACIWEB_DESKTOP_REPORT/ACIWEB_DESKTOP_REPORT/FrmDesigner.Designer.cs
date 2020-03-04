namespace ACIWEB_DESKTOP_REPORT
{
    partial class FrmDesigner
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkedListReport = new System.Windows.Forms.CheckedListBox();
            this.btnDesigner = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btoEditSage = new System.Windows.Forms.Button();
            this.btnRefreshSage = new System.Windows.Forms.Button();
            this.btnDelSage = new System.Windows.Forms.Button();
            this.gpoTempSage = new System.Windows.Forms.GroupBox();
            this.checkedListReportSage = new System.Windows.Forms.CheckedListBox();
            this.btnNewSage = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.comboBoxRepType = new System.Windows.Forms.ComboBox();
            this.btnFSDEdit = new System.Windows.Forms.Button();
            this.btnFSDRefresh = new System.Windows.Forms.Button();
            this.btnFSDDel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkedListReportFS = new System.Windows.Forms.CheckedListBox();
            this.btnFSDNew = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gpoTempSage.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(598, 428);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.change_tab);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnEdit);
            this.tabPage1.Controls.Add(this.btnRefresh);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.btnDesigner);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(590, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Aciweb Templates";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(366, 47);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 28;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(366, 105);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 27;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(366, 76);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkedListReport);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(354, 274);
            this.groupBox5.TabIndex = 25;
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
            this.checkedListReport.Size = new System.Drawing.Size(342, 240);
            this.checkedListReport.TabIndex = 20;
            this.checkedListReport.SelectedIndexChanged += new System.EventHandler(this.checkedListReport_SelectedIndexChanged_1);
            // 
            // btnDesigner
            // 
            this.btnDesigner.Location = new System.Drawing.Point(366, 18);
            this.btnDesigner.Name = "btnDesigner";
            this.btnDesigner.Size = new System.Drawing.Size(75, 23);
            this.btnDesigner.TabIndex = 24;
            this.btnDesigner.Text = "New ";
            this.btnDesigner.UseVisualStyleBackColor = true;
            this.btnDesigner.Click += new System.EventHandler(this.btnDesigner_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btoEditSage);
            this.tabPage2.Controls.Add(this.btnRefreshSage);
            this.tabPage2.Controls.Add(this.btnDelSage);
            this.tabPage2.Controls.Add(this.gpoTempSage);
            this.tabPage2.Controls.Add(this.btnNewSage);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(590, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sage Tamplates";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btoEditSage
            // 
            this.btoEditSage.Location = new System.Drawing.Point(369, 47);
            this.btoEditSage.Name = "btoEditSage";
            this.btoEditSage.Size = new System.Drawing.Size(75, 23);
            this.btoEditSage.TabIndex = 33;
            this.btoEditSage.Text = "Edit";
            this.btoEditSage.UseVisualStyleBackColor = true;
            this.btoEditSage.Click += new System.EventHandler(this.btoEditSage_Click);
            // 
            // btnRefreshSage
            // 
            this.btnRefreshSage.Location = new System.Drawing.Point(369, 105);
            this.btnRefreshSage.Name = "btnRefreshSage";
            this.btnRefreshSage.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshSage.TabIndex = 32;
            this.btnRefreshSage.Text = "Refresh";
            this.btnRefreshSage.UseVisualStyleBackColor = true;
            this.btnRefreshSage.Click += new System.EventHandler(this.btnRefreshSage_Click);
            // 
            // btnDelSage
            // 
            this.btnDelSage.Location = new System.Drawing.Point(369, 76);
            this.btnDelSage.Name = "btnDelSage";
            this.btnDelSage.Size = new System.Drawing.Size(75, 23);
            this.btnDelSage.TabIndex = 31;
            this.btnDelSage.Text = "Delete";
            this.btnDelSage.UseVisualStyleBackColor = true;
            this.btnDelSage.Click += new System.EventHandler(this.btnDelSage_Click);
            // 
            // gpoTempSage
            // 
            this.gpoTempSage.Controls.Add(this.checkedListReportSage);
            this.gpoTempSage.Location = new System.Drawing.Point(9, 6);
            this.gpoTempSage.Name = "gpoTempSage";
            this.gpoTempSage.Size = new System.Drawing.Size(354, 274);
            this.gpoTempSage.TabIndex = 30;
            this.gpoTempSage.TabStop = false;
            this.gpoTempSage.Text = "Reports templates";
            // 
            // checkedListReportSage
            // 
            this.checkedListReportSage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListReportSage.CheckOnClick = true;
            this.checkedListReportSage.FormattingEnabled = true;
            this.checkedListReportSage.Location = new System.Drawing.Point(6, 21);
            this.checkedListReportSage.Name = "checkedListReportSage";
            this.checkedListReportSage.Size = new System.Drawing.Size(342, 240);
            this.checkedListReportSage.TabIndex = 20;
            this.checkedListReportSage.SelectedIndexChanged += new System.EventHandler(this.checkedListReportSage_SelectedIndexChanged);
            // 
            // btnNewSage
            // 
            this.btnNewSage.Location = new System.Drawing.Point(369, 18);
            this.btnNewSage.Name = "btnNewSage";
            this.btnNewSage.Size = new System.Drawing.Size(75, 23);
            this.btnNewSage.TabIndex = 29;
            this.btnNewSage.Text = "New ";
            this.btnNewSage.UseVisualStyleBackColor = true;
            this.btnNewSage.Click += new System.EventHandler(this.btnNewSage_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.comboBoxRepType);
            this.tabPage4.Controls.Add(this.btnFSDEdit);
            this.tabPage4.Controls.Add(this.btnFSDRefresh);
            this.tabPage4.Controls.Add(this.btnFSDDel);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.btnFSDNew);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(590, 402);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "File Source Templates";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // comboBoxRepType
            // 
            this.comboBoxRepType.FormattingEnabled = true;
            this.comboBoxRepType.Location = new System.Drawing.Point(6, 26);
            this.comboBoxRepType.Name = "comboBoxRepType";
            this.comboBoxRepType.Size = new System.Drawing.Size(162, 21);
            this.comboBoxRepType.TabIndex = 44;
            this.comboBoxRepType.SelectedIndexChanged += new System.EventHandler(this.comboBoxRepType_SelectedIndexChanged);
            // 
            // btnFSDEdit
            // 
            this.btnFSDEdit.Location = new System.Drawing.Point(365, 62);
            this.btnFSDEdit.Name = "btnFSDEdit";
            this.btnFSDEdit.Size = new System.Drawing.Size(75, 23);
            this.btnFSDEdit.TabIndex = 43;
            this.btnFSDEdit.Text = "Edit";
            this.btnFSDEdit.UseVisualStyleBackColor = true;
            this.btnFSDEdit.Click += new System.EventHandler(this.btnFSDEdit_Click);
            // 
            // btnFSDRefresh
            // 
            this.btnFSDRefresh.Location = new System.Drawing.Point(365, 120);
            this.btnFSDRefresh.Name = "btnFSDRefresh";
            this.btnFSDRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnFSDRefresh.TabIndex = 42;
            this.btnFSDRefresh.Text = "Refresh";
            this.btnFSDRefresh.UseVisualStyleBackColor = true;
            this.btnFSDRefresh.Click += new System.EventHandler(this.btnFSDRefresh_Click);
            // 
            // btnFSDDel
            // 
            this.btnFSDDel.Location = new System.Drawing.Point(365, 91);
            this.btnFSDDel.Name = "btnFSDDel";
            this.btnFSDDel.Size = new System.Drawing.Size(75, 23);
            this.btnFSDDel.TabIndex = 41;
            this.btnFSDDel.Text = "Delete";
            this.btnFSDDel.UseVisualStyleBackColor = true;
            this.btnFSDDel.Click += new System.EventHandler(this.btnFSDDel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkedListReportFS);
            this.groupBox2.Location = new System.Drawing.Point(5, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 274);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reports templates";
            // 
            // checkedListReportFS
            // 
            this.checkedListReportFS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListReportFS.CheckOnClick = true;
            this.checkedListReportFS.FormattingEnabled = true;
            this.checkedListReportFS.Location = new System.Drawing.Point(6, 21);
            this.checkedListReportFS.Name = "checkedListReportFS";
            this.checkedListReportFS.Size = new System.Drawing.Size(342, 240);
            this.checkedListReportFS.TabIndex = 20;
            this.checkedListReportFS.SelectedIndexChanged += new System.EventHandler(this.checkedListReportFS_SelectedIndexChanged);
            // 
            // btnFSDNew
            // 
            this.btnFSDNew.Location = new System.Drawing.Point(172, 25);
            this.btnFSDNew.Name = "btnFSDNew";
            this.btnFSDNew.Size = new System.Drawing.Size(75, 23);
            this.btnFSDNew.TabIndex = 39;
            this.btnFSDNew.Text = "New ";
            this.btnFSDNew.UseVisualStyleBackColor = true;
            this.btnFSDNew.Click += new System.EventHandler(this.btnFSDNew_Click);
            // 
            // FrmDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 428);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDesigner";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.gpoTempSage.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox checkedListReport;
        private System.Windows.Forms.Button btnDesigner;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btoEditSage;
        private System.Windows.Forms.Button btnRefreshSage;
        private System.Windows.Forms.Button btnDelSage;
        private System.Windows.Forms.GroupBox gpoTempSage;
        private System.Windows.Forms.CheckedListBox checkedListReportSage;
        private System.Windows.Forms.Button btnNewSage;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnFSDEdit;
        private System.Windows.Forms.Button btnFSDRefresh;
        private System.Windows.Forms.Button btnFSDDel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox checkedListReportFS;
        private System.Windows.Forms.Button btnFSDNew;
        public System.Windows.Forms.ComboBox comboBoxRepType;
    }
}