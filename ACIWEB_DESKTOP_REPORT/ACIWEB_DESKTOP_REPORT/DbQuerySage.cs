using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.Windows.Forms;

namespace ACIWEB_DESKTOP_REPORT
{
    class DbQuerySage
    {
        DbConnetionPervasive dbcon = new DbConnetionPervasive();

        public static ManualResetEvent mre = new ManualResetEvent(false);
        public static DataTable queryTable;
        public static bool doQuery;
        public static bool theresData;
        public static DataSet repPreview;
        public static string exportFileName;
        public static bool kill = false;
        string companyName = "";

        //Selection options 
        FrmReportFilter SO = new FrmReportFilter();
            DataTable SelectOptions = new DataTable("SelectOption");

            //variables de parametros de seleccion
            public static string From;
            public static string To;
            public static string SoNo;
            public static string PoNo;
            //variables de parametros de seleccion
        //Selection options 

        public DbQuerySage()
        {
            SelectionOptionsTbl();
           

        }

        //SELECTION OPTIONS
        private void SelectionOptionsTbl()
            {
                SelectOptions.Columns.Add("type", typeof(String));
                SelectOptions.Columns.Add("fieldname", typeof(String));
                SelectOptions.Columns.Add("long", typeof(String));
                SelectOptions.Columns.Add("default", typeof(String));
            }
        
            private void showSelecOptionByReport(int Type)
            {
            
                if (Type == 1)
                {
                    //selection option 
                    SelectOptions.NewRow();
                    SelectOptions.Rows.Add("date", "Up_To");
                    SelectOptions.NewRow();
                    SelectOptions.Rows.Add("button", "Go");


                    SO.SetSelectionsOptions(SelectOptions);
                    SO.ShowDialog();
                    

                    DateTimePicker to = SO.selectOptionsPanel.Controls.Find("date_Up_To", true).FirstOrDefault() as DateTimePicker;
                    To = to.Text;
                
                }

                if (Type == 2)
                {
                //selection option 
                    SelectOptions.NewRow();
                    SelectOptions.Rows.Add("text", "Purchase_Order_#", 10);
                    SelectOptions.NewRow();
                    SelectOptions.Rows.Add("date", "From");
                    SelectOptions.NewRow();
                    SelectOptions.Rows.Add("date", "To");
                    SelectOptions.NewRow();
                    SelectOptions.Rows.Add("button", "Go");


                    SO.SetSelectionsOptions(SelectOptions);
                    SO.ShowDialog();

                    DateTimePicker from = SO.selectOptionsPanel.Controls.Find("date_From", true).FirstOrDefault() as DateTimePicker;
                    From = from.Text;
                    DateTimePicker to = SO.selectOptionsPanel.Controls.Find("date_To", true).FirstOrDefault() as DateTimePicker;
                    To = to.Text;
                    TextBox po = SO.selectOptionsPanel.Controls.Find("Purchase_Order_#", true).FirstOrDefault() as TextBox;
                    PoNo = po.Text;

                    exportFileName = PoNo;
            }

                if (Type == 3)
                {
                      //selection option 
                    SelectOptions.NewRow();
                    SelectOptions.Rows.Add("text", "Sales_Order_#", 10);
                    SelectOptions.NewRow();
                    SelectOptions.Rows.Add("date", "From");
                    SelectOptions.NewRow();
                    SelectOptions.Rows.Add("date", "To");
                    
                    SelectOptions.NewRow();
                    SelectOptions.Rows.Add("button", "Go");


                    SO.SetSelectionsOptions(SelectOptions);
                    SO.ShowDialog();

                    DateTimePicker from = SO.selectOptionsPanel.Controls.Find("date_From", true).FirstOrDefault() as DateTimePicker;
                    From = from.Text;
                    DateTimePicker to = SO.selectOptionsPanel.Controls.Find("date_To", true).FirstOrDefault() as DateTimePicker;
                    To = to.Text;

                    TextBox so = SO.selectOptionsPanel.Controls.Find("Sales_Order_#", true).FirstOrDefault() as TextBox;
                    SoNo = so.Text;

                     exportFileName = SoNo;


            }
            }
        //SELECTION OPTIONS



