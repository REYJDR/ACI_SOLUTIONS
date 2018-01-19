using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPLOADER
{
    public partial class FrmGrid : Form
    {
        

        public FrmGrid()
        {
            InitializeComponent();

          
        }

        public void populatedGrid(DataTable data)
        {

            dataGridTbl.DataSource = data;

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

            DbConnetion dbConn = new DbConnetion();

            try
            {
                dbConn.dbInsert(dataGridTbl);

                this.Hide();
                MessageBox.Show("Proceso terminado", "Mensaje");


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
