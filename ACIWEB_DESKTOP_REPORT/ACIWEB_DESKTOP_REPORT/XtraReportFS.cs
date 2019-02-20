using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;

namespace ACIWEB_DESKTOP_REPORT
{
    public partial class XtraReportFS : DevExpress.XtraReports.UI.XtraReport
    {
        private static List<string> FSParam;


        public XtraReportFS(List<string> Param)
        {
            FSParam = Param;

            initDataSource();
            InitializeComponent();
        }

        private void initDataSource()
        {

            DataSourceFS dataSourceFS = new DataSourceFS();
            DataSourceFS.FSParams = FSParam;



        }


    }

}
