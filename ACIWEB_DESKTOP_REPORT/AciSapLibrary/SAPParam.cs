using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;


namespace AciSapLibrary
{
    class SAPParam
    {

        private string appServerHost;
        private string systemNumber;
        private string systemID;
        private string user;
        private string password;
        private string client;
        private string language;
        private string poolSize;
        private string saprouter;



        public string AppServerHost { get => appServerHost; set => appServerHost = value; }
        public string SystemNumber { get => systemNumber; set => systemNumber = value; }
        public string SystemID { get => systemID; set => systemID = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string Client { get => client; set => client = value; }
        public string Language { get => language; set => language = value; }
        public string PoolSize { get => poolSize; set => poolSize = value; }
        public string SapRouter { get => saprouter; set => saprouter = value; }
        private string localFolder;
        private string remoteFolder;

        public string LocalFolder { get => localFolder; set => localFolder = value; }
        public string RemoteFolder { get => remoteFolder; set => remoteFolder = value; }


        private string dir =  @"C:\\ACIDesktopReport\SAP\conf\";
        private string filedir = @"C:\\ACIDesktopReport\SAP\conf\SAPParams.txt";
        private string bapis = @"C:\\ACIDesktopReport\SAP\conf\SAPBapis.txt";



        public string GetBapiTemp(string template)
        {
            string tempName = "";


            var list =  GetBapiList();

            foreach (DataRow row in list.Rows)
            {
                if(row["template"].ToString() == template)
                {
                    tempName = row["name"].ToString();
                    break;

                }
               
            }


            return tempName;
        }



        public void SetBapiList(DataTable FsTbl)
        {

            bool exists = Directory.Exists(dir);

            if (!exists)
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText(bapis, string.Empty);

            TextWriter file = new StreamWriter(bapis);


            if (FsTbl != null && FsTbl.Rows.Count > 0)
            {
                for (int i = 0; i < FsTbl.Rows.Count; i++)
                {

                    file.WriteLine(FsTbl.Rows[i].Field<string>(0) + "#"
                                    + FsTbl.Rows[i].Field<string>(1));

                }
            }


            file.Close();

        }

        
        public DataTable GetBapiList()
        {
            string line;
            string[] S;

            DataTable FsList = new DataTable("bapi");
            FsList.Columns.Add("name", typeof(String));
            FsList.Columns.Add("template", typeof(String));
          

            if (File.Exists(bapis))
            {
                // create reader & open file
                TextReader file = new StreamReader(bapis);


                while ((line = file.ReadLine()) != null)
                {

                    S = line.Split('#');

                    FsList.Rows.Add(
                               S[0],
                               S[1]);

                }

                // close the stream
                file.Close();


            }

            return FsList;

        }


        public void SetValueOnFile()
        {
           
            bool exists = Directory.Exists(dir);

            if (!exists)
            {
                Directory.CreateDirectory(dir);
            }


            File.WriteAllText(filedir, string.Empty);

            TextWriter file = new StreamWriter(filedir);
            

            // write lines of text to the file
                file.WriteLine(AppServerHost);
                file.WriteLine(SystemNumber);
                file.WriteLine(SystemID);
                file.WriteLine(User);
                file.WriteLine(Password);
                file.WriteLine(Client);
                file.WriteLine(Language);
                file.WriteLine(PoolSize);
                file.WriteLine(SapRouter);
            

            // close the stream     
            file.Close();

        }

        public void GetValueFromFile()
        {

            if (File.Exists(filedir))
            {
                // create reader & open file
                TextReader file = new StreamReader(filedir);

                AppServerHost = file.ReadLine();
                SystemNumber = file.ReadLine();
                SystemID = file.ReadLine();
                User = file.ReadLine();
                Password = file.ReadLine();
                Client = file.ReadLine();
                Language = file.ReadLine();
                PoolSize = file.ReadLine();
                SapRouter = file.ReadLine();

                // write lines of text to the file

                // close the stream
                file.Close();
            }

        }

      
        public void SetSapExportFolder(string localfolder, string remoteFolder)
        {

            bool exists = Directory.Exists(@"C:\\ACIDesktopReport\Conf\SAP\");

            if (!exists)
            {
                Directory.CreateDirectory(@"C:\\ACIDesktopReport\Conf\SAP\");
            }


            File.WriteAllText(@"C:\\ACIDesktopReport\Conf\SAP\export.conf", string.Empty);

            TextWriter file = new StreamWriter(@"C:\\ACIDesktopReport\Conf\SAP\export.conf");

            // write lines of text to the file
            file.WriteLine(localfolder);
            file.WriteLine(remoteFolder);

            file.Close();

        }

        public void GetSapExportFolder()
        {


            if (File.Exists(@"C:\\ACIDesktopReport\Conf\SAP\export.conf"))
            {
                // create reader & open file
                TextReader file = new StreamReader(@"C:\\ACIDesktopReport\Conf\SAP\export.conf");

                localFolder = file.ReadLine();
                remoteFolder = file.ReadLine();

            }

        }

    }
}
