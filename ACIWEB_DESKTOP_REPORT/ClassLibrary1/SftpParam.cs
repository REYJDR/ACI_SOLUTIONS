using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace SFTPLibrary
{
    public class SftpParam
    {
        string dir = @"C:\\ACIDesktopReport\Conf\SFTP\";
        string confFile = @"C:\\ACIDesktopReport\Conf\SFTP\SFTP.txt";

        private string hostname;
        private string user;
        private string password;
        private string port;
        private string type;

        public string Hostname { get => hostname; set => hostname = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string Port { get => port; set => port = value; }
        public string Type { get => type; set => type = value; }


        public void SetSftpConfOnFile(DataTable sftpTbl)
        {
           
            bool exists = Directory.Exists(dir);

            if (!exists)
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText(confFile, string.Empty);

            TextWriter file = new StreamWriter(confFile);

  
            if (sftpTbl != null && sftpTbl.Rows.Count > 0)
            {
                for (int i = 0; i < sftpTbl.Rows.Count; i++)
                {

                    file.WriteLine(   sftpTbl.Rows[i].Field<string>(0) + ";"
                                    + sftpTbl.Rows[i].Field<string>(1) + ";"
                                    + sftpTbl.Rows[i].Field<string>(2) + ";"
                                    + sftpTbl.Rows[i].Field<string>(3) + ";"
                                    + sftpTbl.Rows[i].Field<string>(4) + ";"
                                    + sftpTbl.Rows[i].Field<string>(5));

                }
            }


            file.Close();

        }

        public DataTable GetSftpConfOnFile()
        {
            string line;
            string[] S;

            DataTable SftpList = new DataTable("SftpList");
            SftpList.Columns.Add("Conecction name", typeof(String));
            SftpList.Columns.Add("Host", typeof(String));
            SftpList.Columns.Add("Username", typeof(String));
            SftpList.Columns.Add("Password", typeof(String));
            SftpList.Columns.Add("Port", typeof(String));
            SftpList.Columns.Add("Type", typeof(String));

            if (File.Exists(confFile))
            {
                // create reader & open file
                TextReader file = new StreamReader(confFile);


                while ((line = file.ReadLine()) != null)
                {

                    S = line.Split(';');

                    SftpList.Rows.Add( S[0],
                                       S[1],
                                       S[2],
                                       S[3],
                                       S[4],
                                       S[5]);

                }

                // close the stream
                file.Close();


            }

            return SftpList;

        }

    
        public void GetSftpParameters(string confName)
        {
            string line;
            string[] S;
            

            if (File.Exists(confFile))
            {
                // create reader & open file
                TextReader file = new StreamReader(confFile);

                while ((line = file.ReadLine()) != null)
                {
                    S = line.Split(';');

                    if (S[0] == confName)
                    {
                        Hostname = S[1];
                        User = S[2];
                        Password = S[3];
                        Port = S[4];
                        Type = S[5];

                    }
                }
               
                // close the stream
                file.Close();
            }
            
        }





    }
}
