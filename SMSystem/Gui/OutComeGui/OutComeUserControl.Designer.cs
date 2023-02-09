
namespace SMSystem.Gui.OutComeGui
{
    partial class OutComeUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanelNavBar = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonDamge = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.panelSearchBar = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanelNavBar.SuspendLayout();
            this.panelSearchBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelNavBar
            // 
            this.flowLayoutPanelNavBar.AutoScroll = true;
            this.flowLayoutPanelNavBar.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonAdd);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonEdit);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonDelete);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonDamge);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonRefresh);
            this.flowLayoutPanelNavBar.Controls.Add(this.buttonPrint);
            this.flowLayoutPanelNavBar.Controls.Add(this.panelSearchBar);
            this.flowLayoutPanelNavBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelNavBar.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelNavBar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.flowLayoutPanelNavBar.Name = "flowLayoutPanelNavBar";
            this.flowLayoutPanelNavBar.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelNavBar.Size = new System.Drawing.Size(1062, 75);
            this.flowLayoutPanelNavBar.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Image = global::SMSystem.Properties.Resources.add_32px;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(907, 11);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(120, 54);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "  اضافة";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Image = global::SMSystem.Properties.Resources.edit_32px;
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.Location = new System.Drawing.Point(779, 11);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(120, 54);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "  تعديل";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Image = global::SMSystem.Properties.Resources.Delete_32px;
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.Location = new System.Drawing.Point(651, 11);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(120, 54);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "  حذف";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonDamge
            // 
            this.buttonDamge.Image = global::SMSystem.Properties.Resources.icons8_memo_32px;
            this.buttonDamge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDamge.Location = new System.Drawing.Point(523, 11);
            this.buttonDamge.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonDamge.Name = "buttonDamge";
            this.buttonDamge.Size = new System.Drawing.Size(120, 54);
            this.buttonDamge.TabIndex = 7;
            this.buttonDamge.Text = "  وصل";
            this.buttonDamge.UseVisualStyleBackColor = true;
            this.buttonDamge.Click += new System.EventHandler(this.buttonDamge_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Image = global::SMSystem.Properties.Resources.refresh_32px;
            this.buttonRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRefresh.Location = new System.Drawing.Point(395, 11);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(120, 54);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "  تحديث";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Image = global::SMSystem.Properties.Resources.print_32px;
            this.buttonPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPrint.Location = new System.Drawing.Point(267, 11);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(120, 54);
            this.buttonPrint.TabIndex = 4;
            this.buttonPrint.Text = "  طباعة";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // panelSearchBar
            // 
            this.panelSearchBar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panelSearchBar.Controls.Add(this.buttonSearch);
            this.panelSearchBar.Controls.Add(this.textBoxSearch);
            this.panelSearchBar.Location = new System.Drawing.Point(644, 74);
            this.panelSearchBar.Name = "panelSearchBar";
            this.panelSearchBar.Size = new System.Drawing.Size(384, 44);
            this.panelSearchBar.TabIndex = 4;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSearch.Image = global::SMSystem.Properties.Resources.search_32px;
            this.buttonSearch.Location = new System.Drawing.Point(310, 0);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(74, 44);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.Location = new System.Drawing.Point(0, 0);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(313, 45);
            this.textBoxSearch.TabIndex = 5;
            this.textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView.ColumnHeadersHeight = 40;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(0, 75);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.NullValue = "لا بيانات";
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView.RowHeadersWidth = 60;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(1062, 523);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.DoubleClick += new System.EventHandler(this.dataGridView_DoubleClick);
            // 
            // OutComeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.flowLayoutPanelNavBar);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "OutComeUserControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1062, 598);
            this.flowLayoutPanelNavBar.ResumeLayout(false);
            this.panelSearchBar.ResumeLayout(false);
            this.panelSearchBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNavBar;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Panel panelSearchBar;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonDamge;
    }
}
