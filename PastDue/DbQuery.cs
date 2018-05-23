using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace PastDue
{
    class DbQuery
    {
        DbConnetionPervasive dbcon = new DbConnetionPervasive();

        public static DataTable queryTable;


        public DataTable CompanyName()
        {


            DataTable soData = new DataTable();

            string SqlComp = "select CompanyName from Company;";

            dbcon.Query(SqlComp).Fill(soData);


            return soData;
        }


        public void repQuery()
        {

            DataTable repData = new DataTable();
            
            string date = FrmInit.date;
            string custId = FrmInit.custId;

     
                string sqlRep = "SELECT DISTINCT " +
                                "A.Reference as InvoiceNo," +
                                "A.TransactionDate as InvoiceDate," +
                                "C.CustomerID as IdCustomer," +
                                "C.Customer_Bill_Name as BillTo," +      
                                "C.Customer_Type, " +
                                "A.MainAmount,"+
                                "A.AmountPaid"+
                                " FROM JrnlHdr A" +
                                " INNER JOIN JrnlRow B ON A.PostOrder = B.PostOrder" +
                                " INNER JOIN Customers C ON C.CustomerRecordNumber = B.CustomerRecordNumber" +
                                " WHERE A.JrnlKey_Journal = '3'" +
                                " AND B.RowType = '0'" +
                                " AND A.TransactionDate < " + date + 
                                 custId + 
                                " AND A.AmountPaid < A.MainAmount " +
                                " Order by A.Reference; ";



                /*EJECUTO EL METODO QUERY Y GUARDO EL RESULTADO EN LA VARIABLE DE TIPO DataTable*/
                dbcon.Query(sqlRep).Fill(repData);
            

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
                resTable.Columns.Add("CustomerType", typeof(String));
                resTable.Columns.Add("Amount", typeof(Decimal));
                resTable.Columns.Add("AmountPaid", typeof(Decimal));

                repPreview.Tables.Add(resTable);


                if (queryTable != null)
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
                        queryTable.Rows[i].Field<decimal>(6));

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
