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

namespace ACIWEB_DESKTOP_REPORT
{
    public partial class FrmRepViwer : Form
    {
        public static string docview;
        public static string repType;

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
                    aciRep.CreateDocument();

                    documentViewer1.DocumentSource = aciRep;

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
                    sageRep.CreateDocument();
                    documentViewer1.DocumentSource = sageRep;
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
