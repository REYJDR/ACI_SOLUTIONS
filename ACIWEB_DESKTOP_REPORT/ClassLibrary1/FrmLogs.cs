using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SFTPLibrary
{
    public partial class FrmLogs : Form
    {
        public FrmLogs()
        {
            InitializeComponent();
        }




        public void showMessage(string message)
        {

            txtBoxProgress.AppendText(message);
            txtBoxProgress.AppendText(Environment.NewLine);


        }

        public void saveLog(string fileName)
        {
            bool exists = Directory.Exists(@"C:\\ACIDesktopReport\logs\");

            if (!exists)
            {
                Directory.CreateDirectory(@"C:\\ACIDesktopReport\logs\");
            }

            fileName = String.Concat(@"C:\\ACIDesktopReport\logs\", fileName, DateTime.Now.ToString("yyyy-MM-dd"), ".log");


            if (File.Exists(fileName))
            {

                string date = String.Concat("###", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), "###");
                string text = txtBoxProgress.Text;

                File.AppendAllText(fileName, date);
                File.AppendAllText(fileName, text);

            }
            else
            {
                string date = String.Concat("###", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), "###");
                string text = String.Concat(date, "\n", txtBoxProgress.Text);

                File.WriteAllText(fileName, date);
                File.WriteAllText(fileName, text);

            }





        }

        public void releaseMessage()
        {

            txtBoxProgress.Text = "";


        }

        private void picClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }


    }





}
