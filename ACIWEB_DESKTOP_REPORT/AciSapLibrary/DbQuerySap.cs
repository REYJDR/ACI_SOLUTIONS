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

namespace AciSapLibrary
{
    class DbQuerySap
    {
        SapConnection sapCon = new SapConnection();

        DataSet TablesSet = new DataSet("BapiTables");

        public static DataTable queryTable;
        public static DataSet repPreview;
        public static bool doQuery;
       // public static bool theresData;
       
       
        public static string exportFileName;
        public static bool kill = false;
        public static bool hasImport = false;
        public static string sapBapi;
        public static string ExportTbleName;
        public static string ExportType;
        public static bool hasreturn;
        public static string bapiName;


        //Selection options 
        public static ManualResetEvent mre = new ManualResetEvent(false);
        FrmFilterSap SO = new FrmFilterSap();
        DataTable SelectOptions = new DataTable("SelectOption");

        
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
            SelectOptions.Columns.Add("desc", typeof(String));
            SelectOptions.Columns.Add("datatype", typeof(String));

        }

        private void showSelecOptionByReport(int Type)
        {
            
            if (Type == 1)
            {
                //selection option 
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("text", "BAPI", 35, "BAPI_GL_ACC_GETBALANCE");
                SelectOptions.NewRow();
                SelectOptions.Rows.Add("button", "Go");


                SO.SetSelectionsOptions(SelectOptions);
                SO.ShowDialog();

                TextBox BAPI = SO.selectOptionsPanel.Controls.Find("BAPI", true).FirstOrDefault() as TextBox;
                sapBapi = BAPI.Text; 
                

            }

        }
        //SELECTION OPTIONS

