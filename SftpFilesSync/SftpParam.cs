using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SftpFilesSync
{
    class SftpParam
    {

        private string hostaname;
        private int port;
        private string user;
        private string password;

        public string Hostaname { get => hostaname; set => hostaname = value; }
        public int Port { get => port; set => port = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }


        public void SetValueOnFile()
        {
            File.WriteAllText("SftpParams.txt", string.Empty);

            TextWriter file = new StreamWriter("SftpParams.txt");

            // write lines of text to the file
            file.WriteLine(Hostaname);
            file.WriteLine(port);
            file.WriteLine(User);
            file.WriteLine(Password);

            // close the stream     
            file.Close();

        }

        public void GetValueFromFile()
        {

            if (File.Exists("SftpParams.txt"))
            {
                // create reader & open file
                TextReader file = new StreamReader("SftpParams.txt");

                Hostaname = file.ReadLine();
                port = Convert.ToInt32(file.ReadLine());
                User = file.ReadLine();
                Password = file.ReadLine();


                // close the stream
                file.Close();
            }

        }

        public string ConString()
        {
            string strConn = "";

            // create reader & open file
            if (File.Exists("SftpParams.txt"))
            {

                TextReader file = new StreamReader("SftpParams.txt");

                Hostaname = file.ReadLine();
                port = Convert.ToInt32(file.ReadLine());
                User = file.ReadLine();
                Password = file.ReadLine();

                strConn = "";

                // close the stream
                file.Close();


            }


            return strConn;
        }




    }
}
