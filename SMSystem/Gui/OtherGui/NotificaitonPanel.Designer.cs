
namespace SMSystem.Gui.OtherGui
{
    partial class NotificaitonPanel
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
            this.PanelNote = new System.Windows.Forms.Panel();
            this.LabelNote = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelNote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelNote
            // 
            this.PanelNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelNote.Controls.Add(this.LabelNote);
            this.PanelNote.Controls.Add(this.pictureBox1);
            this.PanelNote.Location = new System.Drawing.Point(3, 3);
            this.PanelNote.Name = "PanelNote";
            this.PanelNote.Size = new System.Drawing.Size(539, 77);
            this.PanelNote.TabIndex = 1;
            // 
            // LabelNote
            // 
            this.LabelNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelNote.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.LabelNote.Location = new System.Drawing.Point(94, 0);
            this.LabelNote.Name = "LabelNote";
            this.LabelNote.Size = new System.Drawing.Size(443, 75);
            this.LabelNote.TabIndex = 1;
            this.LabelNote.Text = "احسبنت لا يلزمك اتخاذ اي اجراء ";
            this.LabelNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::SMSystem.Properties.Resources.icons8_Notification_128px;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // NotificaitonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelNote);
            this.Name = "NotificaitonPanel";
            this.Size = new System.Drawing.Size(548, 84);
            this.PanelNote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel PanelNote;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label LabelNote;
    }
}
