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
    public partial class FrmFileSrcRep : Form
    {
        FileSourceParam fileSourceParam = new FileSourceParam();
        DataTable FsList = new DataTable("FsList");

        public FrmFileSrcRep()
        {
            InitializeComponent();
            InitValue();
        }

        private void InitValue()
        {
           


            cmbSelectSource.Items.Clear();

            FsList = fileSourceParam.GetFSConfOnFile();
            for (int i = 0; i < FsList.Rows.Count; i++)
            {
                cmbSelectSource.Items.Add(FsList.Rows[i].Field<string>(0));

            }


        }

        private void getTemplates(string mask)
        {

            comboBoxRepType.Items.Clear();

            string[] files = Directory.GetFiles(@"C:\\ACIDesktopReport\ReportDesigner\FILE_SOURCE\", mask+"*.repx");

            string filename;

            for (int i = 0; i < files.Length; i++)
            {

                filename = Path.GetFileNameWithoutExtension(files[i]);
                comboBoxRepType.Items.Add(filename);


            }

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

        private void PrintReport()
        {
            try
            {
                Cursor = Cursors.WaitCursor; // change cursor to hourglass type

                FileSourceParam fileSourceParam = new FileSourceParam();

                fileSourceParam.GetFSParameters(cmbSelectSource.SelectedItem.ToString());


                if (fileSourceParam.SftpConImp != "")
                {
                    FrmRepViwer.import = true;
                    FrmRepViwer.impFolder = fileSourceParam.LocalImpDir;
                    FrmRepViwer.sftpImpFolder = fileSourceParam.SftpConImp + ';' + fileSourceParam.SftpConImpDir;


                }

                if (this.chkExport.Checked == true)
                {
                   
                    FrmRepViwer.export = true;
                    FrmRepViwer.expFolder  = fileSourceParam.LocalExpDir;
                    FrmRepViwer.sftpFolder = fileSourceParam.SftpConExp+';'+fileSourceParam.SftpConExpDir;

                   
                }

                FrmRepViwer.repType = "filesource";
                FrmRepViwer repViewer = new FrmRepViwer();



                Cursor = Cursors.Arrow; // change cursor to hourglass type


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
            string template = comboBoxRepType.SelectedItem.ToString();
            FrmRepViwer.docview = template;
        }

        private void cmbSelectSource_SelectedIndexChanged(object sender, EventArgs e)
        {

            string fileSource = cmbSelectSource.SelectedItem.ToString();
            FrmRepViwer.fileSource = fileSource;

            string[] fileMask = fileSource.Split('_');

            getTemplates(fileMask[0]);



        }
    }
}
