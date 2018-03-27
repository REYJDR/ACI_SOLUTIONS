using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISPCollection
{
    public partial class frmRepView : Form
    {
        public static string docview;

        XtraReport_std salesRep = new XtraReport_std();

        public frmRepView()
        {

           InitializeComponent();

            
            string ReportName;

            ReportName = String.Concat(@"C:\\ReportDesigner\",docview, ".repx");
            salesRep.LoadLayout(ReportName);
            salesRep.CreateDocument();
            documentViewer1.DocumentSource = salesRep;
        }
    }
}
