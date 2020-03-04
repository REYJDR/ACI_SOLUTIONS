using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.IO;
using AciSageLibrary;
using SFTPLibrary;
using DevExpress.XtraPrinting;

namespace ACIWEB_DESKTOP_REPORT
{
    public partial class FrmRepViwer : Form
    {
        public static string docview;
        public static string repType;
        public static bool   export;
        public static bool   import;
        public static string expFolder;
        public static string sftpFolder;
        public static string impFolder;
        public static string sftpImpFolder;
        public static string fileSource;
        public static string fileExt;
        public static string bapiName;
        public static bool OnlyDs = false;
        public static bool Excel = false;

        public static bool canceled = false;


        BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        FrmWait frmWait = new FrmWait();


        public FrmRepViwer()
        {
            InitializeComponent();

            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.WorkerReportsProgress = true;


            IniTemplate();



        }

        
        private void IniTemplate(){

            /*Listar conexion*/
            List<string> Parameters = new List<string>();
            DataTable Sqlresult = new DataTable();

            // backgroundWorker1.RunWorkerAsync();

            try
            {

                if (repType == "aci")
                {
                    XtraReportAciweb aciRep = new XtraReportAciweb();

                    string ReportName;

                    ReportName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\ACIWEB\", docview, ".repx");

                    DbQueryAciweb.repPreview = null;
                    DbQueryAciweb.doQuery = true;

                    var exportFileName = DbQueryAciweb.exportFileName;

                    var hasAnyData = false;

                    aciRep.LoadLayout(ReportName);


                    if (DbQueryAciweb.repPreview.Tables.Count > 0)
                    {
                        for (int i = 0; i < DbQueryAciweb.repPreview.Tables.Count; i++)
                        {
                            if (DbQueryAciweb.repPreview.Tables[i].Rows.Count > 0)
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
                                dirName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\ACIWEB\Export\", docview, "\\");
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
                            ReportPrintTool rep = new ReportPrintTool(aciRep);


                            //esporta diseño a text
                            aciRep.ExportToText(fileDir);

                            if (aciRep.RowCount > 0)
                            {

                                if (!string.IsNullOrEmpty(sftpFolder))
                                {
                                    SftpConnection sftpConnection = new SftpConnection();

                                    sftpConnection.sendFile(fileName, fileDir, sftpFolder);

                                }
                                MessageBox.Show("Data successfuly exported to: " + fileDir);
                            }
                            else
                            {

                                File.Delete(fileDir);
                                MessageBox.Show("There´s not data to export for this selection");

                            }


                        }
                        else
                        {
                            // ReportPrintTool rep = new ReportPrintTool(aciRep);

                            if (OnlyDs == false)
                            {
                                aciRep.CreateDocument();

                                documentViewer1.DocumentSource = aciRep;
                                this.Show();


                            }
                            else
                            {

                                if (canceled == false)
                                {
                                    FrmViewGrid frmView = new FrmViewGrid(DbQueryAciweb.repPreview);

                                    frmView.ShowDialog(this);
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

                if (repType == "sage")
                {

                    XtraReportSage sageRep = new XtraReportSage();

                    string ReportName;
                    string exportFileName = "";
                    ReportName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\SAGE\", docview, ".repx");

                    DbQuerySage.repPreview = null;
                    DbQuerySage.doQuery = true;

                    var hasAnyData = false;

                    sageRep.LoadLayout(ReportName);
                    exportFileName = DbQuerySage.exportFileName;

                    if (DbQuerySage.repPreview.Tables.Count > 0)
                    {
                        for (int i = 0; i < DbQuerySage.repPreview.Tables.Count; i++)
                        {
                            if (DbQuerySage.repPreview.Tables[i].Rows.Count > 0)
                            {
                                hasAnyData = true;
                                break;
                            }
                        }

                    }

                    if (hasAnyData)
                    {
                        string fileDir = "";
                        string fileName = "";
                        string dirName = @"C:\\ACIDesktopReport\ReportDesigner\SAGE\Export\";

                        if (export == true || Excel == true)
                        {
                            if (expFolder == "")
                            {

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

                            if (Excel == false)
                            {


                                if (exportFileName != null)
                                {
                                    fileName = String.Concat(docview, "_", exportFileName, '.', fileExt);
                                }
                                else
                                {
                                    fileName = String.Concat(docview, "_", DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss"), '.', fileExt);

                                }

                                fileDir = String.Concat(dirName, fileName);

                            }
                            else
                            {
                                fileName = String.Concat(docview, "_", DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss"), ".xlsx");
                                fileDir = String.Concat(dirName, fileName);

                            }


                            //muestra la pantalla de parametros
                            ReportPrintTool rep = new ReportPrintTool(sageRep);

                            if (export == true)
                            {
                                sageRep.ExportToText(fileDir);
                            }


                            if (Excel == true)
                            {

                                // Get its XLSX export options. 
                                XlsxExportOptions xlsxOptions = sageRep.ExportOptions.Xlsx;

                                // Set XLSX-specific export options. 
                                xlsxOptions.ShowGridLines = true;
                                xlsxOptions.TextExportMode = TextExportMode.Value;
                                xlsxOptions.ExportHyperlinks = true;
                                //   xlsxOptions.SheetName = "IncomeStatement";
                                xlsxOptions.ExportMode = XlsxExportMode.SingleFilePageByPage;


                                sageRep.ExportToXlsx(fileDir, xlsxOptions);

                            }



                            //sageRep.ExportToCsv(fileDir);
                            if (hasAnyData)
                            {

                                if (!string.IsNullOrEmpty(sftpFolder) && Excel == false)
                                {
                                    SftpConnection sftpConnection = new SftpConnection();

                                    sftpConnection.sendFile(fileName, fileDir, sftpFolder);

                                }
                                MessageBox.Show("Data successfuly exported to: " + fileDir);
                                if (Excel == true)
                                {
                                    System.Diagnostics.Process.Start(fileDir);
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
                            //    ReportPrintTool rep = new ReportPrintTool(sageRep);

                            if (OnlyDs == false)
                            {

                                sageRep.CreateDocument();
                                documentViewer1.DocumentSource = sageRep;
                                this.Show();


                            }
                            else
                            {

                                if (canceled == false)
                                {
                                    FrmViewGrid frmView = new FrmViewGrid(DbQuerySage.repPreview);

                                    frmView.ShowDialog(this);
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

                if (repType == "filesource")
                {

                    FileSourceParam fileSourceParam = new FileSourceParam();
                    SftpConnection sftpConnection = new SftpConnection();

                    List<string> Params = new List<string>();

                    fileSourceParam.GetFSParameters(fileSource);

                    Params.Add(fileSourceParam.Datatable);
                    Params.Add(fileSourceParam.Column);
                    Params.Add(fileSourceParam.Separator);
                    Params.Add(fileSourceParam.Mask);
                    Params.Add(fileSourceParam.LocalImpDir);
                    Params.Add(fileSourceParam.Type);


                    if (import == true)
                    {
                        if (!string.IsNullOrEmpty(sftpImpFolder))
                        {

                            sftpConnection.getFile(fileSourceParam.Mask, impFolder, sftpImpFolder);

                        }
                    }


                    XtraReportFileSource fsRep = new XtraReportFileSource();

                    string ReportName;

                    ReportName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\FILE_SOURCE\", docview, ".repx");

                    DataSourceFS dataSourceFS = new DataSourceFS();
                    DataSourceFS.FSParams = Params;
                    DataSourceFS.repPreview = null;
                    DataSourceFS.doQuery = true;

                    fsRep.DataSource = dataSourceFS.SetFileSource();

                    var hasAnyData = false;

                    fsRep.LoadLayout(ReportName);


                    if (DataSourceFS.repPreview.Tables.Count > 0)
                    {
                        for (int i = 0; i < DataSourceFS.repPreview.Tables.Count; i++)
                        {
                            if (DataSourceFS.repPreview.Tables[i].Rows.Count > 0)
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
                                dirName = String.Concat(fileSourceParam.LocalExpDir, docview, "\\");
                                bool exists = Directory.Exists(dirName);
                                if (!exists)
                                {
                                    Directory.CreateDirectory(dirName);
                                }

                            }
                            else
                            {
                                dirName = String.Concat(fileSourceParam.LocalExpDir, "\\");

                            }

                            var fileName = "";

                            fileName = String.Concat(docview, "_", DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss"), '.', fileExt);



                            string fileDir = String.Concat(dirName, fileName);

                            //muestra la pantalla de parametros
                            ReportPrintTool rep = new ReportPrintTool(fsRep);

                            fsRep.ExportToText(fileDir);

                            if (fsRep.RowCount > 0)
                            {

                                MessageBox.Show("Data successfuly exported to: " + fileDir);

                                if (!string.IsNullOrEmpty(fileSourceParam.SftpConExpDir))
                                {

                                    sftpConnection.sendFile(fileName, fileDir, fileSourceParam.SftpConExp + ";" + fileSourceParam.SftpConExpDir);

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
                            //ReportPrintTool rep = new ReportPrintTool(fsRep);

                            if (OnlyDs == false)
                            {
                                fsRep.CreateDocument();


                                documentViewer1.DocumentSource = fsRep;
                                this.Show();



                            }
                            else
                            {
                                if (canceled == false)
                                {

                                    FrmViewGrid frmView = new FrmViewGrid(DataSourceFS.repPreview);

                                    frmView.ShowDialog(this);
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


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            

            try
            {


                //do some work

            }
            finally
            {
                backgroundWorker1.ReportProgress(0);
            }



        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

            Spinner(false);
        }

        public void Spinner(bool start)
        {



            if (start)
            {
                frmWait.Show();
                frmWait.BringToFront();
            }
            else
            {
                frmWait.Hide();
            }



        }



    }
}
