using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;

namespace ACIWEB_DESKTOP_REPORT
{

    class DbConnetionPervasive
    {
        DbParamSage param = new DbParamSage();
        private OdbcCommand comm;
        public OdbcConnection DbConn;

       // private OdbcDataAdapter datos;

        public OdbcConnection StartConn(string conn)
        {

            OdbcConnection con = new OdbcConnection(conn);
            DbConn = con;
            try
            {
                //con.ConnectionTimeout = 0;
                
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
            DbConn = con;
            return con;
        }

        public OdbcDataReader Query(string query)
        {
            OdbcDataReader reader = null;

            try
            {
               //  datos = new OdbcDataAdapter(query, DbConn);

                comm = new OdbcCommand(query, DbConn);
                comm.CommandTimeout = 2000;
                reader = comm.ExecuteReader();

            }
            catch (Exception msg)
            {

                MessageBox.Show("Error al ejecutar query " + msg);

            }

            return reader;

        }

        public void Close()
        {

            try
            {
                DbConn.Close();
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

    }
}
