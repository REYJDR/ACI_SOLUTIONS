using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ACIWEB_DESKTOP_REPORT
{
    public partial class FrmHome : Form
    {

        int TogMove;
        int MValX;
        int MValY;

        FrmSettings setting = new FrmSettings();
        FrmInitializing initialFrm = new FrmInitializing();


        public FrmHome()
        {

            initialFrm.Show();

            InitializeComponent();


            this.mainPanel.Controls.Clear();

            //parametros de configuracion
            setting.InitFieldVal();
            setting.SetCompany();


            FrmSourceOptions options = new FrmSourceOptions();
            options.TopLevel = false;
            options.AutoScroll = true;
            options.AutoSize = true;

            initialFrm.Hide();
            this.mainPanel.Controls.Add(options);
            options.Show();

        
        }


        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
           this.WindowState = FormWindowState.Minimized;

        }

        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

            this.mainPanel.Controls.Clear();

            FrmSourceOptions options = new FrmSourceOptions();
            options.TopLevel = false;
            options.AutoScroll = true;
            options.AutoSize = true;

            this.mainPanel.Controls.Add(options);
            options.Show();



        }

        private void btnDesigner_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Clear();

            FrmDesigner designer = new FrmDesigner();
            designer.TopLevel = false;
            designer.AutoScroll = true;
            designer.AutoSize = true;
            this.mainPanel.Controls.Add(designer);

            designer.Show();

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor; // change cursor to hourglass type

            this.mainPanel.Controls.Clear();


            setting.TopLevel = false;
            setting.AutoScroll = true;
            setting.AutoSize = true;
            this.mainPanel.Controls.Add(setting);
            setting.Show();

            Cursor = Cursors.Arrow; // change cursor to hourglass type

        }

        private void lblVer_Click(object sender, EventArgs e)
        {

        }
    }
}
