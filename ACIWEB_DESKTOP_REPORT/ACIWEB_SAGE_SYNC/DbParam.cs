using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data;

namespace ACIWEB_SAGE_SYNC
{
    class DbParam
    {

        private string hostaname;
        private string dbname;
        private string user;
        private string password;
        private string idComp;
        private string nameComp;
        private string sageConn;



        public string Hostaname { get => hostaname; set => hostaname = value; }
        public string Dbname { get => dbname; set => dbname = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string IdComp { get => idComp; set => idComp = value; }
        public string NameComp { get => nameComp; set => nameComp = value; }
        public string SageConn { get => sageConn; set => sageConn = value; }


        public void SetValueOnFile()
        {
            bool exists = Directory.Exists(@"C:\\AciwebDesktopReport\Db\");

            if (!exists)
            {
                Directory.CreateDirectory(@"C:\\AciwebDesktopReport\Db\");
            }

            File.WriteAllText(@"C:\\AciwebDesktopReport\Db\DbParams.txt", string.Empty);

            TextWriter file = new StreamWriter(@"C:\\AciwebDesktopReport\Db\DbParams.txt");

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

            if (File.Exists(@"C:\\AciwebDesktopReport\Db\DbParams.txt"))
            {
                // create reader & open file
                TextReader file = new StreamReader(@"C:\\AciwebDesktopReport\Db\DbParams.txt");

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
            if (File.Exists(@"C:\\AciwebDesktopReport\Db\DbParams.txt"))
            {

                TextReader file = new StreamReader(@"C:\\AciwebDesktopReport\Db\DbParams.txt");

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
                          "DATABASE=" + dbname + ";" +
                          "UID=" + User + ";" +
                          "PASSWORD=" + Password + ";" +
                          "SslMode = none;";


                // close the stream
                file.Close();


            }


            return strConn;
        }

        public void SetSageConfOnFile(DataTable sageTbl, string URL)
        {

            bool exists = Directory.Exists(@"C:\\AciSageSync\Db\");

            if (!exists)
            {
                Directory.CreateDirectory(@"C:\\AciSageSync\Db\");
            }

            File.WriteAllText(@"C:\\AciSageSync\Db\SageCompanyConfig.txt", string.Empty);

            TextWriter file = new StreamWriter(@"C:\\AciSageSync\Db\SageCompanyConfig.txt");

            file.WriteLine(URL);


            if (sageTbl != null && sageTbl.Rows.Count > 0)
            {
                for (int i = 0; i < sageTbl.Rows.Count; i++)
                {

                    file.WriteLine   (
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

            if (File.Exists(@"C:\\AciSageSync\Db\SageCompanyConfig.txt"))
            {
                // create reader & open file
                TextReader file = new StreamReader(@"C:\\AciSageSync\Db\SageCompanyConfig.txt");


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
            string line="";


            if (File.Exists(@"C:\\AciSageSync\Db\SageCompanyConfig.txt"))
            {
                // create reader & open file
                TextReader file = new StreamReader(@"C:\\AciSageSync\Db\SageCompanyConfig.txt");
                
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
    }

}

