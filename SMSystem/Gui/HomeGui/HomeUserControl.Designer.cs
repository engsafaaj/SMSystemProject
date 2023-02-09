
namespace SMSystem.Gui.Home
{
    partial class HomeUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonAddMaterial = new System.Windows.Forms.Button();
            this.buttonAddIncome = new System.Windows.Forms.Button();
            this.buttonAddOutCome = new System.Windows.Forms.Button();
            this.labelWellcom = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxCompanyLogo = new System.Windows.Forms.PictureBox();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.FlowLayoutPanelNotification = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompanyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddMaterial
            // 
            this.buttonAddMaterial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddMaterial.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddMaterial.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddMaterial.Image = global::SMSystem.Properties.Resources.icons8_box_96px_1;
            this.buttonAddMaterial.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddMaterial.Location = new System.Drawing.Point(669, 232);
            this.buttonAddMaterial.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAddMaterial.Name = "buttonAddMaterial";
            this.buttonAddMaterial.Size = new System.Drawing.Size(268, 142);
            this.buttonAddMaterial.TabIndex = 5;
            this.buttonAddMaterial.Text = "اضافة مادة";
            this.buttonAddMaterial.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddMaterial.UseVisualStyleBackColor = true;
            this.buttonAddMaterial.Click += new System.EventHandler(this.buttonAddMaterial_Click);
            // 
            // buttonAddIncome
            // 
            this.buttonAddIncome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddIncome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddIncome.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddIncome.Image = global::SMSystem.Properties.Resources.icons8_internal_96px_1;
            this.buttonAddIncome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddIncome.Location = new System.Drawing.Point(393, 232);
            this.buttonAddIncome.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAddIncome.Name = "buttonAddIncome";
            this.buttonAddIncome.Size = new System.Drawing.Size(268, 142);
            this.buttonAddIncome.TabIndex = 6;
            this.buttonAddIncome.Text = "ادخال مادة";
            this.buttonAddIncome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddIncome.UseVisualStyleBackColor = true;
            this.buttonAddIncome.Click += new System.EventHandler(this.buttonAddIncome_Click);
            // 
            // buttonAddOutCome
            // 
            this.buttonAddOutCome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddOutCome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddOutCome.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddOutCome.Image = global::SMSystem.Properties.Resources.icons8_external_80px;
            this.buttonAddOutCome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddOutCome.Location = new System.Drawing.Point(117, 232);
            this.buttonAddOutCome.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAddOutCome.Name = "buttonAddOutCome";
            this.buttonAddOutCome.Size = new System.Drawing.Size(268, 142);
            this.buttonAddOutCome.TabIndex = 7;
            this.buttonAddOutCome.Text = "قائمة اخراج";
            this.buttonAddOutCome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddOutCome.UseVisualStyleBackColor = true;
            this.buttonAddOutCome.Click += new System.EventHandler(this.buttonAddOutCome_Click);
            // 
            // labelWellcom
            // 
            this.labelWellcom.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelWellcom.Location = new System.Drawing.Point(17, 15);
            this.labelWellcom.Name = "labelWellcom";
            this.labelWellcom.Size = new System.Drawing.Size(349, 182);
            this.labelWellcom.TabIndex = 8;
            this.labelWellcom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDate.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelDate.Location = new System.Drawing.Point(3, 506);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(419, 55);
            this.labelDate.TabIndex = 8;
            this.labelDate.Text = "000000000";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTime.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTime.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelTime.Location = new System.Drawing.Point(0, 548);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(355, 44);
            this.labelTime.TabIndex = 8;
            this.labelTime.Text = "000000000";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBoxCompanyLogo);
            this.panel1.Controls.Add(this.labelCompanyName);
            this.panel1.Location = new System.Drawing.Point(574, 470);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 125);
            this.panel1.TabIndex = 9;
            // 
            // pictureBoxCompanyLogo
            // 
            this.pictureBoxCompanyLogo.Image = global::SMSystem.Properties.Resources._2022_09_08_1237341;
            this.pictureBoxCompanyLogo.Location = new System.Drawing.Point(335, 3);
            this.pictureBoxCompanyLogo.Name = "pictureBoxCompanyLogo";
            this.pictureBoxCompanyLogo.Size = new System.Drawing.Size(147, 119);
            this.pictureBoxCompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCompanyLogo.TabIndex = 0;
            this.pictureBoxCompanyLogo.TabStop = false;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCompanyName.Location = new System.Drawing.Point(3, 27);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(326, 95);
            this.labelCompanyName.TabIndex = 8;
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FlowLayoutPanelNotification
            // 
            this.FlowLayoutPanelNotification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlowLayoutPanelNotification.AutoScroll = true;
            this.FlowLayoutPanelNotification.BackColor = System.Drawing.Color.White;
            this.FlowLayoutPanelNotification.Location = new System.Drawing.Point(385, 15);
            this.FlowLayoutPanelNotification.Name = "FlowLayoutPanelNotification";
            this.FlowLayoutPanelNotification.Padding = new System.Windows.Forms.Padding(10);
            this.FlowLayoutPanelNotification.Size = new System.Drawing.Size(671, 208);
            this.FlowLayoutPanelNotification.TabIndex = 10;
            // 
            // HomeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.FlowLayoutPanelNotification);
            this.Controls.Add(this.labelWellcom);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.buttonAddMaterial);
            this.Controls.Add(this.buttonAddIncome);
            this.Controls.Add(this.buttonAddOutCome);
            this.Name = "HomeUserControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1062, 598);
            this.Load += new System.EventHandler(this.HomeUserControl_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompanyLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonAddMaterial;
        private System.Windows.Forms.Button buttonAddIncome;
        private System.Windows.Forms.Button buttonAddOutCome;
        private System.Windows.Forms.Label labelWellcom;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxCompanyLogo;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelNotification;
    }
}
