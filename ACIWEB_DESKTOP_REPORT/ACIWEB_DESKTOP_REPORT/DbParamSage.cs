using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace ACIWEB_DESKTOP_REPORT
{
    class DbParamSage
    {


        private string localFolder;
        private string remoteFolder;

        public string LocalFolder { get => localFolder; set => localFolder = value; }
        public string RemoteFolder { get => remoteFolder; set => remoteFolder = value; }

        public void SetSageConfOnFile(DataTable sageTbl, string URL)
        {

            bool exists = Directory.Exists(@"C:\\ACIDesktopReport\DB\SAGE\");

            if (!exists)
            {
                Directory.CreateDirectory(@"C:\\ACIDesktopReport\DB\SAGE\");
            }

            File.WriteAllText(@"C:\\ACIDesktopReport\DB\SAGE\SageCompanyConfig.txt", string.Empty);

            TextWriter file = new StreamWriter(@"C:\\ACIDesktopReport\DB\SAGE\SageCompanyConfig.txt");

            file.WriteLine(URL);


            if (sageTbl != null && sageTbl.Rows.Count > 0)
            {
                for (int i = 0; i < sageTbl.Rows.Count; i++)
                {

                    file.WriteLine(
                                      sageTbl.Rows[i].Field<bool>(0) + ";"
                                    + sageTbl.Rows[i].Field<string>(1) + ";"
                                    + sageTbl.Rows[i].Field<string>(2) + ";"
                                    + sageTbl.Rows[i].Field<string>(3) + ";"
                                    + sageTbl.Rows[i].Field<string>(4) + ";"
                                    + sageTbl.Rows[i].Field<string>(5));

                }
            }


            file.Close();

        }
        
        public DataTable GetSageConf()
        {
            string line;
            string[] S;

            DataTable sageConf = new DataTable("sage");
            sageConf.Columns.Add("Selecction", typeof(bool));
            sageConf.Columns.Add("Company Name", typeof(String));
            sageConf.Columns.Add("DB Name ", typeof(String));
            sageConf.Columns.Add("User", typeof(String));
            sageConf.Columns.Add("Pass", typeof(String));
            sageConf.Columns.Add("Host", typeof(String));

            if (File.Exists(@"C:\\ACIDesktopReport\DB\SAGE\SageCompanyConfig.txt"))
            {
                // create reader & open file
                TextReader file = new StreamReader(@"C:\\ACIDesktopReport\DB\SAGE\SageCompanyConfig.txt");


                file.ReadLine(); //le primera linea

                while ((line = file.ReadLine()) != null)
                {

                    S = line.Split(';');

                    sageConf.Rows.Add(
                               S[0],
                               S[1],
                               S[2],
                               S[3],
                               S[4],
                               S[5]);

                }

                // close the stream
                file.Close();


            }

            return sageConf;

        }

        public string GetSageURL()
        {
            string line = "";


            if (File.Exists(@"C:\\ACIDesktopReport\DB\SAGE\SageCompanyConfig.txt"))
            {
                // create reader & open file
                TextReader file = new StreamReader(@"C:\\ACIDesktopReport\DB\SAGE\SageCompanyConfig.txt");

                line = file.ReadLine();


                // close the stream
                file.Close();


            }

            return line;

        }

        public string SageConString(List<string> Param)
        {
            string strConn = "";

            //string connection odbc ADAPTER
            strConn = "Driver={Pervasive ODBC Client Interface};" +
                                "servername=" + Param[0] + ";" +
                                "dbq=" + Param[1] + ";" +
                                "uid=" + Param[2] + ";" +
                                "pwd=" + Param[3] + ";";

            return strConn;

        }


        public void SetSageExportFolder(string localfolder, string remotefolder)
        {

            bool exists = Directory.Exists(@"C:\\ACIDesktopReport\Conf\SAGE\");

            if (!exists)
            {
                Directory.CreateDirectory(@"C:\\ACIDesktopReport\Conf\SAGE\");
            }


            File.WriteAllText(@"C:\\ACIDesktopReport\Conf\SAGE\export.conf", string.Empty);

            TextWriter file = new StreamWriter(@"C:\\ACIDesktopReport\Conf\SAGE\export.conf");

            // write lines of text to the file
            file.WriteLine(localfolder);
            file.WriteLine(remotefolder);

            file.Close();

        }

        public void GetSageExportFolder()
        {
            

            if (File.Exists(@"C:\\ACIDesktopReport\Conf\SAGE\export.conf"))
            {
                // create reader & open file
                TextReader file = new StreamReader(@"C:\\ACIDesktopReport\Conf\SAGE\export.conf");

                localFolder = file.ReadLine();
                remoteFolder = file.ReadLine();
            }

            
        }


        }
}
