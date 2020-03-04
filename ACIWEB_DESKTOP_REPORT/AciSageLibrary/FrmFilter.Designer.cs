namespace AciSageLibrary
{
    partial class FrmFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFilter));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectOptionsPanel2 = new System.Windows.Forms.Panel();
            this.selectOptionsPanel = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.selectOptionsPanel2);
            this.groupBox1.Controls.Add(this.selectOptionsPanel);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("SAPGUI-Belize-Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 227);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // selectOptionsPanel2
            // 
            this.selectOptionsPanel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.selectOptionsPanel2.Location = new System.Drawing.Point(126, 16);
            this.selectOptionsPanel2.Name = "selectOptionsPanel2";
            this.selectOptionsPanel2.Size = new System.Drawing.Size(132, 30);
            this.selectOptionsPanel2.TabIndex = 5;
            // 
            // selectOptionsPanel
            // 
            this.selectOptionsPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.selectOptionsPanel.Location = new System.Drawing.Point(7, 16);
            this.selectOptionsPanel.Name = "selectOptionsPanel";
            this.selectOptionsPanel.Size = new System.Drawing.Size(121, 30);
            this.selectOptionsPanel.TabIndex = 4;
            // 
            // FrmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 218);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SAPGUI-Belize-Icons", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmFilter";
            this.Text = "Seleccion Option";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.closeTask);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Panel selectOptionsPanel2;
        public System.Windows.Forms.Panel selectOptionsPanel;
    }
}