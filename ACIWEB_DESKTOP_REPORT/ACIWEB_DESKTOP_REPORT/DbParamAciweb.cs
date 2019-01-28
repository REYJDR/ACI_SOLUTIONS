using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ACIWEB_DESKTOP_REPORT
{
    class DbParamAciweb
    {

        private string hostaname;
        private string dbname;
        private string user;
        private string password;
        private string idComp;
        private string nameComp;
        private string localFolder;
        private string remoteFolder;

        
        public string Hostaname { get => hostaname; set => hostaname = value; }
        public string Dbname { get => dbname; set => dbname = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string IdComp { get => idComp; set => idComp = value; }
        public string NameComp { get => nameComp; set => nameComp = value; }
        public string LocalFolder { get => localFolder; set => localFolder = value; }
        public string RemoteFolder { get => remoteFolder; set => remoteFolder = value; }





        public void SetValueOnFile()
        {
            bool exists = Directory.Exists(@"C:\\ACIDesktopReport\DB\ACIWEB\");

            if (!exists)
            {
                Directory.CreateDirectory(@"C:\\ACIDesktopReport\DB\ACIWEB\");
            }


            File.WriteAllText(@"C:\\ACIDesktopReport\DB\ACIWEB\DbParams.txt", string.Empty);

            TextWriter file = new StreamWriter(@"C:\\ACIDesktopReport\DB\ACIWEB\DbParams.txt");

            // write lines of text to the file
            file.WriteLine(Hostaname);
            file.WriteLine(dbname);
            file.WriteLine(User);
            file.WriteLine(Password);
            file.WriteLine(IdComp);
            file.WriteLine(NameComp);



            // close the stream     
            file.Close();

        }

        public void GetValueFromFile()
        {

            if (File.Exists(@"C:\\ACIDesktopReport\DB\ACIWEB\DbParams.txt"))
            {
                // create reader & open file
                TextReader file = new StreamReader(@"C:\\ACIDesktopReport\DB\ACIWEB\DbParams.txt");

                Hostaname = file.ReadLine();
                dbname = file.ReadLine();
                User = file.ReadLine();
                Password = file.ReadLine();
                IdComp = file.ReadLine();
                NameComp = file.ReadLine();



                // close the stream
                file.Close();
            }

        }

        public string ConString()
        {
            string strConn = "";

            // create reader & open file
            if (File.Exists(@"C:\\ACIDesktopReport\DB\ACIWEB\DbParams.txt"))
            {

                TextReader file = new StreamReader(@"C:\\ACIDesktopReport\DB\ACIWEB\DbParams.txt");

                Hostaname = file.ReadLine();
                dbname = file.ReadLine();
                User = file.ReadLine();
                Password = file.ReadLine();
                IdComp = file.ReadLine();
                NameComp = file.ReadLine();


                //string connection SQL ADAPTER
                /*strConn =
                "Data Source="+Hostaname +";" +
                "Initial Catalog=" + dbname + ";" +
                "User id=" + User + ";" +
                "Password=" + Password + ";"; */


                //string connection odbc ADAPTER
                /*strConn = "Driver={Pervasive ODBC Client Interface};" +
                                    "servername=" + Hostaname + ";" +
                                    "dbq=" + dbname + ";" +
                                    "uid=" + User + ";" +
                                    "pwd=" + Password + ";";*/



                //string connection mysql ADAPTER
                strConn = "SERVER=" + Hostaname + ";" +
                          "DATABASE=" + dbname +  ";" +
                          "UID=" + User + ";" + 
                          "PASSWORD=" + Password + ";" +
                          "SslMode = none ;ConnectionTimeout=200";


                // close the stream
                file.Close();


            }


            return strConn;
        }


        public void SetAciExportFolder(string localfolder, string remoteFolder)
        {

            bool exists = Directory.Exists(@"C:\\ACIDesktopReport\Conf\ACIWEB\");

            if (!exists)
            {
                Directory.CreateDirectory(@"C:\\ACIDesktopReport\Conf\ACIWEB\");
            }


            File.WriteAllText(@"C:\\ACIDesktopReport\Conf\ACIWEB\export.conf", string.Empty);

            TextWriter file = new StreamWriter(@"C:\\ACIDesktopReport\Conf\ACIWEB\export.conf");

            // write lines of text to the file
            file.WriteLine(localfolder);
            file.WriteLine(remoteFolder);

            file.Close();

        }

        public void GetAciExportFolder()
        {
            

            if (File.Exists(@"C:\\ACIDesktopReport\Conf\ACIWEB\export.conf"))
            {
                // create reader & open file
                TextReader file = new StreamReader(@"C:\\ACIDesktopReport\Conf\ACIWEB\export.conf");

                localFolder = file.ReadLine();
                remoteFolder = file.ReadLine();

            }

        }




    }
}
