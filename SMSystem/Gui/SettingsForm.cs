using SMSystem.Code;
using SMSystem.Data.EF;
using SMSystem.Data.EFSqlServer;
using SMSystem.Gui.OtherGui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui
{
    public partial class SettingsForm : Form
    {
        private readonly bool isOpenFromStart;
        LoadingUser Loading;
        DBContext db;
        DataBaseBackUpAndRestor BackUpAndRestor;

        public SettingsForm(bool IsOpenFromStart)
        {
            InitializeComponent();

            db = new DBContext();
            Loading = LoadingUser.Instance();
            LoadSettings();
            isOpenFromStart = IsOpenFromStart;
            BackUpAndRestor = new DataBaseBackUpAndRestor();
        }

        private void buttonSaveGeneralSettings_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void buttonSaveServerSettings_Click(object sender, EventArgs e)
        {
            SaveConString();
        }

        private async void buttonBackUp_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            var rs = fbd.ShowDialog();
            if (rs == DialogResult.OK)
            {
                Loading.Show();
                var SelectPath = fbd.SelectedPath;
                var dbName = textBoxDataBase.Text;
                var state = await Task.Run(() => BackUpAndRestor.BackUp(SelectPath, dbName));

                if (state == "1")
                {
                    Properties.Settings.Default.LastBackUpDate = DateTime.Now.ToShortDateString();
                    Properties.Settings.Default.Save();
                    MessageBox.Show("تمت عملية النسخ الاحتياطي بنجاح");
                }
                else
                {
                    MessageBox.Show(state + " خطأ في عملية اجراء النسخ الاحتياطي, تأكد من تشغيل البرنامج كمسؤول لاجراء العملية");
                }

                Loading.Hide();
            }
        }

        private async void buttonRestore_Click(object sender, EventArgs e)
        {
            
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Bak File|*.bak";
                var result = fileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Loading.Show();
                    var FileName = fileDialog.FileName;
                    var dbName = textBoxDataBase.Text;
                    var state = await Task.Run(() => BackUpAndRestor.RestoreDataBase(FileName, dbName));

                    if (state == "1")
                    {
                        MessageBox.Show("تمت عملية استعادة النسخة الاحتياطية بنجاح");
                    }
                    else
                    {
                        MessageBox.Show(state + " خطأ في عملية اجراء النسخ الاحتياطي, تأكد من تشغيل البرنامج كمسؤول لاجراء العملية");
                    }

                    Loading.Hide();
                }
            
           
        }

        private void radioButtonLocalConnect_CheckedChanged(object sender, EventArgs e)
        {
            SetConType();
        }

        private void radioButtonNetworkConnect_CheckedChanged(object sender, EventArgs e)
        {
            SetConType();
        }
        private void linkLabelImportLogo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadImage();
        }

        private void LoadSettings()
        {
            try
            {
                // Get And Set Excit Settings
                textBoxCompanyName.Text = Properties.Settings.Default.CompanyName;
                textBoxCompanyDescription.Text = Properties.Settings.Default.CompanyDescritption;
                comboBoxCurrency.SelectedItem = Properties.Settings.Default.Currency;
                numericUpDownDamageDuration.Value = Properties.Settings.Default.NotificationDamagDuration;
                groupBoxServer.Text = "اخر نسخ احتاطي:"+"(" + Properties.Settings.Default.LastBackUpDate + ")";
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

        private void SaveSettings()
        {
            try
            {
                // Submit Settings
                Properties.Settings.Default.CompanyName = textBoxCompanyName.Text;
                Properties.Settings.Default.CompanyDescritption = textBoxCompanyDescription.Text;
                Properties.Settings.Default.Currency = comboBoxCurrency.SelectedItem.ToString();
                Properties.Settings.Default.NotificationDamagDuration=Convert.ToInt32( numericUpDownDamageDuration.Value);
                numericUpDownDamageDuration.Text = Properties.Settings.Default.NotificationDamagDuration.ToString();

                using (MemoryStream ma = new MemoryStream())
                {
                    pictureBoxCompanyLogo.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Png);
                    Properties.Settings.Default.CompanyLogo = Convert.ToBase64String(ma.ToArray());
                }
                Properties.Settings.Default.Save();
                MessageBox.Show("تمت عملية الحفظ", "تم حفظ الاعدادات بنجاح");

            }
            catch
            {
                MessageBox.Show("خطأ غير متوقع", "تعذر حفظ الاعدادات");
            }
        }

        private void LoadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "اختر شعار الشركة";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Image (.png,jpg)|*.png;*.jpg";
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBoxCompanyLogo.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isOpenFromStart)
            {
                Application.Exit();
            }
        }

        private void SetConType()
        {
            if (radioButtonLocalConnect.Checked == true)
            {
                textBoxPort.Enabled = false;
                textBoxUser.Enabled = false;
                textBoxPassword.Enabled = false;
            }
            else
            {
                textBoxPort.Enabled = true;
                textBoxUser.Enabled = true;
                textBoxPassword.Enabled = true;
            }
        }


        private void SaveConString()
        {
          var reslut=  MessageBox.Show(
                "انتبة انت على وشك تغيير اعدادات الاتصال,. هل انت متأكد من هذا الاجراء؟. تذكر لانسمح بعرض البيانات الاتصال السابقة", "تحديث نص الاتصال",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reslut == DialogResult.Yes)
            {
                // Get input
                var server = textBoxServer.Text;
                var dbname = textBoxDataBase.Text;
                var port = "," + textBoxPort.Text;
                var user = textBoxUser.Text;
                var password = textBoxPassword.Text;

                if (radioButtonLocalConnect.Checked == true)
                {
                    // Local Con
                    var ConString = @"data source=" + server + " ;initial catalog=" + dbname + ";integrated security=true";

                    Properties.Settings.Default.SQLServerConString = ConString;
                    Properties.Settings.Default.Save();


                    MessageBox.Show("تم تحديث الاتصال بنجاح , اعد تشغيل البرنامج لتطبيق الاعدادات ");
                    Application.Exit();
                }
                else
                {
                    // Local Con
                    var ConString = @"data source=" + server + port + ";initial catalog=" + dbname + ";user id=" + user + ";password=" + password + ";connect Timeout=60";

                    Properties.Settings.Default.SQLServerConString = ConString;
                    Properties.Settings.Default.Save();

                    MessageBox.Show("تم تحديث الاتصال بنجاح , اعد تشغيل البرنامج لتطبيق الاعدادات ");
                    Application.Exit();
                }
            }
          

        }


    }
}
