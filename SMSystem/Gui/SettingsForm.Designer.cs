
namespace SMSystem.Gui
{
    partial class SettingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabelImportLogo = new System.Windows.Forms.LinkLabel();
            this.pictureBoxCompanyLogo = new System.Windows.Forms.PictureBox();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.buttonSaveGeneralSettings = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCompanyDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCompanyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.buttonBackUp = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonNetworkConnect = new System.Windows.Forms.RadioButton();
            this.buttonSaveServerSettings = new System.Windows.Forms.Button();
            this.radioButtonLocalConnect = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxDataBase = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownDamageDuration = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompanyLogo)).BeginInit();
            this.groupBoxServer.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDamageDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownDamageDuration);
            this.groupBox1.Controls.Add(this.linkLabelImportLogo);
            this.groupBox1.Controls.Add(this.pictureBoxCompanyLogo);
            this.groupBox1.Controls.Add(this.comboBoxCurrency);
            this.groupBox1.Controls.Add(this.buttonSaveGeneralSettings);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxCompanyDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxCompanyName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(615, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 705);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اعدادات عامة";
            // 
            // linkLabelImportLogo
            // 
            this.linkLabelImportLogo.AutoSize = true;
            this.linkLabelImportLogo.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelImportLogo.Location = new System.Drawing.Point(126, 453);
            this.linkLabelImportLogo.Name = "linkLabelImportLogo";
            this.linkLabelImportLogo.Size = new System.Drawing.Size(58, 32);
            this.linkLabelImportLogo.TabIndex = 5;
            this.linkLabelImportLogo.TabStop = true;
            this.linkLabelImportLogo.Text = "تحميل";
            this.linkLabelImportLogo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelImportLogo_LinkClicked);
            // 
            // pictureBoxCompanyLogo
            // 
            this.pictureBoxCompanyLogo.Image = global::SMSystem.Properties.Resources._2022_09_08_1237341;
            this.pictureBoxCompanyLogo.Location = new System.Drawing.Point(20, 248);
            this.pictureBoxCompanyLogo.Name = "pictureBoxCompanyLogo";
            this.pictureBoxCompanyLogo.Size = new System.Drawing.Size(267, 202);
            this.pictureBoxCompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCompanyLogo.TabIndex = 4;
            this.pictureBoxCompanyLogo.TabStop = false;
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Items.AddRange(new object[] {
            "(د.ع)",
            "($)"});
            this.comboBoxCurrency.Location = new System.Drawing.Point(20, 498);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(340, 45);
            this.comboBoxCurrency.TabIndex = 3;
            // 
            // buttonSaveGeneralSettings
            // 
            this.buttonSaveGeneralSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonSaveGeneralSettings.Location = new System.Drawing.Point(20, 649);
            this.buttonSaveGeneralSettings.Name = "buttonSaveGeneralSettings";
            this.buttonSaveGeneralSettings.Size = new System.Drawing.Size(340, 50);
            this.buttonSaveGeneralSettings.TabIndex = 2;
            this.buttonSaveGeneralSettings.Text = "حفظ الاعدادات";
            this.buttonSaveGeneralSettings.UseVisualStyleBackColor = true;
            this.buttonSaveGeneralSettings.Click += new System.EventHandler(this.buttonSaveGeneralSettings_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(289, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "العملة";
            // 
            // textBoxCompanyDescription
            // 
            this.textBoxCompanyDescription.Location = new System.Drawing.Point(20, 171);
            this.textBoxCompanyDescription.Multiline = true;
            this.textBoxCompanyDescription.Name = "textBoxCompanyDescription";
            this.textBoxCompanyDescription.Size = new System.Drawing.Size(340, 68);
            this.textBoxCompanyDescription.TabIndex = 1;
            this.textBoxCompanyDescription.Text = "وصف معين للشركة";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(293, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 37);
            this.label4.TabIndex = 0;
            this.label4.Text = "الشعار";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(285, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "الوصف";
            // 
            // textBoxCompanyName
            // 
            this.textBoxCompanyName.Location = new System.Drawing.Point(20, 79);
            this.textBoxCompanyName.Name = "textBoxCompanyName";
            this.textBoxCompanyName.Size = new System.Drawing.Size(340, 45);
            this.textBoxCompanyName.TabIndex = 1;
            this.textBoxCompanyName.Text = "اكتب اسم الشركة";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(148, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم الشركة / المؤسسة";
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Controls.Add(this.buttonRestore);
            this.groupBoxServer.Controls.Add(this.buttonBackUp);
            this.groupBoxServer.Controls.Add(this.groupBox3);
            this.groupBoxServer.ForeColor = System.Drawing.Color.Coral;
            this.groupBoxServer.Location = new System.Drawing.Point(12, 12);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(597, 705);
            this.groupBoxServer.TabIndex = 0;
            this.groupBoxServer.TabStop = false;
            // 
            // buttonRestore
            // 
            this.buttonRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonRestore.FlatAppearance.BorderSize = 0;
            this.buttonRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestore.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRestore.ForeColor = System.Drawing.Color.White;
            this.buttonRestore.Image = global::SMSystem.Properties.Resources.icons8_database_restore_80px_1;
            this.buttonRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRestore.Location = new System.Drawing.Point(21, 549);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(277, 125);
            this.buttonRestore.TabIndex = 2;
            this.buttonRestore.Text = "          استعادة النسخة";
            this.buttonRestore.UseVisualStyleBackColor = false;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // buttonBackUp
            // 
            this.buttonBackUp.BackColor = System.Drawing.Color.Teal;
            this.buttonBackUp.FlatAppearance.BorderSize = 0;
            this.buttonBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackUp.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBackUp.ForeColor = System.Drawing.Color.White;
            this.buttonBackUp.Image = global::SMSystem.Properties.Resources.icons8_data_backup_80px;
            this.buttonBackUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBackUp.Location = new System.Drawing.Point(318, 549);
            this.buttonBackUp.Name = "buttonBackUp";
            this.buttonBackUp.Size = new System.Drawing.Size(273, 125);
            this.buttonBackUp.TabIndex = 2;
            this.buttonBackUp.Text = "             اخذ نسخة احتياطية";
            this.buttonBackUp.UseVisualStyleBackColor = false;
            this.buttonBackUp.Click += new System.EventHandler(this.buttonBackUp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonNetworkConnect);
            this.groupBox3.Controls.Add(this.buttonSaveServerSettings);
            this.groupBox3.Controls.Add(this.radioButtonLocalConnect);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(6, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(585, 450);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "اعدادات السيرفر";
            // 
            // radioButtonNetworkConnect
            // 
            this.radioButtonNetworkConnect.AutoSize = true;
            this.radioButtonNetworkConnect.ForeColor = System.Drawing.Color.Black;
            this.radioButtonNetworkConnect.Location = new System.Drawing.Point(473, 121);
            this.radioButtonNetworkConnect.Name = "radioButtonNetworkConnect";
            this.radioButtonNetworkConnect.Size = new System.Drawing.Size(93, 41);
            this.radioButtonNetworkConnect.TabIndex = 1;
            this.radioButtonNetworkConnect.Text = "شبكي";
            this.radioButtonNetworkConnect.UseVisualStyleBackColor = true;
            this.radioButtonNetworkConnect.CheckedChanged += new System.EventHandler(this.radioButtonNetworkConnect_CheckedChanged);
            // 
            // buttonSaveServerSettings
            // 
            this.buttonSaveServerSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSaveServerSettings.FlatAppearance.BorderSize = 0;
            this.buttonSaveServerSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveServerSettings.ForeColor = System.Drawing.Color.White;
            this.buttonSaveServerSettings.Location = new System.Drawing.Point(45, 385);
            this.buttonSaveServerSettings.Name = "buttonSaveServerSettings";
            this.buttonSaveServerSettings.Size = new System.Drawing.Size(340, 50);
            this.buttonSaveServerSettings.TabIndex = 2;
            this.buttonSaveServerSettings.Text = "حفظ الاعدادات";
            this.buttonSaveServerSettings.UseVisualStyleBackColor = false;
            this.buttonSaveServerSettings.Click += new System.EventHandler(this.buttonSaveServerSettings_Click);
            // 
            // radioButtonLocalConnect
            // 
            this.radioButtonLocalConnect.AutoSize = true;
            this.radioButtonLocalConnect.Checked = true;
            this.radioButtonLocalConnect.ForeColor = System.Drawing.Color.Black;
            this.radioButtonLocalConnect.Location = new System.Drawing.Point(478, 61);
            this.radioButtonLocalConnect.Name = "radioButtonLocalConnect";
            this.radioButtonLocalConnect.Size = new System.Drawing.Size(88, 41);
            this.radioButtonLocalConnect.TabIndex = 1;
            this.radioButtonLocalConnect.TabStop = true;
            this.radioButtonLocalConnect.Text = "محلي";
            this.radioButtonLocalConnect.UseVisualStyleBackColor = true;
            this.radioButtonLocalConnect.CheckedChanged += new System.EventHandler(this.radioButtonLocalConnect_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxPassword);
            this.panel1.Controls.Add(this.textBoxUser);
            this.panel1.Controls.Add(this.textBoxPort);
            this.panel1.Controls.Add(this.textBoxDataBase);
            this.panel1.Controls.Add(this.textBoxServer);
            this.panel1.Location = new System.Drawing.Point(7, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 317);
            this.panel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(307, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 37);
            this.label9.TabIndex = 0;
            this.label9.Text = "كلمة السر";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(269, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 37);
            this.label7.TabIndex = 0;
            this.label7.Text = "اسم المستخدم";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(336, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 37);
            this.label6.TabIndex = 0;
            this.label6.Text = "المنفذ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(280, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 37);
            this.label5.TabIndex = 0;
            this.label5.Text = "قاعدة البيانات";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(328, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 37);
            this.label8.TabIndex = 0;
            this.label8.Text = "السيرفر";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Enabled = false;
            this.textBoxPassword.Location = new System.Drawing.Point(14, 259);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxPassword.Size = new System.Drawing.Size(251, 45);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.Text = "12345";
            this.textBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Enabled = false;
            this.textBoxUser.Location = new System.Drawing.Point(14, 198);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.PasswordChar = '*';
            this.textBoxUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxUser.Size = new System.Drawing.Size(251, 45);
            this.textBoxUser.TabIndex = 1;
            this.textBoxUser.Text = "sa";
            this.textBoxUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Enabled = false;
            this.textBoxPort.Location = new System.Drawing.Point(14, 137);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxPort.Size = new System.Drawing.Size(251, 45);
            this.textBoxPort.TabIndex = 1;
            this.textBoxPort.Text = "1433";
            this.textBoxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxDataBase
            // 
            this.textBoxDataBase.Location = new System.Drawing.Point(14, 76);
            this.textBoxDataBase.Name = "textBoxDataBase";
            this.textBoxDataBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxDataBase.Size = new System.Drawing.Size(251, 45);
            this.textBoxDataBase.TabIndex = 1;
            this.textBoxDataBase.Text = "DBSMSystem";
            this.textBoxDataBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(14, 15);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxServer.Size = new System.Drawing.Size(251, 45);
            this.textBoxServer.TabIndex = 1;
            this.textBoxServer.Text = ".\\SQLEXPRESS";
            this.textBoxServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(51, 558);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(311, 37);
            this.label10.TabIndex = 0;
            this.label10.Text = "التذكير للمواد التي سوف تتلف (يوم)";
            // 
            // numericUpDownDamageDuration
            // 
            this.numericUpDownDamageDuration.Location = new System.Drawing.Point(32, 598);
            this.numericUpDownDamageDuration.Name = "numericUpDownDamageDuration";
            this.numericUpDownDamageDuration.Size = new System.Drawing.Size(328, 45);
            this.numericUpDownDamageDuration.TabIndex = 6;
            this.numericUpDownDamageDuration.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 729);
            this.Controls.Add(this.groupBoxServer);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الاعدادات";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompanyLogo)).EndInit();
            this.groupBoxServer.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDamageDuration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.Button buttonSaveGeneralSettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCompanyDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxCompanyLogo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabelImportLogo;
        private System.Windows.Forms.GroupBox groupBoxServer;
        private System.Windows.Forms.Button buttonSaveServerSettings;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxDataBase;
        private System.Windows.Forms.RadioButton radioButtonNetworkConnect;
        private System.Windows.Forms.RadioButton radioButtonLocalConnect;
        private System.Windows.Forms.Button buttonBackUp;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.NumericUpDown numericUpDownDamageDuration;
        private System.Windows.Forms.Label label10;
    }
}