using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AciSageLibrary
{
    public partial class FrmCompanyList : Form
    {

       

        public FrmCompanyList()
        {
            InitializeComponent();
            
        }

        public void setData(DataTable companyList)
        {
            if (gridCompanylist.SelectedRows.Count == 0) { 

                gridCompanylist.Refresh();
                gridCompanylist.DataSource = companyList;
                gridCompanylist.AutoResizeColumns();
                gridCompanylist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridCompanylist.ReadOnly = true;

            }

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            FrmFilter frmFilter = new FrmFilter();
            frmFilter.All = true;
            gridCompanylist.SelectAll();
           
        }

        private void btnUnsel_Click(object sender, EventArgs e)
        {
            FrmFilter frmFilter = new FrmFilter();
            frmFilter.All = false;
            gridCompanylist.ClearSelection();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

          
            DataTable selected = new DataTable();

            foreach (DataGridViewColumn column in gridCompanylist.Columns)
            {

                selected.Columns.Add(column.Name, typeof(String));

            }

            if(gridCompanylist.Columns.Count == 2)
            {
                foreach (DataGridViewRow row in gridCompanylist.SelectedRows)
                {

                    selected.Rows.Add(row.Cells[0].Value, row.Cells[1].Value);

                }
            }
            else
            {
                foreach (DataGridViewRow row in gridCompanylist.SelectedRows)
                {

                    selected.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value);

                }


            }
            

            FrmFilter frmFilter = new FrmFilter();

            FrmFilter.CompanySeleccted = selected.Copy() ;
            frmFilter.BringToFront();
            this.Hide();



        }
    }
}
