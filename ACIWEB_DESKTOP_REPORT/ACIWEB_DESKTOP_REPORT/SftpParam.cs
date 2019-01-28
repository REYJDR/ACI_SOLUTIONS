using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ACIWEB_DESKTOP_REPORT
{
    class SftpParam
    {
        private string hostaname;
        private string user;
        private string password;
        private string port;




        public string Hostaname { get => hostaname; set => hostaname = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string Port { get => port; set => port = value; }



        public void SetSftpConfOnFile()
        {
            bool exists = Directory.Exists(@"C:\\ACIDesktopReport\Conf\");

            if (!exists)
            {
                Directory.CreateDirectory(@"C:\\ACIDesktopReport\Conf\");
            }

            File.WriteAllText(@"C:\\ACIDesktopReport\Conf\sftp.conf", string.Empty);

            TextWriter file = new StreamWriter(@"C:\\ACIDesktopReport\Conf\sftp.conf");

            // write lines of text to the file
            file.WriteLine(Hostaname);
            file.WriteLine(User);
            file.WriteLine(Password);
            file.WriteLine(Port);
            

            // close the stream     
            file.Close();

        }

        public void GetSftpConfFromFile()
        {

            if (File.Exists(@"C:\\ACIDesktopReport\Conf\sftp.conf"))
            {
                // create reader & open file
                TextReader file = new StreamReader(@"C:\\ACIDesktopReport\Conf\sftp.conf");

                Hostaname = file.ReadLine();
                User = file.ReadLine();
                Password = file.ReadLine();
                Port = file.ReadLine();

                // close the stream
                file.Close();
            }



        }





    }
}
