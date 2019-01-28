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
    public partial class FrmSourceOptions : Form
    {
        public FrmSourceOptions()
        {
            InitializeComponent();
        }

        private void btnAciweb_Click(object sender, EventArgs e)
        {
           
            FrmAciwebRep aciweb = new FrmAciwebRep();
            SourcePanel.Controls.Clear();

            aciweb.TopLevel = false;
            aciweb.AutoScroll = true;
            SourcePanel.Controls.Add(aciweb);
            aciweb.Show();

        }

        private void btnSage_Click(object sender, EventArgs e)
        {
            FrmSageRep sage = new FrmSageRep();
            SourcePanel.Controls.Clear();

            sage.TopLevel = false;
            sage.AutoScroll = true;
            SourcePanel.Controls.Add(sage);
            sage.Show();
        }

        private void btnSapRep_Click(object sender, EventArgs e)
        {
            FrmSapRep sap = new FrmSapRep();
            SourcePanel.Controls.Clear();

            sap.TopLevel = false;
            sap.AutoScroll = true;
            SourcePanel.Controls.Add(sap);
            sap.Show();
        }
    }
}
