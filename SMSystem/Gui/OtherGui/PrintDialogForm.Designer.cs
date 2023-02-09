
namespace SMSystem.Gui.OtherGui
{
    partial class PrintDialogForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonExportExel = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonExportExel);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(518, 178);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonExportExel
            // 
            this.buttonExportExel.BackColor = System.Drawing.Color.White;
            this.buttonExportExel.Image = global::SMSystem.Properties.Resources.icons8_csv_80px_1;
            this.buttonExportExel.Location = new System.Drawing.Point(10, 10);
            this.buttonExportExel.Margin = new System.Windows.Forms.Padding(10);
            this.buttonExportExel.Name = "buttonExportExel";
            this.buttonExportExel.Size = new System.Drawing.Size(231, 154);
            this.buttonExportExel.TabIndex = 5;
            this.buttonExportExel.Text = "تصدير كل البيانات ";
            this.buttonExportExel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonExportExel.UseVisualStyleBackColor = false;
            this.buttonExportExel.Click += new System.EventHandler(this.buttonExportExel_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.White;
            this.buttonCancel.Image = global::SMSystem.Properties.Resources.icons8_Close_80px;
            this.buttonCancel.Location = new System.Drawing.Point(261, 10);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(10);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(231, 154);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // PrintDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(518, 178);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "PrintDialogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonExportExel;
        private System.Windows.Forms.Button buttonCancel;
    }
}