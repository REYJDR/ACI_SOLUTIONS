using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AciSageLibrary
{
    public partial class FrmFilter : Form
    {
        public static DataTable CompanySeleccted;
        private bool all;


        public bool All { get => all; set => all = value; }


        int y = 5;
        int yx = 0;
        public static bool winClose;
        public static bool exe;
        public static bool show;
        public static bool select = false;

       // Panel panel3 = new Panel();
        FrmCompanyList frmCompanylist = new FrmCompanyList();
        FrmWait frmWait = new FrmWait();
        DataTable list;


        public FrmFilter()
        {
            InitializeComponent();
            
            exe = false;
            DbQuerySage.kill = false;
        }

        public void SetSelectionsOptions(DataTable SelectionOptions)
        {

            var newSice = SelectionOptions.Rows.Count * 80;

            this.MaximumSize = new Size(800, 800);
            this.AutoSize = true;
            this.AutoScroll = true;

            selectOptionsPanel.AutoSize = true;
            selectOptionsPanel2.AutoSize = true;
           
           // panel3.Hide();

            groupBox1.AutoSize = true;
            
            selectOptionsPanel.Controls.Clear();
            selectOptionsPanel2.Controls.Clear();
        //    panel3.Controls.Clear();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
           
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

                if (dataType == "period1")
                {   // Create new Label
                    
                    var newLabel = new Label();
                    newLabel.AutoSize = false;
                    newLabel.Name = "lbl_" + fielName;
                    newLabel.Text = fielName.Replace("_", " ");
                    newLabel.Location = new Point(10, y);
                    newLabel.Font = new Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                    var comboBox = new ComboBox();
                    comboBox.AutoSize = false;

           

                    comboBox.Items.Add("01 Ene - THIS YEAR");
                    comboBox.Items.Add("01 Feb - THIS YEAR");
                    comboBox.Items.Add("01 Mar - THIS YEAR");
                    comboBox.Items.Add("01 Abr - THIS YEAR");
                    comboBox.Items.Add("01 May - THIS YEAR");
                    comboBox.Items.Add("01 Jun - THIS YEAR");
                    comboBox.Items.Add("01 Jul - THIS YEAR");
                    comboBox.Items.Add("01 Ago - THIS YEAR");
                    comboBox.Items.Add("01 Sep - THIS YEAR");
                    comboBox.Items.Add("01 Oct - THIS YEAR");
                    comboBox.Items.Add("01 Nov - THIS YEAR");
                    comboBox.Items.Add("01 Dic - THIS YEAR");
                
                    comboBox.Items.Add("01 Ene - NEXT YEAR");
                    comboBox.Items.Add("01 Feb - NEXT YEAR");
                    comboBox.Items.Add("01 Mar - NEXT YEAR");
                    comboBox.Items.Add("01 Abr - NEXT YEAR");
                    comboBox.Items.Add("01 May - NEXT YEAR");
                    comboBox.Items.Add("01 Jun - NEXT YEAR");
                    comboBox.Items.Add("01 Jul - NEXT YEAR");
                    comboBox.Items.Add("01 Ago - NEXT YEAR");
                    comboBox.Items.Add("01 Sep - NEXT YEAR");
                    comboBox.Items.Add("01 Oct - NEXT YEAR");
                    comboBox.Items.Add("01 Nov - NEXT YEAR");
                    comboBox.Items.Add("01 Dic - NEXT YEAR");



                    if (longitud != "")
                    {

                        comboBox.MaxLength = Convert.ToInt32(longitud) + 2;

                        using (Graphics G = comboBox.CreateGraphics())
                        {
                            comboBox.Width = (int)(comboBox.MaxLength *
                                                      G.MeasureString("x", comboBox.Font).Width);
                        }
                    }

                    comboBox.Name = "period1_" + fielName;
                    comboBox.Location = new Point(10, y);
                    


                    // Add items to panel, then add panel to form
                    selectOptionsPanel.Controls.Add(newLabel);
                    selectOptionsPanel2.Controls.Add(comboBox);
                    y = y + 25;
                }
                
                if (dataType == "period2")
                {   // Create new Label


                    var newLabel = new Label();
                    newLabel.AutoSize = false;
                    newLabel.Name = "lbl_" + fielName;
                    newLabel.Text = fielName.Replace("_", " ");
                    newLabel.Location = new Point(10, y);
                    newLabel.Font = new Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                    var comboBox = new ComboBox();
                    comboBox.AutoSize = false;

             

                    comboBox.Items.Add("31 Ene - THIS YEAR");
                    comboBox.Items.Add("28 Feb - THIS YEAR");
                    comboBox.Items.Add("31 Mar - THIS YEAR");
                    comboBox.Items.Add("30 Abr - THIS YEAR");
                    comboBox.Items.Add("31 May - THIS YEAR");
                    comboBox.Items.Add("30 Jun - THIS YEAR");
                    comboBox.Items.Add("31 Jul - THIS YEAR");
                    comboBox.Items.Add("31 Ago - THIS YEAR");
                    comboBox.Items.Add("30 Sep - THIS YEAR");
                    comboBox.Items.Add("31 Oct - THIS YEAR");
                    comboBox.Items.Add("30 Nov - THIS YEAR");
                    comboBox.Items.Add("31 Dic - THIS YEAR");
                    
                    comboBox.Items.Add("31 Ene - NEXT YEAR");
                    comboBox.Items.Add("28 Feb - NEXT YEAR");
                    comboBox.Items.Add("31 Mar - NEXT YEAR");
                    comboBox.Items.Add("30 Abr - NEXT YEAR");
                    comboBox.Items.Add("31 May - NEXT YEAR");
                    comboBox.Items.Add("30 Jun - NEXT YEAR");
                    comboBox.Items.Add("31 Jul - NEXT YEAR");
                    comboBox.Items.Add("31 Ago - NEXT YEAR");
                    comboBox.Items.Add("30 Sep - NEXT YEAR");
                    comboBox.Items.Add("31 Oct - NEXT YEAR");
                    comboBox.Items.Add("30 Nov - NEXT YEAR");
                    comboBox.Items.Add("31 Dic - NEXT YEAR");

                    if (longitud != "")
                    {

                        comboBox.MaxLength = Convert.ToInt32(longitud) + 2;

                        using (Graphics G = comboBox.CreateGraphics())
                        {
                            comboBox.Width = (int)(comboBox.MaxLength *
                                                      G.MeasureString("x", comboBox.Font).Width);
                        }
                    }

                    comboBox.Name = "period2_" + fielName;
                    comboBox.Location = new Point(10, y);


                    // Add items to panel, then add panel to form
                    selectOptionsPanel.Controls.Add(newLabel);
                    selectOptionsPanel2.Controls.Add(comboBox);
                    y = y + 25;
                }

                if (dataType == "company")
                { 
                    
                    var newLabel = new Label();
                    newLabel.AutoSize = false;
                    newLabel.Name = "lbl_" + fielName;
                    newLabel.Text = fielName.Replace("_", " ");
                    newLabel.Location = new Point(10, y);
                    newLabel.Font = new Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;


                    var btn = new Button();
                    btn.Text = ">";
                    btn.Font = new Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn.Location = new System.Drawing.Point(10, y);
                    btn.Margin = new System.Windows.Forms.Padding(1);
                    btn.Name = "ListCompany";
                    btn.Size = new System.Drawing.Size(28, 25);
                    btn.TabIndex = 24;
                    btn.UseVisualStyleBackColor = true;
                    btn.MouseClick += new  MouseEventHandler(openList);


                    DbQuerySage query = new DbQuerySage();

                    list = query.CompaniesList();

                    selectOptionsPanel.Controls.Add(newLabel);
                    selectOptionsPanel2.Controls.Add(btn);

                    y = y + 25;


                }

                if (dataType == "budget")
                {

                    var newLabel = new Label();
                    newLabel.AutoSize = false;
                    newLabel.Name = "lbl_" + fielName;
                    newLabel.Text = fielName.Replace("_", " ");
                    newLabel.Location = new Point(10, y);
                    newLabel.Font = new Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;


                    var btn = new Button();
                    btn.Text = ">";
                    btn.Font = new Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn.Location = new System.Drawing.Point(10, y);
                    btn.Margin = new System.Windows.Forms.Padding(1);
                    btn.Name = "ListCompany";
                    btn.Size = new System.Drawing.Size(28, 25);
                    btn.TabIndex = 24;
                    btn.UseVisualStyleBackColor = true;
                    btn.MouseClick += new MouseEventHandler(openList);


                    DbQuerySage query = new DbQuerySage();

                    list = query.BudgetList();

                    selectOptionsPanel.Controls.Add(newLabel);
                    selectOptionsPanel2.Controls.Add(btn);

                    y = y + 25;


                }

                if (dataType == "period")
                {   // Create new Label


                    var newLabel = new Label();
                    newLabel.AutoSize = false;
                    newLabel.Name = "lbl_" + fielName;
                    newLabel.Text = fielName.Replace("_", " ");
                    newLabel.Location = new Point(10, y);
                    newLabel.Font = new Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                    var comboBox = new ComboBox();
                    comboBox.AutoSize = false;


                    comboBox.Items.Add("Ene - THIS YEAR");
                    comboBox.Items.Add("Feb - THIS YEAR");
                    comboBox.Items.Add("Mar - THIS YEAR");
                    comboBox.Items.Add("Abr - THIS YEAR");
                    comboBox.Items.Add("May - THIS YEAR");
                    comboBox.Items.Add("Jun - THIS YEAR");
                    comboBox.Items.Add("Jul - THIS YEAR");
                    comboBox.Items.Add("Ago - THIS YEAR");
                    comboBox.Items.Add("Sep - THIS YEAR");
                    comboBox.Items.Add("Oct - THIS YEAR");
                    comboBox.Items.Add("Nov - THIS YEAR");
                    comboBox.Items.Add("Dic - THIS YEAR");

                    comboBox.Items.Add("Ene - NEXT YEAR");
                    comboBox.Items.Add("Feb - NEXT YEAR");
                    comboBox.Items.Add("Mar - NEXT YEAR");
                    comboBox.Items.Add("Abr - NEXT YEAR");
                    comboBox.Items.Add("May - NEXT YEAR");
                    comboBox.Items.Add("Jun - NEXT YEAR");
                    comboBox.Items.Add("Jul - NEXT YEAR");
                    comboBox.Items.Add("Ago - NEXT YEAR");
                    comboBox.Items.Add("Sep - NEXT YEAR");
                    comboBox.Items.Add("Oct - NEXT YEAR");
                    comboBox.Items.Add("Nov - NEXT YEAR");
                    comboBox.Items.Add("Dic - NEXT YEAR");


                    if (longitud != "")
                    {

                        comboBox.MaxLength = Convert.ToInt32(longitud) + 2;

                        using (Graphics G = comboBox.CreateGraphics())
                        {
                            comboBox.Width = (int)(comboBox.MaxLength *
                                                      G.MeasureString("x", comboBox.Font).Width);
                        }
                    }

                    comboBox.Name = "period_" + fielName;
                    comboBox.Location = new Point(10, y);


                    // Add items to panel, then add panel to form
                    selectOptionsPanel.Controls.Add(newLabel);
                    selectOptionsPanel2.Controls.Add(comboBox);
                    y = y + 25;
                }

                if (dataType == "fiscalyr")
                {

                    var newLabel = new Label();
                    newLabel.AutoSize = false;
                    newLabel.Name = "lbl_" + fielName;
                    newLabel.Text = fielName.Replace("_", " ");
                    newLabel.Location = new Point(10, y);
                    newLabel.Font = new Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;


                    var comboBox = new ComboBox();
                    comboBox.AutoSize = false;

                    comboBox.Items.Add("THIS YEAR");
                    comboBox.Items.Add("NEXT YEAR");


                    if (longitud != "")
                    {

                        comboBox.MaxLength = Convert.ToInt32(longitud) + 2;

                        using (Graphics G = comboBox.CreateGraphics())
                        {
                            comboBox.Width = (int)(comboBox.MaxLength *
                                                      G.MeasureString("x", comboBox.Font).Width);
                        }
                    }

                    comboBox.Name = "fiscalyr_" + fielName;
                    comboBox.Location = new Point(10, y);

                    
                    // Add items to panel, then add panel to form
                    selectOptionsPanel.Controls.Add(newLabel);
                    selectOptionsPanel2.Controls.Add(comboBox);
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
        
        private void openList(object sender, EventArgs e)
        {
                
                frmCompanylist.setData(list);
                frmCompanylist.Show();
          
        }
 
        
        private void Button_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor; // change cursor to hourglass type

            exe = true;

            
           

            DbQuerySage.mre.Set();            
            DbQuerySage.kill = false;

            this.Close();
        }
        
        private void closeTask()
        {
            Cursor = Cursors.Default; // change cursor to hourglass type


            if (exe != true)
            {
               
                DbQuerySage.mre.Set();
                DbQuerySage.kill = true;
              
                this.Close();
            }

        }

        private void closeTask(object sender, FormClosedEventArgs e)
        {
            closeTask();
        }

      
    }

}
