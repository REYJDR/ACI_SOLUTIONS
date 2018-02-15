using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AciWebFilesSync
{
    public partial class FrmInit : Form
    {
        private SyncParam conParams;

        SyncConnection Conn = new SyncConnection();

        OpenFileDialog of = new OpenFileDialog();

     
        public static bool cancelState = false;

        public FrmInit()
        {
            InitializeComponent();
            InitValue();
            InitBgWork();

  
        }

        /*Background Worker*/
        private void InitBgWork()
        {
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

                Conn.StartSync(sender as BackgroundWorker);//ACTIVA EL PROCESO EN FONDO

  
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                setMsgtext("Process was canceled", 0);
                Conn.SetLog("Process was canceled by program", "Sync");
            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                   

                    if (!cancelState)
                    {
                        setMsgtext("Process was completed", 0);
                       
                        Thread.Sleep(5000);
                        backgroundWorker.RunWorkerAsync();

                    }

                    if(cancelState == true)
                    {
                        cancelState = false;
                        setMsgtext("Process was stopped", 0);
                        Conn.SetLog("Process was stopped by user", "Sync");
                        btnConnect.Enabled = true;
                        groupBox2.Enabled = true;
                        groupBox3.Enabled = true;
                        
                    }
                    
                }
            }

            
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            setMsgtext(e.UserState.ToString(), e.ProgressPercentage);

        }
        /* Background Worker*/
         
        private void InitValue()
        {
            conParams = new SyncParam();
            conParams.GetValueFromFile();

            textServer.Text = conParams.Hostaname;
            textPort.Text = Convert.ToString(conParams.Port);
            textUser.Text = conParams.User;
            textPass.Text = conParams.Password;
            textRePath.Text = conParams.RePath;
            textLoPath.Text = conParams.LoPath;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
           

        }
    
        private void btnLoPath_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();

            fbd.ShowDialog();

            textLoPath.Text = fbd.SelectedPath;
        }

        public  void setMsgtext(string text, int porcentage)
        {
            if(!cancelState)
            {
                StatusLabel.Text = text;
                progressBar.Value = porcentage;
                statusStrip1.Refresh();

            }
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            /*INI READ AND SAVE CONNECTION PARAMETERS*/
            conParams.Hostaname = textServer.Text;
            conParams.User = textUser.Text;
            conParams.Password = textPass.Text;
            conParams.Port = Convert.ToInt32(textPort.Text);
            conParams.RePath = textRePath.Text;
            conParams.LoPath = textLoPath.Text;
            /*END READ AND SAVE CONNECTION PARAMETERS*/

            /*Save params values */
            conParams.SetValueOnFile();

            btnCancel.Enabled = true;
            btnConnect.Enabled = false;

            groupBox2.Enabled = false;
            groupBox3.Enabled = false;

            progressBar.Enabled = true;

            cancelState = false;

            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
           



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            backgroundWorker.CancelAsync();
            btnCancel.Enabled = false;


            setMsgtext("Stopping process...", 0);
            cancelState = true;
           
        }
    }
}
