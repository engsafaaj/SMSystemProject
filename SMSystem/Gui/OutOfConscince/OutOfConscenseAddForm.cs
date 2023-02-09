using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using SMSystem.Gui.MaterailsGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SMSystem.Gui.SuppliersGui;

namespace SMSystem.Gui.OutOfConscince
{
    public partial class OutOfConscenseAddForm : Form
    {
        // Fileds
        #region Fileds
        private readonly int id;
        private readonly OutOfConscenseUserControl outOfConscenseUserControl;
        private readonly MaterailsUserControl materailsUserControl;
        private readonly LoadingUser loading;
        public string currnetCode;
        public string currnetMaterialName;
        public bool isAddDirectly;
        private IDataHelper<OutOfConscinesMaterials> _dataHelper;
        private IDataHelper<Materails> _dataHelperforMaterail;
        private IDataHelper<Suppliers> _dataHelperforSupplier;
        private OutOfConscinesMaterials damage;
        private int ResultAddOrEdit;
        private string MaterailName;
        private bool IsCodeExcit;
        private byte[] recitpImage;
        public int MaterialId;
        private Materails materails;
        #endregion

        // Constructores
        public OutOfConscenseAddForm(int Id, OutOfConscenseUserControl MaterialUserControl1, MaterailsUserControl materailsUserControl)
        {
            InitializeComponent();
            // Set Property Instance
            id = Id;
            this.outOfConscenseUserControl = MaterialUserControl1;
            this.materailsUserControl = materailsUserControl;
            label11.Text = label11.Text + Properties.Settings.Default.Currency;
            label16.Text = label16.Text + Properties.Settings.Default.Currency;
            loading = LoadingUser.Instance();
            _dataHelper = (IDataHelper<OutOfConscinesMaterials>)ContainerConfig.ObjectType("OutOfConscinesMaterials");
            _dataHelperforMaterail = (IDataHelper<Materails>)ContainerConfig.ObjectType("Materails");
            _dataHelperforSupplier = (IDataHelper<Suppliers>)ContainerConfig.ObjectType("Supplier");

            // Set DataFileds for Edit void
            if (id > 0)
            {
                SetDataToFileds();
                AutoLoadMaterailData();
            }
        }

