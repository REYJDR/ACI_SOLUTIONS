using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AciSapLibrary
{
    public partial class FrmFilterSap : Form
    {

        int y = 5;
        int yx = 0;
        int dx = 0;
        public static bool winClose;
        public static bool exe;



        public FrmFilterSap()
        {
            InitializeComponent();

            exe = false;
            DbQuerySap.kill = false;
        }


        public void SetSelectionsOptions(DataTable SelectionOptions)
        {

            var newSice = SelectionOptions.Rows.Count * 80;

            this.MaximumSize = new Size(800, 800);
            this.AutoSize = true;
            this.AutoScroll = true;
            selectOptionsPanel.AutoSize = true;
            selectOptionsPanel2.AutoSize = true;
            groupBox1.AutoSize = true;


            selectOptionsPanel.Controls.Clear();
            winClose = false;

            for (int i = 0; i < SelectionOptions.Rows.Count; i++)
            {

                var dataType = SelectionOptions.Rows[i].Field<string>(0);
                var fielName = SelectionOptions.Rows[i].Field<string>(1);
                var longitud = SelectionOptions.Rows[i].Field<string>(2);
                var dafaultVal = SelectionOptions.Rows[i].Field<string>(3);
                var FontType = "SAPGUI - Belize - Icons";

                if (dataType == "lable")
                {
                    // Create new Label
                    var newLabel = new Label();

                    newLabel.AutoSize = true;
                    newLabel.Name = "lbl_" + fielName;
                    newLabel.Text = fielName.Replace("_", " ");
                    newLabel.Location = new Point(10, y);
                    newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    newLabel.Font = new Font(FontType, 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


                    // Add items to panel, then add panel to form
                    selectOptionsPanel.Controls.Add(newLabel);

                    y = y + 20;
                }

                if (dataType == "text")
                {
                    yx = y;

                    // Create new Label
                    var newLabel = new Label();
                    newLabel.AutoSize = false;
                    newLabel.Name = "lbl_" + fielName;
                    newLabel.Text = fielName.Replace("_", " ");
                    newLabel.Location = new Point(10, y);
                    newLabel.Font = new Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;


                    // Create new TextBox
                    var newTextbox = new TextBox();

                    newTextbox.Name = fielName;
                    newTextbox.Location = new Point(10, y);
                    newTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                    newTextbox.BackColor = Color.AliceBlue;
                    newTextbox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                    if (longitud != "")
                    {

                        newTextbox.MaxLength = Convert.ToInt32(longitud) + 2;

                        using (Graphics G = newTextbox.CreateGraphics())
                        {
                            newTextbox.Width = (int)(newTextbox.MaxLength *
                                                      G.MeasureString("x", newTextbox.Font).Width);
                        }
                    }




                    if (dafaultVal != "")
                    {
                        newTextbox.Text = dafaultVal;
                    }

                    // Add items to panel, then add panel to form
                    selectOptionsPanel.Controls.Add(newLabel);
                    selectOptionsPanel2.Controls.Add(newTextbox);
                    // selectOptionsPanel.Controls.Add(newTextbox);
                    y = y + 25;
                }

                if (dataType == "desc")
                {

                    // Create new Label
                    var newLabel = new Label();
                    newLabel.AutoSize = true;
                    newLabel.Name = "lbl_" + fielName;
                    newLabel.Text = "(" + fielName.Replace("_", " ") + ")";
                    newLabel.Location = new Point(10, y);
                    newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    newLabel.Font = new Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    // Add items to panel, then add panel to form
                    selectOptionsPanel2.Controls.Add(newLabel);
                    y = y + 25;
                }

                if (dataType == "date")
                {   // Create new Label


                    var newLabel = new Label();
                    newLabel.AutoSize = false;
                    newLabel.Name = "lbl_" + fielName;
                    newLabel.Text = fielName.Replace("_", " ");
                    newLabel.Location = new Point(10, y);
                    newLabel.Font = new Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                    var newDateBox = new DateTimePicker();
                    newDateBox.AllowDrop = true;
                    newDateBox.Size = new Size(100, 23);
                    newDateBox.Format = DateTimePickerFormat.Custom;
                    newDateBox.CustomFormat = "dd-MM-yyyy";
                    newDateBox.Name = "date_" + fielName;
                    newDateBox.Location = new Point(10, y);


                    // Add items to panel, then add panel to form
                    selectOptionsPanel.Controls.Add(newLabel);
                    selectOptionsPanel2.Controls.Add(newDateBox);
                    y = y + 25;
                }

                if (dataType == "button")
                {

                    Button dynamicButton = new Button();

                    var footerPoint = this.Size.Height - 70;

                    // Set Button properties
                    dynamicButton.AutoSize = true;
                    dynamicButton.Location = new Point(250, y + 5);
                    dynamicButton.Text = fielName;
                    dynamicButton.Name = "btn_" + fielName;
                    dynamicButton.UseVisualStyleBackColor = true;
                    dynamicButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    dynamicButton.Click += new EventHandler(Button_Click);


                    selectOptionsPanel2.Controls.Add(dynamicButton);

                }



            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor; // change cursor to hourglass type

            exe = true;

            DbQuerySap.mre.Set();
            DbQuerySap.kill = false;

            this.Close();
        }



        private void closeTask()
        {
            Cursor = Cursors.Default; // change cursor to hourglass type


            if (exe != true)
            {

                DbQuerySap.mre.Set();

                DbQuerySap.kill = true;
                DbQuerySap.hasImport = false;
             

                this.Close();
            }

        }

        private void closeTask(object sender, FormClosedEventArgs e)
        {
            closeTask();
        }
    }
}
