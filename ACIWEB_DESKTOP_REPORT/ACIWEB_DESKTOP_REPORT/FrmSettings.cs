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
using WinSCP;


namespace ACIWEB_DESKTOP_REPORT
{
    public partial class FrmSettings : Form
    {
        private DbParamAciweb conParams;
        private DbParamSage SageParams;
        private SftpParam sftpParam;
        private SAPParam sapParams;


        SftpConnection sftpConnection = new SftpConnection();
        FolderBrowserDialog Brw = new FolderBrowserDialog();

        DataTable Company = new DataTable("Company");

        
        public FrmSettings()
        {
            InitializeComponent();
         /* InitFieldVal();
            SetCompany();*/
        }

        public void InitFieldVal()
        {
         

            //get ACIWEB config 
            conParams = new DbParamAciweb();
            conParams.GetValueFromFile();

            textHostname.Text = conParams.Hostaname;
            textBD.Text = conParams.Dbname;
            textUser.Text = conParams.User;
            textPass.Text = conParams.Password;
            txtIdComp.Text = conParams.IdComp;
            txtNameComp.Text = conParams.NameComp;

            conParams.GetAciExportFolder();
            txtDirExportAci.Text = conParams.LocalFolder;
            txtRemoteFolderAci.Text = conParams.RemoteFolder;

            //get SAGE config 
            SageParams = new DbParamSage();

            textDirectorySage.Text = SageParams.GetSageURL();
            SageParams.GetSageExportFolder();
            txtDirExportSage.Text = SageParams.LocalFolder;
            txtRemoteFolderSage.Text = SageParams.RemoteFolder;

            Company.Columns.Add("Selecction", typeof(bool));
            Company.Columns.Add("Company Name", typeof(String));
            Company.Columns.Add("DB Name ", typeof(String));
            Company.Columns.Add("User", typeof(String));
            Company.Columns.Add("Pass", typeof(String));
            Company.Columns.Add("Host", typeof(String));

            dataGridPre.DataSource = SageParams.GetSageConf();
            dataGridPre.AutoResizeColumns();

            SageDBSelected();

            //get SAp config 
            sapParams = new SAPParam();
            sapParams.GetValueFromFile();
            txtSapServer.Text = sapParams.AppServerHost;
            txtSapSysInstance.Text = sapParams.SystemNumber;
            txtSapSysId.Text = sapParams.SystemID;
            txtSapPassword.Text = sapParams.Password;
            txtSapUser.Text = sapParams.User;
            txtSapClient.Text = sapParams.Client;
            txtSapRouter.Text = sapParams.SapRouter;

            //get SFTP config
            sftpParam = new SftpParam();
        
            sftpParam.GetSftpConfFromFile();
            txtSftpHostname.Text = sftpParam.Hostaname;
            txtSftpUsername.Text = sftpParam.User;
            txtSftpPassword.Text = sftpParam.Password;




            

        }

        public void SetCompany()
        {
            DbConnectionMysql dbConn = new DbConnectionMysql();

            //if (dbConn.StartConn().State == System.Data.ConnectionState.Open)  //Conexion odbc a Peacthtree
            if (dbConn.StartConn() == true) //Conexion Mysql a  Aciweb
            {

                DbQueryAciweb dbCon = new DbQueryAciweb();
                dbCon.Company();

                comboComp.DataSource = DbQueryAciweb.company.Tables["Company"].DefaultView;
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

                MessageBox.Show("Test de conexión exitoso", "Test de conexión");
                /* this.Close();*/


                DbQueryAciweb dbCon = new DbQueryAciweb();
                dbCon.Company();

                comboComp.DataSource = DbQueryAciweb.company.Tables["Company"].DefaultView;
                comboComp.ValueMember = "ID";
                comboComp.DisplayMember = "NAME";
                comboComp.BindingContext = this.BindingContext;


                dbConn.Close();
            }

        }

        private void btnSaveComp_Click(object sender, EventArgs e)
        {
           
                txtIdComp.Text = comboComp.SelectedValue.ToString();
                txtNameComp.Text = comboComp.Text;


                conParams.IdComp = txtIdComp.Text;
                conParams.NameComp = txtNameComp.Text;

                /*Save params values */
                conParams.SetValueOnFile();



        }

