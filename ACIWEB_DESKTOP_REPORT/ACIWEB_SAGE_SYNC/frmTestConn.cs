﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACIWEB_SAGE_SYNC
{
    public partial class frmTestConn : Form
    {
        public frmTestConn()
        {
            InitializeComponent();
        }

        private void frmTestConn_Load(object sender, EventArgs e)
        {

        }

        public void fillGrid(DataTable data)
        {

            dataGridTest.DataSource = data;
            dataGridTest.AutoResizeColumns();

            //  FitDataGrid(dataGridPre);

            /*setear columnas como NO editable excepto la columna de chackbox */
            dataGridTest.ReadOnly = false;

            foreach (DataGridViewColumn tblColumns in dataGridTest.Columns)
            {
                tblColumns.ReadOnly = true;
            }

            dataGridTest.Columns[0].ReadOnly = false; //COLUMNA DE CHACKBOX
                                                      /* FIN SETADO DE COLUMNAS */

        }
    }
}
