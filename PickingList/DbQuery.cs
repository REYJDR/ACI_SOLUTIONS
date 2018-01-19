using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace PickingList
{
    class DbQuery 
    {

        public static DataTable queryTable;
        



        public DataTable SOCatalog()
        {
           
            DbConnetionPervasive dbcon = new DbConnetionPervasive();

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
            DbConnetionPervasive dbcon = new DbConnetionPervasive();

            DataTable invData = new DataTable();

            /*OBTENGO EL RANGO DE FECHA DE FrmInit y el rango de invoice */
            string dateRange = FrmInit.dateRange;
            string invRange = FrmInit.invRange;

            /*QUERY PARA LLENAR PREVIEW DEL PICKING LIST */
                string sqlInv = "SELECT DISTINCT C.Reference as InvoiceNo,C.TransactionDate as Date,B.CustomerID as CustomerID,B.Customer_Bill_Name as Name FROM JrnlRow A" +
                           " INNER JOIN Customers B ON B.CustomerRecordNumber = A.CustomerRecordNumber" +
                           " INNER JOIN JrnlHdr C ON A.PostOrder = C.PostOrder" +
                           " WHERE A.Journal = '3' " +
                           " AND A.RowType = '0' " +
                           " AND A.RowDate between " +
                           dateRange + invRange+ ";";

            /*INICIA CONEXION A DB*/
            dbcon.StartConn();

            if (dbcon.StartConn().State == System.Data.ConnectionState.Open)
            {
                /*EJECUTO EL METODO QUERY Y GUARDO EL RESULTADO EN LA VARIABLE DE TIPO DataTable*/
                dbcon.Query(sqlInv).Fill(invData);
            }
            
            return invData;
        }



        public void repQuery(DataTable data)
        {

         DbConnetionPervasive dbcon = new DbConnetionPervasive();

         DataTable repData = new DataTable();

           
            string date;
            DateTime rawDate;
            string invNum;
            string cusID;
            

            foreach (DataRow row in data.Rows)
            {

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
                                "D.ItemDescription," +
                                "D.Weight," +
                                "B.Amount,"+
                                "D.StockingUM as Unit"+
                                " FROM JrnlHdr A" +
                                " INNER JOIN JrnlRow B ON A.PostOrder = B.PostOrder" +
                                " INNER JOIN Customers C ON C.CustomerRecordNumber = B.CustomerRecordNumber" +
                                " INNER JOIN LineItem D ON D.ItemRecordNumber = B.ItemRecordNumber" +
                                " WHERE A.JrnlKey_Journal = '3'" +
                                " AND B.RowType = '0'" +
                                " AND A.TransactionDate ='" + date + "'" +
                                " AND A.Reference = '" + invNum + "'" +
                                " AND C.CustomerID = '" + cusID + "'" +
                                " Order by A.Reference; ";


                dbcon.StartConn();

                if (dbcon.StartConn().State == System.Data.ConnectionState.Open)
                {
                    /*EJECUTO EL METODO QUERY Y GUARDO EL RESULTADO EN LA VARIABLE DE TIPO DataTable*/
                    dbcon.Query(sqlRep).Fill(repData);
                }

            }

            //Guardo resultado en DataTable global para esta clase.
            queryTable = repData;

            //Seteo el DataSet
            SetData();
           
            
        }

  

        public DataSet SetData()
        {

            DateTime rawDate;
            string date;

            DataSet repPreview = new DataSet();

            DataTable tableRep = queryTable;

            try
            {
                DataTable resTable = new DataTable("Result");
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

                repPreview.Tables.Add(resTable);

                for (int i = 0; i < tableRep.Rows.Count; i++)
                {

                    resTable.NewRow();

                    rawDate = Convert.ToDateTime(tableRep.Rows[i].Field<DateTime>(1));
                    date = rawDate.ToString("yyyy-MM-dd");

                    resTable.Rows.Add(
                           tableRep.Rows[i].Field<string>(0),
                           date,                    
                           tableRep.Rows[i].Field<string>(2),
                           tableRep.Rows[i].Field<string>(3),
                           tableRep.Rows[i].Field<decimal>(4),
                           tableRep.Rows[i].Field<string>(5),
                           tableRep.Rows[i].Field<string>(6),
                           tableRep.Rows[i].Field<string>(7),
                           tableRep.Rows[i].Field<decimal>(8),
                           tableRep.Rows[i].Field<decimal>(9),
                           tableRep.Rows[i].Field<string>(10) );


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
