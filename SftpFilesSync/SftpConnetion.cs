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

namespace SftpFilesSync
{
    class SftpConnection
    {
        SftpParam param = new SftpParam();
        

        public void StartConn()
        {
            param.GetValueFromFile();

            try
            {

                using (SftpClient client = new SftpClient(param.Hostaname, param.Port, param.User, param.Password))
                {
                    client.Connect();
                    /*  client.ChangeDirectory(destinationpath);
                      using (FileStream fs = new FileStream(sourcefile, FileMode.Open))
                      {
                          client.BufferSize = 4 * 1024;
                          client.UploadFile(fs, Path.GetFileName(sourcefile));
                      */
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

        public void CloseConn()
        {

        }

        public void TestConn(bool isSSH)
        {

            try
            {
                param.GetValueFromFile();

                var methods = new List<AuthenticationMethod>();

                if (isSSH == true)
                {
                    PrivateKeyFile keyFile = new PrivateKeyFile(@param.Ppk, @param.Password);

                    var keyFiles = new[] { keyFile };

                    methods.Add(new PrivateKeyAuthenticationMethod(param.User, keyFiles));
                    methods.Add(new PasswordAuthenticationMethod(param.User, param.Password));

                    ConnectionInfo con = new ConnectionInfo(param.Hostaname, param.User, methods.ToArray());
                    using (SftpClient client = new SftpClient(con))
                    {
                        client.Connect();

                        if (client.IsConnected)
                        {
                            MessageBox.Show("SFTP CONNECTION SUCCESSFULL");
                            client.Disconnect();
                        }
                        else
                        {
                            MessageBox.Show("SFTP CONNECTION FAILED");

                        }
                    }
                }
                else
                {

                    


             /*       using (FTPClient ftpClient = new FTPClient(param.Use, param.Password, param.Hostaname, param.Port);)
                    {
                        client.Connect();

                        if (client.IsConnected)
                        {
                            MessageBox.Show("SFTP CONNECTION SUCCESSFULL");
                            client.Disconnect();
                        }
                        else
                        {

                            MessageBox.Show("SFTP CONNECTION FAILED");

                        }


                    }*/
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

    }

 }
