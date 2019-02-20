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
using Microsoft.VisualBasic.FileIO;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;


namespace ACIWEB_DESKTOP_REPORT
{
    public partial class FrmAciwebRep : Form
    {
        public static string dateRange;
        public static string dateFrom;
        public static string dateTo;
        public static string invRange;
        public static int Type;

        

        DbQueryAciweb dbquery = new DbQueryAciweb();

        OpenFileDialog of = new OpenFileDialog();

        bool Loaded;


        public FrmAciwebRep()
        {
            InitializeComponent();
            InitValue();  
 
        }
        

        private void InitValue()
        {

            
            comboBoxRepType.Items.Clear();

            string[] files = Directory.GetFiles(@"C:\\ACIDesktopReport\ReportDesigner\ACIWEB\", "*.repx");

            string filename;

            for (int i = 0; i < files.Length; i++)
            {

                filename = Path.GetFileNameWithoutExtension(files[i]);
                comboBoxRepType.Items.Add(filename);


            }

        }
        
        public void setMsgtext(string text)
        {
            FrmHome home = new FrmHome();
            home.StatusLabel.Text = text;
            home.statusStrip1.Refresh();

        }
        
        private void PrintReport()
        {
            try
            {
               // Cursor = Cursors.WaitCursor; // change cursor to hourglass type

                if (this.chkExport.Checked == true)
                {
                    DbParamAciweb folder = new DbParamAciweb();
                    FrmRepViwer.export = true;

                    folder.GetAciExportFolder();
                    FrmRepViwer.expFolder = folder.LocalFolder;
                    FrmRepViwer.sftpFolder = folder.RemoteFolder;

                }

                FrmRepViwer.repType = "aci";
                FrmRepViwer repViewer = new FrmRepViwer();

              
               

             //   Cursor = Cursors.Arrow; // change cursor to normal type

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

        private void comboBoxRepType_SelectedIndexChanged(object sender, EventArgs e)
        {

            //frmReport frmReport = new frmReport();

            string template = comboBoxRepType.SelectedItem.ToString();
            FrmRepViwer.docview = template;


        }

        private void dateTimeFrom_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void lblDateFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lblDateTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chkRepD_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimeTo_ValueChanged_1(object sender, EventArgs e)
        {

        }

     

        private void btnQuery_Click(object sender, EventArgs e)
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
    }
}
