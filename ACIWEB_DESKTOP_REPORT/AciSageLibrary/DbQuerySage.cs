using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AciSageLibrary
{
    public class DbQuerySage
    {
            DbConnetionPervasive dbcon = new DbConnetionPervasive();
            DataTable result = new DataTable();
            DbParamSage SageParams = new DbParamSage();
            DataTable strConTbl = new DataTable();
      

            public static ManualResetEvent mre = new ManualResetEvent(false);
            public static DataTable queryTable;
            public static bool doQuery;
            public static bool theresData;
            public static DataSet repPreview;
            public static string exportFileName;
            public static bool kill = false;


            //Selection options 
            FrmFilter SO = new FrmFilter();
            DataTable SelectOptions = new DataTable("SelectOption");

            //variables de parametros de seleccion
            public static string From;
            public static string To;
            public static string SoNo;
            public static string PoNo;
            public static string Invoice;
            public static string CustID;
            public static string CustTyp;
            public static string Budget;
            public static int  period1;
            public static int period2;
            public static int journals;
            public static bool All;
            public static string starPeriodYearSelected;
             String[] strlist;

            private static  string sql;
            private static  string database;
            private static  string fiscalYr;



            DataTable company = new DataTable();
            DataTable budget = new DataTable();



            char C34 = (char)34 ;

            public static DateTime SysDate;
            //variables de parametros de seleccion
            //Selection options 

            public DbQuerySage()
            {
                strConTbl = SageParams.GetSageConf();

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
                        SelectOptions.Rows.Add("company", "Company", 35);

                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("date", "End_Date");

                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("text", "Customer_ID", 20);

                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("desc", "Opcional");

                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("text", "Customer_type", 20);

                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("desc", "Opcional");

                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("button", "Execute");


                        SO.SetSelectionsOptions(SelectOptions);
                        SO.ShowDialog();
                        company.Clear();
                        company = FrmFilter.CompanySeleccted;
                        All = SO.All;

                        TextBox custId = SO.selectOptionsPanel2.Controls.Find("Customer_ID", true).FirstOrDefault() as TextBox;
                        CustID = custId.Text;
                        TextBox custType = SO.selectOptionsPanel2.Controls.Find("Customer_type", true).FirstOrDefault() as TextBox;
                        CustTyp = custType.Text;

                        DateTimePicker to = SO.selectOptionsPanel2.Controls.Find("date_End_Date", true).FirstOrDefault() as DateTimePicker;
                        To = to.Text;

                    }

                    if (Type == 2)
                    {
                        //selection option 
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("company", "Company", 35);

                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("text", "Invoice_#", 20);
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("desc", "Opcional");

                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("date", "From");
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("date", "To");
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("button", "Execute");


                        SO.SetSelectionsOptions(SelectOptions);
                        SO.ShowDialog();

                        company.Clear();
                        company = FrmFilter.CompanySeleccted;
                        All = SO.All;

                        DateTimePicker from = SO.selectOptionsPanel2.Controls.Find("date_From", true).FirstOrDefault() as DateTimePicker;
                        From = from.Text;
                        DateTimePicker to = SO.selectOptionsPanel2.Controls.Find("date_To", true).FirstOrDefault() as DateTimePicker;
                        To = to.Text;
                        TextBox invoice = SO.selectOptionsPanel2.Controls.Find("Invoice_#", true).FirstOrDefault() as TextBox;
                        PoNo = invoice.Text;
        
                        exportFileName = PoNo;

                    }

                    if (Type == 3)
                    {
                        //selection option 
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("company", "Company", 35);

                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("text", "Sales_Order_#", 20);
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("date", "From");
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("date", "To");

                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("button", "Execute");


                        SO.SetSelectionsOptions(SelectOptions);
                        SO.ShowDialog();

                        company.Clear();
                        company = FrmFilter.CompanySeleccted;
                        All = SO.All;
                        DateTimePicker from = SO.selectOptionsPanel2.Controls.Find("date_From", true).FirstOrDefault() as DateTimePicker;
                        From = from.Text;
                        DateTimePicker to = SO.selectOptionsPanel2.Controls.Find("date_To", true).FirstOrDefault() as DateTimePicker;
                        To = to.Text;

                        TextBox so = SO.selectOptionsPanel2.Controls.Find("Sales_Order_#", true).FirstOrDefault() as TextBox;
                        SoNo = so.Text;

                        exportFileName = SoNo;


                    }

                    if (Type == 4)
                    {
                        //selection option 
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("company", "Company", 35);

                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("date", "From");
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("date", "To");

                        //selection option 
                        /*SelectOptions.NewRow();
                        SelectOptions.Rows.Add("journals", "Journals", 35); */

                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("button", "Execute");


                        SO.SetSelectionsOptions(SelectOptions);
                        SO.ShowDialog();

                        company.Clear();
                        company = FrmFilter.CompanySeleccted;
                        All = SO.All;

                        DateTimePicker from = SO.selectOptionsPanel2.Controls.Find("date_From", true).FirstOrDefault() as DateTimePicker;
                        From = from.Text;
                        DateTimePicker to = SO.selectOptionsPanel2.Controls.Find("date_To", true).FirstOrDefault() as DateTimePicker;
                        To = to.Text;

               
                        /*ComboBox comboBox = SO.selectOptionsPanel2.Controls.Find("journals_Journals", true).FirstOrDefault() as ComboBox;
                          journals = comboBox.SelectedIndex; */
             
                    }

                    if (Type == 5)
                    {
                        //selection option 
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("company", "Company",35);
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("period1", "Start",20);
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("period2", "End", 20);
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("button", "Execute");


                        SO.SetSelectionsOptions(SelectOptions);
                        SO.ShowDialog();
                       

                        company.Clear();
                        company = FrmFilter.CompanySeleccted;
                        All = SO.All;

                        ComboBox per1 = SO.selectOptionsPanel2.Controls.Find("period1_Start", true).FirstOrDefault() as ComboBox;
                        period1 = per1.SelectedIndex + 14;

                        strlist = per1.Text.Split('-');
                        starPeriodYearSelected = strlist[1];

                        ComboBox per2 = SO.selectOptionsPanel2.Controls.Find("period2_End", true).FirstOrDefault() as ComboBox;
                        period2 = per2.SelectedIndex + 14;
                
                    }

                    if (Type == 6)
                    {
                        

                        //selection option 
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("budget", "Company/Budget", 35);
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("period1", "Start", 20);
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("period2", "End", 20);
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("button", "Execute");


                        SO.SetSelectionsOptions(SelectOptions);
                        SO.ShowDialog();


                        budget.Clear();
                        budget = FrmFilter.CompanySeleccted;
                        All = SO.All;

                        ComboBox per1 = SO.selectOptionsPanel2.Controls.Find("period1_Start", true).FirstOrDefault() as ComboBox;
                        period1 = per1.SelectedIndex + 14;

                        strlist = per1.Text.Split('-');
                        starPeriodYearSelected = strlist[1];

                        ComboBox per2 = SO.selectOptionsPanel2.Controls.Find("period2_End", true).FirstOrDefault() as ComboBox;
                        period2 = per2.SelectedIndex + 14;




            }
                    
                    if (Type == 7)
                    {
                        //selection option 
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("company", "Company",35);
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("button", "Execute");


                        SO.SetSelectionsOptions(SelectOptions);
                        SO.ShowDialog();
                       

                        company.Clear();
                        company = FrmFilter.CompanySeleccted;
                        All = SO.All;
                

                     }

                    if (Type == 8)
                    {
                        //selection option 
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("company", "Company", 35);
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("period", "Period", 20);
                        SelectOptions.NewRow();
                        SelectOptions.Rows.Add("button", "Execute");


                        SO.SetSelectionsOptions(SelectOptions);
                        SO.ShowDialog();


                        company.Clear();
                        company = FrmFilter.CompanySeleccted;
                        All = SO.All;

                        ComboBox per2 = SO.selectOptionsPanel2.Controls.Find("period_Period", true).FirstOrDefault() as ComboBox;
                        period2 = per2.SelectedIndex + 14;
                
                      
                        strlist = per2.Text.Split('-');
                        starPeriodYearSelected = strlist[1];



            }

                   

        }
           //SELECTION OPTIONS


            public void reportQuery(int Type)
            {

             
            try
            {
                /*QUERY*/
                    //Past Due
                    if (Type == 1)
                    {
                            showSelecOptionByReport(1);
                            mre.WaitOne();

                            if (kill == false)
                            {
                        
                                var to = Convert.ToDateTime(To);
                                //var lastMonth = to.AddDays(-30);

                                var where = "";

                                if (CustID != "")
                                {
                                    where = " and Customers.CustomerID='" + CustID + "' ";
                                }

                                if (CustTyp != "")

                                {

                                    where = where + " and Customers.Customer_Type='" + CustTyp + "' ";

                                }



                                var lastMonth = to.AddDays(-30);
                                //Facturas abiertas
                                sql = "SELECT  " +
                                        "JrnlHdr.Reference as InvoiceNo," +
                                        "JrnlHdr.TransactionDate as InvoiceDate," +
                                        "Customers.CustomerID as IdCustomer," +
                                        "Customers.Customer_Bill_Name as BillTo," +
                                        "Customers.Customer_Type, " +
                                        "JrnlHdr.MainAmount," +
                                        "SUM(IFNULL(Pd.PdAmt,0)) as AmountPaid," +
                                        "Employee.EmployeeID, " +
                                        "Employee.EmployeeName, " +
                                        "JrnlHdr.Comment, " +
                                        "Customers.CustomField1," +
                                        "Customers.CustomField2, " +
                                        "Customers.customField3, " +
                                        "Customers.CustomField4, " +
                                        "Customers.CustomField5, " +
                                        "Company.CompanyName as Company, " +
                                        "Company.DBN as Database, " +
                                        "IFNULL(Pmnt.PmntLast30,0)," +
                                        "Customers.CustomerRecordNumber, " +
                                        "SUM((JrnlHdr.MainAmount + IFNULL(Pd.PdAmt,0))) AS AmountDue " +
                                        "FROM JrnlHdr " +
                                  
                                        " INNER JOIN JrnlRow ON JrnlHdr.PostOrder = JrnlRow.PostOrder " +
                                        " LEFT JOIN Customers ON JrnlHdr.CustVendId = Customers.CustomerRecordNumber " +
                                   
          "                              LEFT JOIN(" +
          "                                   SELECT  JH.CustVendID, " +
          "                                           JR.LinkToAnotherTrx, " +
          "                                           JR.InvNumForThisTrx, " +
          "                                           JR.RowDate, " +
          "                                           SUM(CASE WHEN JH.JournalEx = 9 THEN  JR.Amount * -1 ELSE JR.Amount END) as PdAmt " +
          "                                  FROM JrnlHdr JH " +
          "                                   INNER JOIN JrnlRow JR " +
          "                                     ON JH.PostOrder = JR.PostOrder " +
                                        "    WHERE 1 = 1 " +
                                        "      AND JH.JournalEx in (3, 4, 9)  " +
                                        "      AND JR.RowType in (0, 4, 5, 6, 11)  " +
                                        "      AND JH.PayCustOrRecVend = 0 " +
                                        "      AND JR.RowNumber > 0  " +
                                        "      AND ((JH.CompletedDate IS NULL OR JH.CompletedDate = '9999-12-31') OR (JH.CompletedDate < '" + to.ToString("yyyy-MM-dd") + "' and JH.JournalEx = 9 ) )" +
                                        "      AND JH.CustVendId <> 0 " +
                                        "      AND LinkToAnotherTrx <> 0 " +
                                        "      AND JH.TransactionDate <= '" + to.ToString("yyyy-MM-dd") + "'" +
                                        "     GROUP by JH.CustVendID, JR.LinkToAnotherTrx, JR.InvNumForThisTrx, JR.RowDate " +
                                        "    ) as Pd ON JrnlHdr.PostOrder = Pd.LinkToAnotherTrx and JrnlHdr.CustVendID = Pd.CustVendID " +



          "                              LEFT JOIN(" +
          "                                   SELECT JH.CustVendID, " +
          "                                          SUM(CASE WHEN JH.JournalEx = 9 THEN  JR.Amount * -1 ELSE JR.Amount END) as PmntLast30 " +
          "                                  FROM JrnlHdr JH " +
          "                                   INNER JOIN JrnlRow JR " +
          "                                     ON JH.PostOrder = JR.PostOrder " +
                                        "    WHERE 1 = 1 " +
                                        "     AND JH.JournalEx in (3, 4, 9)  " +
                                        "     AND JR.RowType IN(0, 4, 5, 6, 11)  " +
                                        "     AND JH.PayCustOrRecVend = 0  " +
                                        "     AND JR.RowNumber > 0  " +
                                        "     AND((JH.CompletedDate IS NULL OR JH.CompletedDate = '9999-12-31') OR (JH.CompletedDate < '" + to.ToString("yyyy-MM-dd") + "' and JH.JournalEx = 9 )) " +
                                        "     AND JH.CustVendId <> 0 " +
                                        "      AND LinkToAnotherTrx <> 0 " +
                                        "      AND JH.TransactionDate  between '" + lastMonth.ToString("yyyy-MM-dd") + "' and '" + to.ToString("yyyy-MM-dd") + "'" +
                                        "      GROUP by JH.CustVendID" +
                                        "    ) as Pmnt ON  JrnlHdr.CustVendID = Pmnt.CustVendID " +



                                        "LEFT JOIN Contacts  ON Customers.CustomerRecordNumber = Contacts.CustomerRecord AND Contacts.IsPrimaryContact = 1 " +
                                        "LEFT JOIN Address ON Customers.CustomerRecordNumber = Address.CustomerRecordNumber AND Address.AddressTypeNumber = 0 " +
                                        "LEFT JOIN Employee ON JrnlHdr.EmpRecordNumber = Employee.EmpRecordNumber " +
                                        "INNER JOIN Company ON Company.CompanyName = Company.CompanyName " +
                                        "WHERE 1 = 1 " +
                                        "AND JrnlHdr.JournalEx in (8, 9, 10) " +
                                        "AND JrnlRow.RowType in (0, 4, 5, 6, 11) " +
                                        "AND JrnlHdr.PayCustOrRecVend = 0 " +
                                        "AND JrnlRow.RowNumber = 0 " +
                                        "AND(JrnlHdr.CompletedDate > '" + to.ToString("yyyy-MM-dd") + "'  OR JrnlHdr.CompletedDate IS NULL ) " +
                                        "AND JrnlHdr.TransactionDate <= '" + to.ToString("yyyy-MM-dd") + "'" +

                                        where +

                                        "GROUP BY JrnlHdr.Reference, " +
                                        "JrnlHdr.TransactionDate, " +
                                        "Customers.CustomerID, " +
                                        "Customers.Customer_Bill_Name, " +
                                        "Customers.Customer_Type, " +
                                        "JrnlHdr.MainAmount, " +
                                        "Employee.EmployeeID, " +
                                        "Employee.EmployeeName, " +
                                        "JrnlHdr.Comment, " +
                                        "Customers.CustomField1, " +
                                        "Customers.CustomField2, " +
                                        "Customers.customField3, " +
                                        "Customers.CustomField4, " +
                                        "Customers.CustomField5, " +
                                        "Company.CompanyName, " +
                                        "Company.DBN, " +
                                        "Customers.CustomerRecordNumber," +
                                        "Pmnt.PmntLast30 " +
                                        "ORDER BY JrnlHdr.TransactionDate DESC";



                                if (company == null || company.Rows.Count == 0)
                                {

                                    MessageBox.Show("No company selected");
                                }
                                else
                                {
                                    if (All == true)
                                    {
                                        excecute();
                                    }
                                    else
                                    {
                                        for (int i = 0; i < company.Rows.Count; i++)
                                        {

                                            database = company.Rows[i].Field<string>(1);

                                            SqlExceByDB();

                                        }

                                    }
                                }




                        }


                    }

                    //PickingList
                    if (Type == 2)
                     {

                                showSelecOptionByReport(2);

                                mre.WaitOne();
                                if (kill == false)
                                {

                                var to = Convert.ToDateTime(To);
                                var from = Convert.ToDateTime(From);


                                var InvoiceFilter = "";

                                if(Invoice != "")
                                {
                                    InvoiceFilter = " AND Reference = '" + Invoice + "' ";
                                }

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
                                    "D.CustomField5, " +
                                    "(SELECT CompanyName FROM company) as Company, " +
                                    "(SELECT DBN FROM company) as Database, " +
                                    " B.RowDescription " +
                                    " FROM JrnlHdr A" +
                                    " INNER JOIN JrnlRow B ON A.PostOrder = B.PostOrder" +
                                    " LEFT JOIN Jobs E ON E.JobRecordNumber = B.JobRecordNumber " +
                                    " LEFT JOIN Phase F ON F.PhaseRecordNumber = B.PhaseRecordNumber " +
                                    " LEFT JOIN Employee G on G.EmpRecordNumber = A.EmpRecordNumber" +
                                    " INNER JOIN Customers C ON C.CustomerRecordNumber = B.CustomerRecordNumber" +
                                    " INNER JOIN LineItem D ON D.ItemRecordNumber = B.ItemRecordNumber" +
                                    " WHERE A.JrnlKey_Journal = '3'" +
                                    " AND B.RowType = '0'" +
                                      InvoiceFilter +
                                    " AND A.TransactionDate between '" + from.ToString("yyyy-MM-dd") + "' and '" + to.ToString("yyyy-MM-dd") + "' " +
                                    " Order by A.Reference , B.RowNumber ";

                                    if (company == null || company.Rows.Count == 0)
                                    {

                                        MessageBox.Show("No company selected");
                                    }
                                    else
                                    {
                                        if (All == true)
                                        {
                                            excecute();
                                        }
                                        else
                                        {
                                            for (int i = 0; i < company.Rows.Count; i++)
                                            {

                                            database = company.Rows[i].Field<string>(1);

                                            SqlExceByDB();

                                        }

                                        }
                                    }


                            }


                        }

                    //Purchase Orders
                    if (Type == 3)
                        {
                        showSelecOptionByReport(2);
                        mre.WaitOne();

                        if (kill == false)
                        {

                        var to = Convert.ToDateTime(To);
                        var from = Convert.ToDateTime(From);

                        var PoFilter = "";

                         if (!String.IsNullOrEmpty(PoNo)) { PoFilter = " AND A.Reference = '" + PoNo + "'"; }

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
                                "A.CustomerSONo, " +
                                 "Company.CompanyName as Company, " +
                                 "Company.DBN as Database, " +
                                "B.UnitCost" +
                                " FROM JrnlHdr A" +
                                " INNER JOIN JrnlRow B ON A.PostOrder = B.PostOrder" +
                                " LEFT JOIN Jobs E ON E.JobRecordNumber = B.JobRecordNumber " +
                                " LEFT JOIN Phase F ON F.PhaseRecordNumber = B.PhaseRecordNumber " +
                                " LEFT JOIN Employee G on G.EmpRecordNumber = A.EmpRecordNumber" +
                                " INNER JOIN Vendors C ON C.VendorRecordNumber = B.VendorRecordNumber" +
                                " INNER JOIN LineItem D ON D.ItemRecordNumber = B.ItemRecordNumber" +
                                " INNER JOIN Company ON Company.CompanyName = Company.CompanyName " +
                                " WHERE A.JrnlKey_Journal = '10'" +
                                " AND B.RowType = '0'" +
                                " AND A.TransactionDate between '" + from.ToString("yyyy-MM-dd") + "' and '" + to.ToString("yyyy-MM-dd") + "' " +
                                    PoFilter +
                                " Order by A.Reference; ";



                            if (company == null || company.Rows.Count == 0)
                            {

                                MessageBox.Show("No company selected");
                            }
                            else
                            {
                                if (All == true)
                                {
                                    excecute();
                                }
                                else
                                {
                                    for (int i = 0; i < company.Rows.Count; i++)
                                    {

                                       database = company.Rows[i].Field<string>(1);

                                       SqlExceByDB();

                                    }

                                }
                            }
                     }
                    }
                    
                    //Sales Orders
                    if (Type == 4)
                    {
                        showSelecOptionByReport(3);
                        mre.WaitOne();


                        if (kill == false)
                        {
                            var SoFilter = "";
                            var to = Convert.ToDateTime(To);
                            var from = Convert.ToDateTime(From);

                        if (!String.IsNullOrEmpty(SoNo)) { SoFilter = "AND A.Reference = '" + SoNo + "'"; }


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
                                "A.CustomerSONo, " +
                                "Company.CompanyName as Company, " +
                                "Company.DBN as Database," +
                                "B.UnitCost" +
                                " FROM JrnlHdr A" +
                                " INNER JOIN JrnlRow B ON A.PostOrder = B.PostOrder" +
                                " LEFT JOIN Jobs E ON E.JobRecordNumber = B.JobRecordNumber " +
                                " LEFT JOIN Phase F ON F.PhaseRecordNumber = B.PhaseRecordNumber " +
                                " LEFT JOIN Employee G on G.EmpRecordNumber = A.EmpRecordNumber" +
                                " INNER JOIN Customers C ON C.CustomerRecordNumber = B.CustomerRecordNumber" +
                                " INNER JOIN LineItem D ON D.ItemRecordNumber = B.ItemRecordNumber" +
                                " INNER JOIN Company ON Company.CompanyName = Company.CompanyName " +
                                " WHERE A.JrnlKey_Journal = '11'" +
                                " AND B.RowType = '0'" +
                               " AND A.TransactionDate between '" + from.ToString("yyyy-MM-dd") + "' and '" + to.ToString("yyyy-MM-dd") + "' " +

                                    SoFilter +
                                " Order by A.Reference; ";

                        
                            if (company == null || company.Rows.Count == 0)
                            {

                                MessageBox.Show("No company selected");
                            }
                            else
                            {
                                if (All == true)
                                {
                                    excecute();
                                }
                                else
                                {
                                    for (int i = 0; i < company.Rows.Count; i++)
                                    {
                                    database = company.Rows[i].Field<string>(1);

                                    SqlExceByDB();

                                    }

                                }
                            }
                        }
                    }

                    //Journal
                    if (Type == 5)
                    {

                        showSelecOptionByReport(4);

                        mre.WaitOne();
                        if (kill == false)
                        {


                        var to = Convert.ToDateTime(To);
                        var from = Convert.ToDateTime(From);

                        sql = "SELECT DISTINCT " +
                                "A.JrnlKey_Journal AS Journal," + //0
                                "A.Reference," + //1
                                "A.TransactionDate as Date," + //2
                                "H.AccountID as GLAcntNumber ," + //3
                                "H.AccountDescription as AccountDescription, " + //4
                                "B.PostOrder," + //5
                                "B.RowType, " + //6
                                "B.Amount as RowAmount," + //7
                                "B.RowDescription, " + //8
                                "C.CustomerID as CustomerId," + //9
                                "C.Customer_Bill_Name as CustomerName," + //10
                                "V.VendorID as VendorId," + //11
                                "V.Name as VendorName," + //12
                                "CAST(B.dateCleared AS varchar(10) ) as AccountReconciliationDate," + //13
                                "B.InvNumForThisTrx AS invoiceNum, " + //14
                                "Co.CompanyName as Company, " + //15
                                "Co.DBN as Database," +
                                "  (CASE A.JrnlKey_Journal   " +
                                            "     WHEN 0 THEN 'General Journal'  " +
                                            "     WHEN 1 THEN 'Cash Receipts Journal'   " +
                                            "     WHEN 2 THEN 'Cash Disbursements (Payments) Journal'   " +
                                            "     WHEN 3 THEN 'Sales Journal'   " +
                                            "     WHEN 4 THEN 'Purchase Journal'   " +
                                            "     WHEN 5 THEN 'Payroll Journal'   " +
                                            "     WHEN 6 THEN 'Cost of Goods Sold Journal'   " +
                                            "     WHEN 7 THEN 'Inventory Adjustment Journal'   " +
                                            "     WHEN 8 THEN 'Assembly Adjustments (Build/Unbuild) Journal'   " +
                                            "     WHEN 9 THEN 'TempBelowZeroInvAdj (Only sage use)'   " +
                                            "     WHEN 10 THEN 'Purchase Orders Journal'   " +
                                            "     WHEN 11 THEN 'Sales Orders Journal'   " +
                                            "     WHEN 12 THEN 'Quotes Journal'   " +
                                            "   END) AS JournalDesc  " +
                            " FROM JrnlHdr A" +
                            " LEFT JOIN JrnlRow B ON A.PostOrder = B.PostOrder" +
                            " LEFT JOIN Vendors V ON V.VendorRecordNumber = B.VendorRecordNumber" +
                            " LEFT JOIN Customers C ON C.CustomerRecordNumber = B.CustomerRecordNumber" +
                            " LEFT JOIN Chart H ON H.GLAcntNumber = B.GLAcntNumber " +
                            " INNER JOIN Company Co ON Co.CompanyName = Co.CompanyName " +
                            " WHERE  " +
                            " A.TransactionDate between '" + from.ToString("yyyy-MM-dd") + "' and '" + to.ToString("yyyy-MM-dd") + "' " +
                            " Order by A.Reference; ";


                            if (company == null || company.Rows.Count == 0)
                            {

                                MessageBox.Show("No company selected");
                            }
                            else
                            {
                                if (All == true)
                                {
                                    excecute();
                                }
                                else
                                {
                                    for (int i = 0; i < company.Rows.Count; i++)
                                    {

                                       database = company.Rows[i].Field<string>(1);
    
                                       SqlExceByDB();
    
                                    }

                                }
                            }

                    }


                    }

                    //Inventory OnHand Analysis
                    if (Type == 6)//Inventory OnHand Analysis 
                    {

                        showSelecOptionByReport(7);

                        mre.WaitOne();
                        if (kill == false)
                        {
                            var where = "";
                            SysDate = DateTime.Today;

                            sql =
                                    "SELECT  " +
                                    "A.ItemID, " +
                                    "A.SalesDescription, " +
                                    "A.UPC_SKU, " +
                                    "A.Weight, " +
                                    "A.PriceLevel1Amount," +
                                    "A.StockingUM, " +
                                    "A.CustomField1,  " +
                                    "A.CustomField2,  " +
                                    "A.customField3,  " +
                                    "A.CustomField4,  " +
                                    "A.CustomField5,  " +
                                    "A.ItemRecordNumber, " +
                                    "C.CompanyName as Company, " +
                                    "C.DBN as Database,  " +
                                    "IFNULL(InventoryCosts.Quantity,0) AS QtyOnHand,   " +
                                    "IFNULL(QtyOnPOSO.QtyPO, 0) + IFNULL(QtyOnPS.QtyOnPs,0) 'Quantity on Purchase Orders',  " +
                                    "IFNULL(QtyOnPOSO.QtySO, 0) + IFNULL(QtyOnPS.QtyOnSs,0) 'Quantity on Sales Orders',  " +
                                    "A.ItemIsInactive, " +
                                    "A.ItemClass, " +
                                    "A.Category as ItemType, " +
                                    "A.OrderQty as ReorderQuantity " +
                                    "FROM  LineItem A  " +
                                    "LEFT JOIN  " +
                                    "		( " +
                                    "		SELECT  " +
                                    "			ROW.ItemRecordNumber,  " +
                                    "			SUM(  " +
                                    "				IF ( " +
                                    "					Journal = 10,  " +
                                    "					IFNULL(ROW.StockingQuantity,0) - IFNULL(ROW.StockingQtyReceived,0),  " +
                                    "					0 " +
                                    "				) " +
                                    "			) QtyPO, " +
                                    "			SUM(  " +
                                    "				IF ( " +
                                    "					Journal = 11,  " +
                                    "					IFNULL(ROW.StockingQuantity,0) - IFNULL(ROW.StockingQtyReceived,0),  " +
                                    "					0 " +
                                    "				) " +
                                    "			) QtySO " +
                                    "		FROM (  " +
                                    "			JrnlRow ROW " +
                                    "			INNER JOIN JrnlHdr HDR " +
                                    "			ON ROW.PostOrder = HDR.PostOrder ) " +
                                    "		WHERE  " +
                                    "			HDR.TrxIsPosted = 1  " +
                                    "			AND (HDR.JournalEx != 20 OR HDR.ProposalAccepted = 1)  " +
                                    "			AND HDR.POSOIsClosed = 0  " +
                                    "			AND ROW.Journal in  (10 ,11) " +
                                    "			AND ROW.RowDate <= '" + SysDate.ToString("yyyy-MM-dd") + "'" +
                                    "		GROUP BY ROW.ItemRecordNumber) QtyOnPOSO  " +
                                    "	ON QtyOnPOSO.ItemRecordNumber = A.ItemRecordNumber  " +
                                    "LEFT JOIN ( " +
                                    "		SELECT " +
                                    "			ROW.ItemRecordNumber, " +
                                    "			SUM(IF (Journal = 4, StockingQuantity, 0)) as QtyOnPs, " +
                                    "			SUM(IF (Journal = 3, StockingQuantity, 0)) as QtyOnSs  " +
                                    "		FROM " +
                                    "			JrnlRow ROW " +
                                    "			INNER JOIN JrnlHdr HDR " +
                                    "			ON ROW.PostOrder = HDR.PostOrder " +
                                    "			INNER JOIN JrnlHdr ODRHDR " +
                                    "			ON ROW.LinkToAnotherTrx = ODRHDR.PostOrder    " +
                                    "		WHERE " +
                                    "			HDR.TrxIsPosted=1 AND (HDR.JournalEx IN (8, 10, 11)) " +
                                    "			AND HDR.POSOIsClosed = 0  " +
                                    "			AND ROW.Journal IN (3, 4) AND ROW.RowType = 0  " +
                                    "			AND ROW.LinkToAnotherTrx !=0 AND ROW.RowDate <=  '" + SysDate.ToString("yyyy-MM-dd") + "'" +
                                    "			AND ODRHDR.TrxIsPosted = 1 AND ODRHDR.TransactionDate <=  '" + SysDate.ToString("yyyy-MM-dd") + "'" +
                                    "		GROUP BY " +
                                    "			ROW.ItemRecordNumber	 " +
                                    "	) QtyOnPS " +
                                    "	ON  QtyOnPS.ItemRecordNumber = A.ItemRecordNumber  " +
                                    "LEFT JOIN  " +
                                    "		( " +
                                    "		SELECT IC.ItemRecNumber,IC.TransDate,IC.RecordType, IC.Quantity, IC.TransAmount " +
                                    "		FROM InventoryCosts IC " +
                                    "		INNER JOIN   " +
                                    "			( " +
                                    "			SELECT IC1.ItemRecNumber,MAX(IC1.TransDate)Transdate  " +
                                    "			FROM InventoryCosts IC1  " +
                                    "			WHERE  IC1.RecordType = '50' AND IC1.TransDate <=  '" + SysDate.ToString("yyyy-MM-dd") + "'" +
                                    "			GROUP BY IC1.ItemRecNumber " +
                                    "			) ICMaxDate " +
                                    "		ON IC.ItemRecNumber = ICMaxDate.ItemRecNumber AND IC.RecordType = '50' AND ICMaxDate.Transdate=IC.TransDate " +
                                    "		) InventoryCosts " +
                                    "	ON  InventoryCosts.ItemRecNumber = A.ItemRecordNumber " +
                                    "INNER JOIN Company C ON C.CompanyName = C.CompanyName " +
                                     where +
                                    "GROUP BY  " +
                                    "A.ItemID,  " +
                                    "A.SalesDescription, " +
                                    "A.UPC_SKU,  " +
                                    "A.Weight,  " +
                                    "A.PriceLevel1Amount, " +
                                    "A.StockingUM,  " +
                                    "A.CustomField1,  " +
                                    "A.CustomField2,  " +
                                    "A.CustomField3,  " +
                                    "A.CustomField4,  " +
                                    "A.CustomField5,  " +
                                    "A.ItemRecordNumber,  " +
                                    "A.ItemIsInactive, " +
                                    "A.ItemClass ,  " +
                                    "A.OrderQty, " +
                                    "QtyPO,  " +
                                    "QtySO,  " +
                                    "QtyOnPs, " +
                                    "QtyOnSs,  " +
                                    "Category, " +
                                    "Quantity, " +
                                    "Company, " +
                                    "Database ;";


                                    if (company == null || company.Rows.Count == 0)
                                    {

                                        MessageBox.Show("No company selected");
                                    }
                                    else
                                    {
                                        if (All == true)
                                        {
                                            excecute();
                                        }
                                        else
                                        {
                                            for (int i = 0; i < company.Rows.Count; i++)
                                            {

                                               database = company.Rows[i].Field<string>(1);

                                                  SqlExceByDB();

                                            }

                                        }
                                    }

                    }


                    }

                    //Income statement
                    if (Type == 7)
                    {

           
                         showSelecOptionByReport(5);
                         mre.WaitOne();
                   

                            if (kill == false)
                            {


                        var thisyear = " ( ";
                        var lastyear = " ( ";
                        var Budgetthisyear = " ( ";
                        var Budgetlastyear = " ( ";




                        for (int rng = period1; rng >= period1 && rng <= period2; rng++)
                        {

                            switch (rng)
                            {

                                
                                //this year vs last year 
                                case 14:
                                    thisyear = thisyear + "    C.Balance15Net + ";
                                    lastyear = lastyear + "    C.Balance1Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period15,0) + ";
                                    Budgetlastyear = Budgetlastyear + "  IFNULL(B.Period1,0) + ";

                                    break;
                                case 15:
                                    thisyear = thisyear + "    C.Balance16Net + ";
                                    lastyear = lastyear + "    C.Balance2Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period16,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period2,0) + ";

                                    break;
                                case 16:
                                    thisyear = thisyear + "    C.Balance17Net + ";
                                    lastyear = lastyear + "    C.Balance3Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period17,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period3,0) + ";

                                    break;
                                case 17:
                                    thisyear = thisyear + "    C.Balance18Net + ";
                                    lastyear = lastyear + "    C.Balance4Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period18,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period4,0) + ";

                                    break;
                                case 18:
                                    thisyear = thisyear + "    C.Balance19Net + ";
                                    lastyear = lastyear + "    C.Balance5Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period19,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period5,0) + ";

                                    break;
                                case 19:
                                    thisyear = thisyear + "    C.Balance20Net + ";
                                    lastyear = lastyear + "    C.Balance6Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period20,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period6,0) + ";

                                    break;
                                case 20:
                                    thisyear = thisyear + "    C.Balance21Net + ";
                                    lastyear = lastyear + "    C.Balance7Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period21,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period7,0) + ";

                                    break;
                                case 21:
                                    thisyear = thisyear + "    C.Balance22Net + ";
                                    lastyear = lastyear + "    C.Balance8Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period22,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period8,0) + ";

                                    break;
                                case 22:
                                    thisyear = thisyear + "    C.Balance23Net + ";
                                    lastyear = lastyear + "    C.Balance9Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period23,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period9,0) + ";

                                    break;
                                case 23:
                                    thisyear = thisyear + "    C.Balance24Net + ";
                                    lastyear = lastyear + "    C.Balance10Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period24,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period10,0) + ";

                                    break;
                                case 24:
                                    thisyear = thisyear + "    C.Balance25Net + ";
                                    lastyear = lastyear + "    C.Balance11Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period25,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period11,0) + ";

                                    break;
                                case 25:
                                    thisyear = thisyear + "    C.Balance26Net + ";
                                    lastyear = lastyear + "    C.Balance12Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period26,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period12,0) + ";

                                    break;
                                //this year 

                                //next year vs this year 

                                case 26:
                                    thisyear = thisyear + "    C.Balance29Net + ";
                                    lastyear = lastyear + "    C.Balance15Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period29,0) + ";
                                    Budgetlastyear = Budgetlastyear + "  IFNULL(B.Period15,0) + ";

                                    break;
                                case 27:
                                    thisyear = thisyear + "    C.Balance30Net + ";
                                    lastyear = lastyear + "    C.Balance16Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period30,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period16,0) + ";

                                    break;
                                case 28:
                                    thisyear = thisyear + "    C.Balance31Net + ";
                                    lastyear = lastyear + "    C.Balance17Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period31,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period17,0) + ";

                                    break;
                                case 29:
                                    thisyear = thisyear + "    C.Balance32Net + ";
                                    lastyear = lastyear + "    C.Balance18Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period32,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period18,0) + ";

                                    break;
                                case 30:
                                    thisyear = thisyear + "    C.Balance33Net + ";
                                    lastyear = lastyear + "    C.Balance19Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period33,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period19,0) + ";

                                    break;
                                case 31:
                                    thisyear = thisyear + "    C.Balance34Net + ";
                                    lastyear = lastyear + "    C.Balance20Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period34,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period20,0) + ";

                                    break;
                                case 32:
                                    thisyear = thisyear + "    C.Balance35Net + ";
                                    lastyear = lastyear + "    C.Balance21Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period35,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period21,0) + ";

                                    break;
                                case 33:
                                    thisyear = thisyear + "    C.Balance36Net + ";
                                    lastyear = lastyear + "    C.Balance22Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period36,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period22,0) + ";

                                    break;
                                case 34:
                                    thisyear = thisyear + "    C.Balance37Net + ";
                                    lastyear = lastyear + "    C.Balance23Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period37,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period23,0) + ";

                                    break;
                                case 35:
                                    thisyear = thisyear + "    C.Balance38Net + ";
                                    lastyear = lastyear + "    C.Balance24Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period38,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period24,0) + ";

                                    break;
                                case 36:
                                    thisyear = thisyear + "    C.Balance39Net + ";
                                    lastyear = lastyear + "    C.Balance25Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period39,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period25,0) + ";

                                    break;
                                case 37:
                                    thisyear = thisyear + "    C.Balance40Net + ";
                                    lastyear = lastyear + "    C.Balance26Net + ";
                                    Budgetthisyear = Budgetthisyear + " IFNULL(B.Period40,0) + ";
                                    Budgetlastyear = Budgetlastyear + " IFNULL(B.Period26,0) + ";
                                    break;
                                    //next year vs this year 

                            }

                        }



                        thisyear = thisyear.Remove(thisyear.Length - 2, 1) + " ) as ThisYearBalance,  ";
                        lastyear = lastyear.Remove(lastyear.Length - 2, 1) + " ) as LastYearBalance,  ";
                        Budgetthisyear = Budgetthisyear.Remove(Budgetthisyear.Length - 2, 1) + "  ) as BudgetThisYearBalance,  ";
                        Budgetlastyear = Budgetlastyear.Remove(Budgetlastyear.Length - 2, 1) + "  ) as BudgetLastYearBalance,  ";

                        var thisyearYTD = " ( ";
                        var lastyearYTD = " ( ";
                        var BudgetthisyearYTD = " ( ";
                        var BudgetlastyearYTD = " ( ";
                        int starYP = 0;

                        switch (starPeriodYearSelected.Contains("THIS"))
                        {


                            case true:
                                starYP = 14;
                                break;
                            case false:
                                starYP = 26;
                                break;

                        }

                        for (int rng = starYP; rng >= starYP && rng <= period2; rng++)
                        {

                            switch (rng)
                            {

                                case 14:
                                    thisyearYTD = thisyearYTD + "    C.Balance15Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance1Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period15,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + "  IFNULL(B.Period1,0) + ";

                                    break;
                                case 15:
                                    thisyearYTD = thisyearYTD + "    C.Balance16Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance2Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period16,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period2,0) + ";

                                    break;
                                case 16:
                                    thisyearYTD = thisyearYTD + "    C.Balance17Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance3Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period17,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period3,0) + ";

                                    break;
                                case 17:
                                    thisyearYTD = thisyearYTD + "    C.Balance18Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance4Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period18,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period4,0) + ";

                                    break;
                                case 18:
                                    thisyearYTD = thisyearYTD + "    C.Balance19Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance5Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period19,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period5,0) + ";

                                    break;
                                case 19:
                                    thisyearYTD = thisyearYTD + "    C.Balance20Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance6Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period20,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period6,0) + ";

                                    break;
                                case 20:
                                    thisyearYTD = thisyearYTD + "    C.Balance21Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance7Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period21,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period7,0) + ";

                                    break;
                                case 21:
                                    thisyearYTD = thisyearYTD + "    C.Balance22Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance8Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period22,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period8,0) + ";

                                    break;
                                case 22:
                                    thisyearYTD = thisyearYTD + "    C.Balance23Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance9Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period23,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period9,0) + ";

                                    break;
                                case 23:
                                    thisyearYTD = thisyearYTD + "    C.Balance24Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance10Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period24,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period10,0) + ";

                                    break;
                                case 24:
                                    thisyearYTD = thisyearYTD + "    C.Balance25Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance11Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period25,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period11,0) + ";

                                    break;
                                case 25:
                                    thisyearYTD = thisyearYTD + "    C.Balance26Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance12Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period26,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period12,0) + ";

                                    break;

                                case 26:
                                    thisyearYTD = thisyearYTD + "    C.Balance29Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance15Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period29,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + "  IFNULL(B.Period15,0) + ";

                                    break;
                                case 27:
                                    thisyearYTD = thisyearYTD + "    C.Balance30Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance16Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period30,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period16,0) + ";

                                    break;
                                case 28:
                                    thisyearYTD = thisyearYTD + "    C.Balance31Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance17Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period31,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period17,0) + ";

                                    break;
                                case 29:
                                    thisyearYTD = thisyearYTD + "    C.Balance32Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance18Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period32,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period18,0) + ";

                                    break;
                                case 30:
                                    thisyearYTD = thisyearYTD + "    C.Balance33Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance19Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period33,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period19,0) + ";

                                    break;
                                case 31:
                                    thisyearYTD = thisyearYTD + "    C.Balance34Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance20Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period34,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period20,0) + ";

                                    break;
                                case 32:
                                    thisyearYTD = thisyearYTD + "    C.Balance35Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance21Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period35,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period21,0) + ";

                                    break;
                                case 33:
                                    thisyearYTD = thisyearYTD + "    C.Balance36Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance22Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period36,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period22,0) + ";

                                    break;
                                case 34:
                                    thisyearYTD = thisyearYTD + "    C.Balance37Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance23Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period37,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period23,0) + ";

                                    break;
                                case 35:
                                    thisyearYTD = thisyearYTD + "    C.Balance38Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance24Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period38,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period24,0) + ";

                                    break;
                                case 36:
                                    thisyearYTD = thisyearYTD + "    C.Balance39Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance25Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period39,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period25,0) + ";

                                    break;
                                case 37:
                                    thisyearYTD = thisyearYTD + "    C.Balance40Net + ";
                                    lastyearYTD = lastyearYTD + "    C.Balance26Net + ";
                                    BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period40,0) + ";
                                    BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period26,0) + ";

                                    break;
                            }

                        }




                        thisyearYTD = thisyearYTD.Remove(thisyearYTD.Length - 2, 1) + " ) as ThisYearYTDBalance,  ";
                        lastyearYTD = lastyearYTD.Remove(lastyearYTD.Length - 2, 1) + " ) as LastYearYTDBalance,  ";
                        BudgetthisyearYTD = BudgetthisyearYTD.Remove(BudgetthisyearYTD.Length - 2, 1) + " ) as BudgetThisYearYTDBalance,  ";
                        BudgetlastyearYTD = BudgetlastyearYTD.Remove(BudgetlastyearYTD.Length - 2, 1) + "  ) as BudgetLastYearYTDBalance,  ";


                        sql = " SELECT DISTINCT   " +
                                                    "  (CASE C.AccountType   " +
                                                    "     WHEN 21 THEN 'INGRESOS'  " +
                                                    "     WHEN 23 THEN 'COSTOS'   " +
                                                    "     WHEN 24 THEN 'GASTOS'   " +
                                                    "   END) AS Tipo,   " +//1
                                                    "    C.AccountID,    " + //2
                                                    "    C.AccountType,    " + //3
                                                    "    C.AccountDescription, " + //4
                                                    "    C.GLAcntNumber , " + //5

                                                            thisyear + //6
                                                            lastyear + //7
                                                            thisyearYTD + //8
                                                            lastyearYTD +//9

                                                    "    D.CompanyName,  " + //10
                                                    "    D.DBN  " + //11

                                                    " FROM Chart C  " +
                                                    " INNER JOIN Company D ON D.CompanyName = D.CompanyName  " +
                                                    " LEFT JOIN General_GL GL ON GL.AcctgModule = 4 " +
                                                    " WHERE C.AccountType in (21,23,24)" +
                                                    " ORDER BY C.AccountType asc  ;  ";



                        if (company == null || company.Rows.Count == 0)
                        {

                            MessageBox.Show("No company selected");
                        }
                        else
                        {
                            if (All == true)
                            {
                                excecute();
                            }
                            else
                            {
                                for (int i = 0; i < company.Rows.Count; i++)
                                {
                                    

                                  //  fiscalYr = company.Rows[i].Field<string>(0);
                                    database = company.Rows[i].Field<string>(1);

                                    SqlExceByDB();

                                }

                            }
                        }




                    }


                    }
                    
                    //Customer balance
                    if (Type == 8)
                    {


                        showSelecOptionByReport(5);
                        mre.WaitOne();


                        if (kill == false)
                        {


                            sql = " Select   " +
                                    "    CustomerID,  " +
                                    "    Customer_Bill_Name, " +
                                    "    Customer_Type, " +
                                    "    CustomField1," +
                                    "    CustomField2," +
                                    "    CustomField3," +
                                    "    CustomField4," +
                                    "    CustomField5," +
                                    "    Balance," +
                                    "    Sales2 as SalesPeriod1," + //9
                                    "    Sales3 as SalesPeriod2," +
                                    "    Sales4 as SalesPeriod3," +
                                    "    Sales5 as SalesPeriod4," +
                                    "    Sales6 as SalesPeriod5," +
                                    "    Sales7 as SalesPeriod6," +
                                    "    Sales8 as SalesPeriod7," +
                                    "    Sales9 as SalesPeriod8," +
                                    "    Sales10 as SalesPeriod9," +
                                    "    Sales11 as SalesPeriod10," +
                                    "    Sales12 as SalesPeriod11," +
                                    "    Sales13 as SalesPeriod12," + //20
                                    "    Sales16 as SalesPeriod13, " +
                                    "    Sales17 as SalesPeriod14," +
                                    "    Sales18 as SalesPeriod15," +
                                    "    Sales19 as SalesPeriod16," +
                                    "    Sales20 as SalesPeriod17," +
                                    "    Sales21 as SalesPeriod18," +
                                    "    Sales22 as SalesPeriod19," +
                                    "    Sales23 as SalesPeriod20," +
                                    "    Sales24 as SalesPeriod21," +
                                    "    Sales25 as SalesPeriod22," +
                                    "    Sales26 as SalesPeriod23," +
                                    "    Sales27 as SalesPeriod24," +//32
                                    "    Payments2 as PynmtPeriod1," +
                                    "    Payments3 as PynmtPeriod2," +
                                    "    Payments4 as PynmtPeriod3," +
                                    "    Payments5 as PynmtPeriod4," +
                                    "    Payments6 as PynmtPeriod5," +
                                    "    Payments7 as PynmtPeriod6," +
                                    "    Payments8 as PynmtPeriod7," +
                                    "    Payments9 as PynmtPeriod8," +
                                    "    Payments10 as PynmtPeriod9," +
                                    "    Payments11 as PynmtPeriod10," +
                                    "    Payments12 as PynmtPeriod11," +
                                    "    Payments13 as PynmtPeriod12," +//44
                                    "    Payments16 as PynmtPeriod13," +
                                    "    Payments17 as PynmtPeriod14," +
                                    "    Payments18 as PynmtPeriod15," +
                                    "    Payments19 as PynmtPeriod16," +
                                    "    Payments20 as PynmtPeriod17," +
                                    "    Payments21 as PynmtPeriod18," +
                                    "    Payments22 as PynmtPeriod19," +
                                    "    Payments23 as PynmtPeriod20," +
                                    "    Payments24 as PynmtPeriod21," +
                                    "    Payments25 as PynmtPeriod22," +
                                    "    Payments26 as PynmtPeriod23," +
                                    "    Payments27 as PynmtPeriod24," +
                                    "    D.CompanyName,  " +//57
                                    "    D.DBN,  " +
                                    "    YEAR(GL.Periods29FrmDate) AS FisacalYear  " +
                                    " FROM   Customers  " +
                                    " INNER JOIN Company D ON D.CompanyName = D.CompanyName  " +
                                    " LEFT JOIN General_GL GL ON GL.AcctgModule = 4 " +
                                    " WHERE  CustomerIsInactive = 0 AND " +
                                    "        IsProspect         = 0  ";

                        if (company == null || company.Rows.Count == 0)
                        {

                            MessageBox.Show("No company selected");
                        }
                        else
                        {
                            if (All == true)
                            {
                                excecute();
                            }
                            else
                            {
                                for (int i = 0; i < company.Rows.Count; i++)
                                {
                                   // fiscalYr = company.Rows[i].Field<string>(0);
                                    database = company.Rows[i].Field<string>(1);

                                    SqlExceByDB();

                                }

                            }
                        }




                    }


                    }

                    //BalanceSheet
                    if (Type == 9)
                    {


                        showSelecOptionByReport(8);
                                mre.WaitOne();


                                if (kill == false)
                                {


                        var thisyearYTD = " ( ";
                        var beginBalance = "";
                        int starYP= 0 ;

                        switch (starPeriodYearSelected.Contains("THIS"))
                        {
                            
                            case true:
                                starYP = 14;
                                beginBalance = "      ( C.Balance0Net + C.Balance1Net + C.Balance2Net + " +
                                                "       C.Balance3Net + C.Balance4Net + C.Balance5Net + " +
                                                "       C.Balance6Net + C.Balance7Net + C.Balance8Net + " +
                                                "       C.Balance9Net + C.Balance10Net + C.Balance11Net + " +
                                                "       C.Balance12Net + C.Balance13Net + C.Balance14Net  ) as BeginBalance  ";
                                break;
                            case false:
                                starYP = 26;
                                beginBalance = "      ( C.Balance0Net + C.Balance1Net + C.Balance2Net + " +
                                                "       C.Balance3Net + C.Balance4Net + C.Balance5Net +" +
                                                "       C.Balance6Net + C.Balance7Net + C.Balance8Net + " +
                                                "       C.Balance9Net + C.Balance10Net + C.Balance11Net + " +
                                                "       C.Balance12Net + C.Balance13Net + C.Balance14Net + " +
                                                "       C.Balance15Net + C.Balance16Net + C.Balance17Net +" +
                                                "       C.Balance18Net + C.Balance19Net + C.Balance20Net + " +
                                                "       C.Balance21Net + C.Balance22Net + C.Balance23Net +" +
                                                "       C.Balance24Net + C.Balance25Net + C.Balance26Net + " +
                                                "      C.Balance27Net + C.Balance28Net ) AS BeginBalance  "; // 9
                                break;

                        }





                        for (int rng = starYP;  rng <= period2; rng++)
                        {

                            switch (rng)
                            {

                                case 14:
                                    thisyearYTD = thisyearYTD + "    C.Balance15Net + ";
                                  

                                    break;
                                case 15:
                                    thisyearYTD = thisyearYTD + "    C.Balance16Net + ";
                                    

                                    break;
                                case 16:
                                    thisyearYTD = thisyearYTD + "    C.Balance17Net + ";
                                   

                                    break;
                                case 17:
                                    thisyearYTD = thisyearYTD + "    C.Balance18Net + ";
                                    

                                    break;
                                case 18:
                                    thisyearYTD = thisyearYTD + "    C.Balance19Net + ";
                                   

                                    break;
                                case 19:
                                    thisyearYTD = thisyearYTD + "    C.Balance20Net + ";
                                  
                                    break;
                                case 20:
                                    thisyearYTD = thisyearYTD + "    C.Balance21Net + ";
                                  

                                    break;
                                case 21:
                                    thisyearYTD = thisyearYTD + "    C.Balance22Net + ";
                                   
                                    break;
                                case 22:
                                    thisyearYTD = thisyearYTD + "    C.Balance23Net + ";
                                   
                                    break;
                                case 23:
                                    thisyearYTD = thisyearYTD + "    C.Balance24Net + ";
                                   
                                    break;
                                case 24:
                                    thisyearYTD = thisyearYTD + "    C.Balance25Net + ";
                                  
                                    break;
                                case 25:
                                    thisyearYTD = thisyearYTD + "    C.Balance26Net + ";
                                   
                                    break;

                                case 26:
                                    thisyearYTD = thisyearYTD + "    C.Balance29Net + ";
                                   
                                    break;
                                case 27:
                                    thisyearYTD = thisyearYTD + "    C.Balance30Net + ";
                                   
                                    break;
                                case 28:
                                    thisyearYTD = thisyearYTD + "    C.Balance31Net + ";
                                   
                                    break;
                                case 29:
                                    thisyearYTD = thisyearYTD + "    C.Balance32Net + ";
                                   
                                    break;
                                case 30:
                                    thisyearYTD = thisyearYTD + "    C.Balance33Net + ";
                                   
                                    break;
                                case 31:
                                    thisyearYTD = thisyearYTD + "    C.Balance34Net + ";
                                   
                                    break;
                                case 32:
                                    thisyearYTD = thisyearYTD + "    C.Balance35Net + ";
                                   
                                    break;
                                case 33:
                                    thisyearYTD = thisyearYTD + "    C.Balance36Net + ";
                                  
                                    break;
                                case 34:
                                    thisyearYTD = thisyearYTD + "    C.Balance37Net + ";
                                   
                                    break;
                                case 35:
                                    thisyearYTD = thisyearYTD + "    C.Balance38Net + ";
                                   
                                    break;
                                case 36:
                                    thisyearYTD = thisyearYTD + "    C.Balance39Net + ";
                                   
                                    break;
                                case 37:
                                    thisyearYTD = thisyearYTD + "    C.Balance40Net + ";
                                   
                                    break;
                            }

                        }
                        

                        thisyearYTD = thisyearYTD.Remove(thisyearYTD.Length - 2, 1) + " ) as netbalance,  ";
                       
                    
                        sql = " SELECT DISTINCT   " +
                              " (  CASE C.AccountType " +
                                      "  WHEN 0 THEN 'Cash'  " +
                                      "  WHEN 1 THEN 'Accounts Receivable'  " +
                                      "  WHEN 2 THEN 'Inventory'  " +
                                      "  WHEN 3 THEN 'Receivable Retainage'  " +
                                      "  WHEN 4 THEN 'Other Current Assets'  " +
                                      "  WHEN 5 THEN 'Fixed Assets'  " +
                                      "  WHEN 6 THEN 'Accumulated Depreciation'  " +
                                      "  WHEN 8 THEN 'Other Assets' " +
                                      "  WHEN 10 THEN 'Accounts Payable' " +
                                      "  WHEN 11 THEN 'Payable Retainage' " +
                                      "  WHEN 12 THEN 'Other Current Liabilities' " +
                                      "  WHEN 14 THEN 'Long Term Liabilities' " +
                                      "  WHEN 16 THEN 'Equity-does not close' " +
                                      "  WHEN 18 THEN 'Equity-Retained Earnings' " +
                                      "  WHEN 19 THEN 'Equity-gets closed' " +
                                      "  WHEN 21 THEN 'Income' " +
                                      "  WHEN 23 THEN 'Cost of Sales' " +
                                      "  WHEN 24 THEN 'Expenses' " +
                                " END )  as 'Account_Type', " +// 1
                                "    C.AccountID,    " +// 2
                                "    C.AccountType,    " + // 3
                                "    C.AccountDescription, " + // 4
                                "    C.GLAcntNumber , " + // 5
                                     thisyearYTD +   // 6
                                "    D.CompanyName,  " + // 7
                                "    D.DBN,  " + // 8
                                     beginBalance + //9
                                " FROM Chart C  " +
                                " INNER JOIN Company D ON D.CompanyName = D.CompanyName  " +
                                " LEFT JOIN General_GL GL ON GL.AcctgModule = 4 ;"; 
                              

                                   

                        if (company == null || company.Rows.Count == 0)
                        {

                            MessageBox.Show("No company selected");
                        }
                        else
                        {
                            if (All == true)
                            {
                                excecute();
                            }
                            else
                            {
                                for (int i = 0; i < company.Rows.Count; i++)
                                {
                                    //fiscalYr = company.Rows[i].Field<string>(0);
                                    database = company.Rows[i].Field<string>(1);

                                    SqlExceByDB();

                                }

                            }
                        }




                    }


                        }
                    
                    //Income statement vs budget
                    if (Type == 10)
                    {


                        showSelecOptionByReport(6);
                        mre.WaitOne();


                        if (kill == false)
                        {

                        


                        if (budget == null || budget.Rows.Count == 0)
                        {

                            MessageBox.Show("No company selected");
                        }
                        else
                        {
                            for (int i = 0; i < budget.Rows.Count; i++)
                                {


                                var thisyear = " ( ";
                                var lastyear = " ( ";
                                var Budgetthisyear = " ( ";
                                var Budgetlastyear = " ( ";
                              

      

                                for (int rng = period1; rng >= period1 && rng <= period2; rng++)
                                {

                                    switch (rng)
                                    {

                                     


                                        //this year vs last year 
                                        case 14:
                                            thisyear = thisyear + "    C.Balance15Net + ";
                                            lastyear = lastyear + "    C.Balance1Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period15,0) + ";
                                            Budgetlastyear = Budgetlastyear + "  IFNULL(B.Period1,0) + ";

                                            break;
                                        case 15:
                                            thisyear = thisyear + "    C.Balance16Net + ";
                                            lastyear = lastyear + "    C.Balance2Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period16,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period2,0) + ";

                                            break;
                                        case 16:
                                            thisyear = thisyear + "    C.Balance17Net + ";
                                            lastyear = lastyear + "    C.Balance3Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period17,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period3,0) + ";

                                            break;
                                        case 17:
                                            thisyear = thisyear + "    C.Balance18Net + ";
                                            lastyear = lastyear + "    C.Balance4Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period18,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period4,0) + ";

                                            break;
                                        case 18:
                                            thisyear = thisyear + "    C.Balance19Net + ";
                                            lastyear = lastyear + "    C.Balance5Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period19,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period5,0) + ";

                                            break;
                                        case 19:
                                            thisyear = thisyear + "    C.Balance20Net + ";
                                            lastyear = lastyear + "    C.Balance6Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period20,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period6,0) + ";

                                            break;
                                        case 20:
                                            thisyear = thisyear + "    C.Balance21Net + ";
                                            lastyear = lastyear + "    C.Balance7Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period21,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period7,0) + ";

                                            break;
                                        case 21:
                                            thisyear = thisyear + "    C.Balance22Net + ";
                                            lastyear = lastyear + "    C.Balance8Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period22,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period8,0) + ";

                                            break;
                                        case 22:
                                            thisyear = thisyear + "    C.Balance23Net + ";
                                            lastyear = lastyear + "    C.Balance9Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period23,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period9,0) + ";

                                            break;
                                        case 23:
                                            thisyear = thisyear + "    C.Balance24Net + ";
                                            lastyear = lastyear + "    C.Balance10Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period24,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period10,0) + ";

                                            break;
                                        case 24:
                                            thisyear = thisyear + "    C.Balance25Net + ";
                                            lastyear = lastyear + "    C.Balance11Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period25,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period11,0) + ";

                                            break;
                                        case 25:
                                            thisyear = thisyear + "    C.Balance26Net + ";
                                            lastyear = lastyear + "    C.Balance12Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period26,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period12,0) + ";

                                            break;
                                        //this year 

                                        //next year vs this year 
                                       
                                        case 26:
                                            thisyear = thisyear + "    C.Balance29Net + ";
                                            lastyear = lastyear + "    C.Balance15Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period29,0) + ";
                                            Budgetlastyear = Budgetlastyear + "  IFNULL(B.Period15,0) + ";

                                            break;
                                        case 27:
                                            thisyear = thisyear + "    C.Balance30Net + ";
                                            lastyear = lastyear + "    C.Balance16Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period30,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period16,0) + ";

                                            break;
                                        case 28:
                                            thisyear = thisyear + "    C.Balance31Net + ";
                                            lastyear = lastyear + "    C.Balance17Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period31,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period17,0) + ";

                                            break;
                                        case 29:
                                            thisyear = thisyear + "    C.Balance32Net + ";
                                            lastyear = lastyear + "    C.Balance18Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period32,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period18,0) + ";

                                            break;
                                        case 30:
                                            thisyear = thisyear + "    C.Balance33Net + ";
                                            lastyear = lastyear + "    C.Balance19Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period33,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period19,0) + ";

                                            break;
                                        case 31:
                                            thisyear = thisyear + "    C.Balance34Net + ";
                                            lastyear = lastyear + "    C.Balance20Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period34,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period20,0) + ";

                                            break;
                                        case 32:
                                            thisyear = thisyear + "    C.Balance35Net + ";
                                            lastyear = lastyear + "    C.Balance21Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period35,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period21,0) + ";

                                            break;
                                        case 33:
                                            thisyear = thisyear + "    C.Balance36Net + ";
                                            lastyear = lastyear + "    C.Balance22Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period36,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period22,0) + ";

                                            break;
                                        case 34:
                                            thisyear = thisyear + "    C.Balance37Net + ";
                                            lastyear = lastyear + "    C.Balance23Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period37,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period23,0) + ";

                                            break;
                                        case 35:
                                            thisyear = thisyear + "    C.Balance38Net + ";
                                            lastyear = lastyear + "    C.Balance24Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period38,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period24,0) + ";

                                            break;
                                        case 36:
                                            thisyear = thisyear + "    C.Balance39Net + ";
                                            lastyear = lastyear + "    C.Balance25Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period39,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period25,0) + ";

                                            break;
                                        case 37:
                                            thisyear = thisyear + "    C.Balance40Net + ";
                                            lastyear = lastyear + "    C.Balance26Net + ";
                                            Budgetthisyear = Budgetthisyear + " IFNULL(B.Period40,0) + ";
                                            Budgetlastyear = Budgetlastyear + " IFNULL(B.Period26,0) + ";
                                            break;
                                            //next year vs this year 

                                    }

                                }



                                thisyear = thisyear.Remove(thisyear.Length - 2, 1) + " ) as ThisYearBalance,  ";
                                lastyear = lastyear.Remove(lastyear.Length - 2, 1) + " ) as LastYearBalance,  ";
                                Budgetthisyear = Budgetthisyear.Remove(Budgetthisyear.Length - 2, 1) + "  ) as BudgetThisYearBalance,  ";
                                Budgetlastyear = Budgetlastyear.Remove(Budgetlastyear.Length - 2, 1) + "  ) as BudgetLastYearBalance,  ";

                                var thisyearYTD = " ( ";
                                var lastyearYTD = " ( ";
                                var BudgetthisyearYTD = " ( ";
                                var BudgetlastyearYTD = " ( ";
                                int starYP = 0;

                                switch (starPeriodYearSelected.Contains("THIS"))
                                {

                                  
                                    case true:
                                        starYP = 14;
                                        break;
                                    case false:
                                        starYP = 26;
                                        break;

                                }

                                for (int rng = starYP ; rng >= period1 && rng <= period2; rng++)
                                {

                                    switch (rng)
                                    {
                               
                                        case 14:
                                            thisyearYTD = thisyearYTD + "    C.Balance15Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance1Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period15,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + "  IFNULL(B.Period1,0) + ";

                                            break;
                                        case 15:
                                            thisyearYTD = thisyearYTD + "    C.Balance16Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance2Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period16,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period2,0) + ";

                                            break;
                                        case 16:
                                            thisyearYTD = thisyearYTD + "    C.Balance17Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance3Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period17,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period3,0) + ";

                                            break;
                                        case 17:
                                            thisyearYTD = thisyearYTD + "    C.Balance18Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance4Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period18,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period4,0) + ";

                                            break;
                                        case 18:
                                            thisyearYTD = thisyearYTD + "    C.Balance19Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance5Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period19,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period5,0) + ";

                                            break;
                                        case 19:
                                            thisyearYTD = thisyearYTD + "    C.Balance20Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance6Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period20,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period6,0) + ";

                                            break;
                                        case 20:
                                            thisyearYTD = thisyearYTD + "    C.Balance21Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance7Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period21,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period7,0) + ";

                                            break;
                                        case 21:
                                            thisyearYTD = thisyearYTD + "    C.Balance22Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance8Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period22,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period8,0) + ";

                                            break;
                                        case 22:
                                            thisyearYTD = thisyearYTD + "    C.Balance23Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance9Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period23,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period9,0) + ";

                                            break;
                                        case 23:
                                            thisyearYTD = thisyearYTD + "    C.Balance24Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance10Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period24,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period10,0) + ";

                                            break;
                                        case 24:
                                            thisyearYTD = thisyearYTD + "    C.Balance25Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance11Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period25,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period11,0) + ";

                                            break;
                                        case 25:
                                            thisyearYTD = thisyearYTD + "    C.Balance26Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance12Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period26,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period12,0) + ";

                                            break;

                                        case 26:
                                            thisyearYTD = thisyearYTD + "    C.Balance29Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance15Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period29,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + "  IFNULL(B.Period15,0) + ";

                                            break;
                                        case 27:
                                            thisyearYTD = thisyearYTD + "    C.Balance30Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance16Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period30,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period16,0) + ";

                                            break;
                                        case 28:
                                            thisyearYTD = thisyearYTD + "    C.Balance31Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance17Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period31,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period17,0) + ";

                                            break;
                                        case 29:
                                            thisyearYTD = thisyearYTD + "    C.Balance32Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance18Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period32,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period18,0) + ";

                                            break;
                                        case 30:
                                            thisyearYTD = thisyearYTD + "    C.Balance33Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance19Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period33,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period19,0) + ";

                                            break;
                                        case 31:
                                            thisyearYTD = thisyearYTD + "    C.Balance34Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance20Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period34,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period20,0) + ";

                                            break;
                                        case 32:
                                            thisyearYTD = thisyearYTD + "    C.Balance35Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance21Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period35,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period21,0) + ";

                                            break;
                                        case 33:
                                            thisyearYTD = thisyearYTD + "    C.Balance36Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance22Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period36,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period22,0) + ";

                                            break;
                                        case 34:
                                            thisyearYTD = thisyearYTD + "    C.Balance37Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance23Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period37,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period23,0) + ";

                                            break;
                                        case 35:
                                            thisyearYTD = thisyearYTD + "    C.Balance38Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance24Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period38,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period24,0) + ";

                                            break;
                                        case 36:
                                            thisyearYTD = thisyearYTD + "    C.Balance39Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance25Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period39,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period25,0) + ";

                                            break;
                                        case 37:
                                            thisyearYTD = thisyearYTD + "    C.Balance40Net + ";
                                            lastyearYTD = lastyearYTD + "    C.Balance26Net + ";
                                            BudgetthisyearYTD = BudgetthisyearYTD + " IFNULL(B.Period40,0) + ";
                                            BudgetlastyearYTD = BudgetlastyearYTD + " IFNULL(B.Period26,0) + ";

                                            break;
                                    }

                                }

            


                                thisyearYTD = thisyearYTD.Remove(thisyearYTD.Length - 2, 1) + " ) as ThisYearYTDBalance,  ";
                                lastyearYTD = lastyearYTD.Remove(lastyearYTD.Length - 2, 1) + " ) as LastYearYTDBalance,  ";
                                BudgetthisyearYTD = BudgetthisyearYTD.Remove(BudgetthisyearYTD.Length - 2, 1) + " ) as BudgetThisYearYTDBalance,  ";
                                BudgetlastyearYTD = BudgetlastyearYTD.Remove(BudgetlastyearYTD.Length - 2, 1) + "  ) as BudgetLastYearYTDBalance,  ";


                                          sql = " SELECT DISTINCT   " +
                                                "  (CASE C.AccountType   " +
                                                "     WHEN 21 THEN 'INGRESOS'  " +
                                                "     WHEN 23 THEN 'COSTOS'   " +
                                                "     WHEN 24 THEN 'GASTOS'   " +
                                                "   END) AS Tipo,   " +//0
                                                "    C.AccountID,    " + //1
                                                "    C.AccountType,    " + //2
                                                "    C.AccountDescription, " + //3
                                                "    C.GLAcntNumber , " + //4

                                                        thisyear + //5
                                                        lastyear + //6
                                                        thisyearYTD + //7
                                                        lastyearYTD +//8
                                                        Budgetthisyear + //9
                                                        Budgetlastyear + //10
                                                        BudgetthisyearYTD +//11
                                                        BudgetlastyearYTD + //12

                                                "    D.CompanyName,  " + //13
                                                "    D.DBN  " + //14

                                                " FROM Chart C  " +
                                                " INNER JOIN Company D ON D.CompanyName = D.CompanyName  " +
                                               " LEFT JOIN " + C34 + "Budget Details" + C34 + " B ON C.GUID = B.AccountGuid  " +
                                               " INNER JOIN Budgets E ON E.BudgetGuid = B.BudgetGuid   " +
                                               " LEFT JOIN General_GL GL ON GL.AcctgModule = 4 " +
                                               " WHERE C.AccountType in (21,23,24)" +
                                               "  and E.BudgetID = '" + budget.Rows[i].Field<string>(0) + "'" +
                                               " ORDER BY C.AccountType asc  ;  ";




                             
                                database = budget.Rows[i].Field<string>(3);

                                SqlExceByDB();

                                }
                            
                        }






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

            public void excecute()//Eejecuta query por cada compañia
            {
            
                /*Listar conexion*/
                List<string> Parameters = new List<string>();


                for (int i = 0; i < strConTbl.Rows.Count; i++) //LEES CADA LINEA  de configuracion de cada conexion
                {
                    Parameters.Clear();
                    Parameters.Add(strConTbl.Rows[i].Field<string>(5));
                    Parameters.Add(strConTbl.Rows[i].Field<string>(2));
                    Parameters.Add(strConTbl.Rows[i].Field<string>(3));
                    Parameters.Add(strConTbl.Rows[i].Field<string>(4));
                
                    string strCon = SageParams.SageConString(Parameters);

                    if (dbcon.StartConn(strCon).State == System.Data.ConnectionState.Open)
                    {
                        result.Load(dbcon.Query(sql));
                        queryTable = result;
                    }

                }

                dbcon.Close();
            }

            private void  SqlExceByDB()//Eejecuta query por cada compañia
            {

                /*Listar conexion*/
                List<string> Parameters = new List<string>();
                DataTable Sqlresult = new DataTable();

            

                for (int i = 0; i < strConTbl.Rows.Count; i++) //LEES CADA LINEA  de configuracion de cada conexion
                {
                    if (strConTbl.Rows[i].Field<string>(2) == database.Trim())
                    {
                        Parameters.Clear();
                        Parameters.Add(strConTbl.Rows[i].Field<string>(5));
                        Parameters.Add(strConTbl.Rows[i].Field<string>(2));
                        Parameters.Add(strConTbl.Rows[i].Field<string>(3));
                        Parameters.Add(strConTbl.Rows[i].Field<string>(4));

                        string strCon = SageParams.SageConString(Parameters);

                        if (dbcon.StartConn(strCon).State == System.Data.ConnectionState.Open)
                        {
                            result.Load(dbcon.Query(sql));
                            queryTable = result;
                            dbcon.Close();
                        }
                    }
                   
                }
                

            

            }
        
            public DataTable fiscalyear()
                {
                    DataTable list = new DataTable();
                    list.Columns.Add("firstyear", typeof(String));
                    list.Columns.Add("lastyear", typeof(String));
                    list.Columns.Add("currentyear", typeof(String));
                    list.Columns.Add("Company", typeof(String));
                    list.Columns.Add("DBN", typeof(String));

                    list.Clear();   

                    sql = " Select YEAR(G.Periods1FrmDate )  AS FisacalYear1  ," +
                                "  YEAR(G.Periods15FrmDate ) AS FisacalYear2  ," +
                                "  YEAR(G.Periods29FrmDate ) AS FisacalYear3  ," +
                                "  C.CompanyName      ," +
                                "  C.DBN               " +
                                " FROM  General_GL G " +
                                " INNER JOIN Company C ON C.CompanyName = C.CompanyName" +
                                " where G.AcctgModule = 4";

                    excecute();

                    for (int i = 0; i < queryTable.Rows.Count; i++) //LEES CADA LINEA  de configuracion de cada conexion
                    {
                        var FiscalYear1 = queryTable.Rows[i].Field<Int32>(0);
                        var FiscalYear2 = queryTable.Rows[i].Field<Int32>(1);
                        var FiscalYear3 = queryTable.Rows[i].Field<Int32>(2);


                        list.Rows.Add  (FiscalYear1.ToString(),
                                        queryTable.Rows[i].Field<string>(3),
                                        queryTable.Rows[i].Field<string>(4));

                        list.Rows.Add(FiscalYear2.ToString(),
                                        queryTable.Rows[i].Field<string>(3),
                                        queryTable.Rows[i].Field<string>(4));

                        list.Rows.Add(FiscalYear3.ToString(),
                                        queryTable.Rows[i].Field<string>(3),
                                        queryTable.Rows[i].Field<string>(4));

                    }

                    return list;

                }
        
            public DataTable BudgetList()
            {
            

                DataTable list = new DataTable();
                list.Columns.Add("BudgetID", typeof(String));
                list.Columns.Add("BudgetDescription", typeof(String));
                list.Columns.Add("CompanyName", typeof(String));
                list.Columns.Add("DBN", typeof(String));


                list.Clear();
       
                sql = " Select B.BudgetID, " +
                          "        B.BudgetDescription, " +
                          "        C.CompanyName ," +
                          "        C.DBN " +
                          " FROM Budgets B " +
                          " INNER JOIN Company C ON C.CompanyName = C.CompanyName";

                excecute();

                for (int i = 0; i < queryTable.Rows.Count; i++) //LEES CADA LINEA  de configuracion de cada conexion
                {


                    list.Rows.Add(queryTable.Rows[i].Field<string>(0),
                                  queryTable.Rows[i].Field<string>(1),
                                  queryTable.Rows[i].Field<string>(2),
                                  queryTable.Rows[i].Field<string>(3));


                }

                return list;

            }
        
            public DataTable CompaniesList()
            {
               
                DataTable list = new DataTable();
               // list.Columns.Add("Description", typeof(String));
               // list.Columns.Add("FiscalYear", typeof(String));
                list.Columns.Add("Company", typeof(String));
                list.Columns.Add("DBCompany", typeof(String));

                list.Clear();


            sql = " Select " +
                 "    C.CompanyName , " +
                 "    C.DBN" +
                 "    FROM  Company C;";


            excecute();

                for (int i = 0; i < queryTable.Rows.Count; i++) //LEES CADA LINEA  de configuracion de cada conexion
                {




                list.Rows.Add( 
                                //queryTable.Rows[i].Field<string>(0),
                                //queryTable.Rows[i].Field<Int32>(1),
                                queryTable.Rows[i].Field<string>(0),
                                queryTable.Rows[i].Field<string>(1));




            }

                return list;

            
            }

            public DataSet SetPastDue() //facturas abiertas 
            {

                try
                {
                    

                    if (repPreview is null)
                    {


                        DataTable resTable = new DataTable("PastDue");
                        resTable.Columns.Add("CompanyName", typeof(String));
                        resTable.Columns.Add("InvoiceNo", typeof(String));
                        resTable.Columns.Add("InvoiceDate", typeof(DateTime));
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
                        resTable.Columns.Add("date_query", typeof(DateTime));
                        resTable.Columns.Add("DbName", typeof(String));
                        resTable.Columns.Add("CustRecordId", typeof(Int64));
                        resTable.Columns.Add("AmountDue", typeof(Decimal));




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

                                    // rawDate = Convert.ToDateTime(queryTable.Rows[i].Field<DateTime>(1));
                                    //date = rawDate.ToString("dd-MM-yyyy");


                                    resTable.Rows.Add(
                                    queryTable.Rows[i].Field<string>(15),
                                    queryTable.Rows[i].Field<string>(0),
                                    queryTable.Rows[i].Field<DateTime>(1),
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
                                    queryTable.Rows[i].Field<decimal>(17),
                                    Convert.ToDateTime(To),
                                    queryTable.Rows[i].Field<string>(16),
                                    queryTable.Rows[i].Field<Int32>(18),
                                    queryTable.Rows[i].Field<decimal>(19)

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
                        resTable.Columns.Add("DbName", typeof(String));
                        resTable.Columns.Add("RowDescription", typeof(String));



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
                                    date = rawDate.ToString("dd-MM-yyyy");



                                    resTable.Rows.Add(
                                     queryTable.Rows[i].Field<string>(21),
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
                                    To,
                                    queryTable.Rows[i].Field<string>(22),
                                    queryTable.Rows[i].Field<string>(23)

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
                        resTable.Columns.Add("CompanyName", typeof(String));
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
                        resTable.Columns.Add("DbName", typeof(String));
                        resTable.Columns.Add("UnitCost", typeof(Decimal));



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
                                    date = rawDate.ToString("dd-MM-yyyy");

                                    resTable.Rows.Add(
                                    queryTable.Rows[i].Field<string>(25),
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
                                    To,
                                    queryTable.Rows[i].Field<string>(26),
                                    queryTable.Rows[i].Field<decimal>(27)

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
                        resTable.Columns.Add("DbName", typeof(String));
                        resTable.Columns.Add("UnitCost", typeof(Decimal));


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
                                    date = rawDate.ToString("dd-MM-yyyy");


                                    resTable.Rows.Add(
                                    queryTable.Rows[i].Field<string>(25),
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
                                    To,
                                    queryTable.Rows[i].Field<string>(26),
                                    queryTable.Rows[i].Field<decimal>(27)
                                
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

            public DataSet Journal()//Journal
            {

                try
                {
                    DateTime rawDate;
                    string date;

                    if (repPreview is null)
                    {
                    
                        DataTable resTable = new DataTable("Journals");

                        resTable.Columns.Add("Journal", typeof(Int32));
                        resTable.Columns.Add("Reference", typeof(String));
                        resTable.Columns.Add("Date", typeof(DateTime));
                        resTable.Columns.Add("GLAcntNumber", typeof(String));
                        resTable.Columns.Add("GLAcntDescription", typeof(String));
                        resTable.Columns.Add("PostOrder", typeof(Int64));
                        resTable.Columns.Add("RowType", typeof(Int16));
                        resTable.Columns.Add("RowAmount", typeof(Decimal));
                        resTable.Columns.Add("RowDescription", typeof(String));
                        resTable.Columns.Add("IdCustomer", typeof(String));
                        resTable.Columns.Add("CustomerName", typeof(String));
                        resTable.Columns.Add("IdVendor", typeof(String));
                        resTable.Columns.Add("VendorName", typeof(String));
                        resTable.Columns.Add("AccountReconciliationDate", typeof(String));
                        resTable.Columns.Add("InvoiceNum", typeof(String));
                        resTable.Columns.Add("Date_from", typeof(String));
                        resTable.Columns.Add("Date_to", typeof(String));
                        resTable.Columns.Add("Company", typeof(String));
                        resTable.Columns.Add("DbName", typeof(String));
                        resTable.Columns.Add("Journal_Description", typeof(String));



                    repPreview = new DataSet();
                       repPreview.Tables.Add(resTable);

                        if (doQuery == true)
                        {
                            reportQuery(5);

                            if (queryTable != null && queryTable.Rows.Count > 0)
                            {
                                for (int i = 0; i < queryTable.Rows.Count; i++)
                                {

               

                                if (queryTable.Rows[i].Field<string>(15) != "")
                                {
                                        resTable.NewRow();

                                        rawDate = Convert.ToDateTime(queryTable.Rows[i].Field<DateTime>(2));
                                        date = rawDate.ToString("dd-MM-yyyy");

                                    var clearedDate = queryTable.Rows[i].Field<string>(13); 
                                   // var clearedDateStr = clearedDate.ToString("dd-MM-yyyy");

                                    
                                    resTable.Rows.Add(
                                        queryTable.Rows[i].Field<Int32>(0),
                                        queryTable.Rows[i].Field<string>(1),
                                        date,
                                        queryTable.Rows[i].Field<string>(3),
                                        queryTable.Rows[i].Field<string>(4),
                                        queryTable.Rows[i].Field<Int64>(5),
                                        queryTable.Rows[i].Field<Int32>(6),
                                        queryTable.Rows[i].Field<decimal>(7),
                                        queryTable.Rows[i].Field<string>(8),
                                        queryTable.Rows[i].Field<string>(9),
                                        queryTable.Rows[i].Field<string>(10),
                                        queryTable.Rows[i].Field<string>(11),
                                        queryTable.Rows[i].Field<string>(12),
                                        clearedDate,
                                        queryTable.Rows[i].Field<string>(14),
                                        From,
                                        To,
                                        queryTable.Rows[i].Field<string>(15),
                                        queryTable.Rows[i].Field<string>(16),
                                        queryTable.Rows[i].Field<string>(17)

                                    );


                                    }



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

            public DataSet InventoryOnHand()//Inventory on hand analisys
            {

                try
                {

                    if (repPreview is null)
                    {



                        DataTable resTable = new DataTable("InventoryOnHand");

                        resTable.Columns.Add("ItemID", typeof(String));
                        resTable.Columns.Add("SalesDescription", typeof(String));
                        resTable.Columns.Add("UPC_SKU", typeof(String));
                        resTable.Columns.Add("Weight", typeof(Decimal));
                        resTable.Columns.Add("PriceLevel1Amount", typeof(Decimal));
                        resTable.Columns.Add("StockingUM", typeof(String));
                        resTable.Columns.Add("CustomField1", typeof(String));
                        resTable.Columns.Add("CustomField2", typeof(String));
                        resTable.Columns.Add("CustomField3", typeof(String));
                        resTable.Columns.Add("CustomField4", typeof(String));
                        resTable.Columns.Add("CustomField5", typeof(String));
                        resTable.Columns.Add("ItemRecordNumber", typeof(Int32));
                        resTable.Columns.Add("Company", typeof(String));
                        resTable.Columns.Add("Database", typeof(String));
                        resTable.Columns.Add("QtyOnHand", typeof(Decimal));
                        resTable.Columns.Add("QtyOnPO", typeof(Decimal));
                        resTable.Columns.Add("QtyOnSO", typeof(Decimal));
                        resTable.Columns.Add("ItemIsInactive", typeof(Byte));
                        resTable.Columns.Add("ItemClass", typeof(Int64));
                        resTable.Columns.Add("ItemType", typeof(String));
                        resTable.Columns.Add("ReorderQuantity", typeof(Decimal));
                        resTable.Columns.Add("date_to", typeof(DateTime));


                        repPreview = new DataSet();
                        repPreview.Tables.Add(resTable);

                        if (doQuery == true)
                        {
                            reportQuery(6);

                            if (queryTable != null && queryTable.Rows.Count > 0)
                            {
                                for (int i = 0; i < queryTable.Rows.Count; i++)
                                {

                                    if (queryTable.Rows[i].Field<string>(0) != "")
                                    {
                                        resTable.NewRow();

                                        resTable.Rows.Add(

                                         queryTable.Rows[i].Field<string>(0),
                                         queryTable.Rows[i].Field<string>(1),
                                         queryTable.Rows[i].Field<string>(2),
                                         queryTable.Rows[i].Field<decimal>(3),
                                         queryTable.Rows[i].Field<decimal>(4),
                                         queryTable.Rows[i].Field<string>(5),
                                         queryTable.Rows[i].Field<string>(6),
                                         queryTable.Rows[i].Field<string>(7),
                                         queryTable.Rows[i].Field<string>(8),
                                         queryTable.Rows[i].Field<string>(9),
                                         queryTable.Rows[i].Field<string>(10),
                                         queryTable.Rows[i].Field<Int32>(11),
                                         queryTable.Rows[i].Field<string>(12),
                                         queryTable.Rows[i].Field<string>(13),
                                         queryTable.Rows[i].Field<decimal>(14),
                                         queryTable.Rows[i].Field<decimal>(15),
                                         queryTable.Rows[i].Field<decimal>(16),
                                         queryTable.Rows[i].Field<Byte>(17),
                                         queryTable.Rows[i].Field<Int64>(18),
                                         queryTable.Rows[i].Field<string>(19),
                                         queryTable.Rows[i].Field<decimal>(20),
                                         SysDate
                                         );


                                    }

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

            public DataSet IncomeStatement()//Income Statement
            {

                try
                {
                    
                    if (repPreview is null)
                    {

                        DataTable resTable = new DataTable("IncomeStatement");
                        resTable.Columns.Add("Type", typeof(String)); 
                        resTable.Columns.Add("AccountID", typeof(String));
                        resTable.Columns.Add("AccountType", typeof(Int32));
                        resTable.Columns.Add("AccountDescription", typeof(String));
                        resTable.Columns.Add("GLAcntNumber", typeof(Int32));
                        resTable.Columns.Add("ActBalance", typeof(Decimal));
                        resTable.Columns.Add("BalanceYTD", typeof(Decimal));
                        resTable.Columns.Add("LastYrdBalance", typeof(Decimal));
                        resTable.Columns.Add("LastYrdBalanceYTD", typeof(Decimal));
                        resTable.Columns.Add("Company", typeof(String));
                        resTable.Columns.Add("Database", typeof(String));
                        resTable.Columns.Add("period_start", typeof(Int32));
                        resTable.Columns.Add("period_end", typeof(Int32));
                        resTable.Columns.Add("FiscalYear", typeof(String));



                        repPreview = new DataSet();
                        repPreview.Tables.Add(resTable);

                   

                     if (doQuery == true)
                      {
                            reportQuery(7);
                        
                            if (queryTable != null && queryTable.Rows.Count > 0)
                            {
                                for (int i = 0; i < queryTable.Rows.Count; i++)
                                {
                                

                                if (queryTable.Rows[i].Field<string>(0) != "")  
                                        {
                                            resTable.NewRow();
                                    
                                            resTable.Rows.Add(
                                            queryTable.Rows[i].Field<string>(0),
                                            queryTable.Rows[i].Field<string>(1),
                                            queryTable.Rows[i].Field<Int32>(2),
                                            queryTable.Rows[i].Field<string>(3),
                                            queryTable.Rows[i].Field<Int32>(4),
                                            queryTable.Rows[i].Field<Decimal>(5),
                                            queryTable.Rows[i].Field<Decimal>(7),
                                            queryTable.Rows[i].Field<Decimal>(6),
                                            queryTable.Rows[i].Field<Decimal>(8),
                                            queryTable.Rows[i].Field<string>(9),
                                            queryTable.Rows[i].Field<string>(10),
                                            period1,
                                            period2,
                                            "");


                                    }



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

            public DataSet IncomeStatementBudget()//Income Statement vs Budget
            {

                try
                {

                    if (repPreview is null)
                    {

                        DataTable resTable = new DataTable("IncomeStatementVsBudget");
                        resTable.Columns.Add("Type", typeof(String));
                        resTable.Columns.Add("AccountID", typeof(String));
                        resTable.Columns.Add("AccountType", typeof(Int32));
                        resTable.Columns.Add("AccountDescription", typeof(String));
                        resTable.Columns.Add("GLAcntNumber", typeof(Int32));
                        resTable.Columns.Add("ActBalance", typeof(Decimal)); //thisyear  //5
                        resTable.Columns.Add("BalanceYTD", typeof(Decimal));// thisyearYTD  //7
                        resTable.Columns.Add("LastYrdBalance", typeof(Decimal)); // lastyear + //6
                        resTable.Columns.Add("LastYrdBalanceYTD", typeof(Decimal)); // lastyearYTD +//8
                        resTable.Columns.Add("ActBudget", typeof(Decimal)); // Budgetthisyear + //9
                        resTable.Columns.Add("BudgetYTD", typeof(Decimal)); //   BudgetthisyearYTD +//11
                        resTable.Columns.Add("LastYrdBudget", typeof(Decimal));// Budgetlastyear + //10
                        resTable.Columns.Add("LastYrdBudgetYTD", typeof(Decimal)); // BudgetlastyearYTD + //12
                        resTable.Columns.Add("Company", typeof(String));
                        resTable.Columns.Add("Database", typeof(String));
                        resTable.Columns.Add("period_start", typeof(Int32));
                        resTable.Columns.Add("period_end", typeof(Int32));
                        resTable.Columns.Add("FiscalYear", typeof(String));

                                                 

                        repPreview = new DataSet();
                        repPreview.Tables.Add(resTable);

                

                        if (doQuery == true)
                        {
                            reportQuery(10);

                            if (queryTable != null && queryTable.Rows.Count > 0)
                            {
                                for (int i = 0; i < queryTable.Rows.Count; i++)
                                {


                      

                                    if (queryTable.Rows[i].Field<string>(0) != "")
                                    {
                                        resTable.NewRow();
                              
                                      resTable.Rows.Add(
                                        queryTable.Rows[i].Field<string>(0),
                                        queryTable.Rows[i].Field<string>(1),
                                        queryTable.Rows[i].Field<Int32>(2),
                                        queryTable.Rows[i].Field<string>(3),
                                        queryTable.Rows[i].Field<Int32>(4),

                                        queryTable.Rows[i].Field<Decimal>(5),
                                        queryTable.Rows[i].Field<Decimal>(7),
                                        queryTable.Rows[i].Field<Decimal>(6),
                                        queryTable.Rows[i].Field<Decimal>(8),

                                        queryTable.Rows[i].Field<Decimal>(9),
                                        queryTable.Rows[i].Field<Decimal>(11),
                                        queryTable.Rows[i].Field<Decimal>(10),
                                        queryTable.Rows[i].Field<Decimal>(12),
                                        queryTable.Rows[i].Field<string>(13),
                                        queryTable.Rows[i].Field<string>(14),
                                        period1,
                                        period2,
                                        "");


                                    }



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

            public DataSet BalanceSheet()//BalanceSheet
            {


            try
            {

                if (repPreview is null)
                {

                    DataTable resTable = new DataTable("BalaceSheet");
                        resTable.Columns.Add("Type", typeof(String));
                        resTable.Columns.Add("AccountID", typeof(String));
                        resTable.Columns.Add("AccountType", typeof(Int32));
                        resTable.Columns.Add("AccountDescription", typeof(String));
                        resTable.Columns.Add("GLAcntNumber", typeof(Int32));
                        resTable.Columns.Add("BegingBalance", typeof(Decimal));
                        resTable.Columns.Add("NetBalance", typeof(Decimal));
                        resTable.Columns.Add("Company", typeof(String));
                        resTable.Columns.Add("Database", typeof(String));
                        resTable.Columns.Add("period_start", typeof(Int32));
                        resTable.Columns.Add("period_end", typeof(Int32));
                        resTable.Columns.Add("FiscalYear", typeof(String));

                 

                    repPreview = new DataSet();
                    repPreview.Tables.Add(resTable);

  
                  
                    
                    DateTime now = DateTime.Today;

            
                    if (doQuery == true)
                    {
                        reportQuery(9);

                        if (queryTable != null && queryTable.Rows.Count > 0)
                        {
                            for (int i = 0; i < queryTable.Rows.Count; i++)
                            {
        



                                if (queryTable.Rows[i].Field<string>(0) != "")
                                {
                                    resTable.NewRow();

                                    resTable.Rows.Add(
                                    queryTable.Rows[i].Field<string>(0),
                                    queryTable.Rows[i].Field<string>(1),
                                    queryTable.Rows[i].Field<Int32>(2),
                                    queryTable.Rows[i].Field<string>(3),
                                    queryTable.Rows[i].Field<Int32>(4),
                                    queryTable.Rows[i].Field<Decimal>(8),
                                    queryTable.Rows[i].Field<Decimal>(5) + queryTable.Rows[i].Field<Decimal>(8),
                                    queryTable.Rows[i].Field<string>(6),
                                    queryTable.Rows[i].Field<string>(7),
                                    "1",
                                    period2,
                                    fiscalYr);


                                }



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

            public DataSet CustomesrBalance()
            {
               try
            {

                if (repPreview is null)
                {
                   

                    DataTable resTable = new DataTable("CustomersBalance");
                    resTable.Columns.Add("CustomerID", typeof(String));
                    resTable.Columns.Add("CustomerName", typeof(String));
                    resTable.Columns.Add("CustomerType", typeof(String));
                    resTable.Columns.Add("CustomField1", typeof(String));
                    resTable.Columns.Add("CustomField2", typeof(String));
                    resTable.Columns.Add("CustomField3", typeof(String));
                    resTable.Columns.Add("CustomField4", typeof(String));
                    resTable.Columns.Add("CustomField5", typeof(String));
                    resTable.Columns.Add("Balance", typeof(Decimal));
                    resTable.Columns.Add("SalesInPeriod", typeof(Decimal));
                    resTable.Columns.Add("PaymentsInPeriod", typeof(Decimal));
                    resTable.Columns.Add("AmountDueInPeriod", typeof(Decimal));
                    resTable.Columns.Add("SalesYTD", typeof(Decimal));
                    resTable.Columns.Add("PaymentsYTD", typeof(Decimal));
                    resTable.Columns.Add("AmountDueYTD", typeof(Decimal));
                    resTable.Columns.Add("Company", typeof(String));
                    resTable.Columns.Add("Database", typeof(String));
                    resTable.Columns.Add("period_start", typeof(Int32));
                    resTable.Columns.Add("period_end", typeof(Int32));
                    resTable.Columns.Add("FiscalYear", typeof(String));



                    repPreview = new DataSet();
                    repPreview.Tables.Add(resTable);

                    Decimal SalesInPeriod = 0;
                    Decimal PaymentsInPeriod = 0;
                    Decimal AmountDueInPeriod = 0;
                    Decimal SalesYTD = 0;
                    Decimal PaymentsYTD = 0;
                    Decimal AmountDueYTD = 0;
                    DateTime now = DateTime.Today;

                    if (doQuery == true)
                    {
                        reportQuery(8);

                        if (queryTable != null && queryTable.Rows.Count > 0)
                        {
                            for (int i = 0; i < queryTable.Rows.Count; i++)
                            {
                                SalesInPeriod = 0;
                                PaymentsInPeriod = 0;
                                AmountDueInPeriod = 0;
                                SalesYTD = 0;
                                PaymentsYTD = 0;
                                AmountDueYTD = 0;

                               // var FiscalYear = queryTable.Rows[i].Field<Int32>(59);

                                if (fiscalYr == now.Year.ToString("YYYY"))
                                {
                                    if (period1 != period2)
                                    {

                                        for (int rng = period1; rng >= period1 && rng <= period2; rng++)
                                        {
                                            SalesInPeriod = SalesInPeriod + queryTable.Rows[i].Field<Decimal>(20 + rng);
                                        }

                                        for (int rng = period1; rng >= period1 && rng <= period2; rng++)
                                        {
                                            PaymentsInPeriod = PaymentsInPeriod + queryTable.Rows[i].Field<Decimal>(44 + rng);
                                        }
                                        

                                    }
                                    else
                                    {
                                        SalesInPeriod = SalesInPeriod + queryTable.Rows[i].Field<Decimal>(20 + period1);
                                        PaymentsInPeriod = PaymentsInPeriod + queryTable.Rows[i].Field<Decimal>(44 + period1);

                                    }

                                    for (int rng2 = 1; rng2 <= period2; rng2++)
                                    {
                                        SalesYTD = SalesYTD + queryTable.Rows[i].Field<Decimal>(20 + rng2);
                                    }
                                    for (int rng = 1; rng <= period2; rng++)
                                    {
                                        PaymentsYTD = PaymentsYTD + queryTable.Rows[i].Field<Decimal>(44 + rng);
                                    }


                                }
                                else
                                {

                                    if (period1 != period2)
                                    {

                                        for (int rng = period1; rng >= period1 && rng <= period2; rng++)
                                        {
                                            SalesInPeriod = SalesInPeriod + queryTable.Rows[i].Field<Decimal>(8 + rng);
                                        }

                                        for (int rng = period1; rng >= period1 && rng <= period2; rng++)
                                        {
                                            PaymentsInPeriod = PaymentsInPeriod + queryTable.Rows[i].Field<Decimal>(32 + rng);
                                        }
                                        

                                    }
                                    else
                                    {
                                        SalesInPeriod = SalesInPeriod + queryTable.Rows[i].Field<Decimal>(8 + period1);
                                        PaymentsInPeriod = PaymentsInPeriod + queryTable.Rows[i].Field<Decimal>(32 + period1);

                                    }

                                    for (int rng2 = 1; rng2 <= period2; rng2++)
                                    {
                                        SalesYTD = SalesYTD + queryTable.Rows[i].Field<Decimal>(8 + rng2);
                                    }
                                    for (int rng = 1; rng <= period2; rng++)
                                    {
                                        PaymentsYTD = PaymentsYTD + queryTable.Rows[i].Field<Decimal>(32 + rng);
                                    }


                                }

                                AmountDueInPeriod = SalesInPeriod + PaymentsInPeriod;
                                AmountDueYTD = SalesYTD + PaymentsYTD;


                                if (queryTable.Rows[i].Field<string>(0) != "")
                                {
                                    resTable.NewRow();


                                    resTable.Rows.Add(
                                    queryTable.Rows[i].Field<string>(0),
                                    queryTable.Rows[i].Field<string>(1),
                                    queryTable.Rows[i].Field<string>(2),
                                    queryTable.Rows[i].Field<string>(3),
                                    queryTable.Rows[i].Field<string>(4),
                                    queryTable.Rows[i].Field<string>(5),
                                    queryTable.Rows[i].Field<string>(6),
                                    queryTable.Rows[i].Field<string>(7),
                                    queryTable.Rows[i].Field<Decimal>(9),
                                    SalesInPeriod,
                                    PaymentsInPeriod,
                                    AmountDueInPeriod,
                                    SalesYTD,
                                    PaymentsYTD,
                                    AmountDueYTD,
                                    queryTable.Rows[i].Field<string>(57),
                                    queryTable.Rows[i].Field<string>(58),
                                    period1,
                                    period2,
                                    fiscalYr);


                                }



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
