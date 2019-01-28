namespace ACIWEB_DESKTOP_REPORT
{
    partial class FrmAciwebRep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAciwebRep));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkExport = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.comboBoxRepType = new System.Windows.Forms.ComboBox();
            this.chkRepD = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.chkExport);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 429);
            this.panel1.TabIndex = 3;
            // 
            // chkExport
            // 
            this.chkExport.AutoSize = true;
            this.chkExport.Location = new System.Drawing.Point(12, 66);
            this.chkExport.Name = "chkExport";
            this.chkExport.Size = new System.Drawing.Size(104, 17);
            this.chkExport.TabIndex = 21;
            this.chkExport.Text = "Export to text file";
            this.chkExport.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnQuery);
            this.groupBox3.Controls.Add(this.comboBoxRepType);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(339, 48);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report template";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(233, 16);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 14;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
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
            // chkRepD
            // 
            this.chkRepD.Location = new System.Drawing.Point(0, 0);
            this.chkRepD.Name = "chkRepD";
            this.chkRepD.Size = new System.Drawing.Size(104, 24);
            this.chkRepD.TabIndex = 0;
            this.chkRepD.CheckedChanged += new System.EventHandler(this.chkRepD_CheckedChanged);
            // 
            // FrmAciwebRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 428);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAciwebRep";
          
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkRepD;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ComboBox comboBoxRepType;
        private System.Windows.Forms.CheckBox chkExport;
        private System.Windows.Forms.Button btnQuery;
    }
}

