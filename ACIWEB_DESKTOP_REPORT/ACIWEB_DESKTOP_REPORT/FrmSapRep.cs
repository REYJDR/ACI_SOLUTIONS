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
   

namespace ACIWEB_DESKTOP_REPORT
{
    public partial class FrmSapRep : Form
    {
        public FrmSapRep()
        {
            InitializeComponent();
            InitValue();
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
            try
            {
               
                if (this.chkExport.Checked == true)
                {
                    SAPParam folder = new SAPParam();
                    FrmRepViwer.export = true;

                    folder.GetSapExportFolder();
                    FrmRepViwer.expFolder = folder.LocalFolder;
                    FrmRepViwer.sftpFolder = folder.RemoteFolder;
                }

                FrmRepViwer.repType = "sap";
                FrmRepViwer repViewer = new FrmRepViwer();


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

        public void setMsgtext(string text)
        {
            FrmHome home = new FrmHome();
            home.StatusLabel.Text = text;
            home.statusStrip1.Refresh();

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
            FrmRepViwer.docview = template;
        }
    }
}
