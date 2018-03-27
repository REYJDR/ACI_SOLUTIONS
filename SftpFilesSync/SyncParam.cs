using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AciWebFilesSync
{
    class SyncParam
    {

        private string hostaname;
        private int port;
        private string user;
        private string password;
        private string rePath;
        private string loPath;
        private string rootPath;

        public string Hostaname { get => hostaname; set => hostaname = value; }
        public int Port { get => port; set => port = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string RePath { get => rePath; set => rePath = value; }
        public string LoPath { get => loPath; set => loPath = value; }
        public string RootPath { get => rootPath; set => rootPath = value; }

        public void SetValueOnFile()
        {
            File.WriteAllText(@"C://AciwebSync/SyncParams.txt", string.Empty);

            TextWriter file = new StreamWriter(@"C://AciwebSync/SyncParams.txt");

            // write lines of text to the file
            file.WriteLine(Hostaname);
            file.WriteLine(port);
            file.WriteLine(User);
            file.WriteLine(Password);
            file.WriteLine(RootPath);
            file.WriteLine(RePath);
            file.WriteLine(LoPath);

            // close the stream     
            file.Close();

        }

        public void GetValueFromFile()
        {

            if (File.Exists(@"C://AciwebSync/SyncParams.txt"))
            {
                // create reader & open file
                TextReader file = new StreamReader(@"C://AciwebSync/SyncParams.txt");

                Hostaname = file.ReadLine();
                port = Convert.ToInt32(file.ReadLine());
                User = file.ReadLine();
                Password = file.ReadLine();
                RootPath = file.ReadLine();
                RePath = file.ReadLine();
                LoPath = file.ReadLine();

                // close the stream
                file.Close();
            }

        }

        public string ConString()
        {
            string strConn = "";

            // create reader & open file
            if (File.Exists(@"C://AciwebSync/SyncParams.txt"))
            {

                TextReader file = new StreamReader(@"C://AciwebSync/SyncParams.txt");

                Hostaname = file.ReadLine();
                port = Convert.ToInt32(file.ReadLine());
                User = file.ReadLine();
                Password = file.ReadLine();
                RootPath = file.ReadLine();
                RePath = file.ReadLine();
                LoPath = file.ReadLine();
                strConn = "";

                // close the stream
                file.Close();


            }


            return strConn;
        }




    }
}