        // Events
        #region Events
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // check requirments of fileds
            if (IsRequiredFiledEmpty())
            {
                MessageCollection.ShowEmptyFields();
            }
            else
            {
                loading.Show();
                // Check if add or edit
                SetCodeExcit();
                if (id == 0)
                {
                    // Check if Code is Excit
                    if (IsCodeExcit == true)
                    {
                        MessageCollection.ShowDuplicateData();
                    }
                    else
                    {
                        // Add
                        AddData();
                    }

                }
                else
                {
                    // Edit
                    EditData();
                }
                loading.Hide();
                IsCodeExcit = false;
            }
        }
        private void OutOfConscinesMaterialsAddForm_Load(object sender, EventArgs e)
        {
            LoadMaterailsName();
            LoadSupplierName();
            LoadMaterailsCode();
            LoadReciptName();
            textBoxNewCode.Text = GetRandome();

            // Set Properties for Directly Added
            if (isAddDirectly)
            {
                comboBoxName.SelectedItem = currnetMaterialName;
                textBoxCode.SelectedItem = currnetCode;
                comboBoxName.Enabled = false;
                textBoxCode.Enabled = false;
                SetMaterailIdByName();
            }
            // Set Last Enter Number

        }
        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxQuantity.Text, "^[0-9]"))
            {
                MessageCollection.ShowInvalidValue();
                textBoxQuantity.Text = "1";
            }
            else
            {
                CalcuateTotalPrice();
            }

        }
        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxPrice.Text, "^[0-9]"))
            {
                MessageCollection.ShowInvalidValue();
                textBoxPrice.Text = "0";
            }
            else
            {
                CalcuateTotalPrice();
            }
        }
        private void linkLabelCodeGenerator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxNewCode.Text = GetRandome();
        }
        private void linkLabelImprotreciptImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadImageAsByte();
        }
        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            SetMaterailIdByName();
            AutoLoadMaterailData();
        }
        private void textBoxCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isAddDirectly)
            {
                SetMaterailIdByCode();
                AutoLoadMaterailData();
            }
        }
        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isAddDirectly)
            {
                SetMaterailIdByName();
                AutoLoadMaterailData();
            }
        }
        private void checkBoxIsExpDataEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsExpDataEnabled.Checked == true)
            {
                dateTimePickerExpData.Enabled = false;
            }
            else
            {
                dateTimePickerExpData.Enabled = true;
            }
        }
        private void textBoxInterNo_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxReciptNo_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxReciptNo.Text, "^[0-9]"))
            {
                MessageCollection.ShowInvalidValue();
                textBoxReciptNo.Text = "0";
            }

        }
        private void textBoxInterNo_TextChanged_1(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxInterNo.Text, "^[0-9]"))
            {
                MessageCollection.ShowInvalidValue();
                textBoxInterNo.Text = "0";
            }
        }
        private void linkLabelNewSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SupplierAddForm supplierAddForm = new SupplierAddForm(0, new SupplierUserControl());
            supplierAddForm.Show();
            supplierAddForm.FormClosed += (sender, EventArgs) =>
              {
                  LoadSupplierName();
              };

        }
        #endregion

        // Methods
        #region Methods
        private async void AddData()
        {
            // Set Data
            SetDataForAdd();
            // Send data and get result
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Add(damage));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfully
            {
                // Upate Material Data
                // Show Notifiction
                MessageCollection.ShowAddNotification();
                ClearFileds();
                // Updat View
                outOfConscenseUserControl.LoadData();
                // Set Last Enter Number
                textBoxNewCode.Text = GetRandome();
            }
            else // End with database error
            {
                MessageCollection.ShowServerMessage();
            }
        }
        private async void EditData()
        {
            // Set Data
            SetDataForEdit();
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Edit(damage));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Upate Material Data
                // Show Notification
                MessageCollection.ShowEditNotification();
                // Updat View
                outOfConscenseUserControl.LoadData();
            }
            else // End with database error
            {
                MessageCollection.ShowServerMessage();
            }
        }
        private void ClearFileds()
        {
            textBoxNewCode.Text = string.Empty;
        }
        private async void SetDataToFileds()
        {
            if (_dataHelper.IsDbConnect())
            {
                damage = await Task.Run(() => _dataHelper.Find(id));
                if (damage != null)
                {
                    // Set Data
                    textBoxNewCode.Text = damage.Code;
                    textBoxNewPrice.Text = damage.Price.ToString();
                    comboBoxName.SelectedItem = damage.Name;
                    textBoxQuantity.Text = damage.Quantity.ToString();
                    textBoxReciptNo.Text = damage.ReciptNo;
                    recitpImage = damage.RectipImg;
                    textBoxStore.Text = damage.Store;
                    comboBoxSupplier.SelectedItem = damage.Supplier;
                    textBoxUnit.Text = damage.Unit;
                    textBoxPrice.Text = damage.TotalPrice.ToString();
                    textBoxReciptName.Text = damage.RectipName;
                    dateTimePickerReciptDate.Value = damage.RectipDate;
                    textBoxInterNo.Text = damage.InterNo.ToString();
                }

            }
            else
            {
                MessageCollection.ShowServerMessage();

            }
            damage = null;
        }
        private void SetDataForAdd()
        {
            damage = new OutOfConscinesMaterials
            {
                AddedDate = DateTime.Now.Date,
                Code = textBoxNewCode.Text,
                Price = Convert.ToDouble(textBoxNewPrice.Text),
                Name = comboBoxName.Text,
                Quantity = Convert.ToDouble(textBoxQuantity.Text),
                ReciptNo = textBoxReciptNo.Text,
                RectipImg = recitpImage,
                Store = textBoxStore.Text,
                Supplier = comboBoxSupplier.SelectedItem.ToString(),
                Unit = textBoxUnit.Text,
                TotalPrice = Convert.ToDouble(textBoxTotalPrice.Text),
                ExpDate = dateTimePickerExpData.Value.Date,
                State = "خارج الذمة",
                InterNo = Convert.ToInt32(textBoxInterNo.Text),
                RectipDate = dateTimePickerReciptDate.Value.Date,
                RectipName = textBoxReciptName.Text,
                User = Properties.Settings.Default.User,
                


            };
        }
        private void SetDataForEdit()
        {
            damage = new OutOfConscinesMaterials
            {
                Id = this.id,
                AddedDate = DateTime.Now.Date,
                Code = textBoxNewCode.Text,
                Price = Convert.ToDouble(textBoxNewPrice.Text),
                Name = comboBoxName.Text,
                Quantity = Convert.ToDouble(textBoxQuantity.Text),
                ReciptNo = textBoxReciptNo.Text,
                RectipImg = recitpImage,
                Store = textBoxStore.Text,
                Supplier = comboBoxSupplier.SelectedItem.ToString(),
                Unit = textBoxUnit.Text,
                TotalPrice = Convert.ToDouble(textBoxTotalPrice.Text),
                ExpDate = dateTimePickerExpData.Value.Date,
                State = "خارج الذمة",
                InterNo = Convert.ToInt32(textBoxInterNo.Text),
                RectipDate = dateTimePickerReciptDate.Value.Date,
                RectipName = textBoxReciptName.Text,
                User = Properties.Settings.Default.User,

            };
        }
        private bool IsRequiredFiledEmpty()
        {
            if (textBoxCode.Text == string.Empty
                || comboBoxName.SelectedItem == null
                || textBoxNewCode.Text == string.Empty
                || textBoxNewPrice.Text == string.Empty
                || textBoxQuantity.Text == string.Empty
                || textBoxTotalPrice.Text == string.Empty
                || textBoxReciptName.Text == string.Empty
                || textBoxInterNo.Text == string.Empty
                || comboBoxSupplier.SelectedItem == null
                || textBoxReciptNo.Text == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void LoadMaterailsName()
        {
            if (_dataHelperforMaterail.IsDbConnect())
            {
                // Load List Of Materails Name
                var ListOfMaterailName =
                _dataHelperforMaterail.GetData().Select(x => x.Name).ToList();
                // Set List and Enable Auto Complete Featrue
                AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
                autoCompleteString.AddRange(ListOfMaterailName.ToArray());
                comboBoxName.AutoCompleteCustomSource = autoCompleteString;
                comboBoxName.DataSource = ListOfMaterailName;
                // Clear Variables
                ListOfMaterailName = null;
                autoCompleteString = null;
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }
        private async void LoadMaterailsCode()
        {
            if (_dataHelperforMaterail.IsDbConnect())
            {
                // Load List Of Code Name
                var ListOfMaterailCode = await Task.Run(() =>
                _dataHelperforMaterail.GetData().Select(x => x.Code).ToList());
                // Set List and Enable Auto Complete Featrue
                AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
                autoCompleteString.AddRange(ListOfMaterailCode.ToArray());
                textBoxCode.AutoCompleteCustomSource = autoCompleteString;
                textBoxCode.DataSource = ListOfMaterailCode;
                // Clear Variables
                ListOfMaterailCode = null;
                autoCompleteString = null;
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }
        private async void LoadReciptName()
        {
            if (_dataHelper.IsDbConnect())
            {
                // Load List Of Recipt Name
                var ListOfMaterailCode = await Task.Run(() =>
                _dataHelper.GetData().Select(x => x.RectipName).Distinct().ToList());
                // Set List and Enable Auto Complete Featrue
                AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
                autoCompleteString.AddRange(ListOfMaterailCode.ToArray());
                textBoxReciptName.AutoCompleteCustomSource = autoCompleteString;
                textBoxReciptName.DataSource = ListOfMaterailCode;
                // Clear Variables
                ListOfMaterailCode = null;
                autoCompleteString = null;
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }
        private async void LoadSupplierName()
        {
            if (_dataHelperforMaterail.IsDbConnect())
            {
                // Load List Of Materails Name
                var ListOfMaterailName = await Task.Run(() =>
                _dataHelperforSupplier.GetData().Select(x => x.Name).ToList());
                // Set List and Enable Auto Complete Feature
                AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
                autoCompleteString.AddRange(ListOfMaterailName.ToArray());
                comboBoxSupplier.AutoCompleteCustomSource = autoCompleteString;
                comboBoxSupplier.DataSource = ListOfMaterailName;
                // Clear Variables
                ListOfMaterailName = null;
                autoCompleteString = null;
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }
        private void SetMaterailIdByName()
        {
            MaterailName = comboBoxName.SelectedItem.ToString();
            if (_dataHelperforMaterail.IsDbConnect())
            {
                MaterialId = _dataHelperforMaterail.GetData()
                .Where(x => x.Name == MaterailName).Select(x => x.Id).First();
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }
        private void SetMaterailIdByCode()
        {
            if (comboBoxName.DataSource != null)
            {
                var Code = textBoxCode.Text;
                if (_dataHelperforMaterail.IsDbConnect())
                {
                    MaterialId = _dataHelperforMaterail.GetData()
                    .Where(x => x.Code == Code).Select(x => x.Id).First();
                }
                else
                {
                    MessageCollection.ShowServerMessage();
                }
            }
        }
        private void CalcuateTotalPrice()
        {
            try
            {
                double Quantity = Convert.ToDouble(textBoxQuantity.Text);
                double UnitPrice = Convert.ToDouble(textBoxNewPrice.Text);
                double TotalPrice = Quantity * UnitPrice;
                textBoxTotalPrice.Text = TotalPrice.ToString("0.00");
            }
            catch { }

        }
        private void SetCodeExcit()
        {
            if (_dataHelper.IsDbConnect())
            {
                if (_dataHelper.IsDbConnect())
                {
                    var NewCode = textBoxNewCode.Text;
                    var datacheck = _dataHelper.GetData().Where(x => x.Code == NewCode).ToList();
                    if (datacheck.Count > 0)
                    {
                        IsCodeExcit = true;
                    }
                    else
                    {
                        IsCodeExcit = false;
                    }
                    datacheck = null;
                }
                else
                {
                    MessageCollection.ShowServerMessage();
                }
            }
            else
            {
                MessageCollection.ShowServerMessage();
                IsCodeExcit = false;
            }
        }
        private string GetRandome()
        {
            Random random = new Random();
            return random.Next().ToString();
        }
        private void LoadImageAsByte()
        {
            // Define Open File Dialog
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "اختر صورة الوصل";
            fileDialog.Filter = "Image Files (jpg)|*.jpg";
            fileDialog.RestoreDirectory = true;
            // Show Dialog
            var resultdilog = fileDialog.ShowDialog();
            if (resultdilog == DialogResult.OK)
            {
                recitpImage =
                recitpImage = File.ReadAllBytes(fileDialog.FileName);
            }

        }
        private void AutoLoadMaterailData()
        {
            if (_dataHelperforMaterail.IsDbConnect())
            {
                if (MaterialId > 0)
                {
                    // Load Data
                    materails = _dataHelperforMaterail.Find(MaterialId);
                    // Assign Data
                    if (materails != null)
                    {
                        textBoxCode.Text = materails.Code;
                        textBoxPrice.Text = materails.Price.ToString();
                        textBoxNewPrice.Text = materails.Price.ToString();
                        textBoxStore.Text = materails.Store;
                        textBoxCurrentQuanttiy.Text = materails.Quantity.ToString();
                        textBoxUnit.Text = materails.Unit;
                    }
                }
            }
        }
     
     
        #endregion


    }
}