        public void reportQuery(int Type)
        {
       

            DataTable result = new DataTable();

            string sql = "";

            
            try
            {
                /*Listar conexion*/
                List<string> Parameters = new List<string>();
                DataTable  strConTbl = new DataTable();
                DbParamSage SageParams = new DbParamSage();

                strConTbl =  SageParams.GetSageConf();

                for (int i = 0; i < strConTbl.Rows.Count; i++) //LEES CADA LINEA  de configuracion de cada conexion
                {
                    Parameters.Add(strConTbl.Rows[i].Field<string>(5));
                    Parameters.Add(strConTbl.Rows[i].Field<string>(2));
                    Parameters.Add(strConTbl.Rows[i].Field<string>(3));
                    Parameters.Add(strConTbl.Rows[i].Field<string>(4));

                    this.companyName = strConTbl.Rows[i].Field<string>(1);
                   
                    string strCon = SageParams.SageConString(Parameters);

                    if (dbcon.StartConn(strCon).State == System.Data.ConnectionState.Open)
                    {

                        /*QUERY*/
                        if (Type == 1)//Past Due
                        {
                            showSelecOptionByReport(1);
                            mre.WaitOne();

                            if(kill == false)
                            {
                                var to = Convert.ToDateTime(To);
                                var lastMonth = to.AddDays(-30);


                                //Facturas abiertas
                                sql = "SELECT DISTINCT " +
                                        "A.Reference as InvoiceNo," +
                                        "A.TransactionDate as InvoiceDate," +
                                        "C.CustomerID as IdCustomer," +
                                        "C.Customer_Bill_Name as BillTo," +
                                        "C.Customer_Type, " +
                                        "A.MainAmount," +
                                        "A.AmountPaid," +
                                        "G.EmployeeID, " +
                                        "G.EmployeeName, " +
                                        "A.Comment, " +
                                        "C.CustomField1, " +
                                        "C.CustomField2, " +
                                        "C.customField3, " +
                                        "C.CustomField4, " +
                                        "C.CustomField5, " +

                                        " CAST(COALESCE((SELECT SUM(I.Amount) FROM JrnlHdr H INNER JOIN JrnlRow  I ON H.PostOrder = I.PostOrder " +
                                          " WHERE H.JrnlKey_Journal = '1' AND I.RowType = '0' " +
                                          " AND H.TransactionDate between '" + lastMonth.ToString("yyyy-MM-dd") + "' and '" + to.ToString("yyyy-MM-dd") + "'" +
                                          " AND I.InvNumForThisTrx = A.Reference AND B.CustomerRecordNumber = I.CustomerRecordNumber  ) " +
                                        " , 0) AS decimal(16, 4)) AS PAID  " +

                                        " FROM JrnlHdr A" +
                                        " INNER JOIN JrnlRow B ON A.PostOrder = B.PostOrder" +
                                        " INNER JOIN Customers C ON C.CustomerRecordNumber = B.CustomerRecordNumber" +
                                        " LEFT JOIN Employee G on G.EmpRecordNumber = A.EmpRecordNumber" +
                                        " WHERE A.JrnlKey_Journal = '3'" +
                                        " AND B.RowType = '0'" +
                                        " AND A.TransactionDate <= '" + to.ToString("yyyy-MM-dd") + "'" +
                                        " AND A.AmountPaid < A.MainAmount " +
                                        " Order by A.Reference; ";


                               // dbcon.Query(sql).Fill(result);

                                result.Load(dbcon.Query(sql));

                            }
                     
                           
                        }
                       
                        if (Type == 2)//PickingList
                        {
                            
                            showSelecOptionByReport(2);
                         
                            mre.WaitOne();
                            if (kill == false)
                            {

                                sql = "SELECT DISTINCT " +
                                "A.Reference as InvoiceNo," +
                                "A.TransactionDate as InvoiceDate," +
                                "C.CustomerID as IdCustomer," +
                                "C.Customer_Bill_Name as BillTo," +
                                "B.Quantity," +
                                "D.ItemID," +
                                "D.UPC_SKU," +
                                "D.SalesDescription," +
                                "D.Weight," +
                                "B.Amount," +
                                "D.StockingUM as Unit, " +
                                "E.JobDescription, " +
                                "F.PhaseDescription, " +
                                "G.EmployeeID, " +
                                "G.EmployeeName, " +
                                "C.Customer_Type, " +
                                "D.CustomField1, " +
                                "D.CustomField2, " +
                                "D.customField3, " +
                                "D.CustomField4, " +
                                "D.CustomField5 " +
                                " FROM JrnlHdr A" +
                                " INNER JOIN JrnlRow B ON A.PostOrder = B.PostOrder" +
                                " LEFT JOIN Jobs E ON E.JobRecordNumber = B.JobRecordNumber " +
                                " LEFT JOIN Phase F ON F.PhaseRecordNumber = B.PhaseRecordNumber " +
                                " LEFT JOIN Employee G on G.EmpRecordNumber = A.EmpRecordNumber" +
                                " INNER JOIN Customers C ON C.CustomerRecordNumber = B.CustomerRecordNumber" +
                                " INNER JOIN LineItem D ON D.ItemRecordNumber = B.ItemRecordNumber" +
                                " WHERE A.JrnlKey_Journal = '3'" +
                                " AND B.RowType = '0'" +
                                " AND A.TransactionDate between '" + From + "' and '" + To + "' " +
                                " Order by A.Reference; ";

                                //  dbcon.Query(sql).Fill(result);
                                result.Load(dbcon.Query(sql));

                            }
                        

                        }
                        
                        if (Type == 3)//Purchase Orders
                        {
                            showSelecOptionByReport(2);
                            mre.WaitOne();

                            if (kill == false)
                            {


                                var PoFilter = "";

                                if (PoNo != null) { PoFilter = "AND A.Reference = '" + PoNo + "'"; }

                                sql = "SELECT DISTINCT " +
                                    "A.Reference as PONo," +
                                    "A.TransactionDate as PODate," +
                                    "C.VendorID as IdVendor," +
                                    "C.Name as VendorName," +
                                    "B.Quantity," +
                                    "D.ItemID," +
                                    "D.UPC_SKU," +
                                    "D.SalesDescription," +
                                    "D.Weight," +
                                    "B.Amount," +
                                    "D.StockingUM as Unit, " +
                                    "E.JobDescription, " +
                                    "F.PhaseDescription, " +
                                    "G.EmployeeID, " +
                                    "G.EmployeeName, " +
                                    "C.VendorType, " +
                                    "B.RowNumber," +
                                    "D.CustomField1, " +
                                    "D.CustomField2, " +
                                    "D.customField3, " +
                                    "D.CustomField4, " +
                                    "D.CustomField5, " +
                                    "A.PurchOrder , " +
                                    "A.CustomerInvoiceNo, " +
                                    "A.CustomerSONo " +
                                    " FROM JrnlHdr A" +
                                    " INNER JOIN JrnlRow B ON A.PostOrder = B.PostOrder" +
                                    " LEFT JOIN Jobs E ON E.JobRecordNumber = B.JobRecordNumber " +
                                    " LEFT JOIN Phase F ON F.PhaseRecordNumber = B.PhaseRecordNumber " +
                                    " LEFT JOIN Employee G on G.EmpRecordNumber = A.EmpRecordNumber" +
                                    " INNER JOIN Vendors C ON C.VendorRecordNumber = B.VendorRecordNumber" +
                                    " INNER JOIN LineItem D ON D.ItemRecordNumber = B.ItemRecordNumber" +
                                    " WHERE A.JrnlKey_Journal = '10'" +
                                    " AND B.RowType = '0'" +
                                    " AND A.TransactionDate between '" + From + "' and '" + To + "' " +
                                      PoFilter +
                                    " Order by A.Reference; ";


                                //dbcon.Query(sql).Fill(result);
                                result.Load(dbcon.Query(sql));
                            }
                        }

                        if (Type == 4)//Sales Orders
                        {
                            showSelecOptionByReport(3);
                            mre.WaitOne();


                            if (kill == false)
                            {
                                var SoFilter = "";

                                if (SoNo != null) { SoFilter = "AND A.Reference = '" + SoNo + "'"; }


                                sql = "SELECT DISTINCT " +
                                    "A.Reference as PONo," +
                                    "A.TransactionDate as PODate," +
                                    "C.CustomerID as IdCustomer," +
                                    "C.Customer_Bill_Name as CustomerName," +
                                    "B.Quantity," +
                                    "D.ItemID," +
                                    "D.UPC_SKU," +
                                    "D.SalesDescription," +
                                    "D.Weight," +
                                    "B.Amount," +
                                    "D.StockingUM as Unit, " +
                                    "E.JobDescription, " +
                                    "F.PhaseDescription, " +
                                    "G.EmployeeID, " +
                                    "G.EmployeeName, " +
                                    "C.Customer_Type, " +
                                    "B.RowNumber," +
                                    "D.CustomField1, " +
                                    "D.CustomField2, " +
                                    "D.customField3, " +
                                    "D.CustomField4, " +
                                    "D.CustomField5, " +
                                    "A.PurchOrder , " +
                                    "A.CustomerInvoiceNo, " +
                                    "A.CustomerSONo " +
                                    " FROM JrnlHdr A" +
                                    " INNER JOIN JrnlRow B ON A.PostOrder = B.PostOrder" +
                                    " LEFT JOIN Jobs E ON E.JobRecordNumber = B.JobRecordNumber " +
                                    " LEFT JOIN Phase F ON F.PhaseRecordNumber = B.PhaseRecordNumber " +
                                    " LEFT JOIN Employee G on G.EmpRecordNumber = A.EmpRecordNumber" +
                                    " INNER JOIN Customers C ON C.CustomerRecordNumber = B.CustomerRecordNumber" +
                                    " INNER JOIN LineItem D ON D.ItemRecordNumber = B.ItemRecordNumber" +
                                    " WHERE A.JrnlKey_Journal = '11'" +
                                    " AND B.RowType = '0'" +
                                    " AND A.TransactionDate between '" + From + "' and '" + To + "' " +
                                     SoFilter +
                                    " Order by A.Reference; ";


                                // dbcon.Query(sql).Fill(result);

                                result.Load(dbcon.Query(sql));
                            }
                        }


                        dbcon.Close();
                    }

                    
                }


            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }

            //Guardo resultado en DataTable global para esta clase.
            queryTable = result;
            
        }
        
