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
using System.Data.Odbc;
using System.Data.OleDb;


namespace CollectionISP
{
    public partial class frmInit : Form
    {
        public static string dateRangeInv;
        public static string dateRangeRep;
        public static string dateCollectOF;


        private DbParam conParams;

        DbQuery dbquery = new DbQuery();

        OpenFileDialog of = new OpenFileDialog();
        

        public frmInit()
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
            DbConnetionPervasive dbConn = new DbConnetionPervasive();

            /*Abre conexion para test*/
            dbConn.StartConn();

            if (dbConn.StartConn().State == System.Data.ConnectionState.Open)
            {

                MessageBox.Show("Test de conexión exitoso", "Test de conexión");
                /* this.Close();*/

                //dbConn.Closed();
            }

        }

        private void FrmInit_Load(object sender, EventArgs e)
        {

            setDatesRange();

        }

        
        private void setDatesRange()
        {

            if (dateInvFrom.Text != "" && dateInvTo.Text != "")
            {
                int result = DateTime.Compare(dateInvFrom.Value, dateInvTo.Value);

                if (result > 0)
                {
                    MessageBox.Show("Set a valid range of dates for invoices", "Warning");
                }
                else
                {
                    dateRangeInv = "'" + dateInvFrom.Text + "' and '" + dateInvTo.Text + "'";
                }
   
            }
            else
            {
                MessageBox.Show("Set a valid range of dates for invoices", "Warning");

            }

            if (dateRepFrom.Text != "" && dateRepTo.Text != "")
            {

                int result = DateTime.Compare(dateRepFrom.Value, dateRepTo.Value);

                if (result > 0)
                {
                    MessageBox.Show("Set a valid range of dates for receipts", "Warning");
                }
                else
                {
                    dateRangeRep = "'" + dateRepFrom.Text + "' and '" + dateRepTo.Text + "'";
                }
            }
            else
            {
                MessageBox.Show("Set a valid range of dates for receipts", "Warning");

            }

            dateCollectOF = dateCollectOf.Text;
    }

        public void setMsgtext(string text)
        {

            StatusLabel.Text = text;
            statusStrip1.Refresh();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataSet ouputPreview;

            setMsgtext("Quering data, please wait...");

            System.Threading.Thread.Sleep(2);

            ouputPreview = dbquery.collectionQuery();

            
          // frmDataGrid tableGrid = new frmDataGrid();
           frmRepView  viewReport = new frmRepView();

           // int filled = tableGrid.fillGrid(ouputPreview.Tables["Joinedtable"]);
            
            if (ouputPreview.Tables["Joinedtable"].Rows.Count > 0)
            {

                viewReport.Show();
                //tableGrid.Show();
                setMsgtext("Done!");
            }
            else
            {
                setMsgtext("There's no data for this selection"); 
                MessageBox.Show("There's no data for this selection", "Warning");

            }            
                
            
        }

        private void dateInvFrom_ValueChanged(object sender, EventArgs e)
        {
            setDatesRange();
        }

        private void dateInvTo_ValueChanged(object sender, EventArgs e)
        {
            setDatesRange();
        }

        private void dateRepFrom_ValueChanged(object sender, EventArgs e)
        {
            setDatesRange();
        }



        private void dateRepTo_ValueChanged_1(object sender, EventArgs e)
        {
          setDatesRange();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
