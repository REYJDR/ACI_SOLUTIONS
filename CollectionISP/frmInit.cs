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

        public static bool CheckInvRep;
        public static bool CheckCollectRep;

        bool Loaded;

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

            
            dateCollectOf.Value = DateTime.Now;

            SetInvDate();
            SetRepDate();


            setDatesRange();



        }

        public void SetInvDate()
        {
            Loaded = false;
            dateInvTo.Value = DateTime.Now;
            dateInvFrom.Value = DateTime.Now;
            Loaded = true;

        }

        public void SetRepDate()
        {
            Loaded = false;
            dateRepTo.Value = DateTime.Now;
            dateRepFrom.Value = DateTime.Now;
            Loaded = true;

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


        
        private void setDatesRange()
        {
            
            if(Loaded == true)
            {

                if (dateInvFrom.Value != null && dateInvTo.Value != null)
                {
                  
                    if (dateInvTo.Value.Date < dateInvFrom.Value.Date)
                    {
                        MessageBox.Show("Set a valid range of dates for invoices", "Warning");
                        SetInvDate();
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

                if (dateRepFrom.Value != null && dateRepTo.Value != null)
                {

                    if (dateRepTo.Value.Date < dateRepFrom.Value.Date)
                    {
                        MessageBox.Show("Set a valid range of dates for receipts", "Warning");
                        SetRepDate();
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

           
    }

        public void setMsgtext(string text)
        {

            StatusLabel.Text = text;
            statusStrip1.Refresh();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

            if(checkCollect.Checked || checkInvDS.Checked){

                DataSet ouputPreview;

                setMsgtext("Quering data, please wait...");


                if (checkCollect.Checked)
                {
                    
                    ouputPreview = dbquery.collectionQuery();


                    frmRepView viewReport = new frmRepView();

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

                if (checkInvDS.Checked)
                {
                    ouputPreview = dbquery.DsQuery();

                   

                    frmReportViewDS viewReportDs = new frmReportViewDS();

                    if (ouputPreview.Tables["DATASOURCE"].Rows.Count > 0)
                    {

                        viewReportDs.Show();
                        setMsgtext("Done!");
                    }
                    else
                    {
                        setMsgtext("There's no data for this selection");
                        MessageBox.Show("There's no data for this selection", "Warning");

                    }

                }
            }
            else{

                setMsgtext("At least one report option is required");
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


    }
}
