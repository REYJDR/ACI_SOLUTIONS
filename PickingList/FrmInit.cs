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


namespace PickingList
{
    public partial class FrmInit : Form
    {
        public static string dateRange;

        public static string invRange;

        private DbParam conParams;

        DbQuery dbquery = new DbQuery();

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
            DbConnetionPervasive dbConn = new DbConnetionPervasive();

            /*Abre conexion para test*/
            dbConn.StartConn();

            if (dbConn.StartConn().State == System.Data.ConnectionState.Open)
            {
                setMsgtext("Test de conexión exitoso");
                MessageBox.Show("Test de conexión exitoso", "Test de conexión");
                /* this.Close();*/

                //dbConn.Closed();
            }

        }

        private void FrmInit_Load(object sender, EventArgs e)
        {

            setRefCat();

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TextRefFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            setRefCat();



        }

        private void dateTimeTo_ValueChanged(object sender, EventArgs e)
        {
            setRefCat();



        }

        private void setRefCat()
        {

            dateRange = "'"+dateTimeFrom.Text+ "' and '" + dateTimeTo.Text+"'";

        }

        public void setMsgtext(string text)
        {

            StatusLabel.Text = text;
            statusStrip1.Refresh();

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

            if(comboBoxRepType.SelectedIndex == -1)
            {
                setMsgtext("Please select a Report Type");
                MessageBox.Show("Please select a Report Type");
            }
            else
            { 

                        if (textInvFrom.Text != "" )
                        {

                            if (textInvTo.Text != "")
                            {

                            invRange = " and A.InvNumForThisTrx between '" + textInvFrom.Text + "' and '" + textInvTo.Text + "'";

                            }
                            else
                            {
                            invRange = " and A.InvNumForThisTrx = '" + textInvFrom.Text + "'";
                            }

                        }
                        else
                        {
                        invRange = "";
                        }

            
                        DataTable ouputPreview = dbquery.invQuery();

                        frmDataGrid tableGrid = new frmDataGrid();

                        tableGrid.Show();

                        tableGrid.fillGrid(ouputPreview);

            }

        }

        private void comboBoxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxRepType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            //frmReport frmReport = new frmReport();


            string reportType = comboBoxRepType.SelectedItem.ToString();


            if (reportType == "Sales")
            {

                frmReport.docview = "Sales";
            }
            else
            {

                frmReport.docview = "Delivery";
            }

        }

        private void comboBoxFrom_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
