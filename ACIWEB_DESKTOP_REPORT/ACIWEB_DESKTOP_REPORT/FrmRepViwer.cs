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



        public FrmRepViwer()
        {
            InitializeComponent();
            IniTemplate();


        }

        private void IniTemplate(){

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
                    aciRep.LoadLayout(ReportName);

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
                            fileName = String.Concat(docview, "_", exportFileName, ".txt");
                        }
                        else
                        {
                            fileName = String.Concat(docview, "_", DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss"), ".txt");

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
                        ReportPrintTool rep = new ReportPrintTool(aciRep);
                        aciRep.CreateDocument();
                        if (aciRep.RowCount > 0)
                        {
                            documentViewer1.DocumentSource = aciRep;
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("There´s not data to export for this selection");

                        }

                    }


                    export = false;
                    repType = "";

                }

                if (repType == "sage")
                {
                    XtraReportSage sageRep = new XtraReportSage();

                    string ReportName;

                    ReportName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\SAGE\", docview, ".repx");

                    DbQuerySage.repPreview = null;
                    DbQuerySage.doQuery = true;
                    var exportFileName = DbQuerySage.exportFileName;

                    sageRep.LoadLayout(ReportName);

                    if (export == true)
                    {
                        string dirName = "";
                        if (expFolder == "")
                        {
                            dirName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\Sage\Export\", docview, "\\");
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
                            fileName = String.Concat(docview, "_", exportFileName, ".txt");
                        }
                        else
                        {
                            fileName = String.Concat(docview, "_", DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss"), ".txt");

                        }


                        string fileDir = String.Concat(dirName, fileName);

                        //muestra la pantalla de parametros
                        ReportPrintTool rep = new ReportPrintTool(sageRep);

                        sageRep.ExportToText(fileDir);

                        if (sageRep.RowCount > 0)
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

                        //muestra la pantalla de parametros
                        ReportPrintTool rep = new ReportPrintTool(sageRep);

                        sageRep.CreateDocument();

                        if (sageRep.RowCount > 0)
                        {
                            documentViewer1.DocumentSource = sageRep;
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("There´s not data to export for this selection");

                        }


                    }


                    export = false;
                    repType = "";
                }

                if (repType == "sap")
                {
                    XtraReportSap sapRep = new XtraReportSap();

                    string ReportName;

                    ReportName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\SAP\", docview, ".repx");

                    DbQuerySap.repPreview = null;
                    DbQuerySap.doQuery = true;
                    var exportFileName = DbQuerySap.exportFileName;

                    sapRep.LoadLayout(ReportName);

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
                            fileName = String.Concat(docview, "_", exportFileName, ".txt");
                        }
                        else
                        {
                            fileName = String.Concat(docview, "_", DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss"), ".txt");

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
                                SftpConnection sftpConnection = new SftpConnection();

                                sftpConnection.sendFile(fileName, fileDir, sftpFolder);

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
                        ReportPrintTool rep = new ReportPrintTool(sapRep);

                        sapRep.CreateDocument();
                        if (sapRep.RowCount > 0)
                        {

                            documentViewer1.DocumentSource = sapRep;
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("There´s not data to export for this selection");

                        }



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

                    var exportFileName = "";

                    fsRep.LoadLayout(ReportName);

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

                        if (exportFileName != null)
                        {
                            fileName = String.Concat(docview, "_", exportFileName, ".txt");
                        }
                        else
                        {
                            fileName = String.Concat(docview, "_", DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss"), ".txt");

                        }

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
                        ReportPrintTool rep = new ReportPrintTool(fsRep);

                        fsRep.CreateDocument();
                        if (fsRep.RowCount > 0)
                        {

                            documentViewer1.DocumentSource = fsRep;
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("There´s not data to export for this selection");

                        }



                        //   }


                        export = false;
                        repType = "";

                    }




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
