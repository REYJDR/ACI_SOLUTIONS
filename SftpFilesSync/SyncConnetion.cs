using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Renci.SshNet;
using System.IO;
using System.Net;
using Microsoft.Synchronization.Files;
using Microsoft.Synchronization;
using WebDav;
using System.ComponentModel;

namespace AciWebFilesSync
{
    class SyncConnection
    {
        SyncParam param = new SyncParam();
       
       
        public void StartSync(BackgroundWorker bw)
        {

            try
            {
                param.GetValueFromFile();

                var methods = new List<AuthenticationMethod>();
                

                bw.ReportProgress(0, "Reading directory...");

                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(string.Concat(param.RootPath, param.RePath));

                    if (!dirInfo.Exists)
                    {
                        string mapping = "net use * https://" + param.Hostaname + ":" + param.Port + param.RePath + " /User:" + param.User + " " + param.Password;
                        System.Diagnostics.Process.Start(mapping);

                    }


                    string RemotePath = param.RootPath + param.RePath + "File.ID";

                    string LocalPath = param.LoPath + "File.ID";
                    Guid sourceId = GetSyncID(RemotePath);
                    Guid destId = GetSyncID(LocalPath);

                    // Set options for the synchronization session. In this case, options specify
                    // that the application will explicitly call FileSyncProvider.DetectChanges, and
                    // that items should be moved to the Recycle Bin instead of being permanently deleted.
                    FileSyncOptions options = FileSyncOptions.ExplicitDetectChanges |
                    FileSyncOptions.RecycleDeletedFiles | FileSyncOptions.RecyclePreviousFileOnUpdates |
                    FileSyncOptions.RecycleConflictLoserFiles;

                    FileSyncScopeFilter filter = new FileSyncScopeFilter();
                    filter.FileNameExcludes.Add("*.metadata");
                    filter.FileNameExcludes.Add("File.ID");

                    //create a FileSyncProvider object by passing the SyncID and the
                    //source location.
                    FileSyncProvider sourceReplica = new FileSyncProvider(sourceId, string.Concat(param.RootPath, param.RePath), filter, options);


                    //create a FileSyncProvider object by passing the SyncID and the
                    //destination location.
                    FileSyncProvider destReplica = new FileSyncProvider(destId, param.LoPath, filter, options);

                    //DETECT CHANGES
                    sourceReplica.DetectChanges();
                    destReplica.DetectChanges();

                    //Initialize the agent which actually performs the
                    //synchronization.
                    // SyncAgent agent = new SyncAgent();
                    SyncOrchestrator agent = new SyncOrchestrator();



                    //assign the source replica as the Local Provider and the
                    //destination replica as the Remote provider so that the agent
                    //knows which is the source and which one is the destination.
                    agent.LocalProvider = sourceReplica;
                    agent.RemoteProvider = destReplica;


                    //Set the direction of synchronization from Source to destination
                    //as this is a one way synchronization. You may use
                    //SyncDirection.Download if you want the Local replica to be
                    //treated as Destination and the Remote replica to be the source;
                    //use SyncDirection.DownloadAndUpload or
                    //SyncDirection.UploadAndDownload for two way synchronization.
                    agent.Direction = SyncDirectionOrder.DownloadAndUpload;


                    agent.SessionProgress += new EventHandler<SyncStagedProgressEventArgs>(agent_SessionProgress);

                    //make a call to the Synchronize method for starting the
                    //synchronization process.

                    SyncOperationStatistics syncStats = agent.Synchronize();



                    //Escribe log del proceso.
                    if (syncStats.UploadChangesTotal > 0 || syncStats.DownloadChangesTotal > 0)
                    {
                        string log = "Start Time: " + syncStats.SyncStartTime + " Uploaded: " + syncStats.UploadChangesTotal + " Downloaded: " + syncStats.DownloadChangesTotal + " Complete Time: " + syncStats.SyncEndTime;
                        SetLog(log, "Sync");

                    }

                    // close the stream     



                    void agent_SessionProgress(object sender, SyncStagedProgressEventArgs args)
                    {

                        int porcentage = 0;

                        if (args.TotalWork > 0)
                        {
                            porcentage = Convert.ToInt32(100 * args.CompletedWork / args.TotalWork);
                            bw.ReportProgress(porcentage, "Syncronizing");
                        }

                        if (args.TotalWork == 0)
                        {

                            bw.ReportProgress(0, "Syncronized");

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

                    SetLog(errorMessage, "Error");
                }




            }
                catch (Exception theException)
                {
                    String errorMessage;
                    errorMessage = "Error: ";
                    errorMessage = String.Concat(errorMessage, theException.Message);
                    errorMessage = String.Concat(errorMessage, " Line: ");
                    errorMessage = String.Concat(errorMessage, theException.Source);

                    SetLog(errorMessage, "Error");
                }

                
        }

        public void SetLog(string msg, string type)
        {
            FrmInit frmInit = new FrmInit();

            //Escribe log del proceso.
            if (!File.Exists(@"C://AciwebSync/AciSync.log"))
            {
                if (!Directory.Exists(@"C://AciwebSync/AciSync.log"))
                {
                    Directory.CreateDirectory(@"C://AciwebSync/");
                }
                File.WriteAllText(@"C://AciwebSync/AciSync.log", string.Empty);

            }

            string content = "***" + DateTime.Now + " " + type + ": " + msg+"\r\n";
            File.AppendAllText(@"C://AciwebSync/AciSync.log", content);
            // close the stream     


        }

        private static Guid GetSyncID(string syncFilePath)
        {

            Guid guid;
            SyncId replicaID = null;
            if (!File.Exists(syncFilePath)) //The ID file doesn't exist. 
                                            //Create the file and store the guid which is used to 
                                            //instantiate the instance of the SyncId.

            {

                guid = Guid.NewGuid();
                replicaID = new SyncId(guid);
                FileStream fs = File.Open(syncFilePath, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(guid.ToString());
                sw.Close();
                fs.Close();

            }

            else

            {

                FileStream fs = File.Open(syncFilePath, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string guidString = sr.ReadLine();
                guid = new Guid(guidString);
                replicaID = new SyncId(guid);
                sr.Close();
                fs.Close();

            }

            return (guid);

        }

    }

 }
