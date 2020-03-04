using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AciSapLibrary
{
    public partial class FrmSapRep : Form
    {
        public FrmSapRep()
        {
            InitializeComponent();
        }

        public static int Type;

        DbQuerySap dbquery = new DbQuerySap();

        private void InitValue()
        {
            try
            {

                comboBoxRepType.Items.Clear();

                string[] files = Directory.GetFiles(@"C:\\ACIDesktopReport\ReportDesigner\SAP\", "*.repx");

                string filename;

                for (int i = 0; i < files.Length; i++)
                {

                    filename = Path.GetFileNameWithoutExtension(files[i]);
                    comboBoxRepType.Items.Add(filename);


                }
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }

        }

        private void PrintReport()
        {
            SAPParam saparam = new SAPParam();

            try
            {

                if (this.chkExport.Checked == true)
                {

                    FrmRepViwerSap.export = true;

                    saparam.GetSapExportFolder();
                    FrmRepViwerSap.expFolder = saparam.LocalFolder;
                    FrmRepViwerSap.sftpFolder = saparam.RemoteFolder;
                }
                else
                {
                    FrmRepViwerSap.export = false;
                }

                var bapiName = saparam.GetBapiTemp(comboBoxRepType.SelectedItem.ToString());

                if (this.chkOnlyDS.Checked == true)
                {
                    FrmRepViwerSap.OnlyDs = true;
                }

                FrmRepViwerSap.repType = "sap";
                FrmRepViwerSap.bapiName = bapiName;
                FrmRepViwerSap repViewer = new FrmRepViwerSap();


            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }

        }


        private void btnSapQuery_Click(object sender, EventArgs e)
        {


            if (comboBoxRepType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a template");
            }
            else
            {


                PrintReport();

            }
        }

        private void comboBoxRepType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string template = comboBoxRepType.SelectedItem.ToString();
            FrmRepViwerSap.docview = template;
        }

        private void chkExport_CheckedChanged(object sender, EventArgs e)
        {
            chkOnlyDS.Checked = false;
        }

        private void chkOnlyDS_CheckedChanged(object sender, EventArgs e)
        {
            chkExport.Checked = false;
        }

    }
}
