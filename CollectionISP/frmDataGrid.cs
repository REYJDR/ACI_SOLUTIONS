using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionISP
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

        public int  fillGrid(DataTable data)
        {
            int filled;

            dataGridPre.DataSource = data;
            dataGridPre.AutoResizeColumns();

            if (dataGridPre.Rows.Count > 0)
            {

                filled = 1;
            }
            else
            {
                filled = 0;
            }

            return filled;
        }
    }
}
