
namespace SMSystem.Gui.MaterailsGui
{
    partial class MaterailsAddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanelNavBar = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabelCodeGenerator = new System.Windows.Forms.LinkLabel();
            this.linkLabelAddStore = new System.Windows.Forms.LinkLabel();
            this.comboBoxStore = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxUnit = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxIncome = new System.Windows.Forms.TextBox();
            this.textBoxOutCome = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.flowLayoutPanelNavBar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelNavBar
            // 
            this.flowLayoutPanelNavBar.AutoScroll = true;
            this.flowLayoutPanelNavBar.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonSave);
            this.flowLayoutPanelNavBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelNavBar.Location = new System.Drawing.Point(0, 553);
            this.flowLayoutPanelNavBar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.flowLayoutPanelNavBar.Name = "flowLayoutPanelNavBar";
            this.flowLayoutPanelNavBar.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelNavBar.Size = new System.Drawing.Size(1118, 75);
            this.flowLayoutPanelNavBar.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Image = global::SMSystem.Properties.Resources.save_32px;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(984, 11);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 54);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "  حفظ";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabelCodeGenerator);
            this.groupBox1.Controls.Add(this.linkLabelAddStore);
            this.groupBox1.Controls.Add(this.comboBoxStore);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDescription);
            this.groupBox1.Controls.Add(this.textBoxFullName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 514);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات المادة";
            // 
            // linkLabelCodeGenerator
            // 
            this.linkLabelCodeGenerator.AutoSize = true;
            this.linkLabelCodeGenerator.Location = new System.Drawing.Point(6, 129);
            this.linkLabelCodeGenerator.Name = "linkLabelCodeGenerator";
            this.linkLabelCodeGenerator.Size = new System.Drawing.Size(59, 37);
            this.linkLabelCodeGenerator.TabIndex = 8;
            this.linkLabelCodeGenerator.TabStop = true;
            this.linkLabelCodeGenerator.Text = "توليد";
            this.linkLabelCodeGenerator.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCodeGenerator_LinkClicked);
            // 
            // linkLabelAddStore
            // 
            this.linkLabelAddStore.AutoSize = true;
            this.linkLabelAddStore.Location = new System.Drawing.Point(6, 56);
            this.linkLabelAddStore.Name = "linkLabelAddStore";
            this.linkLabelAddStore.Size = new System.Drawing.Size(67, 37);
            this.linkLabelAddStore.TabIndex = 8;
            this.linkLabelAddStore.TabStop = true;
            this.linkLabelAddStore.Text = "اضافة";
            this.linkLabelAddStore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddStore_LinkClicked);
            // 
            // comboBoxStore
            // 
            this.comboBoxStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStore.FormattingEnabled = true;
            this.comboBoxStore.Location = new System.Drawing.Point(84, 56);
            this.comboBoxStore.Name = "comboBoxStore";
            this.comboBoxStore.Size = new System.Drawing.Size(320, 45);
            this.comboBoxStore.TabIndex = 7;
            this.comboBoxStore.SelectedIndexChanged += new System.EventHandler(this.comboBoxStore_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(424, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 37);
            this.label6.TabIndex = 6;
            this.label6.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(423, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 37);
            this.label4.TabIndex = 6;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(419, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 37);
            this.label3.TabIndex = 6;
            this.label3.Text = "*";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(83, 254);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(321, 241);
            this.textBoxDescription.TabIndex = 4;
            this.textBoxDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(84, 188);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(321, 45);
            this.textBoxFullName.TabIndex = 4;
            this.textBoxFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(438, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 37);
            this.label7.TabIndex = 2;
            this.label7.Text = "الوصف:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(455, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 37);
            this.label5.TabIndex = 2;
            this.label5.Text = "الاسم:";
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(84, 122);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(321, 45);
            this.textBoxCode.TabIndex = 4;
            this.textBoxCode.Text = "1568467461";
            this.textBoxCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(451, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "الكود:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(439, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "المخزن:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxUnit);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBoxTotalPrice);
            this.groupBox2.Controls.Add(this.textBoxPrice);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.textBoxOutCome);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.textBoxIncome);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBoxQuantity);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(567, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 514);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "خصائص المادة الاولية";
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.Location = new System.Drawing.Point(16, 56);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(331, 45);
            this.comboBoxUnit.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(362, 406);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(25, 37);
            this.label19.TabIndex = 6;
            this.label19.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(420, 336);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 37);
            this.label18.TabIndex = 6;
            this.label18.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(419, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 37);
            this.label9.TabIndex = 6;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(419, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 37);
            this.label10.TabIndex = 6;
            this.label10.Text = "*";
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Location = new System.Drawing.Point(16, 406);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.ReadOnly = true;
            this.textBoxTotalPrice.Size = new System.Drawing.Size(332, 45);
            this.textBoxTotalPrice.TabIndex = 4;
            this.textBoxTotalPrice.Text = "0";
            this.textBoxTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(16, 336);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(332, 45);
            this.textBoxPrice.TabIndex = 4;
            this.textBoxPrice.Text = "0";
            this.textBoxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPrice.TextChanged += new System.EventHandler(this.textBoxPrice_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(383, 418);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 37);
            this.label16.TabIndex = 2;
            this.label16.Text = "اجمالي السعر:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(446, 345);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 37);
            this.label15.TabIndex = 2;
            this.label15.Text = "السعر:";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(16, 126);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(332, 45);
            this.textBoxQuantity.TabIndex = 4;
            this.textBoxQuantity.Text = "0";
            this.textBoxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxQuantity.TextChanged += new System.EventHandler(this.textBoxQuantity_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(440, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 37);
            this.label13.TabIndex = 2;
            this.label13.Text = "الكمية";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(439, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 37);
            this.label14.TabIndex = 2;
            this.label14.Text = "الوحدة:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(450, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 37);
            this.label12.TabIndex = 2;
            this.label12.Text = "إدخال:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(454, 272);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 37);
            this.label11.TabIndex = 2;
            this.label11.Text = "إخراج:";
            // 
            // textBoxIncome
            // 
            this.textBoxIncome.Enabled = false;
            this.textBoxIncome.Location = new System.Drawing.Point(16, 196);
            this.textBoxIncome.Name = "textBoxIncome";
            this.textBoxIncome.Size = new System.Drawing.Size(332, 45);
            this.textBoxIncome.TabIndex = 4;
            this.textBoxIncome.Text = "0";
            this.textBoxIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxIncome.TextChanged += new System.EventHandler(this.textBoxIncome_TextChanged);
            // 
            // textBoxOutCome
            // 
            this.textBoxOutCome.Enabled = false;
            this.textBoxOutCome.Location = new System.Drawing.Point(16, 266);
            this.textBoxOutCome.Name = "textBoxOutCome";
            this.textBoxOutCome.Size = new System.Drawing.Size(332, 45);
            this.textBoxOutCome.TabIndex = 4;
            this.textBoxOutCome.Text = "0";
            this.textBoxOutCome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxOutCome.TextChanged += new System.EventHandler(this.textBoxOutCome_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(419, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 37);
            this.label8.TabIndex = 6;
            this.label8.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(419, 266);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 37);
            this.label17.TabIndex = 6;
            this.label17.Text = "*";
            // 
            // MaterailsAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 628);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanelNavBar);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterailsAddForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اضافة مادة";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MaterailsAddForm_Load);
            this.flowLayoutPanelNavBar.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNavBar;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxStore;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxUnit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.LinkLabel linkLabelCodeGenerator;
        private System.Windows.Forms.LinkLabel linkLabelAddStore;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxOutCome;
        private System.Windows.Forms.TextBox textBoxIncome;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}