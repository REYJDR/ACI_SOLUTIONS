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


namespace PickingList
{
    public partial class FrmInit : Form
    {
        public static string dateRange;

        public static string invRange;

        private DbParam conParams;

        DbQuery dbquery = new DbQuery();

        OpenFileDialog of = new OpenFileDialog();
        

        public FrmInit()
        {
            InitializeComponent();
            InitValue();
            InitDesignerRepVal();
        }

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

        private void InitValue()
        {
            conParams = new DbParam();
            conParams.GetValueFromFile();

            textHostname.Text = conParams.Hostaname;
            textBD.Text = conParams.Dbname;
            textUser.Text = conParams.User;
            textPass.Text = conParams.Password;


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
                setMsgtext("Test de conexión exitoso");
                MessageBox.Show("Test de conexión exitoso", "Test de conexión");
                /* this.Close();*/

                //dbConn.Closed();
            }

        }

        private void FrmInit_Load(object sender, EventArgs e)
        {

            setRefCat();

        }



        private void dateTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            setRefCat();



        }

        private void dateTimeTo_ValueChanged(object sender, EventArgs e)
        {
            setRefCat();



        }

        private void setRefCat()
        {

            dateRange = "'"+dateTimeFrom.Text+ "' and '" + dateTimeTo.Text+"'";

        }

        public void setMsgtext(string text)
        {

            StatusLabel.Text = text;
            statusStrip1.Refresh();

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

            if(comboBoxRepType.SelectedIndex == -1)
            {
                setMsgtext("Please select a Report Type");
                MessageBox.Show("Please select a Report Type");
            }
            else
            { 

                        if (textInvFrom.Text != "" )
                        {

                            if (textInvTo.Text != "")
                            {

                            invRange = " and A.InvNumForThisTrx between '" + textInvFrom.Text + "' and '" + textInvTo.Text + "'";

                            }
                            else
                            {
                            invRange = " and A.InvNumForThisTrx = '" + textInvFrom.Text + "'";
                            }

                        }
                        else
                        {
                        invRange = "";
                        }

            
                        DataTable ouputPreview = dbquery.invQuery();

                        frmDataGrid tableGrid = new frmDataGrid();

                        tableGrid.Show();

                        tableGrid.fillGrid(ouputPreview);

            }

        }


        private void comboBoxRepType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            //frmReport frmReport = new frmReport();


            string reportType = comboBoxRepType.SelectedItem.ToString();

            frmReport.docview = reportType;
            

        }

  
        private void btnDesigner_Click_1(object sender, EventArgs e)
        {

            XtraReport_standard report = new XtraReport_standard();
            ReportDesignTool dt = new ReportDesignTool(report);

             string ReportName = GetReportName();

             if (ReportName != "")
             {
                 ReportName = String.Concat(@"C:\\ReportDesigner\", ReportName,".repx");
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




        private void checkedListReport_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (checkedListReport.CheckedItems.Count >= 1) //leo que la lista tenga al menos un checkbox tildado
            {
                //leo segun la cantidad total de items que tenga la lista
                for (int i = 0; i+1 <= checkedListReport.Items.Count; i++){ 
                    //comparo el valor del item que acabo de check con el que estoy leyendo.
                    if ( checkedListReport.SelectedIndex.ToString() != checkedListReport.Items[i].ToString()) {
                      
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
                for (int i = 0; i+1 <= checkedListReport.Items.Count; i++)
                {
                    if (checkedListReport.GetItemCheckState(i).ToString() == "Checked")
                    {

                      reportName = checkedListReport.Items[i].ToString();

                      
                    }
                    

                }

            }

            return reportName;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string reportName = GetReportName();
            string reportToDelete = String.Concat(reportName, ".repx");

            
            try
            {

                if (reportName != "")
                {

                    DialogResult dr = MessageBox.Show("Do you want to delete this report desing ?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        if(File.Exists(reportToDelete))
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            InitDesignerRepVal();
            
        }
    }
}
