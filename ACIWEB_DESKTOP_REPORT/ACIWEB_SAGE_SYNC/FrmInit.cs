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
using System.Text.RegularExpressions;


namespace ACIWEB_SAGE_SYNC
{
    public partial class FrmInit : Form
    {
        public static string dateRange;
        public static int Type;
        private DbParam conParams;


        DbQuery dbquery = new DbQuery();
        OpenFileDialog of = new OpenFileDialog();
        FolderBrowserDialog Brw = new FolderBrowserDialog();

        DataTable Company = new DataTable("Company");


        bool Loaded;


        public FrmInit()
        {
            InitializeComponent();
            InitValue();
            SetCompany();
        }
        
        private void InitValue()
        {
            conParams = new DbParam();
            conParams.GetValueFromFile();

            textHostname.Text = conParams.Hostaname;
            textBD.Text = conParams.Dbname;
            textUser.Text = conParams.User;
            textPass.Text = conParams.Password;
 
            textDirectorySage.Text = conParams.GetSageURL();

            Company.Columns.Add("Selecction", typeof(bool));
            Company.Columns.Add("Company Name", typeof(String));
            Company.Columns.Add("DB Name ", typeof(String));
            Company.Columns.Add("User", typeof(String));
            Company.Columns.Add("Pass", typeof(String));
            Company.Columns.Add("Host", typeof(String));


            dataGridPre.DataSource = conParams.GetSageConf();
            dataGridPre.AutoResizeColumns();

            SageDBSelected();

            SetInvDate();

        }

        public  void SetInvDate()
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

             /*   comboComp.DataSource = DbQuery.company.Tables["Company"].DefaultView;
                comboComp.ValueMember = "ID";
                comboComp.DisplayMember = "NAME";
                comboComp.BindingContext = this.BindingContext;*/


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


              /*  DbQuery dbCon = new DbQuery();
                  dbCon.Company();

                comboComp.DataSource = DbQuery.company.Tables["Company"].DefaultView;
                comboComp.ValueMember = "ID";
                comboComp.DisplayMember = "NAME";
                comboComp.BindingContext = this.BindingContext; */

