using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.IO;
using CsvHelper;


namespace ACIWEB_DESKTOP_REPORT
{
    class DataSourceFS
    {
        public static List<string> FSParams;
        public static DataSet repPreview;
        public static bool doQuery;
        public static DataTable queryTable;
        public static bool theresData;
        public static Int32 Col;

        public void GetData()
        {

            var line = "";
            queryTable = new DataTable();

            queryTable.Columns.Add("filename", typeof(String));

            for (int i = 0; i < Col; i++)
            {
                queryTable.Columns.Add("col-" + i, typeof(String));

            }

            string[] files = Directory.GetFiles(FSParams[4], FSParams[3]+"*."+ FSParams[5]);
              
                string filename;
                string fileNameNoExt;
                string fileExt;
                string[] ColVal = null;

                for (int i = 0; i < files.Length; i++)
                {
                    filename = Path.GetFileName(files[i]);
                    fileExt = Path.GetExtension(files[i]);
                    fileNameNoExt = Path.GetFileNameWithoutExtension(files[i]);

                if(fileExt == ".txt")
                {

                    TextReader file = new StreamReader(FSParams[4] + "/" + filename);


                    while ((line = file.ReadLine()) != null)
                    {

                        queryTable.NewRow();

                        var sepa = Convert.ToChar(FSParams[2]);


                        line = String.Concat(fileNameNoExt, sepa, line);
                      

                        ColVal = line.Split(sepa);

                        queryTable.Rows.Add(ColVal);

                    }

                }

                if (fileExt == ".csv")
                {

                    var dt = new DataTable();
                    

                    using (var file = new StreamReader(FSParams[4] + "/" + filename))
                    using (var csv = new CsvReader(file))
                    {
                        csv.Configuration.Delimiter = FSParams[2];
                        csv.Configuration.MissingFieldFound = null;

                        // Do any configuration to `CsvReader` before creating CsvDataReader.
                        using (var dr = new CsvDataReader(csv))
                        {
                           
                            dt.Load(dr);
                            
                        }
                    }

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        var sepa = Convert.ToChar(FSParams[2]);

                        foreach (DataRow rows in dt.Rows)
                        {
                            queryTable.NewRow();

                            var sepaTemp = "^";

                            line = String.Concat(fileNameNoExt, sepaTemp, string.Join(sepaTemp, rows.ItemArray));

                            ColVal = line.Split(Convert.ToChar(sepaTemp));

                            queryTable.Rows.Add(ColVal);
                        }


                      

                    }

                }

            }


        }

           
       

        public DataSet SetFileSource() //facturas abiertas
        {
            List<string> lineCollection = new List<string>();


            try
            {
                DataTable table = new DataTable(FSParams[0]);

                if (repPreview is null)
                {

                    Col = Convert.ToInt32(FSParams[1]);

                    table.Columns.Add("filename", typeof(String));

                    for (int i = 0; i < Col; i++)
                    {
                        table.Columns.Add("col-" + i, typeof(String));

                    }

                    repPreview = new DataSet();
                    repPreview.Tables.Add(table);

                }

                if (doQuery == true)
                {
                    GetData();
                    if (queryTable != null && queryTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < queryTable.Rows.Count; i++)
                        {

                            table.NewRow();
                            
                            table.ImportRow(queryTable.Rows[i]);

                        }

                        theresData = true;

                    }
                    else
                    {

                        theresData = false;

                    }

                    doQuery = false;






                }
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }


            return repPreview;
        }






    }
}
