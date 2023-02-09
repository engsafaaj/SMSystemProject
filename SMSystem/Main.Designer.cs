
namespace SMSystem
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.flowLayoutPanelNavBar = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonhome = new System.Windows.Forms.Button();
            this.buttonStore = new System.Windows.Forms.Button();
            this.buttonMaterails = new System.Windows.Forms.Button();
            this.buttonIncome = new System.Windows.Forms.Button();
            this.buttonOutCome = new System.Windows.Forms.Button();
            this.buttonDamage = new System.Windows.Forms.Button();
            this.buttonSuppliers = new System.Windows.Forms.Button();
            this.buttonCustomers = new System.Windows.Forms.Button();
            this.buttonAnalysis = new System.Windows.Forms.Button();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.buttonOutOfConscneine = new System.Windows.Forms.Button();
            this.flowLayoutPanelNavBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelNavBar
            // 
            this.flowLayoutPanelNavBar.AutoScroll = true;
            this.flowLayoutPanelNavBar.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonhome);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonStore);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonMaterails);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonIncome);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonOutCome);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonDamage);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonOutOfConscneine);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonSuppliers);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonCustomers);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonAnalysis);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonUsers);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonHelp);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonAbout);
            this.flowLayoutPanelNavBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelNavBar.Location = new System.Drawing.Point(0, 598);
            this.flowLayoutPanelNavBar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.flowLayoutPanelNavBar.Name = "flowLayoutPanelNavBar";
            this.flowLayoutPanelNavBar.Size = new System.Drawing.Size(1062, 75);
            this.flowLayoutPanelNavBar.TabIndex = 0;
            // 
            // buttonhome
            // 
            this.buttonhome.Image = global::SMSystem.Properties.Resources.home_32px;
            this.buttonhome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonhome.Location = new System.Drawing.Point(897, 6);
            this.buttonhome.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonhome.Name = "buttonhome";
            this.buttonhome.Size = new System.Drawing.Size(140, 60);
            this.buttonhome.TabIndex = 0;
            this.buttonhome.Text = "الرئيسة";
            this.buttonhome.UseVisualStyleBackColor = true;
            this.buttonhome.Click += new System.EventHandler(this.buttonhome_Click);
            // 
            // buttonStore
            // 
            this.buttonStore.Image = global::SMSystem.Properties.Resources.department_store_32px;
            this.buttonStore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStore.Location = new System.Drawing.Point(749, 6);
            this.buttonStore.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonStore.Name = "buttonStore";
            this.buttonStore.Size = new System.Drawing.Size(140, 60);
            this.buttonStore.TabIndex = 1;
            this.buttonStore.Text = "المخازن";
            this.buttonStore.UseVisualStyleBackColor = true;
            this.buttonStore.Click += new System.EventHandler(this.buttonStore_Click);
            // 
            // buttonMaterails
            // 
            this.buttonMaterails.Image = global::SMSystem.Properties.Resources.open_box_32px;
            this.buttonMaterails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMaterails.Location = new System.Drawing.Point(601, 6);
            this.buttonMaterails.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonMaterails.Name = "buttonMaterails";
            this.buttonMaterails.Size = new System.Drawing.Size(140, 60);
            this.buttonMaterails.TabIndex = 2;
            this.buttonMaterails.Text = "  المواد";
            this.buttonMaterails.UseVisualStyleBackColor = true;
            this.buttonMaterails.Click += new System.EventHandler(this.buttonMaterails_Click);
            // 
            // buttonIncome
            // 
            this.buttonIncome.Image = global::SMSystem.Properties.Resources.icons8_internal_32px_1;
            this.buttonIncome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIncome.Location = new System.Drawing.Point(453, 6);
            this.buttonIncome.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonIncome.Name = "buttonIncome";
            this.buttonIncome.Size = new System.Drawing.Size(140, 60);
            this.buttonIncome.TabIndex = 9;
            this.buttonIncome.Text = "  المدخلات";
            this.buttonIncome.UseVisualStyleBackColor = true;
            this.buttonIncome.Click += new System.EventHandler(this.buttonIncome_Click);
            // 
            // buttonOutCome
            // 
            this.buttonOutCome.Image = global::SMSystem.Properties.Resources.icons8_external_32px;
            this.buttonOutCome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOutCome.Location = new System.Drawing.Point(305, 6);
            this.buttonOutCome.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonOutCome.Name = "buttonOutCome";
            this.buttonOutCome.Size = new System.Drawing.Size(140, 60);
            this.buttonOutCome.TabIndex = 10;
            this.buttonOutCome.Text = "  المخرجات";
            this.buttonOutCome.UseVisualStyleBackColor = true;
            this.buttonOutCome.Click += new System.EventHandler(this.buttonOutCome_Click);
            // 
            // buttonDamage
            // 
            this.buttonDamage.Image = global::SMSystem.Properties.Resources.icons8_damaged_parcel_32px_1;
            this.buttonDamage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDamage.Location = new System.Drawing.Point(157, 6);
            this.buttonDamage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonDamage.Name = "buttonDamage";
            this.buttonDamage.Size = new System.Drawing.Size(140, 60);
            this.buttonDamage.TabIndex = 11;
            this.buttonDamage.Text = "  التالف";
            this.buttonDamage.UseVisualStyleBackColor = true;
            this.buttonDamage.Click += new System.EventHandler(this.buttonDamage_Click);
            // 
            // buttonSuppliers
            // 
            this.buttonSuppliers.Image = global::SMSystem.Properties.Resources.supplier_32px;
            this.buttonSuppliers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSuppliers.Location = new System.Drawing.Point(897, 78);
            this.buttonSuppliers.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSuppliers.Name = "buttonSuppliers";
            this.buttonSuppliers.Size = new System.Drawing.Size(140, 60);
            this.buttonSuppliers.TabIndex = 3;
            this.buttonSuppliers.Text = "  الموردين";
            this.buttonSuppliers.UseVisualStyleBackColor = true;
            this.buttonSuppliers.Click += new System.EventHandler(this.buttonSuppliers_Click);
            // 
            // buttonCustomers
            // 
            this.buttonCustomers.Image = global::SMSystem.Properties.Resources.users_32px;
            this.buttonCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCustomers.Location = new System.Drawing.Point(749, 78);
            this.buttonCustomers.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonCustomers.Name = "buttonCustomers";
            this.buttonCustomers.Size = new System.Drawing.Size(140, 60);
            this.buttonCustomers.TabIndex = 7;
            this.buttonCustomers.Text = "  العملاء";
            this.buttonCustomers.UseVisualStyleBackColor = true;
            this.buttonCustomers.Click += new System.EventHandler(this.buttonCustomers_Click);
            // 
            // buttonAnalysis
            // 
            this.buttonAnalysis.Image = global::SMSystem.Properties.Resources.chart_32px;
            this.buttonAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAnalysis.Location = new System.Drawing.Point(601, 78);
            this.buttonAnalysis.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAnalysis.Name = "buttonAnalysis";
            this.buttonAnalysis.Size = new System.Drawing.Size(140, 60);
            this.buttonAnalysis.TabIndex = 4;
            this.buttonAnalysis.Text = "التحليل";
            this.buttonAnalysis.UseVisualStyleBackColor = true;
            this.buttonAnalysis.Click += new System.EventHandler(this.buttonAnalysis_Click);
            // 
            // buttonUsers
            // 
            this.buttonUsers.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUsers.Image = global::SMSystem.Properties.Resources.icons8_select_users_32px;
            this.buttonUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUsers.Location = new System.Drawing.Point(453, 78);
            this.buttonUsers.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(140, 60);
            this.buttonUsers.TabIndex = 12;
            this.buttonUsers.Text = "المستخدمين";
            this.buttonUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Image = global::SMSystem.Properties.Resources.settings_32px;
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(305, 78);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(140, 60);
            this.buttonHelp.TabIndex = 5;
            this.buttonHelp.Text = "  الاعدادات";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Image = global::SMSystem.Properties.Resources.about_32px;
            this.buttonAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAbout.Location = new System.Drawing.Point(157, 78);
            this.buttonAbout.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(140, 60);
            this.buttonAbout.TabIndex = 6;
            this.buttonAbout.Text = "حول";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1062, 598);
            this.panelContainer.TabIndex = 1;
            // 
            // buttonOutOfConscneine
            // 
            this.buttonOutOfConscneine.Image = global::SMSystem.Properties.Resources.icons8_export_32px;
            this.buttonOutOfConscneine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOutOfConscneine.Location = new System.Drawing.Point(9, 6);
            this.buttonOutOfConscneine.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonOutOfConscneine.Name = "buttonOutOfConscneine";
            this.buttonOutOfConscneine.Size = new System.Drawing.Size(140, 60);
            this.buttonOutOfConscneine.TabIndex = 13;
            this.buttonOutOfConscneine.Text = "   خارج الذمة";
            this.buttonOutOfConscneine.UseVisualStyleBackColor = true;
            this.buttonOutOfConscneine.Click += new System.EventHandler(this.buttonOutOfConscneine_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.flowLayoutPanelNavBar);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "مخزن";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.flowLayoutPanelNavBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNavBar;
        private System.Windows.Forms.Button buttonhome;
        private System.Windows.Forms.Button buttonStore;
        private System.Windows.Forms.Button buttonMaterails;
        private System.Windows.Forms.Button buttonSuppliers;
        private System.Windows.Forms.Button buttonAnalysis;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonAbout;
        public System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button buttonCustomers;
        private System.Windows.Forms.Button buttonIncome;
        private System.Windows.Forms.Button buttonOutCome;
        private System.Windows.Forms.Button buttonDamage;
        private System.Windows.Forms.Button buttonUsers;
        private System.Windows.Forms.Button buttonOutOfConscneine;
    }
}

