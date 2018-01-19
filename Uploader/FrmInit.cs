using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace UPLOADER
{
    public partial class FrmInit : Form
    {

        private DbParam conParams;

        OpenFileDialog of = new OpenFileDialog();

        public FrmInit()
        {
            InitializeComponent();
            InitValue();
        }

        private void InitValue()
        {
            conParams = new DbParam();
            conParams.GetValueFromFile();

            textHostname.Text = conParams.Hostaname;
            textBD.Text = conParams.Dbname;
            textUser.Text = conParams.User;
            textPass.Text = conParams.Password;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            /*INI READ AND SAVE CONNECTION PARAMETERS*/
            conParams.Hostaname = textHostname.Text;
            conParams.User = textUser.Text;
            conParams.Password = textPass.Text;
            conParams.Dbname = textBD.Text;
            /*END READ AND SAVE CONNECTION PARAMETERS*/

            /*Save params values */
            conParams.SetValueOnFile();


            //Test BD CONNETION
            DbConnetion dbConn = new DbConnetion();

            /*Abre conexion para test*/
            dbConn.StartConn();

            if (dbConn.StartConn().State == System.Data.ConnectionState.Open)
            {

                MessageBox.Show("Test de conexión exitoso", "Test de conexión");
                /* this.Close();*/

                dbConn.Closed();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

   

            of.Filter = "Archivo Excel (.xls/.xlsx)| *.xls*";
            of.ShowDialog();

            textFilename.Text = of.FileName;

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

            if(textFilename.Text != "")
            {

                GetDataFromFile(textFilename.Text , textHoja.Text);

                    
               
            }

        }

        private void GetDataFromFile(string file_path, string sheet)
        {
            DataTable excelData = new DataTable();
            FrmGrid GridForm = new FrmGrid();

            try
            {
                string stringconn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file_path + ";Extended Properties=\"Excel 12.0;HDR=Yes;\";";
                OleDbConnection conn = new OleDbConnection(stringconn);

                if (file_path != "")
                {

                    string excelQuery = "select  [Número de carton], " +
                                                "[Delivery], " +
                                                "[Contenedor]," +
                                                "[Material]," +
                                                "[EAN]," +
                                                "[Grid Value]," +
                                                "[Delivery quantity]," +
                                                "[Invoice Date]," +
                                                "[Purchase order no]," +
                                                "[Model Description]," +
                                                "[Gender]," +
                                                "[Division]," +
                                                "[Brand code]," +
                                                "[Product type]," +
                                                "[Sports Description]," +
                                                "[Age Group Description] " +
                                             " from [" + sheet + "$]";



                    OleDbDataAdapter da = new OleDbDataAdapter(excelQuery, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridForm.Show();

                    GridForm.populatedGrid(dt);

                }
                else
                {
                    MessageBox.Show("ER");
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

        }

        static void InsertDataIntoSQLServerUsingSQLBulkCopy(DataTable csvFileData)
        {
            //Test BD CONNETION
            DbConnetion dbConn = new DbConnetion();

            /*Abre conexion para test
            dbConn.StartConn();*/


                using (SqlBulkCopy s = new SqlBulkCopy(dbConn.StartConn()))
                {
                    s.DestinationTableName = "COMPRAS_ADIDAS";
                    foreach (var column in csvFileData.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    s.WriteToServer(csvFileData);
                }
            

        }

    }
}
