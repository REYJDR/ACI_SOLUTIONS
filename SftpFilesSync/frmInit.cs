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

        OpenFileDialog of = new OpenFileDialog();

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
            textPPK.Text = conParams.Ppk;
            textRePath.Text = conParams.RePath;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*INI READ AND SAVE CONNECTION PARAMETERS*/
            conParams.Hostaname = textServer.Text;
            conParams.User = textUser.Text;
            conParams.Password = textPass.Text;
            conParams.Port = Convert.ToInt32(textPort.Text);
            conParams.Ppk = textPPK.Text;
            conParams.RePath = textRePath.Text;
            /*END READ AND SAVE CONNECTION PARAMETERS*/

            /*Save params values */
            conParams.SetValueOnFile();

            //abre  Sftp CONNETION
            if (checkBox1.Checked) {

                Sftp.TestConn(true);

            } else {

                Sftp.TestConn(false);
            }



            /*Abre conexion para test*/


            /*   if (dbConn.StartConn().State == System.Data.ConnectionState.Open)
               {
                   setMsgtext("Test de conexión exitoso");
                   MessageBox.Show("Test de conexión exitoso", "Test de conexión");


                   //dbConn.Closed();
               } 
           */





        }

        private void btnPPK_Click(object sender, EventArgs e)
        {

            of.Filter = "PrivateKey (.ppk)| *.ppk*";
            of.ShowDialog();

            textPPK.Text = of.FileName;


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textPPK.Enabled = true;
                textPort.Text = "22";
            }
            else
            {

                textPPK.Enabled = false;
                textPort.Text = "21";
            }
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmInit_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