        public DataSet SetPastDue() //facturas abiertas
        {
           
            try
            {
                DateTime rawDate;
                string date;

                if (repPreview is null)
                {
                  
                    
                    DataTable resTable = new DataTable("PastDue");
                    resTable.Columns.Add("CompanyName", typeof(String));
                    resTable.Columns.Add("InvoiceNo", typeof(String));
                    resTable.Columns.Add("InvoiceDate", typeof(String));
                    resTable.Columns.Add("IdCustomer", typeof(String));
                    resTable.Columns.Add("BillTo", typeof(String));
                    resTable.Columns.Add("CustomerType", typeof(String));
                    resTable.Columns.Add("Amount", typeof(Decimal));
                    resTable.Columns.Add("AmountPaid", typeof(Decimal));
                    resTable.Columns.Add("EmployeeID", typeof(String));
                    resTable.Columns.Add("EmployeeName", typeof(String));
                    resTable.Columns.Add("Comment", typeof(String));
                    resTable.Columns.Add("CustomField1", typeof(String));
                    resTable.Columns.Add("CustomField2", typeof(String));
                    resTable.Columns.Add("CustomField3", typeof(String));
                    resTable.Columns.Add("CustomField4", typeof(String));
                    resTable.Columns.Add("CustomField5", typeof(String));
                    resTable.Columns.Add("lastpays", typeof(Decimal));
                    resTable.Columns.Add("date_query", typeof(String));




                    repPreview = new DataSet();
                    repPreview.Tables.Add(resTable);

             

                if (doQuery == true)
                {
                    reportQuery(1);


                    if (queryTable != null && queryTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < queryTable.Rows.Count; i++)
                        {

                            resTable.NewRow();

                            rawDate = Convert.ToDateTime(queryTable.Rows[i].Field<DateTime>(1));
                            date = rawDate.ToString("dd-mm-yyy");

                               

                            resTable.Rows.Add(
                            this.companyName,
                            queryTable.Rows[i].Field<string>(0),
                            date,
                            queryTable.Rows[i].Field<string>(2),
                            queryTable.Rows[i].Field<string>(3),
                            queryTable.Rows[i].Field<string>(4),
                            queryTable.Rows[i].Field<decimal>(5),
                            queryTable.Rows[i].Field<decimal>(6),
                            queryTable.Rows[i].Field<string>(7),
                            queryTable.Rows[i].Field<string>(8),
                            queryTable.Rows[i].Field<string>(9),
                            queryTable.Rows[i].Field<string>(10),
                            queryTable.Rows[i].Field<string>(11),
                            queryTable.Rows[i].Field<string>(12),
                            queryTable.Rows[i].Field<string>(13),
                            queryTable.Rows[i].Field<string>(14),
                            queryTable.Rows[i].Field<decimal>(15),
                            To );

                        }

                        theresData = true;

                    } else{

                        theresData = false;

                    }

                    doQuery = false;
                }

                }
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }


