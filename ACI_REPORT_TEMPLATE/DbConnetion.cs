using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace $safeprojectname$
{
    class DbConnection
    {
       
        
        public SqlConnection StartConn()
        {
            DbParam param = new DbParam();
        
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
            DbParam param = new DbParam();

            SqlConnection con = new SqlConnection(param.ConString());
            con.Close();

        }

 
               

    }

 }
