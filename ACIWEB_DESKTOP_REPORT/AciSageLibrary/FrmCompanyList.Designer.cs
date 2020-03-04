namespace AciSageLibrary
{
    partial class FrmCompanyList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompanyList));
            this.gridCompanylist = new System.Windows.Forms.DataGridView();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnUnsel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompanylist)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCompanylist
            // 
            this.gridCompanylist.AllowUserToAddRows = false;
            this.gridCompanylist.AllowUserToDeleteRows = false;
            this.gridCompanylist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCompanylist.Location = new System.Drawing.Point(1, 0);
            this.gridCompanylist.Name = "gridCompanylist";
            this.gridCompanylist.ReadOnly = true;
            this.gridCompanylist.Size = new System.Drawing.Size(531, 208);
            this.gridCompanylist.TabIndex = 0;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(3, 212);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 1;
            this.btnAll.Text = "Select All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(454, 212);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnUnsel
            // 
            this.btnUnsel.Location = new System.Drawing.Point(80, 212);
            this.btnUnsel.Name = "btnUnsel";
            this.btnUnsel.Size = new System.Drawing.Size(75, 23);
            this.btnUnsel.TabIndex = 3;
            this.btnUnsel.Text = "Unselect All";
            this.btnUnsel.UseVisualStyleBackColor = true;
            this.btnUnsel.Click += new System.EventHandler(this.btnUnsel_Click);
            // 
            // FrmCompanyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 237);
            this.Controls.Add(this.btnUnsel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.gridCompanylist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCompanyList";
            this.Text = "Company List";
            ((System.ComponentModel.ISupportInitialize)(this.gridCompanylist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCompanylist;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnUnsel;
    }
}