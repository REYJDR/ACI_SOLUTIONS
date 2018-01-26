using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SftpFilesSync
{
    public partial class FrmInit : Form
    {
        private SftpParam conParams;

        SftpConnection Sftp = new SftpConnection();

        public FrmInit()
        {
            InitializeComponent();
            InitValue();
        }

        private void InitValue()
        {
            conParams = new SftpParam();
            conParams.GetValueFromFile();

            textServer.Text = conParams.Hostaname;
            textPort.Text = Convert.ToString(conParams.Port);
            textUser.Text = conParams.User;
            textPass.Text = conParams.Password;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*INI READ AND SAVE CONNECTION PARAMETERS*/
            conParams.Hostaname = textServer.Text;
            conParams.User = textUser.Text;
            conParams.Password = textPass.Text;
            conParams.Port = Convert.ToInt32(textPort.Text);
            /*END READ AND SAVE CONNECTION PARAMETERS*/

            /*Save params values */
            conParams.SetValueOnFile();

            //abre  Sftp CONNETION
            Sftp.TestConn();


            /*Abre conexion para test*/


            /*   if (dbConn.StartConn().State == System.Data.ConnectionState.Open)
               {
                   setMsgtext("Test de conexión exitoso");
                   MessageBox.Show("Test de conexión exitoso", "Test de conexión");


                   //dbConn.Closed();
               } 
           */





        }


    }
}
