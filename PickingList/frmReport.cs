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
    public partial class frmReport : Form
    {
        public static string docview;


        public frmReport()
        {
            InitializeComponent();

            XtraReport_Sales salesRep = new XtraReport_Sales();
            XtraReport_Delivery deliveryRep = new XtraReport_Delivery();

            if (docview == "Sales")

            {
                salesRep.LoadLayout("XtraReport_Delivery2.repx");
                salesRep.CreateDocument();
                documentViewer1.DocumentSource = salesRep;
            }
            if (docview == "Delivery")
            {

                deliveryRep.CreateDocument();
                documentViewer1.DocumentSource = deliveryRep;
            }
            
        }

        private void documentViewer1_Load(object sender, EventArgs e)
        {

        }

        private void barDockControlRight_Click(object sender, EventArgs e)
        {

        }

        private void barDockControlTop_Click(object sender, EventArgs e)
        {

        }
    }
}
