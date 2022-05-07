using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACIWEB_DESKTOP_REPORT
{
    public partial class FrmDbRep : Form
    {
        public FrmDbRep()
        {
            InitializeComponent();
            InitValue();
        }

        private void InitValue()
        {
            comboBoxRepType.Items.Clear();

            string[] files = Directory.GetFiles(@"C:\\ACIDesktopReport\ReportDesigner\CUSTOMS\", "*.repx");

            string filename;

            for (int i = 0; i < files.Length; i++)
            {

                filename = Path.GetFileNameWithoutExtension(files[i]);
                comboBoxRepType.Items.Add(filename);


            }

        }

        private void comboBoxRepType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string template = comboBoxRepType.SelectedItem.ToString();
            FrmRepViwer.docview = template;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (comboBoxRepType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a template");
            }
            else
            {

                PrintReport();

            }
        }

        private void PrintReport()
        {

            FrmRepViwer.Excel = false;
            FrmRepViwer.export = false;


            try
            {
                
                Cursor = Cursors.WaitCursor; // change cursor to hourglass type


                FrmRepViwer.export = false;
                FrmRepViwer.repType = "customs";
                FrmRepViwer repViewer = new FrmRepViwer();


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
    }
}
