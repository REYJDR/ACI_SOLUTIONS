using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.Windows.Forms;
using SAP.Middleware.Connector;
using System.Globalization;

namespace ACIWEB_DESKTOP_REPORT
{
    class DbQuerySap
    {
        SapConnection sapCon = new SapConnection();

        public static DataTable queryTable;
        public static bool doQuery;
        public static bool theresData;
        public static DataSet repPreview;
        public static ManualResetEvent mre = new ManualResetEvent(false);

        //Selection options 
        FrmReportFilter SO = new FrmReportFilter();
        DataTable SelectOptions = new DataTable("SelectOption");

        //variables de parametros de seleccion
        public static string From;
        public static string To;
        public static string companycode;
        public static string customer;
        public static string noteditems; 


        public DbQuerySap()
        {
            SelectionOptionsTbl();

        }
        //SELECTION OPTIONS
        private void SelectionOptionsTbl()
        {

            SelectOptions.Columns.Add("type", typeof(String));
            SelectOptions.Columns.Add("fieldname", typeof(String));

        }

        private void showSelecOptionByReport(int Type)
        {

            if (Type == 1)
            {
               
                //selection option 
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("text", "COMPANY");
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("text", "CUSTOMER");
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("date", "FROM");
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("date", "TO");
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("text", "NOTEDITEMS");
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("button", "Go");


                SO.SetSelectionsOptions(SelectOptions);
                SO.ShowDialog();

                TextBox COMPANYCODE = SO.selectOptionsPanel.Controls.Find("COMPANY", true).FirstOrDefault() as TextBox;
                if (COMPANYCODE != null) { companycode = COMPANYCODE.Text; } else { companycode = ""; };
              
                TextBox CUSTOMER = SO.selectOptionsPanel.Controls.Find("CUSTOMER", true).FirstOrDefault() as TextBox;
                if (CUSTOMER != null) { customer = CUSTOMER.Text; } else { customer = ""; };
                
                TextBox NOTEDITEMS = SO.selectOptionsPanel.Controls.Find("NOTEDITEMS", true).FirstOrDefault() as TextBox;
                 if (NOTEDITEMS != null) { noteditems = NOTEDITEMS.Text; } else { noteditems = ""; };

                DateTimePicker to = SO.selectOptionsPanel.Controls.Find("date_FROM", true).FirstOrDefault() as DateTimePicker;
                To = to.Text;
                DateTimePicker from = SO.selectOptionsPanel.Controls.Find("date_TO", true).FirstOrDefault() as DateTimePicker;
                From = from.Text;
        


            }

        }
        //SELECTION OPTIONS

