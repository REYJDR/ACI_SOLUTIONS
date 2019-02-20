namespace ACIWEB_DESKTOP_REPORT
{
    partial class FrmSourceOptions
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
            this.SourcePanel = new System.Windows.Forms.Panel();
            this.btnFileSource = new System.Windows.Forms.Button();
            this.btnSapRep = new System.Windows.Forms.Button();
            this.btnAciweb = new System.Windows.Forms.Button();
            this.btnSage = new System.Windows.Forms.Button();
            this.SourcePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourcePanel
            // 
            this.SourcePanel.Controls.Add(this.btnFileSource);
            this.SourcePanel.Controls.Add(this.btnSapRep);
            this.SourcePanel.Controls.Add(this.btnAciweb);
            this.SourcePanel.Controls.Add(this.btnSage);
            this.SourcePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SourcePanel.Location = new System.Drawing.Point(0, 0);
            this.SourcePanel.Name = "SourcePanel";
            this.SourcePanel.Size = new System.Drawing.Size(549, 435);
            this.SourcePanel.TabIndex = 2;
            // 
            // btnFileSource
            // 
            this.btnFileSource.BackColor = System.Drawing.Color.White;
            this.btnFileSource.FlatAppearance.BorderSize = 0;
            this.btnFileSource.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFileSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileSource.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileSource.ForeColor = System.Drawing.Color.Black;
            this.btnFileSource.Image = global::ACIWEB_DESKTOP_REPORT.Properties.Resources.FILESOURCE;
            this.btnFileSource.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFileSource.Location = new System.Drawing.Point(7, 106);
            this.btnFileSource.Name = "btnFileSource";
            this.btnFileSource.Size = new System.Drawing.Size(162, 91);
            this.btnFileSource.TabIndex = 3;
            this.btnFileSource.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFileSource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFileSource.UseVisualStyleBackColor = false;
            this.btnFileSource.Click += new System.EventHandler(this.btnFileSource_Click);
            // 
            // btnSapRep
            // 
            this.btnSapRep.BackColor = System.Drawing.Color.White;
            this.btnSapRep.FlatAppearance.BorderSize = 0;
            this.btnSapRep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSapRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSapRep.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSapRep.ForeColor = System.Drawing.Color.Black;
            this.btnSapRep.Image = global::ACIWEB_DESKTOP_REPORT.Properties.Resources.sap_logo1;
            this.btnSapRep.Location = new System.Drawing.Point(343, 9);
            this.btnSapRep.Name = "btnSapRep";
            this.btnSapRep.Size = new System.Drawing.Size(162, 91);
            this.btnSapRep.TabIndex = 2;
            this.btnSapRep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSapRep.UseVisualStyleBackColor = false;
            this.btnSapRep.Click += new System.EventHandler(this.btnSapRep_Click);
            // 
            // btnAciweb
            // 
            this.btnAciweb.BackColor = System.Drawing.Color.White;
            this.btnAciweb.FlatAppearance.BorderSize = 0;
            this.btnAciweb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAciweb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAciweb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAciweb.ForeColor = System.Drawing.Color.Black;
            this.btnAciweb.Image = global::ACIWEB_DESKTOP_REPORT.Properties.Resources.AciWeb1;
            this.btnAciweb.Location = new System.Drawing.Point(7, 9);
            this.btnAciweb.Name = "btnAciweb";
            this.btnAciweb.Size = new System.Drawing.Size(162, 91);
            this.btnAciweb.TabIndex = 0;
            this.btnAciweb.Text = "Aciweb";
            this.btnAciweb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAciweb.UseVisualStyleBackColor = false;
            this.btnAciweb.Click += new System.EventHandler(this.btnAciweb_Click);
            // 
            // btnSage
            // 
            this.btnSage.BackColor = System.Drawing.Color.White;
            this.btnSage.FlatAppearance.BorderSize = 0;
            this.btnSage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSage.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSage.ForeColor = System.Drawing.Color.Black;
            this.btnSage.Image = global::ACIWEB_DESKTOP_REPORT.Properties.Resources.sage_50_3;
            this.btnSage.Location = new System.Drawing.Point(175, 9);
            this.btnSage.Name = "btnSage";
            this.btnSage.Size = new System.Drawing.Size(162, 91);
            this.btnSage.TabIndex = 1;
            this.btnSage.Text = "Peachtree";
            this.btnSage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSage.UseVisualStyleBackColor = false;
            this.btnSage.Click += new System.EventHandler(this.btnSage_Click);
            // 
            // FrmSourceOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 435);
            this.Controls.Add(this.SourcePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSourceOptions";
            this.Text = "FrmRerportList";
            this.SourcePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAciweb;
        private System.Windows.Forms.Button btnSage;
        private System.Windows.Forms.Panel SourcePanel;
        private System.Windows.Forms.Button btnSapRep;
        private System.Windows.Forms.Button btnFileSource;
    }
}