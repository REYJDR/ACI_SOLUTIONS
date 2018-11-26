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
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

namespace ACIWEB_DESKTOP_REPORT
{
    public partial class FrmSageRep : Form
    {
        public static string dateRange;
        public static string invRange;
        public static int Type;
        bool Loaded;

        DbQuerySage dbquery = new DbQuerySage();

        public FrmSageRep()
        {
            InitializeComponent();
            InitValue();
        }

        private void InitValue()
        {

            setInitDate();


            comboBoxRepType.Items.Clear();

            string[] files = Directory.GetFiles(@"C:\\ACIDesktopReport\ReportDesigner\SAGE\", "*.repx");

            string filename;

            for (int i = 0; i < files.Length; i++)
            {

                filename = Path.GetFileNameWithoutExtension(files[i]);
                comboBoxRepType.Items.Add(filename);


            }

        }
        
        private void setInitDate()
        {
            Loaded = false;
            dateTimeTo.Value = DateTime.Now;
            dateTimeFrom.Value = DateTime.Now;
            Loaded = true;

        }

        private void setDateRange()
        {
            if (dateTimeFrom.Text == dateTimeTo.Text)
            {

                dateRange = "like '" + dateTimeFrom.Text + "%'";

            }
            else
            {

                dateRange = "between '" + dateTimeFrom.Text + "' and '" + dateTimeTo.Text + "'";

            }


        }

        private void dateTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            setDateRange();
        }

        private void dateTimeTo_ValueChanged(object sender, EventArgs e)
        {
            setDateRange();
        }

        private void comboBoxRepType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string template = comboBoxRepType.SelectedItem.ToString();
            FrmRepViwer.docview = template;

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

            setDateRange();

            if (comboBoxRepType.SelectedIndex == -1)
            {
                setMsgtext("Please select a template");
                MessageBox.Show("Please select a template");
            }
            else
            {


                PrintReport();
               
            }
        }

        private void PrintReport()
        {
            try
            {
                Cursor = Cursors.WaitCursor; // change cursor to hourglass type

                FrmRepViwer.repType = "sage";
                FrmRepViwer repViewer = new FrmRepViwer();

                
                repViewer.Show();

                Cursor = Cursors.Arrow; // change cursor to hourglass type


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

        public void setMsgtext(string text)
        {
            FrmHome home = new FrmHome();
            home.StatusLabel.Text = text;
            home.statusStrip1.Refresh();

        }



    }
}
