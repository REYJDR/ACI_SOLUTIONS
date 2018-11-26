using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace ACIWEB_DESKTOP_REPORT
{
    class DbQueryAciweb
    {
       
        DbConnectionMysql dbcon = new DbConnectionMysql();

        
        public static DataTable compTable;
        public static bool theresData;
        public static bool doQuery;
        public static DataSet company;


        public static  DataSet repPreview;


        //Get sage company
        public void Company()
        {

            DataTable result = new DataTable();

            string sql = "";


            try
            {

                /*INICIA CONEXION A DB*/
                dbcon.StartConn();

                if (dbcon.StartConn() == true)
                {
                    
                        //Facturas
                        sql = "SELECT ID_compania , CompanyNameSage50 FROM CompanySession;";

                        dbcon.Query(sql).Fill(result);

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
            compTable = result;


            //Seteo resultado de reporte diario
            SetCompany();

        }

        public DataSet SetCompany()
        {
            DataSet repCompany= new DataSet();

            try
            {

                //Creo estructura de tabla
                DataTable resTable = new DataTable("Company");
                resTable.Columns.Add("ID", typeof(Int64));
                resTable.Columns.Add("NAME", typeof(String));
   

             
                //Inserto tabla en dataset
                repCompany.Tables.Add(resTable);

                //Inserto data resultado en tabla para reporte

                if (compTable != null && compTable.Rows.Count > 0)
                {
                    for (int i = 0; i < compTable.Rows.Count; i++)
                    {

                        resTable.NewRow();

                        resTable.Rows.Add(

                            compTable.Rows[i].Field<Int64>(0),
                            compTable.Rows[i].Field<string>(1)


                        );

                    }
                    theresData = true;
                }
                else
                {

                    theresData = false;

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

            company = repCompany;
            return repCompany;
        }
        //Get sage company

            
        //MAIN QUERY REPORT 
        public DataTable reportQuery(int Type)
        {

            DataTable result = new DataTable();
            DbParamAciweb param = new DbParamAciweb();
        
            param.GetValueFromFile();
            string idComp = param.IdComp;

            string sql = "";

            /*OBTENGO EL RANGO DE FECHA DE FrmInit y el rango de invoice */
            string dateRange = FrmAciwebRep.dateRange;

            try
            {

                /*INICIA CONEXION A DB
                dbcon.StartConn();*/

                if (dbcon.StartConn() == true)
                {

                /*QUERY*/
                if (Type == 1)//Reporte diario
                {
                       //Facturas
                       sql = " SELECT A.InvoiceNumber AS DOCUMENTO_FISCAL," +
                                    " C.SalesOrderNumber AS PEDIDO , "+
                                    " A.CustomerID AS CUSTID," +
                                     "A.date AS DATE," +
                                    " A.CustomerName AS CUSTNAME ," +
                                    " A.Net_due AS AMOUNT , " +
                                    " IFNULL(A.OrderTax, 0) AS TAX," +
                                    " C.NOTAS AS TYPE_PAYMENT ," +
                                    " '-' as NOTE ," +
                                    " 'FAC' as DOCTYPE" +
                                " FROM Sales_Header_Imp as A " +
                                " INNER JOIN Sales_Detail_Imp as B ON A.InvoiceNumber = B.InvoiceNumber   and  B.ID_compania = '" + idComp + "' " +
                                " INNER JOIN INVOICE_GEN_HEADER as C ON C.InvoiceNumber = B.InvoiceNumber and  C.ID_compania = '" + idComp + "' " +
                                " WHERE A.date " + dateRange + 
                                " AND A.ID_compania = '"+idComp+"'" +
                                " GROUP BY A.InvoiceNumber ORDER BY A.LAST_CHANGE";

                            dbcon.Query(sql).Fill(result);
                        
                        //Devoluciones
                        sql = " SELECT " +
                                " A.CreditNumber AS  DOCUMENTO_FISCAL, " +
                                " A.CreditNoteNumber  AS PEDIDO , " +
                                " A.CustomerID AS CUSTID, " +
                                " A.Date  AS DATE, " +
                                " A.CustomerName AS CUSTNAME, " +
                                " A.Net_Credit_due AS AMOUNT  ," +
                                " '0'  AS TAX ," +
                                " C.motivo AS TYPE_PAYMENT, " +
                                " C.observaciones  as NOTE ," +
                                " 'NC'  as DOCTYPE " +
                                " FROM Customer_Credit_Memo_Header_Imp A" +
                                " INNER JOIN Customer_Credit_Memo_Detail_Imp B ON A.TransactionID = B.TransactionID AND B.ID_compania = '" + idComp + "' " +
                                " INNER JOIN CREDITNOTE_HEADER as C ON C.CreditNoteNumber = A.CreditNoteNumber and  C.ID_compania = '" + idComp + "' " +
                                " WHERE A.Date " + dateRange +
                                " AND A.ID_compania = '" + idComp + "'" +
                                " GROUP BY A.CreditNumber ORDER BY B.TransactionID"; 

                             dbcon.Query(sql).Fill(result);

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
            return result;


        }

      
        //SET DATA REPORTE-DIARIO
        public DataSet SetDiaryReport()
        {
            

            try
            {
               
                DateTime rawDate;
                string date;

                if (repPreview is null) {

                    //Creo estructura de tabla
                    DataTable resTable = new DataTable("JournalReport");
                    resTable.Columns.Add("DOCUMENTO_FISCAL", typeof(String));
                    resTable.Columns.Add("PEDIDO", typeof(String));
                    resTable.Columns.Add("CLIENTE", typeof(String));
                    resTable.Columns.Add("FECHA", typeof(DateTime));
                    resTable.Columns.Add("NOMBRE", typeof(String));
                    resTable.Columns.Add("MONTO", typeof(Decimal));
                    resTable.Columns.Add("TAX", typeof(Decimal));
                    resTable.Columns.Add("TERMINO", typeof(String));
                    resTable.Columns.Add("PRINTER", typeof(String));
                    resTable.Columns.Add("NOTA", typeof(String));
                    resTable.Columns.Add("DOCTYPE", typeof(String));

                    repPreview = new DataSet();

                    //Inserto tabla en dataset
                    repPreview.Tables.Add(resTable);

              
                
               // doQuery = true; //quitar

                if (doQuery == true)
                {
                    DataTable queryTable;
                    queryTable =  reportQuery(1);
                    

                    if (queryTable != null && queryTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < queryTable.Rows.Count; i++)
                        {

                            resTable.NewRow();

                            rawDate = Convert.ToDateTime(queryTable.Rows[i].Field<DateTime>(3));
                            date = rawDate.ToString("yyyy-MM-dd");

                            string printer = queryTable.Rows[i].Field<string>(0);
                            string[] printerName = printer.Split('-');

                            string termino = queryTable.Rows[i].Field<string>(7);

                            if (queryTable.Rows[i].Field<string>(9) == "FAC")
                            {

                                string[] terminoPago = termino.Split('-');

                                if (terminoPago[1] == "CONTADO")
                                {

                                    termino = "Contado";
                                }
                                else if (terminoPago[1] != "CONTADO")
                                {

                                    termino = "Credito";

                                }


                            }


                            resTable.Rows.Add(

                                queryTable.Rows[i].Field<string>(0),
                                queryTable.Rows[i].Field<string>(1),
                                queryTable.Rows[i].Field<string>(2),
                                date,
                                queryTable.Rows[i].Field<string>(4),
                                queryTable.Rows[i].Field<decimal>(5),
                                queryTable.Rows[i].Field<decimal>(6),
                                termino,
                                printerName[0],
                                queryTable.Rows[i].Field<string>(8),
                                queryTable.Rows[i].Field<string>(9)

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

                    //Inserto data resultado en tabla para reporte


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