            return repPreview;
        }
        
        public DataSet PickingList()//PickinList
        {

            try
            {
                DateTime rawDate;
                string date;

                if (repPreview is null)
                {


                    DataTable resTable = new DataTable("PickingList");
                    resTable.Columns.Add("CompanyName", typeof(String));
                    resTable.Columns.Add("InvoiceNo", typeof(String));
                    resTable.Columns.Add("InvoiceDate", typeof(String));
                    resTable.Columns.Add("IdCustomer", typeof(String));
                    resTable.Columns.Add("BillTo", typeof(String));
                    resTable.Columns.Add("Quantity", typeof(Decimal));
                    resTable.Columns.Add("ItemID", typeof(String));
                    resTable.Columns.Add("UPC_SKU", typeof(String));
                    resTable.Columns.Add("ItemDescription", typeof(String));
                    resTable.Columns.Add("Weight", typeof(Decimal));
                    resTable.Columns.Add("Amount", typeof(Decimal));
                    resTable.Columns.Add("Unit", typeof(String));
                    resTable.Columns.Add("JobDescription", typeof(String));
                    resTable.Columns.Add("PhaseDescription", typeof(String));
                    resTable.Columns.Add("EmployeeID", typeof(String));
                    resTable.Columns.Add("EmployeeName", typeof(String));
                    resTable.Columns.Add("CustomerType", typeof(String));
                    resTable.Columns.Add("CustomField1", typeof(String));
                    resTable.Columns.Add("CustomField2", typeof(String));
                    resTable.Columns.Add("CustomField3", typeof(String));
                    resTable.Columns.Add("CustomField4", typeof(String));
                    resTable.Columns.Add("CustomField5", typeof(String));
                    resTable.Columns.Add("date_from", typeof(String));
                    resTable.Columns.Add("date_to", typeof(String));



                    repPreview = new DataSet();
                    repPreview.Tables.Add(resTable);

                    if (doQuery == true)
                    {
                        reportQuery(2);


                        if (queryTable != null && queryTable.Rows.Count > 0)
                        {
                            for (int i = 0; i < queryTable.Rows.Count; i++)
                            {
                                resTable.NewRow();

                                rawDate = Convert.ToDateTime(queryTable.Rows[i].Field<DateTime>(1));
                                date = rawDate.ToString("dd-mm-yyyy");

                              

                                resTable.Rows.Add(
                                this.companyName,
                                queryTable.Rows[i].Field<string>(0),
                                date,
                                queryTable.Rows[i].Field<string>(2),
                                queryTable.Rows[i].Field<string>(3),
                                queryTable.Rows[i].Field<decimal>(4),
                                queryTable.Rows[i].Field<string>(5),
                                queryTable.Rows[i].Field<string>(6),
                                queryTable.Rows[i].Field<string>(7),
                                queryTable.Rows[i].Field<decimal>(8),
                                queryTable.Rows[i].Field<decimal>(9),
                                queryTable.Rows[i].Field<string>(10),
                                queryTable.Rows[i].Field<string>(11),
                                queryTable.Rows[i].Field<string>(12),
                                queryTable.Rows[i].Field<string>(13),
                                queryTable.Rows[i].Field<string>(14),
                                queryTable.Rows[i].Field<string>(15),
                                queryTable.Rows[i].Field<string>(16),
                                queryTable.Rows[i].Field<string>(17),
                                queryTable.Rows[i].Field<string>(18),
                                queryTable.Rows[i].Field<string>(19),
                                queryTable.Rows[i].Field<string>(20),
                                From,
                                To
                                );


                            }

                            theresData = true;

                        }
                        else
                        {

                            theresData = false;

                        }

                        doQuery = false;
                    }

                }
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }


            return repPreview;

        }
        
