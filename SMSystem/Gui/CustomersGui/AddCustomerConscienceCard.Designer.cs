
namespace SMSystem.Gui.CustomersGui
{
    partial class AddCustomerConscienceCard
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
            this.comboBoxMaterialName = new System.Windows.Forms.ComboBox();
            this.TextBoxInterNo = new System.Windows.Forms.TextBox();
            this.textBoxCurrentQuanttiy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerInterDateTime = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxMoveToAnotherDep = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxReciverName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerRecive = new System.Windows.Forms.DateTimePicker();
            this.textBoxReciverSign = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxMoveToAnotherDep = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxDepName = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBoxTransportReciverName = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePickerTransprotReciverDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxTransportReciverSign = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelNavBar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxMoveToAnotherDep.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelNavBar
            // 
            this.flowLayoutPanelNavBar.AutoScroll = true;
            this.flowLayoutPanelNavBar.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonSave);
            this.flowLayoutPanelNavBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelNavBar.Location = new System.Drawing.Point(0, 501);
            this.flowLayoutPanelNavBar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.flowLayoutPanelNavBar.Name = "flowLayoutPanelNavBar";
            this.flowLayoutPanelNavBar.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelNavBar.Size = new System.Drawing.Size(1091, 75);
            this.flowLayoutPanelNavBar.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Image = global::SMSystem.Properties.Resources.save_32px;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(957, 11);
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
            this.groupBox1.Controls.Add(this.comboBoxMaterialName);
            this.groupBox1.Controls.Add(this.TextBoxInterNo);
            this.groupBox1.Controls.Add(this.textBoxCurrentQuanttiy);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dateTimePickerInterDateTime);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 471);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات المادة ";
            // 
            // comboBoxMaterialName
            // 
            this.comboBoxMaterialName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMaterialName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxMaterialName.FormattingEnabled = true;
            this.comboBoxMaterialName.Location = new System.Drawing.Point(18, 81);
            this.comboBoxMaterialName.Name = "comboBoxMaterialName";
            this.comboBoxMaterialName.Size = new System.Drawing.Size(321, 45);
            this.comboBoxMaterialName.TabIndex = 7;
            this.comboBoxMaterialName.Text = "اختر او اكتب اسم المادة";
            // 
            // TextBoxInterNo
            // 
            this.TextBoxInterNo.Location = new System.Drawing.Point(18, 276);
            this.TextBoxInterNo.Name = "TextBoxInterNo";
            this.TextBoxInterNo.Size = new System.Drawing.Size(321, 45);
            this.TextBoxInterNo.TabIndex = 4;
            this.TextBoxInterNo.Text = "0";
            this.TextBoxInterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxInterNo.TextChanged += new System.EventHandler(this.TextBoxInterNo_TextChanged_2);
            // 
            // textBoxCurrentQuanttiy
            // 
            this.textBoxCurrentQuanttiy.Location = new System.Drawing.Point(18, 180);
            this.textBoxCurrentQuanttiy.Name = "textBoxCurrentQuanttiy";
            this.textBoxCurrentQuanttiy.Size = new System.Drawing.Size(321, 45);
            this.textBoxCurrentQuanttiy.TabIndex = 4;
            this.textBoxCurrentQuanttiy.Text = "0";
            this.textBoxCurrentQuanttiy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCurrentQuanttiy.TextChanged += new System.EventHandler(this.textBoxCurrentQuanttiy_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(165, 343);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 37);
            this.label10.TabIndex = 2;
            this.label10.Text = "تاريخ مستند الادخال:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerInterDateTime
            // 
            this.dateTimePickerInterDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInterDateTime.Location = new System.Drawing.Point(18, 383);
            this.dateTimePickerInterDateTime.Name = "dateTimePickerInterDateTime";
            this.dateTimePickerInterDateTime.Size = new System.Drawing.Size(321, 45);
            this.dateTimePickerInterDateTime.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(165, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 37);
            this.label9.TabIndex = 2;
            this.label9.Text = "رقم مستند الادخال:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(282, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 37);
            this.label5.TabIndex = 2;
            this.label5.Text = "الاسم:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(270, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 37);
            this.label7.TabIndex = 2;
            this.label7.Text = "الكمية:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxMoveToAnotherDep);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBoxReciverName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dateTimePickerRecive);
            this.groupBox2.Controls.Add(this.textBoxReciverSign);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(404, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 477);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "معلومات المستلم";
            // 
            // checkBoxMoveToAnotherDep
            // 
            this.checkBoxMoveToAnotherDep.AutoSize = true;
            this.checkBoxMoveToAnotherDep.Location = new System.Drawing.Point(65, 394);
            this.checkBoxMoveToAnotherDep.Name = "checkBoxMoveToAnotherDep";
            this.checkBoxMoveToAnotherDep.Size = new System.Drawing.Size(195, 41);
            this.checkBoxMoveToAnotherDep.TabIndex = 10;
            this.checkBoxMoveToAnotherDep.Text = "نقل الى وحدة اخرى";
            this.checkBoxMoveToAnotherDep.UseVisualStyleBackColor = true;
            this.checkBoxMoveToAnotherDep.CheckedChanged += new System.EventHandler(this.checkBoxMoveToAnotherDep_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(179, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "تاريخ الاستلام";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(222, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "التوقيع";
            // 
            // comboBoxReciverName
            // 
            this.comboBoxReciverName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxReciverName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxReciverName.FormattingEnabled = true;
            this.comboBoxReciverName.Location = new System.Drawing.Point(16, 81);
            this.comboBoxReciverName.Name = "comboBoxReciverName";
            this.comboBoxReciverName.Size = new System.Drawing.Size(285, 45);
            this.comboBoxReciverName.TabIndex = 7;
            this.comboBoxReciverName.Text = "اختر او اكتب اسم المستلم";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(234, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "الاسم:";
            // 
            // dateTimePickerRecive
            // 
            this.dateTimePickerRecive.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerRecive.Location = new System.Drawing.Point(16, 180);
            this.dateTimePickerRecive.Name = "dateTimePickerRecive";
            this.dateTimePickerRecive.Size = new System.Drawing.Size(285, 45);
            this.dateTimePickerRecive.TabIndex = 9;
            // 
            // textBoxReciverSign
            // 
            this.textBoxReciverSign.Location = new System.Drawing.Point(16, 276);
            this.textBoxReciverSign.Name = "textBoxReciverSign";
            this.textBoxReciverSign.Size = new System.Drawing.Size(285, 45);
            this.textBoxReciverSign.TabIndex = 4;
            this.textBoxReciverSign.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(191, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 37);
            this.label8.TabIndex = 6;
            this.label8.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(158, 132);
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
            this.label4.Location = new System.Drawing.Point(203, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 37);
            this.label4.TabIndex = 6;
            this.label4.Text = "*";
            // 
            // groupBoxMoveToAnotherDep
            // 
            this.groupBoxMoveToAnotherDep.Controls.Add(this.label11);
            this.groupBoxMoveToAnotherDep.Controls.Add(this.label12);
            this.groupBoxMoveToAnotherDep.Controls.Add(this.comboBoxDepName);
            this.groupBoxMoveToAnotherDep.Controls.Add(this.label18);
            this.groupBoxMoveToAnotherDep.Controls.Add(this.comboBoxTransportReciverName);
            this.groupBoxMoveToAnotherDep.Controls.Add(this.label13);
            this.groupBoxMoveToAnotherDep.Controls.Add(this.dateTimePickerTransprotReciverDate);
            this.groupBoxMoveToAnotherDep.Controls.Add(this.textBoxTransportReciverSign);
            this.groupBoxMoveToAnotherDep.Enabled = false;
            this.groupBoxMoveToAnotherDep.ForeColor = System.Drawing.Color.Blue;
            this.groupBoxMoveToAnotherDep.Location = new System.Drawing.Point(742, 6);
            this.groupBoxMoveToAnotherDep.Name = "groupBoxMoveToAnotherDep";
            this.groupBoxMoveToAnotherDep.Size = new System.Drawing.Size(321, 477);
            this.groupBoxMoveToAnotherDep.TabIndex = 3;
            this.groupBoxMoveToAnotherDep.TabStop = false;
            this.groupBoxMoveToAnotherDep.Text = "معلومات المستلم";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(175, 245);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 37);
            this.label11.TabIndex = 2;
            this.label11.Text = "تاريخ الاستلام";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(218, 341);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 37);
            this.label12.TabIndex = 2;
            this.label12.Text = "التوقيع";
            // 
            // comboBoxDepName
            // 
            this.comboBoxDepName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxDepName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxDepName.FormattingEnabled = true;
            this.comboBoxDepName.Location = new System.Drawing.Point(12, 87);
            this.comboBoxDepName.Name = "comboBoxDepName";
            this.comboBoxDepName.Size = new System.Drawing.Size(285, 45);
            this.comboBoxDepName.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(183, 47);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 37);
            this.label18.TabIndex = 2;
            this.label18.Text = "اسم الوحدة:";
            // 
            // comboBoxTransportReciverName
            // 
            this.comboBoxTransportReciverName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTransportReciverName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxTransportReciverName.FormattingEnabled = true;
            this.comboBoxTransportReciverName.Location = new System.Drawing.Point(12, 186);
            this.comboBoxTransportReciverName.Name = "comboBoxTransportReciverName";
            this.comboBoxTransportReciverName.Size = new System.Drawing.Size(285, 45);
            this.comboBoxTransportReciverName.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(230, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 37);
            this.label13.TabIndex = 2;
            this.label13.Text = "الاسم:";
            // 
            // dateTimePickerTransprotReciverDate
            // 
            this.dateTimePickerTransprotReciverDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTransprotReciverDate.Location = new System.Drawing.Point(12, 285);
            this.dateTimePickerTransprotReciverDate.Name = "dateTimePickerTransprotReciverDate";
            this.dateTimePickerTransprotReciverDate.Size = new System.Drawing.Size(285, 45);
            this.dateTimePickerTransprotReciverDate.TabIndex = 9;
            // 
            // textBoxTransportReciverSign
            // 
            this.textBoxTransportReciverSign.Location = new System.Drawing.Point(12, 381);
            this.textBoxTransportReciverSign.Name = "textBoxTransportReciverSign";
            this.textBoxTransportReciverSign.Size = new System.Drawing.Size(285, 45);
            this.textBoxTransportReciverSign.TabIndex = 4;
            this.textBoxTransportReciverSign.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AddCustomerConscienceCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 576);
            this.Controls.Add(this.groupBoxMoveToAnotherDep);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanelNavBar);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCustomerConscienceCard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ادخال مادة ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddCustomerConscienceCard_Load);
            this.flowLayoutPanelNavBar.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxMoveToAnotherDep.ResumeLayout(false);
            this.groupBoxMoveToAnotherDep.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNavBar;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox comboBoxMaterialName;
        public System.Windows.Forms.TextBox textBoxCurrentQuanttiy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBoxReciverName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dateTimePickerRecive;
        private System.Windows.Forms.TextBox textBoxReciverSign;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TextBoxInterNo;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.DateTimePicker dateTimePickerInterDateTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxMoveToAnotherDep;
        private System.Windows.Forms.GroupBox groupBoxMoveToAnotherDep;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox comboBoxDepName;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.ComboBox comboBoxTransportReciverName;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.DateTimePicker dateTimePickerTransprotReciverDate;
        private System.Windows.Forms.TextBox textBoxTransportReciverSign;
    }
}