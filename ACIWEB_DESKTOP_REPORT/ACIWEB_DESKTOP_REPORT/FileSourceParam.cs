using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace ACIWEB_DESKTOP_REPORT
{
    class FileSourceParam
    {

        string dir = @"C:\\ACIDesktopReport\Conf\FILE_SOURCE\";
        string confFile = @"C:\\ACIDesktopReport\Conf\FILE_SOURCE\FILE_SOURCE.txt";

  

        private string datatable;
        private string mask;
        private string type;
        private string column;
        private string separator;
        private string sftpConImp;
        private string localImpDir;
        private string sftpConImpDir;
        private string sftpConExp;
        private string localExpDir;
        private string sftpConExpDir;

        public string Datatable { get => datatable; set => datatable = value; }
        public string Mask { get => mask; set => mask = value; }
        public string Type { get => type; set => type = value; }
        public string Column { get => column; set => column = value; }
        public string Separator { get => separator; set => separator = value; }
        public string SftpConImp { get => sftpConImp; set => sftpConImp = value; }
        public string LocalImpDir { get => localImpDir; set => localImpDir = value; }
        public string SftpConImpDir { get => sftpConImpDir; set => sftpConImpDir = value; }
        public string SftpConExp { get => sftpConExp; set => sftpConExp = value; }
        public string LocalExpDir { get => localExpDir; set => localExpDir = value; }
        public string SftpConExpDir { get => sftpConExpDir; set => sftpConExpDir = value; }


        public void SetFSpConfOnFile(DataTable FsTbl)
        {

            bool exists = Directory.Exists(dir);

            if (!exists)
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText(confFile, string.Empty);

            TextWriter file = new StreamWriter(confFile);


            if (FsTbl != null && FsTbl.Rows.Count > 0)
            {
                for (int i = 0; i < FsTbl.Rows.Count; i++)
                {

                    file.WriteLine(   FsTbl.Rows[i].Field<string>(0) + "#"
                                    + FsTbl.Rows[i].Field<string>(1) + "#"
                                    + FsTbl.Rows[i].Field<string>(2) + "#"
                                    + FsTbl.Rows[i].Field<string>(3) + "#"
                                    + FsTbl.Rows[i].Field<string>(4) + "#"
                                    + FsTbl.Rows[i].Field<string>(5) + "#"
                                    + FsTbl.Rows[i].Field<string>(6) + "#"
                                    + FsTbl.Rows[i].Field<string>(7) + "#"
                                    + FsTbl.Rows[i].Field<string>(8) + "#"
                                    + FsTbl.Rows[i].Field<string>(9) + "#"
                                    + FsTbl.Rows[i].Field<string>(10)  );

                }
            }


            file.Close();

        }

        public DataTable GetFSConfOnFile()
        {
            string line;
            string[] S;

            DataTable FsList = new DataTable("FSList");
            FsList.Columns.Add("Data Table", typeof(String));
            FsList.Columns.Add("File mask", typeof(String));
            FsList.Columns.Add("Type", typeof(String));
            FsList.Columns.Add("Column", typeof(String));
            FsList.Columns.Add("Separator", typeof(String));
            FsList.Columns.Add("Imp. SFTP Connection", typeof(String));
            FsList.Columns.Add("Imp. Local Folder", typeof(String));
            FsList.Columns.Add("Imp. Remote Folder", typeof(String));
            FsList.Columns.Add("Exp. SFTP Connection", typeof(String));
            FsList.Columns.Add("Exp. Local Folder", typeof(String));
            FsList.Columns.Add("Exp. Remote Folder", typeof(String));

            if (File.Exists(confFile))
            {
                // create reader & open file
                TextReader file = new StreamReader(confFile);


                while ((line = file.ReadLine()) != null)
                {

                    S = line.Split('#');

                    FsList.Rows.Add(
                               S[0],
                               S[1],
                               S[2],
                               S[3],
                               S[4],
                               S[5],
                               S[6],
                               S[7],
                               S[8],
                               S[9],
                               S[10]);

                }

                // close the stream
                file.Close();


            }

            return FsList;

        }


        public void GetFSParameters(string confName)
        {
            string line;
            string[] S;


            if (File.Exists(confFile))
            {
                // create reader & open file
                TextReader file = new StreamReader(confFile);

                while ((line = file.ReadLine()) != null)
                {
                    S = line.Split('#');

                    if (S[0] == confName)
                    {
                        Datatable = S[0];
                        Mask = S[1];
                        Type = S[2];
                        Column = S[3];
                        Separator = S[4];
                        SftpConImp = S[5];
                        LocalImpDir = S[6];
                        SftpConImpDir = S[7];
                        SftpConExp = S[8];
                        LocalExpDir = S[9];
                        SftpConExpDir = S[10];
                    
                    }
                }

                // close the stream
                file.Close();
            }

        }




    }
}
