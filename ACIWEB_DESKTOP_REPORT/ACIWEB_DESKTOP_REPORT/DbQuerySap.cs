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
        public static string exportFileName;
        public static bool kill = false;

        //Selection options 
        FrmReportFilter SO = new FrmReportFilter();
        DataTable SelectOptions = new DataTable("SelectOption");

        //variables de parametros de seleccion
        public static string From;
        public static string To;
        public static string companycode;
        public static string customer;
        public static string noteditems;
        public static string year;
        public static string glaccnt;
        public static string type;


        public DbQuerySap()
        {
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
                SelectOptions.Rows.Add("text", "COMPANY", 4, false);
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("text", "CUSTOMER", 10, false);
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("date","FROM");
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("date", "TO");
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("text", "NOTEDITEMS",4);
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

                DateTimePicker to = SO.selectOptionsPanel.Controls.Find("date_TO", true).FirstOrDefault() as DateTimePicker;
                To = to.Text;

                DateTimePicker from = SO.selectOptionsPanel.Controls.Find("date_FROM", true).FirstOrDefault() as DateTimePicker;
                From = from.Text;




            }

            if (Type == 2) { 
                //selection option 
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("text",  "COMPANY", 4,"0105");
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("text", "GL_ACCOUNT", 11, "110201121");
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("text", "YEAR", 4, Convert.ToString(DateTime.Now.Year));
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("text", "CURRENCY_TYPE", 2, "10");
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("button","Go");


                SO.SetSelectionsOptions(SelectOptions);
                SO.ShowDialog();

                TextBox COMPANYCODE = SO.selectOptionsPanel.Controls.Find("COMPANY", true).FirstOrDefault() as TextBox;
                if (COMPANYCODE != null) { companycode = COMPANYCODE.Text; } else { companycode = ""; };

                TextBox GL_ACCOUNT = SO.selectOptionsPanel.Controls.Find("GL_ACCOUNT", true).FirstOrDefault() as TextBox;
                if (GL_ACCOUNT != null) {  glaccnt = GL_ACCOUNT.Text; } else {  glaccnt = ""; };

                TextBox YEAR = SO.selectOptionsPanel.Controls.Find("YEAR", true).FirstOrDefault() as TextBox;
                if (YEAR != null) {  year = YEAR.Text; } else { year = ""; };

                TextBox TYPE = SO.selectOptionsPanel.Controls.Find("CURRENCY_TYPE", true).FirstOrDefault() as TextBox;
                if (TYPE != null) { type = TYPE.Text; } else { type = ""; };

                

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
                        RfcDestinationManager.RegisterDestinationConfiguration(sapCon);
                        RfcDestination dest = RfcDestinationManager.GetDestination("SAPDest");
                        RfcRepository repo = dest.Repository;


                        if (Type == 1)//BAPI_COMPANYCODE_GETLIST
                        {

                        
                            IRfcFunction testfn = repo.CreateFunction("BAPI_COMPANYCODE_GETLIST");

                            testfn.Invoke(dest);

                            var companyCodeList = testfn.GetTable("COMPANYCODE_LIST");

                            result = companyCodeList.ToDataTable("CompanyList");
                 
                            

                        }

                         

                        if (Type == 2)// BAPI_GL_ACC_GETBALANCE
                        {

                            IRfcFunction testfn = repo.CreateFunction("BAPI_GL_ACC_GETBALANCE");

                                showSelecOptionByReport(2);
                                mre.WaitOne();

                            if (kill == false)
                            {
                                testfn.SetValue("COMPANYCODE", companycode);
                                testfn.SetValue("GLACCT", glaccnt);
                                testfn.SetValue("FISCALYEAR", year);
                                testfn.SetValue("CURRENCYTYPE", type);

                                testfn.Invoke(dest);

                                var fnRes = testfn.GetStructure("RETURN").GetValue("MESSAGE");


                                if (fnRes.ToString() != "")
                                {

                                    MessageBox.Show(fnRes.ToString(), "SAP Response");

                                }
                                else
                                {

                                    var finatialStatement = testfn.GetStructure("ACCOUNT_BALANCE");

                                    //  result = finatialStatement;

                                }

                            }
                        }

                         RfcDestinationManager.UnregisterDestinationConfiguration(sapCon);
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
                
                    DataTable resTable = new DataTable("CompanyList");
                    resTable.Columns.Add("COMP", typeof(String));
                    resTable.Columns.Add("COMP_NAME", typeof(String));
            
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

        public DataSet GetGlBalance()//Get Sap Financial_Statement
        {

            try
            {

                if (repPreview is null)
                {
                    

                    DataTable resTable = new DataTable("GL_Balance");
                    resTable.Columns.Add("COMP_CODE", typeof(String));
                    resTable.Columns.Add("GL_ACCOUNT", typeof(String));
                    resTable.Columns.Add("FISC_YEAR", typeof(String));
                    resTable.Columns.Add("BALANCE", typeof(String));
                    resTable.Columns.Add("CURRENCY", typeof(String));
                    resTable.Columns.Add("CURRENCY_ISO", typeof(String));
                 

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

                                
                                resTable.Rows.Add(

                                queryTable.Rows[i].Field<string>(0),
                                queryTable.Rows[i].Field<string>(1),
                                queryTable.Rows[i].Field<string>(2),
                                queryTable.Rows[i].Field<string>(3),
                                queryTable.Rows[i].Field<string>(4),
                                queryTable.Rows[i].Field<string>(5)

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
