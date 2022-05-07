using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACIWEB_DESKTOP_REPORT
{
    public partial class FrmViewGrid : Form
    {

        protected DataSet dataSet;

        public FrmViewGrid(DataSet tableView)
        {
            
            InitializeComponent();


            DSGridView.AutoSize = true;
           

            this.AutoScroll = true;
            dataSet = tableView;

            cmbTables.Items.Clear();
            foreach (DataTable dt in dataSet.Tables)
            {
                
                    cmbTables.Items.Add(dt.TableName);
                
            }

            

        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string table= cmbTables.SelectedItem.ToString();
            DSGridView.RowHeadersVisible = false;
            DSGridView.DataSource = dataSet.Tables[table];
           // DSGridView.RowHeadersVisible = true;
          //  DSGridView.Refresh();
           
            //DSGridView.AutoResizeColumns();
            DSGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;

            cmbFields.Items.Clear();

            for (int i = 0; i < DSGridView.ColumnCount; i++)
            {
                cmbFields.Items.Add(DSGridView.Columns[i].Name);

            }

            

        }

        private void LoadData()
        {

            textSearch.Text = "";
            DSGridView.RowHeadersVisible = false;
            DSGridView.DataSource = dataSet.Tables[cmbTables.SelectedItem.ToString()];
            DSGridView.Update();
            DSGridView.Refresh();
           // DSGridView.AutoResizeColumns();
            DSGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;

        }

     
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ((DataTable)DSGridView.DataSource).DefaultView.RowFilter = string.Format("" + cmbFields.Text + " like '%{0}%'", textSearch.Text.Trim().Replace("'", "''"));
          
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }


        }

       
        private void button1_Click(object sender, EventArgs e)
        {

            LoadData();

        }
    }
}