        public void ExecuteBapi()
        {

            
            DataTable resTable = null;
            TablesSet.Clear();

            try
            {

                    if (true)//validar conexion abierta
                    {

                        if (RfcDestinationManager.TryGetDestination("SAPDest") == null)
                        {

                           RfcDestinationManager.RegisterDestinationConfiguration(sapCon);
                      
                        }


                        SelectOptions.Clear();

                            RfcDestination dest = RfcDestinationManager.GetDestination("SAPDest");
                            RfcRepository repo = dest.Repository;
                            IRfcFunction testfn = repo.CreateFunction(bapiName);

                            if(testfn.Metadata.ParameterCount > 0)
                            {
                                for (int i = 0; i < testfn.Metadata.ParameterCount; i++)
                                    {

                                        var type = testfn.GetElementMetadata(i).DataType.ToString();
                                        var name = testfn.GetElementMetadata(i).Name;
                                        var paramDesc = testfn.GetElementMetadata(i).Documentation;
                                       

                                        if (testfn.GetElementMetadata(i).ToString().Contains("IMPORT"))
                                        {
                                             
                                                hasImport = true;
                                           
                                                if (type == "STRUCTURE")
                                                {
                                                    IRfcStructure resultTable = testfn.GetStructure(name);

                                                    IEnumerator<IRfcField> list = resultTable.GetEnumerator();

                                                    List<string> valueList = new List<string>();

                                                    SelectOptions.NewRow();
                                                    SelectOptions.Rows.Add("lable", name);


                                                    while (list.MoveNext())
                                                    {
                                            
                                                        SelectOptions.NewRow();
                                                        SelectOptions.Rows.Add("text", list.Current.Metadata.Name, list.Current.Metadata.NucLength);
                                                  
                                                    }


                                                }
                                                else
                                                {
                                                     var defaultValue = "";
                                                    /*var defaultValue =  testfn.GetElementMetadata(i).ToString().Split(':')[2].Replace("]", "");
                                                      if (defaultValue.Contains("SPACE"))
                                                      {
                                                          defaultValue = "";
                                                      }*/

                                                    SelectOptions.NewRow();
                                                    SelectOptions.Rows.Add("text", name, testfn.GetElementMetadata(i).NucLength, defaultValue, null, type);
                                                    if(paramDesc != null)
                                                    {
                                                        SelectOptions.NewRow();
                                                        SelectOptions.Rows.Add("desc", paramDesc, paramDesc.Length);
                                                    }
                                                   
                                                   

                                                }



                                            }

                                        if (testfn.GetElementMetadata(i).ToString().Contains("TABLES"))
                                         {

                                                if (type == "TABLE")
                                                {
                                        
                                                    ExportTbleName = name;
                                                    ExportType = "TABLE";
                                        
                                                }
                                        }

                                        if (testfn.GetElementMetadata(i).ToString().Contains("EXPORT"))
                                        {

                                            if (type == "TABLE")
                                            {
                                                ExportTbleName = name;
                                                ExportType = "TABLE";
                                        
                                            }

                                            
                                            if (type == "STRUCTURE" && name != "RETURN")
                                            {
                                                ExportType = "STRUCTURE";
                                                ExportTbleName = name;
                                            }

                                            if (name == "RETURN")
                                            {
                                                hasreturn =true;
                                            }


                                        }

                                    }
                                
                                     if (hasImport)
                                     {
                                        SelectOptions.NewRow();
                                        SelectOptions.Rows.Add("button", "Execute");

                                        SO.SetSelectionsOptions(SelectOptions);
                                        SO.ShowDialog();
                                      
                                        mre.WaitOne();

                                        TextBox val;

                                        for (int i = 0; i < SelectOptions.Rows.Count; i++)
                                        {
                                            if (SelectOptions.Rows[i].Field<string>(0) == "text")
                                            {
                                                val = SO.selectOptionsPanel2.Controls.Find(SelectOptions.Rows[i].Field<string>(1), true).FirstOrDefault() as TextBox;

                                                if (SelectOptions.Rows[i].Field<string>(5).Contains("CHAR"))
                                                {
                                                  testfn.SetValue(SelectOptions.Rows[i].Field<string>(1), val.Text);
                                                }

                                                if (SelectOptions.Rows[i].Field<string>(5).Contains("INT"))
                                                {
                                                    testfn.SetValue(SelectOptions.Rows[i].Field<string>(1), Convert.ToInt32(val.Text));
                                                }


                                        }


                                        }
                                       
                                     }
                                 
                            
                           
                            if (kill == false)
                            {
                                hasImport = false;
                                string fnRes = ""; 

                                testfn.Invoke(dest);

                            
                                if(hasreturn)
                                {
                                    hasreturn = false;
                                

                                    fnRes = testfn.GetStructure("RETURN").GetValue("MESSAGE").ToString();

                                }



                               if (fnRes != "")
                                {

                                      MessageBox.Show(fnRes.ToString(), "SAP BAPI Response");

                                }
                                else
                                {


                                    if(ExportType == "TABLE")
                                    {
                                  
                                       resTable = TablesSet.Tables[ExportTbleName];
                                       var resFnTable = testfn.GetTable(ExportTbleName);
                                    
                                        foreach(DataRow dr in resFnTable.ToDataTable(ExportTbleName).Rows)
                                        {
                                            resTable.ImportRow(dr);
                                        }
                                       
                                    }

                                    if (ExportType == "STRUCTURE")
                                    {

                                   
                                          resTable = TablesSet.Tables[ExportTbleName];
                                          var value  = testfn.GetStructure(ExportTbleName);

                                    
                                            var resFnEstructure = testfn.GetStructure(ExportTbleName);

                                            DataRow dr = resTable.NewRow();
                                            foreach (var column in resTable.Columns)
                                            {
                                                dr[column.ToString()] = value.GetValue(column.ToString());
                                            }
                                            resTable.Rows.Add(dr);

                                    }

                                }

                           

                            }


                        }

                        
                      //  RfcDestinationManager.UnregisterDestinationConfiguration(sapCon);
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
                RfcDestinationManager.UnregisterDestinationConfiguration(sapCon);

            }

            //Guardo resultado en DataTable global para esta clase.
            queryTable = resTable;
           

        }

        
        public DataSet BapiDataset()
        {
            DataTable resTable = null;

            try
            {

                if (repPreview is null)
                {
                    if (RfcDestinationManager.TryGetDestination("SAPDest") == null)
                    {

                        RfcDestinationManager.RegisterDestinationConfiguration(sapCon);
                       

                    }

                    RfcDestination dest = RfcDestinationManager.GetDestination("SAPDest");
                    RfcRepository repo = dest.Repository;
                    
                   
                    IRfcFunction testfn = repo.CreateFunction(bapiName);

                    for (int i = 0; i < testfn.Metadata.ParameterCount; i++)
                    {
                        var type = testfn.GetElementMetadata(i).DataType.ToString();
                        var name = testfn.GetElementMetadata(i).Name;


                        if (type == "TABLE")
                        {
                            resTable = new DataTable(name);
                            TablesSet.Tables.Add(resTable);

                            var datatable = testfn.GetTable(name);
                            var ColumnCount = datatable.Metadata.LineType.FieldCount;

                               if (ColumnCount > 0)
                                {
                                    for (int l = 0; l < ColumnCount ; l++)
                                    {
                                   
                                        resTable.Columns.Add(datatable.GetElementMetadata(l).Name, typeof(String));


                                    }
                                

                                }
                        }

                        if (type == "STRUCTURE" && name != "RETURN")
                        {
                            ExportType = "STRUCTURE";
                            ExportTbleName = name;

                            resTable = new DataTable(name);
                            TablesSet.Tables.Add(resTable);

                            IRfcStructure resultTable = testfn.GetStructure(name);

                            IEnumerator<IRfcField> list = resultTable.GetEnumerator();

                            List<string> valueList = new List<string>();

                            while (list.MoveNext())
                            {

                                resTable.Columns.Add(list.Current.Metadata.Name, typeof(String));
                               
                            }


                        }


                    }


                 //   RfcDestinationManager.UnregisterDestinationConfiguration(sapCon);

              

                    if (doQuery == true)
                    {

                        ExecuteBapi(); //llamo a la bapi

                        doQuery = false;
                    }

                    repPreview = new DataSet();
                    repPreview = TablesSet;

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