                dbConn.Close();
            }

        }

        private void btnSaveComp_Click(object sender, EventArgs e)
        {
         /* txtIdComp.Text = comboComp.SelectedValue.ToString();
            txtNameComp.Text = comboComp.Text;


            conParams.IdComp = txtIdComp.Text;
            conParams.NameComp = txtNameComp.Text; */

            /*Save params values */
            conParams.SetValueOnFile();


        }

        //START SYNCING
        private void btnSaveSync_Click(object sender, EventArgs e)
        {
            setRefCat();

            setMsgtext("Sycing...");

            DbQuery getData = new DbQuery();

            getData.reportQuery(Type);

            setMsgtext("Done");

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
            if (dateTimeFrom.Text == dateTimeTo.Text)
            {

                dateRange = "like '" + dateTimeFrom.Text + "%'";

            }
            else
            {

                dateRange = "between '" + dateTimeFrom.Text + "%' and '" + dateTimeTo.Text + "%'";

            }


        }

        public  void setMsgtext(string text)
        {

            StatusLabel.Text = text;
            statusStrip1.Refresh();

        }

        //Test/Save Pervasive conexion
        private void btnSageConn_Click(object sender, EventArgs e)
        {

          

            frmTestConn tableGrid = new frmTestConn();

            //Test BD CONNETION
            DbConnetionPervasive dbConn = new DbConnetionPervasive();  //Conexion odbc a Peacthtree

            List<string> Parameters = new List<string>();
            conParams = new DbParam();
       
            DataTable sageConf = new DataTable("sage");
            sageConf.Columns.Add("Selecction ", typeof(bool));
            sageConf.Columns.Add("Name ", typeof(String));
            sageConf.Columns.Add("DB ", typeof(String));
            sageConf.Columns.Add("User", typeof(String));
            sageConf.Columns.Add("Pass", typeof(String));
            sageConf.Columns.Add("Host ", typeof(String));
            sageConf.Columns.Add("Connection", typeof(String));

            DataTable test = new DataTable("test");
            test.Columns.Add("DB Name", typeof(String));
            test.Columns.Add("Status", typeof(String));

            for (int i = 0; i < dataGridPre.Rows.Count; i++) //LEES CADA LINEA DE LA TABLA DEL GRIDVIEW
            {
                if (Convert.ToBoolean(dataGridPre.Rows[i].Cells[0].Value))//VERIFICAR SI LA COLUMNA DEL CHECKBOX ES TRUE
                {


                    Parameters.Add(dataGridPre.Rows[i].Cells[5].Value.ToString());
                    Parameters.Add(dataGridPre.Rows[i].Cells[2].Value.ToString());
                    Parameters.Add(dataGridPre.Rows[i].Cells[3].Value.ToString());
                    Parameters.Add(dataGridPre.Rows[i].Cells[4].Value.ToString());


                    conParams.SageConString(Parameters);

                    if (dbConn.StartConn(conParams.SageConString(Parameters)).State == System.Data.ConnectionState.Open)
                    {  //Conexion odbc a Peacthtree

                        test.Rows.Add(
                                 dataGridPre.Rows[i].Cells[2].Value,
                                 "Test OK");

                        sageConf.Rows.Add(
                                         dataGridPre.Rows[i].Cells[0].Value,
                                         dataGridPre.Rows[i].Cells[1].Value,
                                         dataGridPre.Rows[i].Cells[2].Value,
                                         dataGridPre.Rows[i].Cells[3].Value,
                                         dataGridPre.Rows[i].Cells[4].Value,
                                         dataGridPre.Rows[i].Cells[5].Value
                                         );

                        Parameters.Clear();
                    }
                    else
                    {
                        test.Rows.Add(
                                 dataGridPre.Rows[i].Cells[2].Value,
                                 "Check Parameters");
                        
                    }
                    
                    dbConn.Close();

                    tableGrid.Show();
                    tableGrid.fillGrid(test);



                }
            }
            
            conParams.SetSageConfOnFile(sageConf, textDirectorySage.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (Brw.ShowDialog() == DialogResult.OK)
            {
                textDirectorySage.Text = Brw.SelectedPath; // prints path


                // Recurse into subdirectories of this directory.
                string[] subdirectoryEntries = Directory.GetDirectories(Brw.SelectedPath);
                string[] fileEntries;
                string[] DbConString;
                string line = "";
                string[] fields;
                string ext;
                string dbname = "";
                string dbuser = "";
                string host = "";
                TextReader file;

                foreach (string subdirectory in subdirectoryEntries)
                {

                    // Process the list of files found in the directory.
                    fileEntries = Directory.GetFiles(subdirectory);
                    var folder = new DirectoryInfo(subdirectory).Name;

                    foreach (string fileName in fileEntries)
                    {
                        ext = Path.GetExtension(fileName);

                        if (ext == ".udl")
                        {

                            // create reader & open file
                            file = new StreamReader(fileName);

                            Company.NewRow();

                            file.ReadLine();
                            file.ReadLine();

                            line = file.ReadLine();
                            DbConString = line.Split(';');

                            foreach (string fline in DbConString)
                            {
                                if (fline.Contains("Data Source="))
                                {
                                    fields = fline.Split('=');
                                    dbname = fields[1];
                                }

                                if (fline.Contains("User ID="))
                                {
                                    fields = fline.Split('=');
                                    dbuser = fields[1];
                                }

                                if (fline.Contains("Location="))
                                {
                                    fields = fline.Split('=');
                                    host = fields[1];
                                }

                            }

                            Company.Rows.Add(false,folder, dbname, dbuser, "" ,host);

                        }


                    }

                }

            }
            SageListComp();

        }
        
        private void SageListComp()
        {

            
            dataGridPre.DataSource = Company;
            dataGridPre.AutoResizeColumns();

            /*setear columnas como NO editable excepto la columna de chackbox */
            dataGridPre.ReadOnly = false;

            foreach (DataGridViewColumn tblColumns in dataGridPre.Columns)
            {
                tblColumns.ReadOnly = true;
            }

            dataGridPre.Columns[0].ReadOnly = false; //COLUMNA DE CHECKBOX
            dataGridPre.Columns[3].ReadOnly = false; //COLUMNA DE CHECKBOX
            dataGridPre.Columns[4].ReadOnly = false; //COLUMNA DE CHECKBOX
            /* FIN SETADO DE COLUMNAS */

        }

        private void SageDBSelected()
        {
            
            conParams = new DbParam();
            
            dataGridTables.DataSource = conParams.GetSageConf();
            dataGridTables.AutoResizeColumns();



        }
    }
    }

