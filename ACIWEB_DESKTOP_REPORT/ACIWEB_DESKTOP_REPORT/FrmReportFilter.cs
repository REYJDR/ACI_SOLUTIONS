using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACIWEB_DESKTOP_REPORT
{
    public partial class FrmReportFilter : Form
    {


        int y = 0;
        public static bool winClose;




        public FrmReportFilter()
        {
            InitializeComponent();
           
        }

        public void SetSelectionsOptions(DataTable SelectionOptions)
        {
            selectOptionsPanel.Controls.Clear();
            winClose = false;

            for (int i = 0; i < SelectionOptions.Rows.Count ; i++)
            {

               var dataType =  SelectionOptions.Rows[i].Field<string>(0);
               var fielName =  SelectionOptions.Rows[i].Field<string>(1);

                if (dataType == "text")
                {
                    // Create new Label
                    var newLabel = new Label();
                    newLabel.Name = "lbl_" + fielName;
                    newLabel.Text = fielName;
                    newLabel.Location = new Point(10, y);

                    // Create new TextBox
                    var newTextbox = new TextBox();
                    newTextbox.Name = fielName;
                    newTextbox.Location = new Point(150, y);

                    // Add items to panel, then add panel to form
                    selectOptionsPanel.Controls.Add(newLabel);
                    selectOptionsPanel.Controls.Add(newTextbox);
                    y = y + 40;
                }

                if (dataType == "date")
                {   // Create new Label


                    var newLabel = new Label();
                    newLabel.Name = "lbl_" +fielName;
                    newLabel.Text = fielName;
                    newLabel.Size = new Size(90, 23);
                    newLabel.Location = new Point(10, y);
                    newLabel.Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    var newDateBox = new DateTimePicker();
                    newDateBox.AllowDrop = true;
                    newDateBox.Size = new Size(150, 23);
                    newDateBox.CustomFormat = "yyyy-MM-dd";
                    newDateBox.Format = DateTimePickerFormat.Custom;
                    newDateBox.Name = "date_" + fielName;
                    newDateBox.Location = new Point(120, y);


                    // Add items to panel, then add panel to form
                    selectOptionsPanel.Controls.Add(newLabel);
                    selectOptionsPanel.Controls.Add(newDateBox);
                    y = y + 30;
                }

            
                if (dataType == "button")
                {  
                    
                    Button dynamicButton = new Button();
                    
                    // Set Button properties
                    dynamicButton.Size = new Size(75, 23);
                    dynamicButton.Location = new Point(393, 130);
                    dynamicButton.Text = fielName;
                    dynamicButton.Name = "btn_" + fielName;
                    dynamicButton.UseVisualStyleBackColor = true;

                    dynamicButton.Click += new EventHandler(Button_Click);
                    
                    selectOptionsPanel.Controls.Add(dynamicButton);
                   
                }



            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            DbQueryAciweb.mre.Set();
            DbQuerySage.mre.Set();
            DbQuerySap.mre.Set();
            this.Close();
        }

        private void picClose_Click_1(object sender, EventArgs e)
        {
            DbQueryAciweb.mre.Close();
            DbQuerySage.mre.Close();
            DbQuerySap.mre.Close();

            this.Close();

        }
    }
}
