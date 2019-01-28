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
    class SftpConnection
    {
       
        SftpParam sftpParam = new SftpParam();
        private ProgressBar progressBar = new ProgressBar();
        private FrmLogs progressForm = new FrmLogs();
     


        public void sendFile(string fileMask, string local, string remote)
        {


            try{
                SessionOptions sessionOptions = new SessionOptions();

                sftpParam.GetSftpConfFromFile();
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
                        //transfer

                        TransferOptions transferOptions = new TransferOptions();
                        transferOptions.TransferMode = TransferMode.Binary;
                        transferOptions.ResumeSupport.State = TransferResumeSupportState.Off;
                        transferOptions.FileMask = fileMask;
                       


                        // Download the files in the OUT directory.
                        TransferOperationResult transferOperationResult = 
                            session.PutFiles(local, String.Concat(remote,"/"), false, transferOptions);                            
                        
                        // Check and throw if there are any errors with the transfer operation.
                        transferOperationResult.Check();

                        // Remove files that have been downloaded.
                        /*   foreach (TransferEventArgs transfer in transferOperationResult.Transfers)
                           {
                               RemovalOperationResult removalResult = session.RemoveFiles(session.EscapeFileMask(transfer.FileName));

                               if (!removalResult.IsSuccess)
                               {
                                   eventLogUtility.WriteToEventLog("There was an error removing the file: " + transfer.FileName + " from " + sessionOptions.HostName + ".", EventLogEntryType.Error);
                               }
                           }*/

                        progressForm.releaseMessage();
                        progressForm.showMessage("Files uploaded: ");
                        int upFile = 0;
                        foreach (TransferEventArgs transfer in transferOperationResult.Transfers)
                        {
                            progressForm.showMessage(transfer.FileName);
                            upFile += 1;

                        }
                        progressForm.showMessage("Total uploaded: " + upFile);

                        progressBar.Close();
                        progressForm.saveLog("SFTP_UPLOAD");
                        progressForm.Show();

                        
                       // MessageBox.Show("Transferencia de archivos a "+sftpParam.Hostaname+":"+remote+" exitosa! ", "Transferencia sftp");

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
        
        public void syncDir(string local, string remote, string fileMask)
        {
            
            try
            {
                SessionOptions sessionOptions = new SessionOptions();

                sftpParam.GetSftpConfFromFile();
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
                    
                    session.FileTransferProgress += SessionFileTransferProgress;

                    session.Open(sessionOptions);

                    if(session.Opened)
                    {
                       

                            //transfer options
                            TransferOptions transferOptions = new TransferOptions();
                            transferOptions.TransferMode = TransferMode.Binary;
                            transferOptions.ResumeSupport.State = TransferResumeSupportState.Off;
                            transferOptions.FileMask = fileMask;




                        // Will continuously report progress of synchronization
                        // session.FileTransferred += FileTransferred;


                            progressBar.Show();

                            //sync directory.                        
                            SynchronizationResult synchronizationResult;
                            synchronizationResult = session.SynchronizeDirectories(SynchronizationMode.Both,
                                                                                     local,
                                                                                     remote,
                                                                                     false,
                                                                                     false,
                                                                                     SynchronizationCriteria.Time,
                                                                                     transferOptions);

                            // Check and throw if there are any errors with the transfer operation.
                            synchronizationResult.Check();

                        
                        progressForm.releaseMessage();
                        // Print results descargar
                        progressForm.showMessage("Files downloaded: ");
                        int DownFile = 0;
                        foreach (TransferEventArgs transfer in synchronizationResult.Downloads)
                        {
                            progressForm.showMessage(transfer.FileName);
                            DownFile += 1;
                        }
                        progressForm.showMessage("Total downloaded: "+DownFile);


                        progressForm.showMessage("Files uploaded: ");
                        int upFile = 0;
                        foreach (TransferEventArgs transfer in synchronizationResult.Uploads)
                        {
                            progressForm.showMessage(transfer.FileName);
                            upFile += 1;
                            
                        }
                        progressForm.showMessage("Total uploaded: "+ upFile);

                        progressBar.Close();
                        progressForm.saveLog("SFTP_SYNC");
                        progressForm.Show();
                        
                        // MessageBox.Show("Transferencia de archivos a " + sftpParam.Hostaname + ":" + remote + "exitosa", "Transferencia sftp");

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
 
        private void SessionFileTransferProgress(object sender, FileTransferProgressEventArgs e)
            {

            // Print transfer progress
            Console.WriteLine("\r{0} ({1:P0})", e.FileName, e.FileProgress);

            progressBar.UpdateProgress("Sftp transfer progress",e.Side+":"+e.FileName,e.FileProgress);
            

        }


       

    }
}
