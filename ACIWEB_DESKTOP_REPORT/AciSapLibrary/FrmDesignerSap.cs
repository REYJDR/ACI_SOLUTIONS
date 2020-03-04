using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using System;

namespace AciSapLibrary
{
    public partial class FrmDesignerSap : Form
    {
        SAPParam sapParams = new SAPParam();
        DataTable Bapi = new DataTable("Bapi");

        public FrmDesignerSap()
        {
            InitializeComponent();
            setBapiList();
        }

   
        
        private void InitVal()
        {

            bool exists = Directory.Exists(@"C:\\ACIDesktopReport\ReportDesigner\SAP\");

            if (!exists)
            {
                Directory.CreateDirectory(@"C:\\ACIDesktopReport\ReportDesigner\SAP\");
            }

            // FrmAciwebRep frmAciwebRep = new FrmAciwebRep();
            checkedListReportSap.Items.Clear();
            //  frmAciwebRep.comboBoxRepType.Items.Clear();

            string[] files = Directory.GetFiles(@"C:\\ACIDesktopReport\ReportDesigner\SAP\", "*.repx");

            string filename;

            for (int i = 0; i < files.Length; i++)
            {

                filename = Path.GetFileNameWithoutExtension(files[i]);
                checkedListReportSap.Items.Add(filename);


            }

        }

        private string GetReportName()
        {

            string reportName = "";

            if (checkedListReportSap.CheckedItems.Count >= 1)
            {
                for (int i = 0; i + 1 <= checkedListReportSap.Items.Count; i++)
                {
                    if (checkedListReportSap.GetItemCheckState(i).ToString() == "Checked")
                    {

                        reportName = checkedListReportSap.Items[i].ToString();


                    }


                }
            }

            return reportName;

        }

        private void setBapiList()
        {

              Bapi = sapParams.GetBapiList();

            for (int i = 0; i < Bapi.Rows.Count; i++)
            {
                cmbBapiSelect.Items.Add(Bapi.Rows[i].Field<string>(0));

            }

        }


        private void btnSapDEdit_Click(object sender, System.EventArgs e)
        {
            XtraReportSap report = new XtraReportSap();
            ReportDesignTool dt = new ReportDesignTool(report);

            string ReportName = GetReportName();

            if (ReportName != "")
            {
                ReportName = string.Concat(@"C:\\ACIDesktopReport\ReportDesigner\SAP\", ReportName, ".repx");
                report.LoadLayout(ReportName);
                report.CreateDocument();

                // Create a new End-User Report Designer form.
                XRDesignForm designForm = new XRDesignForm();

                DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = @"C:\\ACIDesktopReport\ReportDesigner\SAP";


                // Handle the DesignPanelLoaded event before opening a report in the Report Designer
                designForm.FormClosed += DesignMdiController_FormClosed;

                // Create a new blank report and show it the Report Designer dialog window.
                designForm.OpenReport(report);
                designForm.Show();

            }
            else
            {

                MessageBox.Show("You must select a template to edit", "Warning");


            }
        }

        private void cmbBapiSelect_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            checkedListReportSap.Items.Clear();

            var dir = "";

            if (Bapi.Rows.Count > 0)
            {
                for (int i = 0; i < Bapi.Rows.Count; i++)
                {

                    if (Bapi.Rows[i].Field<string>(0) == cmbBapiSelect.SelectedItem.ToString())
                    {
                        dir = @"C:\\ACIDesktopReport\ReportDesigner\SAP\" + Bapi.Rows[i].Field<string>(1) + ".repx";

                        bool exists = File.Exists(dir);

                        if (exists)
                        {

                            checkedListReportSap.Items.Add(Bapi.Rows[i].Field<string>(1));
                        }
                    }


                }

            }

        }

        private void btnSapDNew_Click(object sender, System.EventArgs e)
        {


            XtraReportSap report = new XtraReportSap();
            DbQuerySap.repPreview = null;
            DbQuerySap.bapiName = cmbBapiSelect.SelectedItem.ToString();

            report.CreateDocument();
            report.ShowDesigner();




        }


        private void btnSapDDel_Click(object sender, System.EventArgs e)
        {

            string reportName = GetReportName();
            string reportToDelete = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\SAP\", reportName, ".repx");

            try
            {

                if (reportName != "")
                {

                    DialogResult dr = MessageBox.Show("Do you want to delete this report desing ?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        if (File.Exists(reportToDelete))
                        {
                            File.Delete(reportToDelete);
                            InitVal();
                        }

                    }


                }
                else
                {
                    MessageBox.Show("A report design must be selected", "Warning");

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

        private void btnSapDFrsh_Click(object sender, System.EventArgs e)
        {
            InitVal();
        }


        void DesignMdiController_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.InitVal();
            this.Refresh();
        }
    }
}