        public DataSet PurchaseOrders()//Purchase Orders
        {

            try
            {
                DateTime rawDate;
                string date;

                if (repPreview is null)
                {
                   

                    DataTable resTable = new DataTable("PurchaseOrders");
                    resTable.Columns.Add("CompanyNam", typeof(String));
                    resTable.Columns.Add("PONo", typeof(String));
                    resTable.Columns.Add("PODate", typeof(String));
                    resTable.Columns.Add("IdVendor", typeof(String));
                    resTable.Columns.Add("VendorName", typeof(String));
                    resTable.Columns.Add("Quantity", typeof(Decimal));
                    resTable.Columns.Add("ItemID", typeof(String));
                    resTable.Columns.Add("UPC_SKU", typeof(String));
                    resTable.Columns.Add("ItemDescription", typeof(String));
                    resTable.Columns.Add("Weight", typeof(Decimal));
                    resTable.Columns.Add("Amount", typeof(Decimal));
                    resTable.Columns.Add("Unit", typeof(String));
                    resTable.Columns.Add("JobDescription", typeof(String));
                    resTable.Columns.Add("PhaseDescription", typeof(String));
                    resTable.Columns.Add("EmployeeID", typeof(String));
                    resTable.Columns.Add("EmployeeName", typeof(String));
                    resTable.Columns.Add("VendorType", typeof(String));
                    resTable.Columns.Add("RowNumber", typeof(Int16));
                    resTable.Columns.Add("CustomField1", typeof(String));
                    resTable.Columns.Add("CustomField2", typeof(String));
                    resTable.Columns.Add("CustomField3", typeof(String));
                    resTable.Columns.Add("CustomField4", typeof(String));
                    resTable.Columns.Add("CustomField5", typeof(String));
                    resTable.Columns.Add("PurchOrder", typeof(String));
                    resTable.Columns.Add("CustomerInvoiceNo", typeof(String));
                    resTable.Columns.Add("CustomerSONo", typeof(String));
                    resTable.Columns.Add("date_from", typeof(String));
                    resTable.Columns.Add("date_to", typeof(String));

                    repPreview = new DataSet();
                    repPreview.Tables.Add(resTable);

                    if (doQuery == true)
                    {
                        reportQuery(3);


                        if (queryTable != null && queryTable.Rows.Count > 0)
                        {
                            for (int i = 0; i < queryTable.Rows.Count; i++)
                            {
                                resTable.NewRow();

                                rawDate = Convert.ToDateTime(queryTable.Rows[i].Field<DateTime>(1));
                                date = rawDate.ToString("yyyy-MM-dd");
                                
                                resTable.Rows.Add(
                                this.companyName, 
                                queryTable.Rows[i].Field<string>(0),
                                date,
                                queryTable.Rows[i].Field<string>(2),
                                queryTable.Rows[i].Field<string>(3),
                                queryTable.Rows[i].Field<decimal>(4),
                                queryTable.Rows[i].Field<string>(5),
                                queryTable.Rows[i].Field<string>(6),
                                queryTable.Rows[i].Field<string>(7),
                                queryTable.Rows[i].Field<decimal>(8),
                                queryTable.Rows[i].Field<decimal>(9),
                                queryTable.Rows[i].Field<string>(10),
                                queryTable.Rows[i].Field<string>(11),
                                queryTable.Rows[i].Field<string>(12),
                                queryTable.Rows[i].Field<string>(13),
                                queryTable.Rows[i].Field<string>(14),
                                queryTable.Rows[i].Field<string>(15),
                                queryTable.Rows[i].Field<Int16>(16),
                                queryTable.Rows[i].Field<string>(17),
                                queryTable.Rows[i].Field<string>(18),
                                queryTable.Rows[i].Field<string>(19),
                                queryTable.Rows[i].Field<string>(20),
                                queryTable.Rows[i].Field<string>(21),
                                queryTable.Rows[i].Field<string>(22),
                                queryTable.Rows[i].Field<string>(23),
                                queryTable.Rows[i].Field<string>(24),
                                From,
                                To);


                            }

                            theresData = true;

                        }
                        else
                        {

                            theresData = false;

                        }

                        doQuery = false;
                    }

                }
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }


            return repPreview;

        }

