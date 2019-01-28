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
        public static bool export;
        public static string expFolder;
        public static string sftpFolder;
   


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

                        string fileName = String.Concat(docview, "_", DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss"), ".txt");

                        string fileDir = String.Concat(dirName, fileName);

                        //muestra la pantalla de parametros
                        ReportPrintTool rep = new ReportPrintTool(aciRep);


                        //esporta diseño a text
                        aciRep.ExportToText(fileDir);

                        if (aciRep.RowCount > 0) { 

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
                            dirName = String.Concat( expFolder, "\\");
                            
                        }


                        string fileName = String.Concat(docview, "_", DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss"), ".txt");

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

                        }
                        else
                        {

                            File.Delete(fileDir);

                            MessageBox.Show("There´s not data to export for this selection");

                        }






                    }
                    else {

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

                if(repType == "sap")
                {
                    XtraReportSap sapRep = new XtraReportSap();

                    string ReportName;

                    ReportName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\SAP\", docview, ".repx");

                    DbQuerySap.repPreview = null;
                    DbQuerySap.doQuery = true;
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


                        string fileName = String.Concat(docview, "_", DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss"), ".txt");

                        string fileDir = String.Concat(dirName, fileName);

                        //muestra la pantalla de parametros
                        ReportPrintTool rep = new ReportPrintTool(sapRep);

                        sapRep.ExportToText(fileDir);

                        if (sapRep.RowCount > 0)
                        {

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
