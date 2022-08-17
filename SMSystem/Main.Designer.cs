
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
            this.buttonCategory = new System.Windows.Forms.Button();
            this.buttonMaterails = new System.Windows.Forms.Button();
            this.buttonAnalysis = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.flowLayoutPanelNavBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelNavBar
            // 
            this.flowLayoutPanelNavBar.AutoScroll = true;
            this.flowLayoutPanelNavBar.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonhome);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonStore);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonCategory);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonMaterails);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonAnalysis);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonHelp);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonAbout);
            this.flowLayoutPanelNavBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelNavBar.Location = new System.Drawing.Point(0, 598);
            this.flowLayoutPanelNavBar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.flowLayoutPanelNavBar.Name = "flowLayoutPanelNavBar";
            this.flowLayoutPanelNavBar.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelNavBar.Size = new System.Drawing.Size(1062, 75);
            this.flowLayoutPanelNavBar.TabIndex = 0;
            // 
            // buttonhome
            // 
            this.buttonhome.Image = ((System.Drawing.Image)(resources.GetObject("buttonhome.Image")));
            this.buttonhome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonhome.Location = new System.Drawing.Point(867, 11);
            this.buttonhome.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonhome.Name = "buttonhome";
            this.buttonhome.Size = new System.Drawing.Size(160, 60);
            this.buttonhome.TabIndex = 0;
            this.buttonhome.Text = "الرئيسة";
            this.buttonhome.UseVisualStyleBackColor = true;
            this.buttonhome.Click += new System.EventHandler(this.buttonhome_Click);
            // 
            // buttonStore
            // 
            this.buttonStore.Image = ((System.Drawing.Image)(resources.GetObject("buttonStore.Image")));
            this.buttonStore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStore.Location = new System.Drawing.Point(699, 11);
            this.buttonStore.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonStore.Name = "buttonStore";
            this.buttonStore.Size = new System.Drawing.Size(160, 60);
            this.buttonStore.TabIndex = 1;
            this.buttonStore.Text = "المخازن";
            this.buttonStore.UseVisualStyleBackColor = true;
            this.buttonStore.Click += new System.EventHandler(this.buttonStore_Click);
            // 
            // buttonCategory
            // 
            this.buttonCategory.Image = ((System.Drawing.Image)(resources.GetObject("buttonCategory.Image")));
            this.buttonCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCategory.Location = new System.Drawing.Point(531, 11);
            this.buttonCategory.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonCategory.Name = "buttonCategory";
            this.buttonCategory.Size = new System.Drawing.Size(160, 60);
            this.buttonCategory.TabIndex = 2;
            this.buttonCategory.Text = "الاصناف";
            this.buttonCategory.UseVisualStyleBackColor = true;
            // 
            // buttonMaterails
            // 
            this.buttonMaterails.Image = ((System.Drawing.Image)(resources.GetObject("buttonMaterails.Image")));
            this.buttonMaterails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMaterails.Location = new System.Drawing.Point(363, 11);
            this.buttonMaterails.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonMaterails.Name = "buttonMaterails";
            this.buttonMaterails.Size = new System.Drawing.Size(160, 60);
            this.buttonMaterails.TabIndex = 3;
            this.buttonMaterails.Text = "المواد";
            this.buttonMaterails.UseVisualStyleBackColor = true;
            // 
            // buttonAnalysis
            // 
            this.buttonAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("buttonAnalysis.Image")));
            this.buttonAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAnalysis.Location = new System.Drawing.Point(195, 11);
            this.buttonAnalysis.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAnalysis.Name = "buttonAnalysis";
            this.buttonAnalysis.Size = new System.Drawing.Size(160, 60);
            this.buttonAnalysis.TabIndex = 4;
            this.buttonAnalysis.Text = "التحليل";
            this.buttonAnalysis.UseVisualStyleBackColor = true;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Image = ((System.Drawing.Image)(resources.GetObject("buttonHelp.Image")));
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(27, 11);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(160, 60);
            this.buttonHelp.TabIndex = 5;
            this.buttonHelp.Text = "الاعدادات";
            this.buttonHelp.UseVisualStyleBackColor = true;
            // 
            // buttonAbout
            // 
            this.buttonAbout.Image = ((System.Drawing.Image)(resources.GetObject("buttonAbout.Image")));
            this.buttonAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAbout.Location = new System.Drawing.Point(867, 83);
            this.buttonAbout.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(160, 60);
            this.buttonAbout.TabIndex = 6;
            this.buttonAbout.Text = "حول";
            this.buttonAbout.UseVisualStyleBackColor = true;
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.flowLayoutPanelNavBar);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "مخزن";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.flowLayoutPanelNavBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNavBar;
        private System.Windows.Forms.Button buttonhome;
        private System.Windows.Forms.Button buttonStore;
        private System.Windows.Forms.Button buttonCategory;
        private System.Windows.Forms.Button buttonMaterails;
        private System.Windows.Forms.Button buttonAnalysis;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonAbout;
        public System.Windows.Forms.Panel panelContainer;
    }
}

