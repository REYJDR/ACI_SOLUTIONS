using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CollectionISP
{
    public partial class XtraReportCollection : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportCollection()
        {
            InitializeComponent();
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
