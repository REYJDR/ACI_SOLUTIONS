﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UPLOADER
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
            File.WriteAllText("SqlDb.txt", string.Empty);

            TextWriter file = new StreamWriter("SqlDb.txt");

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

            if (File.Exists("SqlDb.txt"))
            {
                // create reader & open file
                TextReader file = new StreamReader("SqlDb.txt");

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
            if (File.Exists("SqlDb.txt"))
            {

                TextReader file = new StreamReader("SqlDb.txt");

                Hostaname = file.ReadLine();
                dbname = file.ReadLine();
                User = file.ReadLine();
                Password = file.ReadLine();


                strConn =
                "Data Source="+Hostaname +";" +
                "Initial Catalog=" + dbname + ";" +
                "User id=" + User + ";" +
                "Password=" + Password + ";";



            /*    strConn = "Driver={Pervasive ODBC Client Interface};" +
                                    "servername=" + Hostaname + ";" +
                                    "dbq=" + dbname + ";" +
                                    "uid=" + User + ";" +
                                    "pwd=" + Password;*/

                // close the stream
                file.Close();


            }


            return strConn;
        }




    }
}
