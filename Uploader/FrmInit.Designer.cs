namespace UPLOADER
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.textPass = new System.Windows.Forms.TextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.textHostname = new System.Windows.Forms.TextBox();
            this.textBD = new System.Windows.Forms.TextBox();
            this.lblDbName = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textFilename = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.textHoja = new System.Windows.Forms.TextBox();
            this.lblSheet = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.tabPrincipal.Size = new System.Drawing.Size(402, 190);
            this.tabPrincipal.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblFile);
            this.tabPage1.Controls.Add(this.lblSheet);
            this.tabPage1.Controls.Add(this.textHoja);
            this.tabPage1.Controls.Add(this.btnUpload);
            this.tabPage1.Controls.Add(this.textFilename);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(394, 164);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cargar Archivo";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.tabPage2.Size = new System.Drawing.Size(394, 164);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Conexión BD";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(312, 133);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(20, 83);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(61, 13);
            this.lblPass.TabIndex = 5;
            this.lblPass.Text = "Contraseña";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(20, 57);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(43, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "Usuario";
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
            // textBD
            // 
            this.textBD.Location = new System.Drawing.Point(88, 102);
            this.textBD.Name = "textBD";
            this.textBD.Size = new System.Drawing.Size(159, 20);
            this.textBD.TabIndex = 7;
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(20, 109);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(51, 13);
            this.lblDbName.TabIndex = 8;
            this.lblDbName.Text = "BD name";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(312, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Examinar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textFilename
            // 
            this.textFilename.Enabled = false;
            this.textFilename.Location = new System.Drawing.Point(53, 37);
            this.textFilename.Name = "textFilename";
            this.textFilename.Size = new System.Drawing.Size(253, 20);
            this.textFilename.TabIndex = 1;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(312, 133);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Abrir";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // textHoja
            // 
            this.textHoja.Location = new System.Drawing.Point(53, 73);
            this.textHoja.Name = "textHoja";
            this.textHoja.Size = new System.Drawing.Size(221, 20);
            this.textHoja.TabIndex = 3;
            // 
            // lblSheet
            // 
            this.lblSheet.AutoSize = true;
            this.lblSheet.Location = new System.Drawing.Point(18, 80);
            this.lblSheet.Name = "lblSheet";
            this.lblSheet.Size = new System.Drawing.Size(29, 13);
            this.lblSheet.TabIndex = 4;
            this.lblSheet.Text = "Hoja";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(4, 44);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(43, 13);
            this.lblFile.TabIndex = 5;
            this.lblFile.Text = "Archivo";
            // 
            // FrmInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 190);
            this.Controls.Add(this.tabPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInit";
            this.Text = "UPLOADER ";
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.TextBox textFilename;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblSheet;
        private System.Windows.Forms.TextBox textHoja;
    }
}

