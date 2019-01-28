using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ACIWEB_DESKTOP_REPORT
{
    class DbConnectionMysql
    {
        DbParamAciweb param = new DbParamAciweb();
        private MySqlConnection connection;
        private MySqlDataAdapter Datos;



        //open connection to database
        public bool  StartConn()
        {
            connection = new MySqlConnection(param.ConString());
           

            try
            {
               
                connection.Open();
                return true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
                return false;

            }


        }

        public MySqlConnection GetSession()
        {
            return connection;
        }


        //Close connection
        public bool Close()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
                return false;
            }
        }


        public MySqlDataAdapter Query(string query)
        {
            try
            {

                    Datos = new MySqlDataAdapter(query, connection);

                    //close Connection
                    this.Close();

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


            return Datos;

        }
    }
}
