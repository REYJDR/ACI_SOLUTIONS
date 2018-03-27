using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CollectionISP
{
    class DbQuery 
    {
        DataSet joinTbl = new DataSet();

        public DataSet DsQuery()
        {
            DbConnetionPervasive dbcon = new DbConnetionPervasive();

            joinTbl.Clear();

            /*OBTENGO EL RANGO DE FECHA DESDE FrmInit  */
            string dateRangeInv = frmInit.dateRangeInv;


            DataTable tblDataInv = new DataTable("DATASOURCE");

            tblDataInv.PrimaryKey = new DataColumn[] { tblDataInv.Columns["ID"] };
            tblDataInv.Columns.Add("ID", typeof(Int32));
            tblDataInv.Columns.Add("InvoiceNo", typeof(String));
            tblDataInv.Columns.Add("Date", typeof(DateTime));
            tblDataInv.Columns.Add("CustomerID", typeof(String));
            tblDataInv.Columns.Add("Name", typeof(String));
            tblDataInv.Columns.Add("Amount", typeof(Double));
            tblDataInv.Columns.Add("address", typeof(String));
            tblDataInv.Columns.Add("Tipo", typeof(String));

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
            try
            {
                /*EJECUTO EL METODO QUERY Y GUARDO EL RESULTADO EN LA VARIABLE DE TIPO DataTable*/
                dbcon.Query(sqlInvoice).Fill(tblDataInv);
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


            joinTbl.Tables.Add(tblDataInv);

            return joinTbl;
        }

            public DataSet collectionQuery()
        {
            DbConnetionPervasive dbcon = new DbConnetionPervasive();

            joinTbl.Clear();

            DataTable tblDataInv = new DataTable();
                tblDataInv.PrimaryKey = new DataColumn[] { tblDataInv.Columns["ID"] };
                tblDataInv.Columns.Add("ID", typeof(Int32));
                tblDataInv.Columns.Add("InvoiceNo", typeof(String));
                tblDataInv.Columns.Add("Date", typeof(DateTime));
                tblDataInv.Columns.Add("CustomerID", typeof(String));
                tblDataInv.Columns.Add("Name", typeof(String));
                tblDataInv.Columns.Add("Amount", typeof(Double));
                tblDataInv.Columns.Add("address", typeof(String));
                tblDataInv.Columns.Add("Tipo", typeof(String));

            DataTable tblDataAmountPaid = new DataTable();
                tblDataAmountPaid.PrimaryKey = new DataColumn[] { tblDataAmountPaid.Columns["ID"] };
                tblDataAmountPaid.Columns.Add("ID", typeof(Int32));
                tblDataAmountPaid.Columns.Add("Invoice", typeof(String));
                tblDataAmountPaid.Columns.Add("AmountPaid", typeof(Double));

            DataSet tblResult;

            /*OBTENGO EL RANGO DE FECHA DESDE FrmInit  */
            string dateRangeInv = frmInit.dateRangeInv;
            string dateRangeRep = frmInit.dateRangeRep;

            /*QUERY PARA LLENAR PREVIEW DEL PICKING LIST */
            string sqlInvoice = "SELECT DISTINCT " +
                                       " A.PostOrder as ID,"+
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
            try
            {
                /*INICIA CONEXION A DB*/
                if(dbcon.StartConn().State == System.Data.ConnectionState.Open)
                {
                    /*EJECUTO EL METODO QUERY Y GUARDO EL RESULTADO EN LA VARIABLE DE TIPO DataTable*/
                    dbcon.Query(sqlInvoice).Fill(tblDataInv);


                   /*EJECUTO EL METODO QUERY Y GUARDO EL RESULTADO EN LA VARIABLE DE TIPO DataTable*/
                    dbcon.Query(sqlAmountPaid).Fill(tblDataAmountPaid);

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

            //LLAMO AL METODO PARA REALIZAR EL JOIN DE AMAS TABLAS
            tblResult = joinTbls(tblDataInv, tblDataAmountPaid);
        

            return tblResult;

        }

        private DataSet joinTbls(DataTable tblInv, DataTable tblRep)
        {
           
            
            DataTable jt = new DataTable("Joinedtable");
            DataRow row = null;

            string dateCollectOf = frmInit.dateCollectOF;


            jt.Columns.Add("InvoiceNo", typeof(String));
            jt.Columns.Add("Date", typeof(DateTime));
            jt.Columns.Add("CustomerID", typeof(String));
            jt.Columns.Add("Name", typeof(String));
            jt.Columns.Add("Amount", typeof(Double));
            jt.Columns.Add("Address", typeof(String));
            jt.Columns.Add("AmountPaid", typeof(Double));
            jt.Columns.Add("CollectOf", typeof(DateTime));


            //Tablas en DataSet joinTbl
            joinTbl.Tables.Add(jt); //Joinedtable
            joinTbl.Tables.Add(tblInv); //table1
            joinTbl.Tables.Add(tblRep); //table2


            try
            {
            //SE REALIZA EL JOIN ENTRE LA TABLA DE FACTURAS Y PAGOS
               var result = (from dataRows1 in joinTbl.Tables["Table1"].AsEnumerable()
                             join dataRows2 in joinTbl.Tables["Table2"].AsEnumerable() on dataRows1.Field<Int32>("ID") equals dataRows2.Field<Int32>("ID") 
                             select new
                               {
                                   InvoiceNo = dataRows1.Field<string>("InvoiceNo"),
                                   Date = dataRows1.Field<DateTime>("Date"),
                                   CustomerID =dataRows1.Field<string>("CustomerID"),
                                   Name = dataRows1.Field<string>("Name"),
                                   Amount = dataRows1.Field<Double>("Amount"),
                                   Address = dataRows1.Field<string>("address"),
                                   AmountPaid = dataRows2.Field<Double>("AmountPaid")
                                  

                             }).ToList();


                foreach (var resTable in result)
                {
                    row = jt.NewRow();


                    jt.Rows.Add( resTable.InvoiceNo,
                                 resTable.Date,
                                 resTable.CustomerID,
                                 resTable.Name,
                                 resTable.Amount,
                                 resTable.Address,
                                 resTable.AmountPaid,
                                 dateCollectOf);

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

    }
}
