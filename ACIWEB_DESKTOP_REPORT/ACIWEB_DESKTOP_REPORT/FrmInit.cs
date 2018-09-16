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
    public partial class FrmInit : Form
    {
        public static string dateRange;

        public static string invRange;

        public static int Type;



        private DbParam conParams;

        DbQuery dbquery = new DbQuery();

        OpenFileDialog of = new OpenFileDialog();

        bool Loaded;


        public FrmInit()
        {
            InitializeComponent();
            InitValue();
            InitDesignerRepVal();
            SetCompany();
        }

        private void InitDesignerRepVal()
        {
            bool exists = Directory.Exists(@"C:\\AciwebDesktopReport\ReportDesigner\");

            if (!exists)
            {
                Directory.CreateDirectory(@"C:\\AciwebDesktopReport\ReportDesigner\");
            }


            checkedListReport.Items.Clear();
            comboBoxRepType.Items.Clear();

            string[] files = Directory.GetFiles(@"C:\\AciwebDesktopReport\ReportDesigner\", "*.repx");

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
            txtIdComp.Text = conParams.IdComp;
            txtNameComp.Text = conParams.NameComp;


            SetInvDate();

        }

        public void SetInvDate()
        {
            Loaded = false;
            dateTimeTo.Value = DateTime.Now;
            dateTimeFrom.Value = DateTime.Now;
            Loaded = true;

        }

        private void SetCompany()
        {
            DbConnectionMysql dbConn = new DbConnectionMysql();

            //if (dbConn.StartConn().State == System.Data.ConnectionState.Open)  //Conexion odbc a Peacthtree
            if (dbConn.StartConn() == true) //Conexion Mysql a  Aciweb
            {

                DbQuery dbCon = new DbQuery();
                dbCon.Company();

                comboComp.DataSource = DbQuery.company.Tables["Company"].DefaultView;
                comboComp.ValueMember = "ID";
                comboComp.DisplayMember = "NAME";
                comboComp.BindingContext = this.BindingContext;


                dbConn.Close();
            }

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
          //DbConnetionPervasive dbConn = new DbConnetionPervasive();  //Conexion odbc a Peacthtree
            DbConnectionMysql dbConn = new DbConnectionMysql();        //Conexion Mysql a  Aciweb



            //if (dbConn.StartConn().State == System.Data.ConnectionState.Open)  //Conexion odbc a Peacthtree
            if (dbConn.StartConn() == true) //Conexion Mysql a  Aciweb
            {
                setMsgtext("Test de conexión exitoso");
                MessageBox.Show("Test de conexión exitoso", "Test de conexión");
                /* this.Close();*/


                DbQuery dbCon = new DbQuery();
                dbCon.Company();

                comboComp.DataSource =  DbQuery.company.Tables["Company"].DefaultView;
                comboComp.ValueMember = "ID";
                comboComp.DisplayMember = "NAME";
                comboComp.BindingContext = this.BindingContext;


                dbConn.Close();
            }

        }

        private void btnSaveComp_Click(object sender, EventArgs e)
        {
            txtIdComp.Text   = comboComp.SelectedValue.ToString(); 
            txtNameComp.Text = comboComp.Text; 
            

            conParams.IdComp = txtIdComp.Text;
            conParams.NameComp = txtNameComp.Text;

            /*Save params values */
            conParams.SetValueOnFile();


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
            if(dateTimeFrom.Text == dateTimeTo.Text)
            {

                dateRange = "like '"+ dateTimeFrom.Text + "%'";

            }
            else
            {

                dateRange = "between '"+ dateTimeFrom.Text + "%' and '" + dateTimeTo.Text + "%'";

            }


        }

        public void setMsgtext(string text)
        {

            StatusLabel.Text = text;
            statusStrip1.Refresh();

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            setRefCat();

            if (comboBoxRepType.SelectedIndex == -1)
            {
                setMsgtext("Please select a template");
                MessageBox.Show("Please select a template");
            }
            else
            {

                setMsgtext("Quering data...");

                DbQuery getData = new DbQuery();


                if (chkRepD.Checked) {

                    Type = 1;

                }else {


                    setMsgtext("You must check at least one Report Type");
                    MessageBox.Show("You must check at least one Report Type");
                    return;
                }

                getData.reportQuery(Type);
                
                setMsgtext("Done");
                PrintReport();

            }

        }


        private void PrintReport()
        {

            frmReport repViewer = new frmReport();


            if (DbQuery.theresData == true) {

                repViewer.Show();

            } else {

              
                setMsgtext("No data for this selection");


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
                ReportName = String.Concat(@"C:\\AciwebDesktopReport\ReportDesigner\", ReportName, ".repx");
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

        private void button1_Click(object sender, EventArgs e)
        {

            string reportName = GetReportName();
            string reportToDelete = String.Concat(@"C:\\AciwebDesktopReport\ReportDesigner\", reportName, ".repx");


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

        private void button1_Click_1(object sender, EventArgs e)
        {

            InitDesignerRepVal();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
