using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickingList
{
    public partial class frmDataGrid : Form
    {
        public frmDataGrid()
        {
            InitializeComponent();
        }

        private void frmDataGrid_Load(object sender, EventArgs e)
        {

        }

        public void fillGrid(DataTable data)
        {


            dataGridPre.DataSource = data;
            dataGridPre.AutoResizeColumns();

            /*setear columnas como NO editable excepto la columna de chackbox */
            dataGridPre.ReadOnly = false;
           
            foreach (DataGridViewColumn tblColumns in dataGridPre.Columns)
            {
                tblColumns.ReadOnly = true;
            }

            dataGridPre.Columns[0].ReadOnly = false; //COLUMNA DE CHACKBOX
            /* FIN SETADO DE COLUMNAS */

        }

        private void btnProc_Click(object sender, EventArgs e)
        {

            FrmInit frmInit = new FrmInit();

            frmInit.setMsgtext("Quering data...");

            /*REY CORRECCIONES */
            DataTable selecRows = new DataTable(); /*DECLARAS LA TABLA COMO DATATABLE*/
            DbQuery repQuery = new DbQuery();

            /*CREAS LAS COLUMNAS QUE VA A TENER DICHA TABLA */
            selecRows.Columns.Add("InvNo"); 
            selecRows.Columns.Add("Date");
            selecRows.Columns.Add("CustID");
            

            for (int i = 0; i < dataGridPre.Rows.Count; i++) //LEES CADA LINEA DE LA TABLA DEL GRIDVIEW
                {
                    if (Convert.ToBoolean(dataGridPre.Rows[i].Cells[0].Value))//VERIFICAR SI LA COLUMNA DEL CHECKBOX ES TRUE
                    {

                    /* INSERTAS EN LAS LINEA EN LA TABLA QUE DEFINISTE, 
                     * LE DEBES INDICAR QUE CELDA DE LA TABLA DEL DATAGRIDVIEW VAS A
                     * INSERTAR EN CADA COLUMNA DE LA NUEVA TABLA */

                     selecRows.Rows.Add(dataGridPre.Rows[i].Cells[1].Value, 
                                        dataGridPre.Rows[i].Cells[2].Value, 
                                        dataGridPre.Rows[i].Cells[3].Value);

                        
                    }
                }

            repQuery.repQuery(selecRows);
            PrintReport();
            frmInit.setMsgtext("Done");

        }


        private void PrintReport()
        {

            
            frmReport repViewer = new frmReport();

            repViewer.Show();
        }

        
    }
}
