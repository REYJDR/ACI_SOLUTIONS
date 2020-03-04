using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFTPLibrary
{
    public partial class ProgressBar : Form
    {
        public ProgressBar()
        {
            InitializeComponent();
        }


        public void UpdateProgress(string title, string desc, double porcent)
        {
            lblTitle.Text = title;

            double loadStep = porcent * 100;
            progressBar1.Value = (int)loadStep;


            progressBar1.Update();

            lblPercent.Text = String.Concat(loadStep, "%");
            lblPercent.Refresh();

            lblDesc.Text = desc;
            lblDesc.Refresh();




        }
        
    }
}
