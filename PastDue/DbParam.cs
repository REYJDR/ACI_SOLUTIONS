﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PastDue
{
    class DbParam
    {

        private string hostaname;
        private string dbname;
        private string user;
        private string password;

        public string Hostaname { get => hostaname; set => hostaname = value; }
        public string Dbname { get => dbname; set => dbname = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }


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

            // close the stream     
            file.Close();

        }

        public void GetValueFromFile()
        {

            if (File.Exists(@"C:\\ACIDesktopReport\DBConfig\DbParams.txt"))
            {
                // create reader & open file
                TextReader file = new StreamReader(@"C:\\ACIDesktopReport\DBConfig\DbParams.txt");

                Hostaname = file.ReadLine();
                dbname = file.ReadLine();
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
            if (File.Exists(@"C:\\ACIDesktopReport\DBConfig\DbParams.txt"))
            {

                TextReader file = new StreamReader(@"C:\\ACIDesktopReport\DBConfig\DbParams.txt");

                Hostaname = file.ReadLine();
                dbname = file.ReadLine();
                User = file.ReadLine();
                Password = file.ReadLine();

                //string connection SQL ADAPTER
                /*strConn =
                "Data Source="+Hostaname +";" +
                "Initial Catalog=" + dbname + ";" +
                "User id=" + User + ";" +
                "Password=" + Password + ";"; */


                //string connection odbc ADAPTER
                strConn = "Driver={Pervasive ODBC Client Interface};" +
                                    "servername=" + Hostaname + ";" +
                                    "dbq=" + dbname + ";" +
                                    "uid=" + User + ";" +
                                    "pwd=" + Password + ";";

                // close the stream
                file.Close();


            }


            return strConn;
        }




    }
}
