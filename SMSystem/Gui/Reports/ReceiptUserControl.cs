using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMSystem.Gui.Reports
{
    public partial class ReceiptUserControl : Form
    {
        private readonly LoadingUser loading;
        private readonly IDataHelper<OutComeMaterail> _dataHelperforOutComeMaterials;
        private readonly IDataHelper<OutCome> _dataHelper;
        private readonly int outComeMaterialId;
        private OutCome outCome;

        public ReceiptUserControl(int OutComeMaterialId)
        {
            InitializeComponent();

            loading = LoadingUser.Instance();

            _dataHelperforOutComeMaterials = (IDataHelper<OutComeMaterail>)ContainerConfig.ObjectType("OutComeMaterail");
            _dataHelper = (IDataHelper<OutCome>)ContainerConfig.ObjectType("OutCome");
            outComeMaterialId = OutComeMaterialId;

            UpdateOutComeMaterailData();
            SetDataToFileds();
            LoadSettings();
            GetEmpDate();

        }

        // Events
        private void TextBoxHighEmpName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HigherEmpName = TextBoxHighEmpName.Text;
            Properties.Settings.Default.Save();
        }

        private void TextBoxLowEmpName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LowerEmpName = TextBoxLowEmpName.Text;
            Properties.Settings.Default.Save();

        }

        private void TextBoxHighEmpTitle_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HihgerEmpTitle = TextBoxHighEmpTitle.Text;
            Properties.Settings.Default.Save();
        }

        private void TextBoxLowEmpTitle_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LowerEmpTitle = TextBoxLowEmpTitle.Text;
            Properties.Settings.Default.Save();

        }

        private void TextBoxDateTimeHigherEmp_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HigherEmpDate = TextBoxDateTimeHigherEmp.Text;
            Properties.Settings.Default.Save();

        }

        private void TextBoxDateTimeLowerEmp_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LowerEmpDate = TextBoxDateTimeLowerEmp.Text;
            Properties.Settings.Default.Save();
        }
        private void printdoc1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap MemoryImage = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(MemoryImage, new Rectangle(Point.Empty, panel1.Size));
            e.Graphics.DrawImage(MemoryImage, new Point(0, 0));
        }

        private void ButtonPageSetup_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void ButtonPreview_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            LabelDateTime.Text = DateTime.Now.Date.ToShortDateString();
        }


        // Methods
        private void SetDataGridViewColumns()
        {
            try
            {
                // Set Title
                dataGridView.Columns[1].HeaderCell.Value = "اسم المادة";
                dataGridView.Columns[2].HeaderCell.Value = "الكمية";
                dataGridView.Columns.Add("Price", "السعر" + Properties.Settings.Default.Currency);
                dataGridView.Columns.Add("TotalPrice", "الاجمالي" + Properties.Settings.Default.Currency);
                // Hide Columns
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns.Add("Description", "ملاحظات");
                dataGridView.Columns[5].Width = 300;

            }
            catch { }
        }

        private void UpdateOutComeMaterailData()
        {
            loading.Show();
            // Check if connection is available
            if (_dataHelperforOutComeMaterials.IsDbConnect())
            {
                // Loading Data and Set Data
                dataGridView.DataSource = _dataHelperforOutComeMaterials.GetData().Where(x => x.MaterialId == outComeMaterialId)
                .Select(x => new
                {
                    x.Id,
                    x.MaterialName,
                    x.Quantity, 
                }
                ).ToList();
                SetDataGridViewColumns();
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
            loading.Hide();


        }

        private void SetDataToFileds()
        {
            if (_dataHelper.IsDbConnect())
            {
                outCome = _dataHelper.Find(outComeMaterialId);
                if (outCome != null)
                {
                    // Set Data
                    LabelId.Text = outCome.Id.ToString();
                    LabelCustomer.Text = outCome.Customer;
                    LabelOutComeDate.Text = outCome.OutDate.ToShortDateString();
                    LabelOutComeNo.Text = outCome.OuterNo.ToString();
                    LabelTotalPrice.Text =  "                   " + Properties.Settings.Default.Currency;
                }
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }

        private void LoadSettings()
        {
            try
            {
                // Get And Set Excit Settings
                labelCompanyName.Text = Properties.Settings.Default.CompanyName;
                var Logo = Convert.FromBase64String(Properties.Settings.Default.CompanyLogo);
                if (Logo != null)
                {
                    using (MemoryStream ma = new MemoryStream(Logo))
                    {
                        pictureBoxCompanyLogo.Image = Image.FromStream(ma);
                    }
                }
            }
            catch
            {
            }
        }

      

        private void GetEmpDate()
        {
            TextBoxHighEmpName.Text = Properties.Settings.Default.HigherEmpName;
            TextBoxHighEmpTitle.Text = Properties.Settings.Default.HihgerEmpTitle;
            TextBoxDateTimeHigherEmp.Text = Properties.Settings.Default.HigherEmpDate;

            TextBoxLowEmpName.Text = Properties.Settings.Default.LowerEmpName;
            TextBoxLowEmpTitle.Text = Properties.Settings.Default.LowerEmpTitle;
            TextBoxDateTimeLowerEmp.Text = Properties.Settings.Default.LowerEmpDate;

            TextBoxReciveDate.Text=Properties.Settings.Default.TextBoxReciveDate ;

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void ReceiptUserControl_Activated(object sender, EventArgs e)
        {
        }

        private void TextBoxReciveDate_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TextBoxReciveDate = TextBoxReciveDate.Text;
            // Save Settings
            Properties.Settings.Default.Save();
        }
    }
}
