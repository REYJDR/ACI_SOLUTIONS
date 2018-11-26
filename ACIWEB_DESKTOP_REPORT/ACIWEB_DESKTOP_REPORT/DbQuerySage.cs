using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace ACIWEB_DESKTOP_REPORT
{
    class DbQuerySage
    {
        DbConnetionPervasive dbcon = new DbConnetionPervasive();

        public static DataTable queryTable;
        public static bool doQuery;
        public static bool theresData;
        public static DataSet repPreview;

        public DataTable CompanyName()
        {
            DataTable soData = new DataTable();

            if (doQuery == true)
            {
               

                string SqlComp = "select CompanyName from Company;";

                dbcon.Query(SqlComp).Fill(soData);


                return soData;

            }

            return soData;
        }

        public void reportQuery(int Type)
        {

            DataTable result = new DataTable();

            string sql = "";

            /*OBTENGO EL RANGO DE FECHA DE FrmInit y el rango de invoice */
            string dateRange = FrmSageRep.dateRange;

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

                    string strCon = SageParams.SageConString(Parameters);

                    if (dbcon.StartConn(strCon).State == System.Data.ConnectionState.Open)
                    {

                        /*QUERY*/
                        if (Type == 1)//Past Due
                        {
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
                                    "C.CustomField5 " +
                                    " FROM JrnlHdr A" +
                                    " INNER JOIN JrnlRow B ON A.PostOrder = B.PostOrder" +
                                    " INNER JOIN Customers C ON C.CustomerRecordNumber = B.CustomerRecordNumber" +
                                    " LEFT JOIN Employee G on G.EmpRecordNumber = A.EmpRecordNumber" +
                                    " WHERE A.JrnlKey_Journal = '3'" +
                                    " AND B.RowType = '0'" +
                                    " AND A.TransactionDate  " + dateRange +
                                    " AND A.AmountPaid < A.MainAmount " +
                                    " Order by A.Reference; ";



                            dbcon.Query(sql).Fill(result);

                        }
                        
                       
                        if (Type == 2)//PickingList
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
                                " AND A.TransactionDate " + dateRange + 
                                " Order by A.Reference; ";
                            

                            dbcon.Query(sql).Fill(result);

                        }


                        if (Type == 3)//Purchase Orders
                        {
                            
                            sql = "SELECT DISTINCT " +
                                "A.Reference as InvoiceNo," +
                                "A.TransactionDate as InvoiceDate," +
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
                                "D.CustomField5 " +
                                " FROM JrnlHdr A" +
                                " INNER JOIN JrnlRow B ON A.PostOrder = B.PostOrder" +
                                " LEFT JOIN Jobs E ON E.JobRecordNumber = B.JobRecordNumber " +
                                " LEFT JOIN Phase F ON F.PhaseRecordNumber = B.PhaseRecordNumber " +
                                " LEFT JOIN Employee G on G.EmpRecordNumber = A.EmpRecordNumber" +
                                " INNER JOIN Vendors C ON C.VendorRecordNumber = B.VendorRecordNumber" +
                                " INNER JOIN LineItem D ON D.ItemRecordNumber = B.ItemRecordNumber" +
                                " WHERE A.JrnlKey_Journal = '10'" +
                                " AND B.RowType = '0'" +
                                " AND A.TransactionDate " + dateRange + 
                                " Order by A.Reference; ";


                            dbcon.Query(sql).Fill(result);

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
                            date = rawDate.ToString("yyyy-MM-dd");

                            DataTable CompanyName = this.CompanyName();


                            resTable.Rows.Add(
                            CompanyName.Rows[0].Field<string>(0),
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
                            queryTable.Rows[i].Field<string>(14)
                            );

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
                                date = rawDate.ToString("yyyy-MM-dd");

                                DataTable CompanyName = this.CompanyName();


                                resTable.Rows.Add(
                                CompanyName.Rows[0].Field<string>(0),
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
                                queryTable.Rows[i].Field<string>(20));


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
                    resTable.Columns.Add("InvoiceNo", typeof(String));
                    resTable.Columns.Add("InvoiceDate", typeof(String));
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

                                DataTable CompanyName = this.CompanyName();


                                resTable.Rows.Add(
                                CompanyName.Rows[0].Field<string>(0), 
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
                                queryTable.Rows[i].Field<string>(21));


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
