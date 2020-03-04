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
using DevExpress.XtraReports.UI;

namespace AciSapLibrary
{
    public partial class FrmRepViwerSap : Form
    {

        public static string docview;
        public static string repType;
        public static bool export;
        public static bool import;
        public static string expFolder;
        public static string sftpFolder;
        public static string impFolder;
        public static string sftpImpFolder;
        public static string fileSource;
        public static string fileExt;
        public static string bapiName;
        public static bool OnlyDs = false;
        public static bool canceled = false;
        public static bool Excel = false;

        public FrmRepViwerSap()
        {
            InitializeComponent();
            IniTemplate();
        }

        private void IniTemplate()
        {

            try
            {

                if (repType == "sap")
                {
                    DbQuerySap.bapiName = bapiName;
                    XtraReportSap sapRep = new XtraReportSap();
                    

                    string ReportName;

                    ReportName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\SAP\", docview, ".repx");

                    DbQuerySap.repPreview = null;
                    DbQuerySap.doQuery = true;
                   
                    var exportFileName = DbQuerySap.exportFileName;
                    
                    var hasAnyData = false;

                    sapRep.LoadLayout(ReportName);


                    if (DbQuerySap.repPreview.Tables.Count > 0)
                    {
                        for (int i = 0; i < DbQuerySap.repPreview.Tables.Count; i++)
                        {
                            if (DbQuerySap.repPreview.Tables[i].Rows.Count > 0)
                            {
                                hasAnyData = true;
                                break;
                            }
                        }

                    }
                    if (hasAnyData)
                    {
                        
                        if (export == true)
                        {
                            string dirName = "";
                            if (expFolder == "")
                            {
                                dirName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\SAP\Export\", docview, "\\");
                                bool exists = Directory.Exists(dirName);
                                if (!exists)
                                {
                                    Directory.CreateDirectory(dirName);
                                }

                            }
                            else
                            {
                                dirName = String.Concat(expFolder, "\\");

                            }

                            var fileName = "";

                            if (exportFileName != null)
                            {
                                fileName = String.Concat(docview, "_", exportFileName, '.', fileExt);
                            }
                            else
                            {
                                fileName = String.Concat(docview, "_", DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss"), '.', fileExt);

                            }
                            string fileDir = String.Concat(dirName, fileName);

                            //muestra la pantalla de parametros
                            ReportPrintTool rep = new ReportPrintTool(sapRep);

                            sapRep.ExportToText(fileDir);
                            
                            if (sapRep.RowCount > 0)
                            {

                                MessageBox.Show("Data successfuly exported to: " + fileDir);

                                if (!string.IsNullOrEmpty(sftpFolder))
                                {
                                  //  SftpConnection sftpConnection = new SftpConnection();

                                   // sftpConnection.sendFile(fileName, fileDir, sftpFolder);

                                }

                            }
                            else
                            {

                                File.Delete(fileDir);

                                MessageBox.Show("There´s not data to export for this selection");

                            }

                            
                        }
                        else
                        {
                            //muestra la pantalla de parametros
                            // ReportPrintTool rep = new ReportPrintTool(sapRep);

                            if (OnlyDs == false)
                            {
                                sapRep.CreateDocument();

                                documentViewer1.DocumentSource = sapRep;
                                this.Show();


                            }
                            else
                            {

                                if (canceled == false)
                                {

                                /*    FrmViewGrid frmView = new FrmViewGrid(DbQuerySap.repPreview);

                                    frmView.ShowDialog(this);*/
                                }
                                OnlyDs = false;
                            }


                        }
                    }
                    else
                    {
                        MessageBox.Show("There´s not data to export for this selection");

                    }

                    export = false;
                    repType = "";

                }


            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, theException.StackTrace);
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }





        }

    }
}
