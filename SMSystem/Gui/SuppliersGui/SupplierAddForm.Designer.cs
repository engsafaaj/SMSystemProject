
namespace SMSystem.Gui.SuppliersGui
{
    partial class SupplierAddForm
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
            this.textBoxDescriptions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanelNavBar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelNavBar
            // 
            this.flowLayoutPanelNavBar.AutoScroll = true;
            this.flowLayoutPanelNavBar.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonSave);
            this.flowLayoutPanelNavBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelNavBar.Location = new System.Drawing.Point(0, 575);
            this.flowLayoutPanelNavBar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.flowLayoutPanelNavBar.Name = "flowLayoutPanelNavBar";
            this.flowLayoutPanelNavBar.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelNavBar.Size = new System.Drawing.Size(605, 75);
            this.flowLayoutPanelNavBar.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Image = global::SMSystem.Properties.Resources.save_32px;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(471, 11);
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
            this.groupBox1.Controls.Add(this.textBoxDescriptions);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxEmail);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxPhone);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxLocation);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 554);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات العميل";
            // 
            // textBoxDescriptions
            // 
            this.textBoxDescriptions.Location = new System.Drawing.Point(16, 324);
            this.textBoxDescriptions.Multiline = true;
            this.textBoxDescriptions.Name = "textBoxDescriptions";
            this.textBoxDescriptions.Size = new System.Drawing.Size(389, 224);
            this.textBoxDescriptions.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(426, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 37);
            this.label3.TabIndex = 6;
            this.label3.Text = "*";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(19, 257);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(389, 45);
            this.textBoxEmail.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(489, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 37);
            this.label8.TabIndex = 2;
            this.label8.Text = "الايميل:";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(19, 186);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(389, 45);
            this.textBoxPhone.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 37);
            this.label6.TabIndex = 2;
            this.label6.Text = "رقم الهاتف:";
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(19, 117);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(389, 45);
            this.textBoxLocation.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(488, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 37);
            this.label4.TabIndex = 2;
            this.label4.Text = "العنوان:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(19, 57);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(389, 45);
            this.textBoxName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(456, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "اسم المورد:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "الوصف:";
            // 
            // SupplierAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 650);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanelNavBar);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplierAddForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اضافة مورد";
            this.TopMost = true;
            this.flowLayoutPanelNavBar.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNavBar;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDescriptions;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Label label4;
    }
}