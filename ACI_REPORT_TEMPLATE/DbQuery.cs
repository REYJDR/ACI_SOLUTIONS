﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace $safeprojectname$
{
    class DbQuery 
    {
        DbConnetionPervasive dbcon = new DbConnetionPervasive();

        public static DataTable queryTable;

        bool nc;
        string onlyFact = " ";

        public DataTable CompanyName()
        {
      

            DataTable soData = new DataTable();

            string  SqlComp = "select CompanyName from Company;";

            dbcon.Query(SqlComp).Fill(soData);


            return soData;
        }
        
        public DataTable SOCatalog()
        {
           
          
            DataTable soData = new DataTable();

            /*OBTENGO EL RANGO DE FECHA DE FrmInit */
            string dateRange = FrmInit.dateRange;

           

            /*QUERY PARA LLENAR CATALOGO DE REFERENCIAS DE FACTURAS */
            string sqlSo = "SELECT DISTINCT InvNumForThisTrx FROM JrnlRow " +
                           " WHERE Journal = '3' " +
                           " AND RowType = '0' " +
                           " AND RowDate between "+
                           dateRange + ";";

            /*INICIA CONEXION A DB*/
            dbcon.StartConn();

            if (dbcon.StartConn().State == System.Data.ConnectionState.Open)
            { 
                /*EJECUTO EL METODO QUERY Y GUARDO EL RESULTADO EN LA VARIABLE DE TIPO DataTable*/
                dbcon.Query(sqlSo).Fill(soData);
            }

            return soData;
        }

        public DataTable invQuery()
        {
           
            DataTable invData = new DataTable();

            /*OBTENGO EL RANGO DE FECHA DE FrmInit y el rango de invoice */
            string dateRange = FrmInit.dateRange;
            string invRange = FrmInit.invRange;

            nc = FrmInit.ncCheck;




            try
            {
                if (nc == true)
                {
                   
                    onlyFact = " ";
                }
                else
                {
                    onlyFact = " AND C.MainAmount > '0'";

                }

                /*QUERY PARA LLENAR PREVIEW DEL PICKING LIST */
                string sqlInv = "SELECT DISTINCT C.Reference as InvoiceNo," +
                               " C.TransactionDate as Date," +
                               " B.CustomerID as CustomerID," +
                               " B.Customer_Bill_Name as Name " +
                               " FROM JrnlRow A" +
                               " INNER JOIN Customers B ON B.CustomerRecordNumber = A.CustomerRecordNumber" +
                               " INNER JOIN JrnlHdr C ON A.PostOrder = C.PostOrder" +
                               " WHERE A.Journal = '3' " +
                               " AND A.RowType = '0' " +
                                 onlyFact +
                               " AND  C.Reference <> '' " +
                               " AND A.RowDate between " +
                               dateRange + invRange + " ; ";

                /*INICIA CONEXION A DB*/
                dbcon.StartConn();

                if (dbcon.StartConn().State == System.Data.ConnectionState.Open)
                {
                    /*EJECUTO EL METODO QUERY Y GUARDO EL RESULTADO EN LA VARIABLE DE TIPO DataTable*/
                    dbcon.Query(sqlInv).Fill(invData);
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

           
            return invData;
        }
        
        public void repQuery(DataTable data)
        {

         DataTable repData = new DataTable();

           
            string date;
            DateTime rawDate;
            string invNum;
            string cusID;

            nc = FrmInit.ncCheck;


            foreach (DataRow row in data.Rows)
            {
                if (nc == true)
                {
                   
                    onlyFact = " ";
                }
                else
                {
                    onlyFact = " AND B.Amount < '0' " ;

                }

                invNum = Convert.ToString(row[0]);
                rawDate = Convert.ToDateTime(row[1]);
                date = rawDate.ToString("yyyy-MM-dd");
                cusID = Convert.ToString(row[2]);

                string sqlRep = "SELECT DISTINCT " +
                                "A.Reference as InvoiceNo," +
                                "A.TransactionDate as InvoiceDate," +
                                "C.CustomerID as IdCustomer," +
                                "C.Customer_Bill_Name as BillTo," +
                                "B.Quantity," +
                                "D.ItemID," +
                                "D.UPC_SKU," +
                                "D.SalesDescription," +
                                "D.Weight," +
                                "B.Amount,"+
                                "D.StockingUM as Unit, "+
                                "E.JobDescription, "+
                                "F.PhaseDescription, " +
                                "G.EmployeeID, " +
                                "G.EmployeeName, " +
                                "C.Customer_Type, "+
                                "B.RowNumber" +
                                " FROM JrnlHdr A" +
                                " INNER JOIN JrnlRow B ON A.PostOrder = B.PostOrder" +
                                " LEFT JOIN Jobs E ON E.JobRecordNumber = B.JobRecordNumber " +
                                " LEFT JOIN Phase F ON F.PhaseRecordNumber = B.PhaseRecordNumber " +
                                " LEFT JOIN Employee G on G.EmpRecordNumber = A.EmpRecordNumber" +
                                " INNER JOIN Customers C ON C.CustomerRecordNumber = B.CustomerRecordNumber" +
                                " INNER JOIN LineItem D ON D.ItemRecordNumber = B.ItemRecordNumber" +
                                " WHERE A.JrnlKey_Journal = '3'" +
                                " AND B.RowType = '0'" +
                                " AND A.TransactionDate ='" + date + "'" +
                                " AND A.Reference = '" + invNum + "'" +
                                " AND C.CustomerID = '" + cusID + "' " +
                                onlyFact +
                                " Order by A.Reference; ";

                

                    /*EJECUTO EL METODO QUERY Y GUARDO EL RESULTADO EN LA VARIABLE DE TIPO DataTable*/
                    dbcon.Query(sqlRep).Fill(repData);
                

            }

            //Guardo resultado en DataTable global para esta clase.
            queryTable = repData;

            //Seteo el DataSet
             SetData();
           
            
        }

        public DataSet SetData()
        {
            DataSet repPreview = new DataSet();
            try
            {

                DateTime rawDate;
                string date;

                
                //DataTable tableRep = queryTable;

                DataTable resTable = new DataTable("Result");
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

  
                repPreview.Tables.Add(resTable);

             
                if(queryTable != null)
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
                        queryTable.Rows[i].Field<string>(15));

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

    }
}
