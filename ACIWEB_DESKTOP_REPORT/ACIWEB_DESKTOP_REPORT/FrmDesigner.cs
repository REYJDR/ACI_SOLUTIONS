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
using AciSageLibrary;

namespace ACIWEB_DESKTOP_REPORT
{
    public partial class FrmDesigner : Form
    {
        FileSourceParam fileSourceParam = new FileSourceParam();
      
        DataTable FsList= new DataTable("FSList");


        // XtraReport report;
        XtraReportFileSource fSreport;

       // XtraReportFS fSreport;
        ReportDesignTool fSdt;

        public FrmDesigner()
        {
            InitializeComponent();
            InitDesignerRepVal();
            setFSList();
            

        }

      

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

                 case 2://design for FS
                    {
                        if (checkedListReportFS.CheckedItems.Count >= 1)
                        {
                            for (int i = 0; i + 1 <= checkedListReportFS.Items.Count; i++)
                            {
                                if (checkedListReportFS.GetItemCheckState(i).ToString() == "Checked")
                                {

                                    reportName = checkedListReportFS.Items[i].ToString();


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
            try
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
            try
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

 
        private void comboBoxRepType_SelectedIndexChanged(object sender, EventArgs e)
        {


            setTemplateList();

        }


        private void setTemplateList()
        {
            string[] fileMask = comboBoxRepType.SelectedItem.ToString().Split('_');
            string Mask = fileMask[0];

            bool exists = Directory.Exists(@"C:\\ACIDesktopReport\ReportDesigner\FILE_SOURCE\");

            if (!exists)
            {
                Directory.CreateDirectory(@"C:\\ACIDesktopReport\ReportDesigner\FILE_SOURCE\");
            }

            checkedListReportFS.Items.Clear();


            string[] files = Directory.GetFiles(@"C:\\ACIDesktopReport\ReportDesigner\FILE_SOURCE\", Mask+"*.repx");

            string filename;

            for (int i = 0; i < files.Length; i++)
            {

                filename = Path.GetFileNameWithoutExtension(files[i]);
                checkedListReportFS.Items.Add(filename);


            }


        }

        private void setFSList()
        {

            FsList = fileSourceParam.GetFSConfOnFile();

            for (int i = 0; i < FsList.Rows.Count; i++)
            {
                comboBoxRepType.Items.Add(FsList.Rows[i].Field<string>(0));

            }

        }
  
        private void btnFSDNew_Click(object sender, EventArgs e)
        {

            try {

                if (comboBoxRepType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a source file");
                }
                else
                {
                   List<string> Params = new List<string>(); ;

                   fileSourceParam.GetFSParameters(comboBoxRepType.SelectedItem.ToString());

                   Params.Add(fileSourceParam.Datatable);
                   Params.Add(fileSourceParam.Column);
                   Params.Add(fileSourceParam.Separator);
                   Params.Add(fileSourceParam.Mask);
                   Params.Add(fileSourceParam.LocalImpDir);

                    DataSourceFS dataSourceFS = new DataSourceFS();
                    DataSourceFS.FSParams = Params;
                    DataSourceFS.repPreview = null;

                    fSreport = new XtraReportFileSource();
                    fSreport.DataSource = dataSourceFS.SetFileSource();
                    fSreport.CreateDocument();
                    fSreport.ShowDesigner();


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

        private void checkedListReportFS_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                if (checkedListReportFS.CheckedItems.Count >= 1) //leo que la lista tenga al menos un checkbox tildado
                {
                    //leo segun la cantidad total de items que tenga la lista
                    for (int i = 0; i + 1 <= checkedListReportFS.Items.Count; i++)
                    {
                        //comparo el valor del item que acabo de check con el que estoy leyendo.
                        if (checkedListReportFS.SelectedIndex.ToString() != checkedListReportFS.Items[i].ToString())
                        {

                        // si los valores difieren cambio el estado del check 
                        checkedListReportFS.SetItemChecked(i, false);

                        }

                    }

                }
            
        }

        private void btnFSDEdit_Click(object sender, EventArgs e)
        {
            try
            { 

                if (comboBoxRepType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a source file");
                }
                else
                {
                   List<string> Params = new List<string>(); 

                    fileSourceParam.GetFSParameters(comboBoxRepType.SelectedItem.ToString());

                    Params.Add(fileSourceParam.Datatable);
                    Params.Add(fileSourceParam.Column);
                    Params.Add(fileSourceParam.Separator);
                    Params.Add(fileSourceParam.Mask);
                    Params.Add(fileSourceParam.LocalImpDir);

                    DataSourceFS dataSourceFS = new DataSourceFS();
                    DataSourceFS.FSParams = Params;
                    DataSourceFS.repPreview = null;


                    fSreport = new XtraReportFileSource();
                    fSreport.DataSource = dataSourceFS.SetFileSource();

                    fSdt = new ReportDesignTool(fSreport);

                string ReportName = GetReportName();

                if (ReportName != "")
                {
                    ReportName = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\FILE_SOURCE\", ReportName, ".repx");

                        fSreport.LoadLayout(ReportName);
                        fSreport.CreateDocument();
                
                    // Create a new End-User Report Designer form.
                    XRDesignForm designForm = new XRDesignForm();

                    DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = @"C:\\ACIDesktopReport\ReportDesigner\FILE_SOURCE";


                    // Handle the DesignPanelLoaded event before opening a report in the Report Designer
                    designForm.FormClosed += DesignMdiController_FormClosed;

                    // Create a new blank report and show it the Report Designer dialog window.
                    designForm.OpenReport(fSreport);
                    designForm.Show();

                }
                else
                {
                    MessageBox.Show("You must select a template to edit", "Warning");

                }

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

        private void btnFSDDel_Click(object sender, EventArgs e)
        {
            string reportName = GetReportName();
            string reportToDelete = String.Concat(@"C:\\ACIDesktopReport\ReportDesigner\FILE_SOURCE\", reportName, ".repx");

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
                            setTemplateList();
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

        private void btnFSDRefresh_Click(object sender, EventArgs e)
        {
            setTemplateList();
        }

      
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
