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
    public partial class FrmDesigner : Form
    {
        public FrmDesigner()
        {
            InitializeComponent();
            InitDesignerRepVal();
        }
        
     
        public XtraReport report;

        void DesignMdiController_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.InitDesignerRepVal();
            this.Refresh();
        }

        private void checkedListReport_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (checkedListReport.CheckedItems.Count >= 1) //leo que la lista tenga al menos un checkbox tildado
            {
                //leo segun la cantidad total de items que tenga la lista
                for (int i = 0; i + 1 <= checkedListReport.Items.Count; i++)
                {
                    //comparo el valor del item que acabo de check con el que estoy leyendo.
                    if (checkedListReport.SelectedIndex.ToString() != checkedListReport.Items[i].ToString())
                    {

                        // si los valores difieren cambio el estado del check 
                        checkedListReport.SetItemChecked(i, false);

                    }

                }

            }


        }

        private string GetReportName()
        {

            string reportName = "";

            switch(tabControl1.SelectedIndex)
            {
                case 0: //design for aci
                    {
                        if (checkedListReport.CheckedItems.Count >= 1)
                        {
                            for (int i = 0; i + 1 <= checkedListReport.Items.Count; i++)
                            {
                                if (checkedListReport.GetItemCheckState(i).ToString() == "Checked")
                                {

                                    reportName = checkedListReport.Items[i].ToString();


                                }


                            }

                        }

                    }
                    break;
                case 1://design for sage
                    {
                        if (checkedListReportSage.CheckedItems.Count >= 1)
                        {
                            for (int i = 0; i + 1 <= checkedListReportSage.Items.Count; i++)
                            {
                                if (checkedListReportSage.GetItemCheckState(i).ToString() == "Checked")
                                {

                                    reportName = checkedListReportSage.Items[i].ToString();


                                }


                            }

                        }

                    }
                    break;
                case 2://design for saP
                    {
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

                    }
                    break;
            }
                       


            return reportName;

        }

        private void InitDesignerRepVal()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0://design for aci
                    {
                        bool exists = Directory.Exists(@"C:\\ACIDesktopReport\ReportDesigner\ACIWEB\");

                        if (!exists)
                        {
                            Directory.CreateDirectory(@"C:\\ACIDesktopReport\ReportDesigner\ACIWEB\");
                        }

                        FrmAciwebRep frmAciwebRep = new FrmAciwebRep();
                        checkedListReport.Items.Clear();
                        frmAciwebRep.comboBoxRepType.Items.Clear();

                        string[] files = Directory.GetFiles(@"C:\\ACIDesktopReport\ReportDesigner\ACIWEB\", "*.repx");

                        string filename;

                        for (int i = 0; i < files.Length; i++)
                        {

                            filename = Path.GetFileNameWithoutExtension(files[i]);
                            checkedListReport.Items.Add(filename);
                            frmAciwebRep.comboBoxRepType.Items.Add(filename);


                        }

                    }
                    break;

                case 1: //design for sage
                    {
                        bool exists = Directory.Exists(@"C:\\ACIDesktopReport\ReportDesigner\SAGE\");

                        if (!exists)
                        {
                            Directory.CreateDirectory(@"C:\\ACIDesktopReport\ReportDesigner\SAGE\");
                        }

                        // FrmAciwebRep frmAciwebRep = new FrmAciwebRep();
                        checkedListReportSage.Items.Clear();
                        //  frmAciwebRep.comboBoxRepType.Items.Clear();

                        string[] files = Directory.GetFiles(@"C:\\ACIDesktopReport\ReportDesigner\SAGE\", "*.repx");

                        string filename;

                        for (int i = 0; i < files.Length; i++)
                        {

                            filename = Path.GetFileNameWithoutExtension(files[i]);
                            checkedListReportSage.Items.Add(filename);
                            //  frmAciwebRep.comboBoxRepType.Items.Add(filename);


                        }

                    }
                    break;

                case 2: //design for sap
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
                            //  frmAciwebRep.comboBoxRepType.Items.Add(filename);


                        }

                    }
                    break;
            }



        }

        private void btnDesigner_Click(object sender, EventArgs e)
        {
            XtraReportAciweb report = new XtraReportAciweb();
            DbQueryAciweb.repPreview = null;
            report.CreateDocument();
            report.ShowDesigner();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitDesignerRepVal();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string reportName = GetReportName();
            string reportToDelete = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\ACIWEB\",reportName, ".repx");


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
                            InitDesignerRepVal();
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

        private void checkedListReport_SelectedIndexChanged_1(object sender, EventArgs e)
        {


                if (checkedListReport.CheckedItems.Count >= 1) //leo que la lista tenga al menos un checkbox tildado
                {
                    //leo segun la cantidad total de items que tenga la lista
                    for (int i = 0; i + 1 <= checkedListReport.Items.Count; i++)
                    {
                        //comparo el valor del item que acabo de check con el que estoy leyendo.
                        if (checkedListReport.SelectedIndex.ToString() != checkedListReport.Items[i].ToString())
                        {

                            // si los valores difieren cambio el estado del check 
                            checkedListReport.SetItemChecked(i, false);

                        }

                    }

                }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            XtraReportAciweb report = new XtraReportAciweb();
            ReportDesignTool dt = new ReportDesignTool(report);

            string ReportName = GetReportName();

            if (ReportName != "")
            {
                ReportName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\ACIWEB\", ReportName, ".repx");
                report.LoadLayout(ReportName);
                report.CreateDocument();

                // Create a new End-User Report Designer form.
                XRDesignForm designForm = new XRDesignForm();

                DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = @"C:\\ACIDesktopReport\ReportDesigner\ACIWEB";


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

        private void change_tab(object sender, EventArgs e)
        {

            InitDesignerRepVal();

        }

        private void btnNewSage_Click(object sender, EventArgs e)
        {
            XtraReportSage report = new XtraReportSage();
            DbQuerySage.repPreview = null;
            report.CreateDocument();
            report.ShowDesigner();

        }

        private void btoEditSage_Click(object sender, EventArgs e)
        {
            XtraReportSage report = new XtraReportSage();
            ReportDesignTool dt = new ReportDesignTool(report);

            string ReportName = GetReportName();

            if (ReportName != "")
            {
                ReportName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\SAGE\", ReportName, ".repx");
                report.LoadLayout(ReportName);
                report.CreateDocument();

                // Create a new End-User Report Designer form.
                XRDesignForm designForm = new XRDesignForm();

                DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = @"C:\\ACIDesktopReport\ReportDesigner\SAGE";


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

        private void btnDelSage_Click(object sender, EventArgs e)
        {
            string reportName = GetReportName();
            string reportToDelete = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\SAGE\",reportName, ".repx");


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
                            InitDesignerRepVal();
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

        private void btnRefreshSage_Click(object sender, EventArgs e)
        {
            InitDesignerRepVal();
        }

        private void checkedListReportSage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListReportSage.CheckedItems.Count >= 1) //leo que la lista tenga al menos un checkbox tildado
            {
                //leo segun la cantidad total de items que tenga la lista
                for (int i = 0; i + 1 <= checkedListReportSage.Items.Count; i++)
                {
                    //comparo el valor del item que acabo de check con el que estoy leyendo.
                    if (checkedListReportSage.SelectedIndex.ToString() != checkedListReportSage.Items[i].ToString())
                    {

                        // si los valores difieren cambio el estado del check 
                        checkedListReportSage.SetItemChecked(i, false);

                    }

                }

            }
        }

        private void btnSapDNew_Click(object sender, EventArgs e)
        {
            XtraReportSap report = new XtraReportSap();
            DbQuerySap.repPreview = null;
            report.CreateDocument();
            report.ShowDesigner();
        }

        private void btnSapDEdit_Click(object sender, EventArgs e)
        {
            XtraReportSage report = new XtraReportSage();
            ReportDesignTool dt = new ReportDesignTool(report);

            string ReportName = GetReportName();

            if (ReportName != "")
            {
                ReportName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\SAP\", ReportName, ".repx");
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

        private void btnSapDDel_Click(object sender, EventArgs e)
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
                            InitDesignerRepVal();
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

        private void btnSapDFrsh_Click(object sender, EventArgs e)
        {
            InitDesignerRepVal();
            
        }
    }
}