        private void btnSageConn_Click(object sender, EventArgs e)
        {
            
            FrmTestConn tableGrid = new FrmTestConn();

            //Test BD CONNETION
            DbConnetionPervasive dbConn = new DbConnetionPervasive();  //Conexion odbc a Peacthtree

            List<string> Parameters = new List<string>();
            SageParams = new DbParamSage();

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


                    SageParams.SageConString(Parameters);

                    if (dbConn.StartConn(SageParams.SageConString(Parameters)).State == System.Data.ConnectionState.Open)
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

            SageParams.SetSageConfOnFile(sageConf, textDirectorySage.Text);

        }

        private void btnSearch_Click(object sender, EventArgs e)
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

                                Company.Rows.Add(false, folder, dbname, dbuser, "", host);

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

            SageParams = new DbParamSage();

            dataGridPre.DataSource = SageParams.GetSageConf();
            dataGridPre.AutoResizeColumns();

         

        }
        
        private void btnExportDir_Click(object sender, EventArgs e)
        {

            if (Brw.ShowDialog() == DialogResult.OK)
            {
                txtDirExportSage.Text = Brw.SelectedPath; // export path
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Brw.ShowDialog() == DialogResult.OK)
            {
                txtDirExportAci.Text = Brw.SelectedPath; // export path
            }
            
        }
        
        private void btnSaveSftp_Click(object sender, EventArgs e)
        {

            sftpParam.Hostaname = txtSftpHostname.Text;
            sftpParam.User = txtSftpUsername.Text;
            sftpParam.Password = txtSftpPassword.Text;
            sftpParam.Port = txtSftpPort.Text;



            try
            {

                SessionOptions sessionOptions = new SessionOptions();


                sessionOptions.HostName = sftpParam.Hostaname;
                sessionOptions.UserName = sftpParam.User;
                sessionOptions.Password = sftpParam.Password;

                if (sftpParam.Port == "21")
                {

                    sessionOptions.Protocol = Protocol.Ftp;
                    sessionOptions.PortNumber = 21;

                }
                else
                {
                    sessionOptions.Protocol = Protocol.Sftp;
                    sessionOptions.PortNumber = 22;
                    sessionOptions.GiveUpSecurityAndAcceptAnySshHostKey = true;
                    // sessionOptions.SshHostKeyFingerprint = "";

                }



                    using (Session session = new Session())
                    {
                        session.Open(sessionOptions);
                        if (session.Opened)
                        {
                            sftpParam.SetSftpConfOnFile();
                            MessageBox.Show("Test de conexión exitoso", "Test de conexión sftp/ftp");

                        }

                        session.Close();

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

        private void btnSafeExpDirAci_Click(object sender, EventArgs e)
        {
            conParams.SetAciExportFolder(txtDirExportAci.Text, txtRemoteFolderAci.Text);
        }
        
        private void btnSafeExpDirSage_Click(object sender, EventArgs e)
        {
            SageParams.SetSageExportFolder(txtDirExportSage.Text, txtRemoteFolderSage.Text);
        }

        private void btnSyncAci_Click(object sender, EventArgs e)
        {
           
            sftpConnection.syncDir(txtDirExportAci.Text, txtRemoteFolderAci.Text, "*.*");
            
        }

        private void btnSyncSage_Click(object sender, EventArgs e)
        {
            sftpConnection.syncDir(txtDirExportSage.Text, txtRemoteFolderSage.Text, "*.*");
        }
        
        private void btnSapConfSave_Click(object sender, EventArgs e)
        {

            /*INI READ AND SAVE CONNECTION PARAMETERS*/
            sapParams.AppServerHost = txtSapServer.Text;
            sapParams.SystemNumber = txtSapSysInstance.Text;
            sapParams.SystemID = txtSapSysId.Text;
            sapParams.Client = txtSapClient.Text;
            sapParams.User = txtSapUser.Text;
            sapParams.Password = txtSapPassword.Text;
            sapParams.SapRouter = txtSapRouter.Text;
            sapParams.Language = "EN";
            sapParams.PoolSize = "5";

            /*END READ AND SAVE CONNECTION PARAMETERS*/

            /*Save params values */
            sapParams.SetValueOnFile();

        }

        private void btnSafeExpDirSap_Click(object sender, EventArgs e)
        {
            sapParams.SetSapExportFolder(txtDirExportSap.Text, txtRemoteFolderSap.Text);

        }

        private void btnSyncSap_Click(object sender, EventArgs e)
        {
            sftpConnection.syncDir(txtDirExportSap.Text, txtRemoteFolderSap.Text, "*.*");

        }

        private void btnDirSapExport_Click(object sender, EventArgs e)
        {
            if (Brw.ShowDialog() == DialogResult.OK)
            {
                txtDirExportSap.Text = Brw.SelectedPath; // export path
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

