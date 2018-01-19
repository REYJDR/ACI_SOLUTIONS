using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CollectionISP
{
    class DbConnection
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

 
               

    }

 }
