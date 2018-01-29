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

            XtraReport_standard salesRep = new XtraReport_standard();

            string ReportName;

                ReportName = String.Concat(docview, ".repx");
                salesRep.LoadLayout(ReportName);
                salesRep.CreateDocument();
                documentViewer1.DocumentSource = salesRep;

        }


    }
}
