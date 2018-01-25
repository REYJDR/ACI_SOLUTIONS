using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SftpFilesSync
{
    class SftpConnection
    {
        SftpParam param = new SftpParam();
        
        public  void StartConn()
        {

   

            try
            {

              
               
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

           
        }

        public void Closed()
        {

           

        }

 
               

    }

 }
