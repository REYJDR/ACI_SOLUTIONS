﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;

namespace CollectionISP
{

    class DbConnetionPervasive
    {
        DbParam param = new DbParam();
        private OdbcDataAdapter datos;

        public OdbcConnection StartConn()
        {

            OdbcConnection con = new OdbcConnection(param.ConString());
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

        public OdbcDataAdapter Query(string query)
        {

            try
            {
                datos = new OdbcDataAdapter(query, StartConn());
                datos.SelectCommand.CommandTimeout = 300;
            }
            catch (Exception msg)
            {

                MessageBox.Show("Error al ejecutar query " + msg);

            }

            return datos;

        }

    }
}
