using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace ISPCollection
{
    class DbQuery 
    {

        DbConnetionPervasive dbcon = new DbConnetionPervasive();



        public static DataTable invoicesTbl = new DataTable("Invoices");
        public static DataTable cashRcvTbl  = new DataTable("CashReciepts");
        public static DataTable jt = new DataTable("Joinedtable");
        public static DataSet joinTbl = new DataSet();

        public DataSet SetTblsStruc()
        {

            try
            {
                
                if (!joinTbl.Tables.Contains("Joinedtable"))
                {

                jt.Columns.Add("InvoiceNo", typeof(String));
                jt.Columns.Add("Date", typeof(DateTime));
                jt.Columns.Add("CustomerID", typeof(String));
                jt.Columns.Add("Name", typeof(String));
                jt.Columns.Add("Amount", typeof(Double));
                jt.Columns.Add("Address", typeof(String));
                jt.Columns.Add("AmountPaid", typeof(Double));
                jt.Columns.Add("CollectOf", typeof(DateTime));


                    joinTbl.Tables.Add(jt);
                }

              if (!joinTbl.Tables.Contains("Invoices"))
                {

                invoicesTbl.PrimaryKey = new DataColumn[] { invoicesTbl.Columns["ID"] };
                invoicesTbl.Columns.Add("ID", typeof(Int32));
                invoicesTbl.Columns.Add("InvoiceNo", typeof(String));
                invoicesTbl.Columns.Add("Date", typeof(DateTime));
                invoicesTbl.Columns.Add("CustomerID", typeof(String));
                invoicesTbl.Columns.Add("Name", typeof(String));
                invoicesTbl.Columns.Add("Amount", typeof(Double));
                invoicesTbl.Columns.Add("address", typeof(String));
                invoicesTbl.Columns.Add("Tipo", typeof(String));

  
                    joinTbl.Tables.Add(invoicesTbl);

                }

                if (!joinTbl.Tables.Contains("CashReciepts"))
                {
                cashRcvTbl.PrimaryKey = new DataColumn[] { cashRcvTbl.Columns["ID"] };
                cashRcvTbl.Columns.Add("ID", typeof(Int32));
                cashRcvTbl.Columns.Add("Invoice", typeof(String));
                cashRcvTbl.Columns.Add("AmountPaid", typeof(Double));


                    joinTbl.Tables.Add(cashRcvTbl);
                }

                if (invoicesTbl != null || cashRcvTbl != null)
                {


                    if (invoicesTbl.Rows.Count > 0 && cashRcvTbl.Rows.Count > 0)
                    {

                        DataRow row = null;

                        string dateCollectOf = frmInit.dateCollectOF;



                        //SE REALIZA EL JOIN ENTRE LA TABLA DE FACTURAS Y PAGOS
                        var result = (from dataRows1 in joinTbl.Tables["Invoices"].AsEnumerable()
                                      join dataRows2 in joinTbl.Tables["CashReciepts"].AsEnumerable() on dataRows1.Field<Int32>("ID") equals dataRows2.Field<Int32>("ID")
                                      select new
                                      {
                                          InvoiceNo = dataRows1.Field<string>("InvoiceNo"),
                                          Date = dataRows1.Field<DateTime>("Date"),
                                          CustomerID = dataRows1.Field<string>("CustomerID"),
                                          Name = dataRows1.Field<string>("Name"),
                                          Amount = dataRows1.Field<Double>("Amount"),
                                          Address = dataRows1.Field<string>("address"),
                                          AmountPaid = dataRows2.Field<Double>("AmountPaid")


                                      }).ToList();


                        foreach (var resTable in result)
                        {
                            row = jt.NewRow();


                            jt.Rows.Add(resTable.InvoiceNo,
                                         resTable.Date,
                                         resTable.CustomerID,
                                         resTable.Name,
                                         resTable.Amount,
                                         resTable.Address,
                                         resTable.AmountPaid,
                                         dateCollectOf);

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
          


        return joinTbl;
        }

        public void Join()
        {
            
            try
                {

                   if (invoicesTbl != null || cashRcvTbl != null)
                    {


                    if (invoicesTbl.Rows.Count > 0 && cashRcvTbl.Rows.Count > 0)
                    {

                        DataRow row = null;

                        string dateCollectOf = frmInit.dateCollectOF;



                        //SE REALIZA EL JOIN ENTRE LA TABLA DE FACTURAS Y PAGOS
                        var result = (from dataRows1 in joinTbl.Tables["Invoices"].AsEnumerable()
                                      join dataRows2 in joinTbl.Tables["CashReciepts"].AsEnumerable() on dataRows1.Field<Int32>("ID") equals dataRows2.Field<Int32>("ID")
                                      select new
                                      {
                                          InvoiceNo = dataRows1.Field<string>("InvoiceNo"),
                                          Date = dataRows1.Field<DateTime>("Date"),
                                          CustomerID = dataRows1.Field<string>("CustomerID"),
                                          Name = dataRows1.Field<string>("Name"),
                                          Amount = dataRows1.Field<Double>("Amount"),
                                          Address = dataRows1.Field<string>("address"),
                                          AmountPaid = dataRows2.Field<Double>("AmountPaid")


                                      }).ToList();


                        foreach (var resTable in result)
                        {
                            row = jt.NewRow();


                            jt.Rows.Add(resTable.InvoiceNo,
                                         resTable.Date,
                                         resTable.CustomerID,
                                         resTable.Name,
                                         resTable.Amount,
                                         resTable.Address,
                                         resTable.AmountPaid,
                                         dateCollectOf);

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
            

    }
        
        public void collectionQuery()
        {


            try
                {

                SetTblsStruc();

                    /*OBTENGO EL RANGO DE FECHA DESDE FrmInit  */
                    string dateRangeInv = frmInit.dateRangeInv;
                    string dateRangeRep = frmInit.dateRangeRep;


                    /*QUERY PARA LLENAR PREVIEW DEL PICKING LIST */
                    string sqlInvoice = "SELECT DISTINCT " +
                                               " A.PostOrder as ID," +
                                               " A.Reference as InvoiceNo, " +
                                               " A.TransactionDate as Date, " +
                                               " C.CustomerID, " +
                                               " C.Customer_Bill_Name as Name, " +
                                               " A.MainAmount as Amount, " +
                                               " A.ShipToAddress1 as address, " +
                                               " SUBSTRING(A.Reference, 1, 2) as TIPO " +
                                               " FROM JrnlHdr A " +
                                               " INNER JOIN JrnlRow  B ON A.PostOrder = B.PostOrder " +
                                               " INNER JOIN Customers C ON C.CustomerRecordNumber = B.CustomerRecordNumber " +
                                               " WHERE A.JrnlKey_Journal = '3' " +
                                               " AND B.RowType = '0' " +
                                               " AND A.TransactionDate between " +
                                                dateRangeInv +
                                               " AND (       A.Reference LIKE 'CD%'" +
                                                       " OR  A.Reference LIKE 'RS%'" +
                                                       " OR  A.Reference LIKE 'AP%'" +
                                                       " OR  A.Reference LIKE 'TT%'" +
                                                       " OR  A.Reference LIKE 'EAL%'" +
                                                       " OR  A.Reference LIKE 'RP%'" +
                                                       " OR  A.Reference LIKE 'PE%'" +
                                                       " OR  A.Reference LIKE 'INF%'" +
                                                       " OR  A.Reference LIKE 'ASA%' ) " +
                                               " Order by A.Reference;";



                    string sqlAmountPaid = " SELECT DISTINCT " +
                                               " D.LinkToAnotherTrx as ID, " +
                                               " D.InvNumForThisTrx as Invoice, " +
                                               " SUM(D.Amount) as AmountPaid" +
                                               " FROM JrnlHdr F " +
                                               " INNER JOIN JrnlRow D ON F.PostOrder = D.PostOrder " +
                                               " WHERE D.Journal = '1' " +
                                                   " AND D.RowType = '0' " +
                                                   " AND D.RowDate between " +
                                                     dateRangeRep +
                                                  " AND D.InvNumForThisTrx <> '' " +
                                                  " AND F.ReceiptNum NOT LIKE 'AJCM%' " +
                                               "Group by D.LinkToAnotherTrx , D.InvNumForThisTrx ";


                    /*EJECUTO EL METODO QUERY Y GUARDO EL RESULTADO EN LA VARIABLE DE TIPO DataTable*/
                    dbcon.Query(sqlInvoice).Fill(invoicesTbl);
                   // invoicesTbl = invoices;
                    /*EJECUTO EL METODO QUERY Y GUARDO EL RESULTADO EN LA VARIABLE DE TIPO DataTable*/
                    dbcon.Query(sqlAmountPaid).Fill(cashRcvTbl);
                // cashRcvTbl = reciepts;

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


            }

    }
}
