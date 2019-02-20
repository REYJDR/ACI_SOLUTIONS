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
        private FileSourceParam fileSourceParam;


        SftpConnection sftpConnection = new SftpConnection();
        FolderBrowserDialog Brw = new FolderBrowserDialog();

        DataTable Company = new DataTable("Company");
        DataTable SftpList = new DataTable("SftpList");
        DataTable FsList = new DataTable("FsList");




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
            SftpList.Columns.Add("Conecction name", typeof(String));
            SftpList.Columns.Add("Host", typeof(String));
            SftpList.Columns.Add("Username", typeof(String));
            SftpList.Columns.Add("Password", typeof(String));
            SftpList.Columns.Add("Port", typeof(String));

            GetSftpList();


            //File Source 
            fileSourceParam = new FileSourceParam();
            FsList.Columns.Add("Data Table", typeof(String));
            FsList.Columns.Add("File mask", typeof(String));
            FsList.Columns.Add("Type", typeof(String));
            FsList.Columns.Add("Column", typeof(String));
            FsList.Columns.Add("Separator", typeof(String));
            FsList.Columns.Add("Imp. SFTP Connection", typeof(String));
            FsList.Columns.Add("Imp. Local Folder", typeof(String));
            FsList.Columns.Add("Imp. Remote Folder", typeof(String));
            FsList.Columns.Add("Exp. SFTP Connection", typeof(String));
            FsList.Columns.Add("Exp. Local Folder", typeof(String));
            FsList.Columns.Add("Exp. Remote Folder", typeof(String));


            GetFsList();

        }

        private void GetSftpList()
        {
            dataGridSftpList.Refresh();

            SftpList = sftpParam.GetSftpConfOnFile();
            dataGridSftpList.DataSource = SftpList;
            dataGridSftpList.AutoResizeColumns();

            SetComboBoxesSftpList();
        }

        //Inicializa todos los combobox con la lista de conexiones SFTP dispobibles
        private void SetComboBoxesSftpList() {

            cmbSftpListAci.Items.Clear();
            cmbSftpListSage.Items.Clear();
            cmbSftpListSap.Items.Clear();
            cmbSftpListFSImport.Items.Clear();
            cmbSftpListFSExport.Items.Clear();


            for (int i = 0; i< SftpList.Rows.Count; i++)
            {
                cmbSftpListAci.Items.Add(SftpList.Rows[i].Field<string>(0));
                cmbSftpListSage.Items.Add(SftpList.Rows[i].Field<string>(0));
                cmbSftpListSap.Items.Add(SftpList.Rows[i].Field<string>(0));
                cmbSftpListFSImport.Items.Add(SftpList.Rows[i].Field<string>(0));
                cmbSftpListFSExport.Items.Add(SftpList.Rows[i].Field<string>(0));

            }
        }

        //CONFIGURACION DE SAGE
        public void  SetCompany()
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

        private void btnSafeExpDirSage_Click(object sender, EventArgs e)
        {
            string sftpconf = "";

            if (txtRemoteFolderSage.Text.IndexOf(';', 0) > 0)
            {
                string[] S;

                S = txtRemoteFolderSage.Text.Split(';');

                sftpconf = cmbSftpListSage.SelectedItem.ToString() + ';' + S[1];

            }
            else
            {
                sftpconf = cmbSftpListSage.SelectedItem.ToString() + ';' + txtRemoteFolderSage.Text;

            }

            SageParams.SetSageExportFolder(txtDirExportSage.Text, sftpconf);

            txtRemoteFolderSage.Text = sftpconf;


        }

        private void btnSyncSage_Click(object sender, EventArgs e)
        {
            sftpConnection.syncDir(txtDirExportSage.Text, txtRemoteFolderSage.Text, "*.*");
        }

        //CONFIGURACION SFTP
        private bool checkSftp()
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
                           // sftpParam.SetSftpConfOnFile();
                            MessageBox.Show("Test de conexión exitoso", "Test de conexión sftp/ftp");
                            session.Close();
                            return true;

                        }
                        else
                        {
                            session.Close();
                            return false;

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
                return false;

            }
            }

        private void btnAddSftpToList_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (checkSftp() == true)
            {//checa conexion al sftp


                foreach (DataGridViewRow row in dataGridSftpList.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(txtSftpName.Text))
                    {
                        MessageBox.Show("This configuration values already exist", "Error");
                        check = true;
                        break;
                    }

                    if (row.Cells[1].Value.ToString().Equals(txtSftpHostname.Text))
                    {
                        if (row.Cells[2].Value.ToString().Equals(txtSftpHostname.Text))
                        {
                            MessageBox.Show("This configuration values already exist", "Error");
                            check = true;
                            break;
                        }
                    }


                }

                if (check == false)
                {
                    
                    SftpList.Rows.Add(      txtSftpName.Text,
                                            txtSftpHostname.Text,
                                            txtSftpUsername.Text,
                                            txtSftpPassword.Text,
                                            txtSftpPort.Text);


                   

                    sftpParam.SetSftpConfOnFile(SftpList);

                    GetSftpList();

                    dataGridSftpList.AutoResizeColumns();

                }

            }

        }


        //CONFIGURACION ACI
        private void btnSafeExpDirAci_Click(object sender, EventArgs e)
        {
            string sftpconf = "";

            if (txtRemoteFolderAci.Text.IndexOf(';', 0)>0)
            {
                string[] S;

                S = txtRemoteFolderAci.Text.Split(';');

                sftpconf = cmbSftpListAci.SelectedItem.ToString() + ';' + S[1];

            }
            else
            {
                sftpconf = cmbSftpListAci.SelectedItem.ToString() + ';' + txtRemoteFolderAci.Text;

            }
            

           
            conParams.SetAciExportFolder(
                        txtDirExportAci.Text,
                        sftpconf );

            txtRemoteFolderAci.Text = sftpconf;

        }
      
        private void btnSyncAci_Click(object sender, EventArgs e)
        {
           
            sftpConnection.syncDir(txtDirExportAci.Text, txtRemoteFolderAci.Text, "*.*");
            
        }


        //CONFIGURACION SAP
        private void btnSafeExpDirSap_Click(object sender, EventArgs e)
        {
            string sftpconf = "";

            if (txtRemoteFolderSap.Text.IndexOf(';', 0) > 0)
            {
                string[] S;

                S = txtRemoteFolderSap.Text.Split(';');

                sftpconf = cmbSftpListSap.SelectedItem.ToString() + ';' + S[1];

            }
            else
            {
                sftpconf = cmbSftpListSap.SelectedItem.ToString() + ';' + txtRemoteFolderSap.Text;

            }

            sapParams.SetSapExportFolder(txtDirExportSap.Text, sftpconf);


            txtRemoteFolderSap.Text = sftpconf;


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


        //CONFIGURACION FILE SOURCE
        private void btnAddFs_Click(object sender, EventArgs e)
        {

            bool check = false;

                foreach (DataGridViewRow row in dataGridFileSource.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(txtDataTable.Text))
                    {
                        MessageBox.Show("This configuration values already exist", "Error");
                        check = true;
                        break;
                    }
                    
                }

            if (check == false)
            {
                var SftpListFSImport = "";

                if (cmbSftpListFSImport.SelectedIndex != -1)
                {
                    SftpListFSImport = cmbSftpListFSImport.SelectedItem.ToString();


                }
                var SftpListFSExport = "";

                if (cmbSftpListFSExport.SelectedIndex != -1)
                {
                    SftpListFSExport = cmbSftpListFSExport.SelectedItem.ToString();
                    
                }

                FsList.NewRow();

                FsList.Rows.Add( txtDataTable.Text,
                               txtFileMask.Text,
                               cmbFileType.SelectedItem.ToString(),
                               numLine.Text,
                               txtSeparator.Text,
                               SftpListFSImport,
                               txtDirExportFs.Text,
                               txtSftpDirExportFS.Text,
                               SftpListFSExport,
                               txtDirImportFS.Text,
                               txtSftpDirImportFS.Text);

               

                fileSourceParam.SetFSpConfOnFile(FsList);

                GetFsList();

                dataGridFileSource.AutoResizeColumns();
            }
        }

        private void btnSearchLocalImpFS_Click(object sender, EventArgs e)
        {
            if (Brw.ShowDialog() == DialogResult.OK)
            {
                txtDirImportFS.Text = Brw.SelectedPath; // export path
            }
        }

        private void btnSearchLocalExpFS_Click(object sender, EventArgs e)
        {
            if (Brw.ShowDialog() == DialogResult.OK)
            {
                txtDirExportFs.Text = Brw.SelectedPath; // export path
            }
        }

        private void GetFsList()
        {
            dataGridFileSource.Refresh();

            FsList = fileSourceParam.GetFSConfOnFile();

            dataGridFileSource.DataSource = FsList;
            dataGridFileSource.AutoResizeColumns();
        }

        private void chkSelAll_CheckedChanged(object sender, EventArgs e)
        {
            dataGridFileSource.SelectAll();
        

        }

        private void btnDelFS_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridFileSource.SelectedRows)
            {
               // MessageBox.Show("test", Convert.ToString(row.Index));
               dataGridFileSource.Rows.RemoveAt(row.Index);
            }

              FsList = (DataTable)(dataGridFileSource.DataSource);

              fileSourceParam.SetFSpConfOnFile(FsList);

              GetFsList();

              dataGridFileSource.AutoResizeColumns();


        }

        private void btnSelAll_Click(object sender, EventArgs e)
        {
            dataGridFileSource.SelectAll();

        }

        private void btnUnSelAll_Click(object sender, EventArgs e)
        {
            dataGridFileSource.ClearSelection();
        }

        private void btnSelAllSftp_Click(object sender, EventArgs e)
        {
            dataGridSftpList.SelectAll();
           
        }

        private void btnUnSelAllSftp_Click(object sender, EventArgs e)
        {
            dataGridSftpList.ClearSelection();
        }

        private void btnDelSFTP_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridSftpList.SelectedRows)
            {
                // MessageBox.Show("test", Convert.ToString(row.Index));
                dataGridSftpList.Rows.RemoveAt(row.Index);
            }

            FsList = (DataTable)(dataGridSftpList.DataSource);

            fileSourceParam.SetFSpConfOnFile(FsList);

            GetFsList();

            dataGridSftpList.AutoResizeColumns();
        }
    }
    }

