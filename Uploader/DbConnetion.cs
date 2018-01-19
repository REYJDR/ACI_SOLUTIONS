using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UPLOADER
{
    class DbConnetion
    {
        DbParam param = new DbParam();
        
        public SqlConnection StartConn()
        {

        
            SqlConnection con = new SqlConnection(param.ConString());

            try
            {
                con.Open();

               
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

            return con;
        }

        public void Closed()
        {

            SqlConnection con = new SqlConnection(param.ConString());
            con.Close();

        }

        public void dbInsert(DataGridView dataGridTbl)
        {

           
                using (SqlConnection con = new SqlConnection(param.ConString()))
                {




                try
                {
                        for (int i = 0; i < dataGridTbl.Rows.Count - 1; i++)
                            {
                            String query = "INSERT " +
                                  "INTO dbo.COMPRAS_ADIDAS (" +
                                  "NO_CARTON," +
                                  "DELIVERY," +
                                  "CONTENEDOR," +
                                  "PROVEEDOR," +
                                  "MATERIAL," +
                                  "EAN," +
                                  "GRID_VALUE," +
                                  "DELIVERY_QTY," +
                                  "ESTADO," +
                                  "INVOICE_DATE," +
                                  "PO_NUMBER," +
                                  "MODEL_DESC," +
                                  "GENDER," +
                                  "DIVISION," +
                                  "BRAND_CODE," +
                                  "PRODUCT_TYPE," +
                                  "SPORT_DESC," +
                                  "AGE_GRP_DESC )" +
                               "VALUES ( " +
                                  "@NO_CARTON," +
                                  "@DELIVERY," +
                                  "@CONTENEDOR," +
                                  "@PROVEEDOR," +
                                  "@MATERIAL," +
                                  "@EAN," +
                                  "@GRID_VALUE," +
                                  "@DELIVERY_QTY," +
                                  "@ESTADO," +
                                  "@INVOICE_DATE," +
                                  "@PO_NUMBER," +
                                  "@MODEL_DESC," +
                                  "@GENDER," +
                                  "@DIVISION," +
                                  "@BRAND_CODE," +
                                  "@PRODUCT_TYPE," +
                                  "@SPORT_DESC," +
                                  "@AGE_GRP_DESC );";


                            using (SqlCommand command = new SqlCommand(query, con))
                            {
                                    command.Parameters.AddWithValue("@NO_CARTON", dataGridTbl.Rows[i].Cells[0].Value);
                                    command.Parameters.AddWithValue("@DELIVERY", dataGridTbl.Rows[i].Cells[1].Value);
                                    command.Parameters.AddWithValue("@CONTENEDOR", dataGridTbl.Rows[i].Cells[2].Value);
                                    command.Parameters.AddWithValue("@PROVEEDOR", "1");
                                    command.Parameters.AddWithValue("@MATERIAL", dataGridTbl.Rows[i].Cells[3].Value);
                                    command.Parameters.AddWithValue("@EAN", dataGridTbl.Rows[i].Cells[4].Value);
                                    command.Parameters.AddWithValue("@GRID_VALUE", dataGridTbl.Rows[i].Cells[5].Value);
                                    command.Parameters.AddWithValue("@DELIVERY_QTY", dataGridTbl.Rows[i].Cells[6].Value);
                                    command.Parameters.AddWithValue("@ESTADO", "DISPONIBLE");
                                    command.Parameters.AddWithValue("@INVOICE_DATE", dataGridTbl.Rows[i].Cells[7].Value);
                                    command.Parameters.AddWithValue("@PO_NUMBER", dataGridTbl.Rows[i].Cells[8].Value);
                                    command.Parameters.AddWithValue("@MODEL_DESC", dataGridTbl.Rows[i].Cells[9].Value);
                                    command.Parameters.AddWithValue("@GENDER", dataGridTbl.Rows[i].Cells[10].Value);
                                    command.Parameters.AddWithValue("@DIVISION", dataGridTbl.Rows[i].Cells[11].Value);
                                    command.Parameters.AddWithValue("@BRAND_CODE", dataGridTbl.Rows[i].Cells[12].Value);
                                    command.Parameters.AddWithValue("@PRODUCT_TYPE", dataGridTbl.Rows[i].Cells[13].Value);
                                    command.Parameters.AddWithValue("@SPORT_DESC", dataGridTbl.Rows[i].Cells[14].Value);
                                    command.Parameters.AddWithValue("@AGE_GRP_DESC", dataGridTbl.Rows[i].Cells[15].Value);


                            if (con.State == System.Data.ConnectionState.Closed)
                            {
                                con.Open();

                            }

                                    int result = command.ExecuteNonQuery();


                            }

                        Closed();//cierra conexion DB
                        }

                }
                catch (Exception msg)
                {

                    MessageBox.Show("Error al ejecutar query " + msg);

                }

            }


        }
               

    }

 }
