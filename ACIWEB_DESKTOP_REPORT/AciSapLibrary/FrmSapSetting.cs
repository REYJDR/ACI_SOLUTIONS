using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFTPLibrary;

namespace AciSapLibrary
{
    public partial class FrmSapSetting : Form
    {
        DataTable Bapi = new DataTable("bapi");
        SftpConnection sftpConnection = new SftpConnection();
        FolderBrowserDialog Brw = new FolderBrowserDialog();
        SAPParam sapParams;

        public FrmSapSetting()
        {
            InitializeComponent();

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


            Bapi.Columns.Add("Name", typeof(String));
            Bapi.Columns.Add("Template", typeof(String));

            GetBapiList(); 

        }

        //CONFIGURACION SAP
              private void btnSafeExpDirSap_Click(object sender, EventArgs e)
              {
                  string sftpconf = "";
                  if (cmbSftpListSap.SelectedItem != null) { 

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

                  txtRemoteFolderSap.Text = sftpconf;

              }

              sapParams.SetSapExportFolder(txtDirExportSap.Text, sftpconf);




              }

              private void btnSapConfSave_Click(object sender, EventArgs e)
              {

                  //INI READ AND SAVE CONNECTION PARAMETERS
                  sapParams.AppServerHost = txtSapServer.Text;
                  sapParams.SystemNumber = txtSapSysInstance.Text;
                  sapParams.SystemID = txtSapSysId.Text;
                  sapParams.Client = txtSapClient.Text;
                  sapParams.User = txtSapUser.Text;
                  sapParams.Password = txtSapPassword.Text;
                  sapParams.SapRouter = txtSapRouter.Text;
                  sapParams.Language = "EN";
                  sapParams.PoolSize = "5";

                  //END READ AND SAVE CONNECTION PARAMETERS

                  //Save params values 
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

              private void btnAddBapi_Click(object sender, EventArgs e)
              {

                  if(textBapiName.Text !="" && textTemName.Text != "")
                  {

                      bool check = false;

                      foreach (DataGridViewRow row in dataGridBapi.Rows)
                      {
                          if (row.Cells[0].Value.ToString().Equals(textBapiName.Text))
                          {
                              if (row.Cells[1].Value.ToString().Equals(textTemName.Text))
                              {
                                  MessageBox.Show("This configuration values already exist", "Error");
                                  check = true;
                                  break;
                              }

                          }

                      }

                      if (check == false)
                      {

                          Bapi.Rows.Add(textBapiName.Text,
                                        textTemName.Text);

                          sapParams.SetBapiList(Bapi);

                          textBapiName.Text = "";
                          textTemName.Text  = "";

                          GetBapiList();

                      }
                  }
                  else
                  {
                      MessageBox.Show("You must complete all fields", "Error");

                  }



              }

              private void btnSelAllBapi_Click(object sender, EventArgs e)
              {
                  dataGridBapi.SelectAll();
              }

              private void btnUnSelAllBapi_Click(object sender, EventArgs e)
              {
                  dataGridBapi.ClearSelection();
              }

              private void GetBapiList()
              {
                  dataGridBapi.Refresh();

                  Bapi  = sapParams.GetBapiList();

                  dataGridBapi.DataSource = Bapi;
                  dataGridBapi.AutoResizeColumns();
              }

              private void btnDelBapi_Click(object sender, EventArgs e)
              {
                  foreach (DataGridViewRow row in dataGridBapi.SelectedRows)
                  {

                      dataGridBapi.Rows.RemoveAt(row.Index);
                  }

                  Bapi = (DataTable)(dataGridBapi.DataSource);

                  sapParams.SetBapiList(Bapi);

                  GetBapiList();

                  dataGridBapi.AutoResizeColumns();


              }

              

    }
}
