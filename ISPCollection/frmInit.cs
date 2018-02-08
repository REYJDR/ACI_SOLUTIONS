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


namespace ISPCollection
{
    public partial class frmInit : Form
    {
        public static string dateRangeInv;
        public static string dateRangeRep;
        public static string dateCollectOF;

        public static bool CheckInvRep;
        public static bool CheckCollectRep;

        bool Loaded;

        private DbParam conParams;

        DbQuery dbquery = new DbQuery();

        OpenFileDialog of = new OpenFileDialog();


        public frmInit()
        {
            InitializeComponent();
            InitValue();
            InitDesignerRepVal();


        }

        private void InitValue()
        {
            conParams = new DbParam();
            conParams.GetValueFromFile();

            textHostname.Text = conParams.Hostaname;
            textBD.Text = conParams.Dbname;
            textUser.Text = conParams.User;
            textPass.Text = conParams.Password;

            
            dateCollectOf.Value = DateTime.Now;

            SetInvDate();
            SetRepDate();


            setDatesRange();



        }

        public void SetInvDate()
        {
            Loaded = false;
            dateInvTo.Value = DateTime.Now;
            dateInvFrom.Value = DateTime.Now;
            Loaded = true;

        }

        public void SetRepDate()
        {
            Loaded = false;
            dateRepTo.Value = DateTime.Now;
            dateRepFrom.Value = DateTime.Now;
            Loaded = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            /*INI READ AND SAVE CONNECTION PARAMETERS*/
            conParams.Hostaname = textHostname.Text;
            conParams.User = textUser.Text;
            conParams.Password = textPass.Text;
            conParams.Dbname = textBD.Text;
            /*END READ AND SAVE CONNECTION PARAMETERS*/

            /*Save params values */
            conParams.SetValueOnFile();


            //Test BD CONNETION
            DbConnetionPervasive dbConn = new DbConnetionPervasive();

            /*Abre conexion para test*/
            dbConn.StartConn();

            if (dbConn.StartConn().State == System.Data.ConnectionState.Open)
            {

                MessageBox.Show("Test de conexión exitoso", "Test de conexión");
                /* this.Close();*/

                //dbConn.Closed();
            }

        }
  
        private void setDatesRange()
        {
            
            if(Loaded == true)
            {

                if (dateInvFrom.Value != null && dateInvTo.Value != null)
                {
                  
                    if (dateInvTo.Value.Date < dateInvFrom.Value.Date)
                    {
                        MessageBox.Show("Set a valid range of dates for invoices", "Warning");
                        SetInvDate();
                    }
                    else
                    {
                        dateRangeInv = "'" + dateInvFrom.Text + "' and '" + dateInvTo.Text + "'";
                    }

                }
                else
                {
                    MessageBox.Show("Set a valid range of dates for invoices", "Warning");

                }

                if (dateRepFrom.Value != null && dateRepTo.Value != null)
                {

                    if (dateRepTo.Value.Date < dateRepFrom.Value.Date)
                    {
                        MessageBox.Show("Set a valid range of dates for receipts", "Warning");
                        SetRepDate();
                    }
                    else
                    {
                        dateRangeRep = "'" + dateRepFrom.Text + "' and '" + dateRepTo.Text + "'";
                    }
                }
                else
                {
                    MessageBox.Show("Set a valid range of dates for receipts", "Warning");

                }

                dateCollectOF = dateCollectOf.Text;

            }

           
    }

        public void setMsgtext(string text)
        {

            StatusLabel.Text = text;
            statusStrip1.Refresh();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            setDatesRange();

            if (comboBoxRepType.SelectedIndex == -1)
            {
                setMsgtext("Please select a Report Type");
                MessageBox.Show("Please select a Report Type");
            }
            else
            {
               
                setMsgtext("Quering data, please wait...");

                dbquery.collectionQuery();

                frmRepView viewReport = new frmRepView();

                viewReport.Show();
                setMsgtext("Done!");

            }    
            
        }

        private void dateInvFrom_ValueChanged(object sender, EventArgs e)
        {
            setDatesRange();
        }

        private void dateInvTo_ValueChanged(object sender, EventArgs e)
        {
            setDatesRange();
        }

        private void dateRepFrom_ValueChanged(object sender, EventArgs e)
        {
            setDatesRange();
        }
        
        private void dateRepTo_ValueChanged_1(object sender, EventArgs e)
        {
          setDatesRange();
        }

        /*report designer*/
        private void InitDesignerRepVal()
        {
            bool exists = Directory.Exists(@"C:\\ReportDesigner\");

            if (!exists)
            {
                Directory.CreateDirectory(@"C:\\ReportDesigner\");
            }


            checkedListReport.Items.Clear();
            comboBoxRepType.Items.Clear();

            string[] files = Directory.GetFiles(@"C:\\ReportDesigner\", "*.repx");

            string filename;

            for (int i = 0; i < files.Length; i++)
            {

                filename = Path.GetFileNameWithoutExtension(files[i]);
                checkedListReport.Items.Add(filename);
                comboBoxRepType.Items.Add(filename);


            }

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

            return reportName;

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
           InitDesignerRepVal();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            string reportName = GetReportName();
            string reportToDelete = String.Concat(@"C:\\ReportDesigner\", reportName, ".repx");


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

        private void btnDesigner_Click(object sender, EventArgs e)
        {
            XtraReport_std report = new XtraReport_std();
            ReportDesignTool dt = new ReportDesignTool(report);

            string ReportName = GetReportName();

            if (ReportName != "")
            {
                ReportName = String.Concat(@"C:\\ReportDesigner\", ReportName, ".repx");
                report.LoadLayout(ReportName);
                report.CreateDocument();


            }
            else
            {

                report.CreateDocument();

            }

            // Create a new End-User Report Designer form.
            XRDesignForm designForm = new XRDesignForm();

            DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = @"C:\\ReportDesigner";


            // Handle the DesignPanelLoaded event before opening a report in the Report Designer
            designForm.FormClosed += DesignMdiController_FormClosed;

            // Create a new blank report and show it the Report Designer dialog window.
            designForm.OpenReport(report);
            designForm.Show();
        }

        public XtraReport report;

        void DesignMdiController_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.InitDesignerRepVal();
            this.Refresh();
        }

        private void comboBoxRepType_SelectedIndexChanged(object sender, EventArgs e)
        {


            string reportType = comboBoxRepType.SelectedItem.ToString();

            frmRepView.docview = reportType;
        }

        /*fin report designer*/
    }
}