        public void reportQuery(int Type)
        {

            DataTable result = new DataTable();

          
            try
            {

                    if (true)//validar conexion abierta
                    {

                       
                        if (Type == 1)//BAPI_COMPANYCODE_GETLIST
                        {

                        
                            RfcDestinationManager.RegisterDestinationConfiguration(sapCon);
                            RfcDestination dest = RfcDestinationManager.GetDestination("SAPDest");
                            RfcRepository repo = dest.Repository;

                            IRfcFunction testfn = repo.CreateFunction("BAPI_AR_ACC_GETSTATEMENT");

                            testfn.Invoke(dest);

                            var companyCodeList = testfn.GetTable("COMPANYCODE_LIST");

                            result = companyCodeList.ToDataTable("CompanyList");
                 
                            RfcDestinationManager.UnregisterDestinationConfiguration(sapCon);

                        }


                        if (Type == 2)//BAPI_COMPANYCODE_GETLIST
                        {


                        RfcDestinationManager.RegisterDestinationConfiguration(sapCon);
                        RfcDestination dest = RfcDestinationManager.GetDestination("SAPDest");
                        RfcRepository repo = dest.Repository;

                        IRfcFunction testfn = repo.CreateFunction("BAPI_AR_ACC_GETSTATEMENT");

                        showSelecOptionByReport(1);
                        mre.WaitOne();

                        string format = "YYYYMMDD";
                        var dateFrom = Convert.ToDateTime(From);
                        var dateTo   = Convert.ToDateTime(To);


                        var D = dateFrom.ToString(format, System.Globalization.CultureInfo.InvariantCulture);

                        testfn.SetValue("COMPANYCODE",companycode);
                        testfn.SetValue("CUSTOMER", customer);
                        testfn.SetValue("DATE_FROM", Convert.ToDateTime(D));
                        testfn.SetValue("DATE_TO", Convert.ToDateTime(D));
                        testfn.SetValue("NOTEDITEMS", noteditems);

                        testfn.Invoke(dest);

                        var fnRes = testfn.GetStructure("RETURN").GetValue("MESSAGE");

                      
                        if (fnRes.ToString() != null)
                        {
                            
                            MessageBox.Show(fnRes.ToString(), "SAP Response");

                        }
                        else
                        {


                            var finatialStatement = testfn.GetTable("LINEITEMS");

                            result = finatialStatement.ToDataTable("GET_STATEMENT");

                        }

                        RfcDestinationManager.UnregisterDestinationConfiguration(sapCon);

                    }


                    }

            }
            catch (Exception theException)
            {
                RfcDestinationManager.UnregisterDestinationConfiguration(sapCon);
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

        public DataSet GetCompanies()//Get Sap Conpanies
        {

            try
            {
                if (repPreview is null)
                {


                    DataTable resTable = new DataTable("Bukrs");
                    resTable.Columns.Add("MANDT", typeof(String));
                    resTable.Columns.Add("BUKRS", typeof(String));
            


                    repPreview = new DataSet();
                    repPreview.Tables.Add(resTable);

                    if (doQuery == true)
                    {
                        reportQuery(1); //llamo a la bapi


                        if (queryTable != null && queryTable.Rows.Count > 0)
                        {
                            for (int i = 0; i < queryTable.Rows.Count; i++)
                            {
                                resTable.NewRow();

                              /*  rawDate = Convert.ToDateTime(queryTable.Rows[i].Field<DateTime>(1));
                                date = rawDate.ToString("yyyy-MM-dd");*/

                                
                                resTable.Rows.Add(
                                queryTable.Rows[i].Field<string>(0),
                                queryTable.Rows[i].Field<string>(1));
  


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

        public DataSet GetFinancialStatement()//Get Sap Financial_Statement
        {

            try
            {

                if (repPreview is null)
                {
                    

                    DataTable resTable = new DataTable("GET_STATEMENT");
                    resTable.Columns.Add("COMP", typeof(String));
                    resTable.Columns.Add("S", typeof(String));
                    resTable.Columns.Add("CLEAR_DATE", typeof(String));
                    resTable.Columns.Add("CLR_DOC_NO", typeof(String));
                    resTable.Columns.Add("ALLOC_NMBR", typeof(String));
                    resTable.Columns.Add("FISC", typeof(String));
                    resTable.Columns.Add("DOC_NO", typeof(String));

                    repPreview = new DataSet();
                    repPreview.Tables.Add(resTable);

                    if (doQuery == true)
                    {
                        reportQuery(2); //llamo a la bapi


                        if (queryTable != null && queryTable.Rows.Count > 0)
                        {
                            for (int i = 0; i < queryTable.Rows.Count; i++)
                            {
                                resTable.NewRow();

                                /*  rawDate = Convert.ToDateTime(queryTable.Rows[i].Field<DateTime>(1));
                                  date = rawDate.ToString("yyyy-MM-dd");*/


                                resTable.Rows.Add(

                                queryTable.Rows[i].Field<string>(0),
                                queryTable.Rows[i].Field<string>(1),
                                queryTable.Rows[i].Field<string>(2),
                                queryTable.Rows[i].Field<string>(3),
                                queryTable.Rows[i].Field<string>(4),
                                queryTable.Rows[i].Field<string>(5),
                                queryTable.Rows[i].Field<string>(6)

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



    }
}
