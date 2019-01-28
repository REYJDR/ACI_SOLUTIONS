using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace ACIWEB_DESKTOP_REPORT
{
    class DbQueryAciweb
    {
        public static ManualResetEvent mre = new ManualResetEvent(false);

        DbConnectionMysql dbcon = new DbConnectionMysql();
        DataTable SelectOptions = new DataTable("SelectOption");
        FrmReportFilter SO = new FrmReportFilter();

        public static DataTable compTable;
        public static bool theresData;
        public static bool doQuery;
        public static DataSet company;

        public static  DataSet repPreview;

        //variables de parametros de seleccion
        public static string From;
        public static string To;

        public DbQueryAciweb()
        {
            SelectionOptionsTbl();

        }


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

        private void SelectionOptionsTbl()
        {

            SelectOptions.Columns.Add("type", typeof(String));
            SelectOptions.Columns.Add("fieldname", typeof(String));

        }

        //SELECTION OPTIONS
        private void showSelecOptionByReport(int Type)
        {
           

            if (Type == 1)
            {
                //selection option 
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

                

            }

  

        }
       
        //MAIN QUERY REPORT 
        private DataTable reportQuery(int Type)
        {
            
            DataTable result = new DataTable();
            DbParamAciweb param = new DbParamAciweb();
        
            param.GetValueFromFile();
            string idComp = param.IdComp;

            string sql = "";

            try
            {

                /*INICIA CONEXION A DB*/
           
                if (dbcon.StartConn() == true)
                {

                /*QUERY*/
                if (Type == 1)//Reporte diario
                {
                      
                        showSelecOptionByReport(1);
                        mre.WaitOne();
                        
                        
                            //Facturas
                            sql = " SELECT A.InvoiceNumber AS DOCUMENTO_FISCAL," +
                                        " C.SalesOrderNumber AS PEDIDO , " +
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
                                    " WHERE A.date   between '" + From + "' and '" + To + "' " +
                                    " AND A.ID_compania = '" + idComp + "'" +
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
                                    " WHERE A.date   between '" + From + "' and '" + To + "' " +
                                    " AND A.ID_compania = '" + idComp + "'" +
                                    " GROUP BY A.CreditNumber ORDER BY B.TransactionID";

                            dbcon.Query(sql).Fill(result);

                     
                    }

                /*QUERY*/
                if (Type == 2)//Reporte de requisiciones
                {
                        showSelecOptionByReport(1);
                        mre.WaitOne();

                        //Reporte de requisiciones
                        sql =
                        " SELECT " +
                        " A.NO_REQ, " +
                        " A.ProductID AS ITEMID, " + 
                        " CAST( COALESCE(A.CANTIDAD, 0 ) AS decimal(16,4))  AS QTY_REQUIRED, " +
                        " CAST( COALESCE((SELECT SUM(Quantity) FROM PurOrdr_Detail_Exp AS I " +
                        " INNER JOIN PurOrdr_Header_Exp as J on J.TransactionID =  I.TransactionID  "+
                        " WHERE I.Item_Id = A.ProductID and J.CustomerSO = B.NO_REQ) , 0 ) AS  decimal(16,4)) AS QTY_ORDERED, " +
                        " CAST( COALESCE((SELECT SUM(QTY) FROM REQ_RECEPT AS L WHERE  L.NO_REQ  = B.NO_REQ  AND  L.ITEM = A.ProductID ), 0) AS decimal(16,4) )AS QTY_RECEIVED, " +
                        " A.DESCRIPCION, " +
                        " B.DATE AS REQ_DATE, " +
                        " COALESCE(E.DATE, '' ) AS QUOTA_DATE, " +
                        " B.NOTA, " +
                        " C.NAME AS REQ_USER_NAME, " +
                        " C.LASTNAME AS REQ_USER_LASTNAME, " +
                        " A.JOB, " +
                        " (SELECT Description from Jobs_Exp AS N where N.JobID = A.JOB AND N.ID_compania = A.ID_compania ) AS JOB_DESCRIPTION, " +
                        " A.PHASE, " +
                        " A.CCOST, " +
                        " (SELECT CompanyNameSage50 from CompanySession AS D where D.ID_compania = A.ID_compania) AS SAGE_COMPANY, "+
                        " B.st_closed as STATUS_CLOSED" +
                        " FROM REQ_DETAIL AS A " +
                        " inner join REQ_HEADER AS B ON A.NO_REQ = B.NO_REQ and A.ID_compania = B.ID_compania " +
                        " LEFT join REQ_QUOTA AS E ON E.NO_REQ = B.NO_REQ and E.ID_compania = B.ID_compania " +
                        " LEFT join SAX_USER AS C ON C.ID = B.USER " +
                        " WHERE B.DATE between '" + From + "' and '" + To + "' " +
                        " ORDER BY A.NO_REQ";

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


                    if (doQuery == true)
                    {
                        if (!FrmReportFilter.winClose)
                        {

                            DataTable queryTable = reportQuery(1);


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


        //SET DATA REPORTE DE REQUISICIONES
        public DataSet setReqReport()
        {
            try
            {

     

                if (repPreview is null)
                {

                    //Creo estructura de tabla
                    DataTable resTable = new DataTable("Requisiciones");
                    resTable.Columns.Add("NO_REQ", typeof(string));
                    resTable.Columns.Add("ITEMID", typeof(string));
                    resTable.Columns.Add("QTY_REQUIRED", typeof(Decimal));
                    resTable.Columns.Add("QTY_ORDERED", typeof(Decimal));
                    resTable.Columns.Add("QTY_RECEIVED", typeof(Decimal));
                    resTable.Columns.Add("DESCRIPCION", typeof(string));
                    resTable.Columns.Add("REQ_DATE", typeof(string));
                    resTable.Columns.Add("QUOTA_DATE", typeof(string));
                    resTable.Columns.Add("NOTA", typeof(string));
                    resTable.Columns.Add("REQ_USER_NAME", typeof(string));
                    resTable.Columns.Add("REQ_USER_LASTNAME", typeof(string));
                    resTable.Columns.Add("JOB", typeof(string));
                    resTable.Columns.Add("JOB_DESCRIPTION", typeof(string));
                    resTable.Columns.Add("PHASE", typeof(string));
                    resTable.Columns.Add("CCOST", typeof(string));
                    resTable.Columns.Add("SAGE_COMPANY", typeof(string));
                    resTable.Columns.Add("STATUS_CLOSED", typeof(string));
                    resTable.Columns.Add("DATE_FROM", typeof(DateTime));
                    resTable.Columns.Add("DATE_TO", typeof(DateTime));



                    repPreview = new DataSet();

                    //Inserto tabla en dataset
                    repPreview.Tables.Add(resTable);



                    // doQuery = true; //quitar

                    if (doQuery == true)
                    {
                        if (!FrmReportFilter.winClose)
                        {

                            DataTable queryTable = reportQuery(2);


                            if (queryTable != null && queryTable.Rows.Count > 0)
                            {
                                for (int i = 0; i < queryTable.Rows.Count; i++)
                                {

                                    resTable.NewRow();

                                    /*  rawDate = Convert.ToDateTime(queryTable.Rows[i].Field<string>(4));
                                      date = rawDate.ToString("yyyy-MM-dd");*/


                                    resTable.Rows.Add(

                                        queryTable.Rows[i].Field<string>(0),
                                        queryTable.Rows[i].Field<string>(1),
                                        queryTable.Rows[i].Field<Decimal>(2),
                                        queryTable.Rows[i].Field<Decimal>(3),
                                        queryTable.Rows[i].Field<Decimal>(4),
                                        queryTable.Rows[i].Field<string>(5),
                                        queryTable.Rows[i].Field<string>(6),
                                        queryTable.Rows[i].Field<string>(7),
                                        queryTable.Rows[i].Field<string>(8),
                                        queryTable.Rows[i].Field<string>(9),
                                        queryTable.Rows[i].Field<string>(10),
                                        queryTable.Rows[i].Field<string>(11),
                                        queryTable.Rows[i].Field<string>(12),
                                        queryTable.Rows[i].Field<string>(13),
                                        queryTable.Rows[i].Field<string>(14),
                                        queryTable.Rows[i].Field<string>(15),
                                        queryTable.Rows[i].Field<Int32>(16),
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
        //lA consulta en el metodo reportType
    }
}
