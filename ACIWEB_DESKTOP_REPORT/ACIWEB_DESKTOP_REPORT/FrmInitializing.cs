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
    public partial class FrmInitializing : Form
    {
        public FrmInitializing()
        {
            InitializeComponent();
        }

        private void Initialazing_Load(object sender, EventArgs e)
        {

        }

   /*     private void label1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to cancel ?",
                                     "Confirm cancel",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                FrmHome home = new FrmHome();
                home.Close();

                this.Close();
            }
            else
            {
                // If 'No', do something here.
            }
           
        }*/



    }
}