        public DataSet SalesOrders()//Sales Orders
        {

            try
            {
                DateTime rawDate;
                string date;

                if (repPreview is null)
                {


                    DataTable resTable = new DataTable("SalesOrders");
                    resTable.Columns.Add("CompanyNam", typeof(String));
                    resTable.Columns.Add("SONo", typeof(String));
                    resTable.Columns.Add("SODate", typeof(String));
                    resTable.Columns.Add("IdCustomer", typeof(String));
                    resTable.Columns.Add("CustomerName", typeof(String));
                    resTable.Columns.Add("Quantity", typeof(Decimal));
                    resTable.Columns.Add("ItemID", typeof(String));
                    resTable.Columns.Add("UPC_SKU", typeof(String));
                    resTable.Columns.Add("ItemDescription", typeof(String));
                    resTable.Columns.Add("Weight", typeof(Decimal));
                    resTable.Columns.Add("Amount", typeof(Decimal));
                    resTable.Columns.Add("Unit", typeof(String));
                    resTable.Columns.Add("JobDescription", typeof(String));
                    resTable.Columns.Add("PhaseDescription", typeof(String));
                    resTable.Columns.Add("EmployeeID", typeof(String));
                    resTable.Columns.Add("EmployeeName", typeof(String));
                    resTable.Columns.Add("CustomerType", typeof(String));
                    resTable.Columns.Add("RowNumber", typeof(Int16));
                    resTable.Columns.Add("CustomField1", typeof(String));
                    resTable.Columns.Add("CustomField2", typeof(String));
                    resTable.Columns.Add("CustomField3", typeof(String));
                    resTable.Columns.Add("CustomField4", typeof(String));
                    resTable.Columns.Add("CustomField5", typeof(String));
                    resTable.Columns.Add("PurchOrder", typeof(String));
                    resTable.Columns.Add("CustomerInvoiceNo", typeof(String));
                    resTable.Columns.Add("CustomerSONo", typeof(String));
                    resTable.Columns.Add("date_from", typeof(String));
                    resTable.Columns.Add("date_to", typeof(String));

                    repPreview = new DataSet();
                    repPreview.Tables.Add(resTable);

                    if (doQuery == true)
                    {
                        reportQuery(4);
                        
                        if (queryTable != null && queryTable.Rows.Count > 0)
                        {
                            for (int i = 0; i < queryTable.Rows.Count; i++)
                            {
                                resTable.NewRow();

                                rawDate = Convert.ToDateTime(queryTable.Rows[i].Field<DateTime>(1));
                                date = rawDate.ToString("yyyy-MM-dd");

                             
                                resTable.Rows.Add(
                                this.companyName,
                                queryTable.Rows[i].Field<string>(0),
                                date,
                                queryTable.Rows[i].Field<string>(2),
                                queryTable.Rows[i].Field<string>(3),
                                queryTable.Rows[i].Field<decimal>(4),
                                queryTable.Rows[i].Field<string>(5),
                                queryTable.Rows[i].Field<string>(6),
                                queryTable.Rows[i].Field<string>(7),
                                queryTable.Rows[i].Field<decimal>(8),
                                queryTable.Rows[i].Field<decimal>(9),
                                queryTable.Rows[i].Field<string>(10),
                                queryTable.Rows[i].Field<string>(11),
                                queryTable.Rows[i].Field<string>(12),
                                queryTable.Rows[i].Field<string>(13),
                                queryTable.Rows[i].Field<string>(14),
                                queryTable.Rows[i].Field<string>(15),
                                queryTable.Rows[i].Field<Int16>(16),
                                queryTable.Rows[i].Field<string>(17),
                                queryTable.Rows[i].Field<string>(18),
                                queryTable.Rows[i].Field<string>(19),
                                queryTable.Rows[i].Field<string>(20),
                                queryTable.Rows[i].Field<string>(21),
                                queryTable.Rows[i].Field<string>(22),
                                queryTable.Rows[i].Field<string>(23),
                                queryTable.Rows[i].Field<string>(24),
                                From,
                                To);

                            }

                            theresData = true;

                        }
                        else
                        {

                            theresData = false;

                        }

                        doQuery = false;
                    }

                }
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }


            return repPreview;

        }


        //Nota : Para un nuevo reporte se crea un metodo que devuelva el data set requerido y se agrega 
        //al consulta en el metodo reportType
    }
}
