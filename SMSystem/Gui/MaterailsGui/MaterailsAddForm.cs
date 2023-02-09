using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using SMSystem.Gui.StoresGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui.MaterailsGui
{
    public partial class MaterailsAddForm : Form
    {
        // Fileds
        private readonly int id;
        private readonly MaterailsUserControl MaterailsUserControl;
        private readonly LoadingUser loading;
        private IDataHelper<Materails> _dataHelper;
        private IDataHelper<Stores> _dataHelperforStore;
        private Materails materails;
        private int ResultAddOrEdit;
        private int StoreId;
        private string StoreName;
        private bool IsCodeExcit;

        // Constructores
        public MaterailsAddForm(int Id, MaterailsUserControl storeUserControl)
        {
            InitializeComponent();
            // Set Property Instance
            id = Id;
            this.MaterailsUserControl = storeUserControl;

            label15.Text = label15.Text + Properties.Settings.Default.Currency;
            label16.Text = label16.Text + Properties.Settings.Default.Currency;

            loading = LoadingUser.Instance();

            _dataHelper = (IDataHelper<Materails>)ContainerConfig.ObjectType("Materails");
            _dataHelperforStore = (IDataHelper<Stores>)ContainerConfig.ObjectType("Store");

            // Set DataFileds for Edit void
            if (id > 0)
            {
                SetDataToFileds();
            }
        }
        // Events
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
                SetCodeExcit();

                // Check if add or edit
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
                        GetRandome();

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
        private void MaterailsAddForm_Load(object sender, EventArgs e)
        {
            LoadStoresName();
            LoadUnitName();
        }
        private void comboBoxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetStoreId();
        }
        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxQuantity.Text, "^[0-9]"))
            {
                MessageCollection.ShowInvalidValue();
                textBoxQuantity.Text = "0";
            }
            else
            {
                CalcuateTotalPrice();
            }

        }
        private void textBoxIncome_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxPrice.Text, "^[0-9]"))
            {
                MessageCollection.ShowInvalidValue();
                textBoxPrice.Text = "0";
            }
        }
        private void textBoxOutCome_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxPrice.Text, "^[0-9]"))
            {
                MessageCollection.ShowInvalidValue();
                textBoxPrice.Text = "0";
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
            GetRandome();
        }
        private void linkLabelAddStore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StoreAddForm storeAdd = new StoreAddForm(0, new StoreUserControl());
            storeAdd.Show();
            storeAdd.FormClosed += (sender, EventArgs) =>
            {
                LoadStoresName();
            };
        }
        // Methods
        #region Methods
        private async void AddData()
        {
            // Set Data
            SetDataForAdd();
            // Send data and get result
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Add(materails));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Show Notifiction
                MessageCollection.ShowAddNotification();
                ClearFileds();
                // Updat View
                MaterailsUserControl.LoadData();
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
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Edit(materails));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Show Notification
                MessageCollection.ShowEditNotification();
                // Updat View
                MaterailsUserControl.LoadData();
            }
            else // End with database error
            {
                MessageCollection.ShowServerMessage();
            }
        }
        private void ClearFileds()
        {
            textBoxCode.Text = textBoxFullName.Text = string.Empty;
        }
        private async void SetDataToFileds()
        {
            if (_dataHelper.IsDbConnect())
            {
                materails = await Task.Run(() => _dataHelper.Find(id));
                textBoxCode.Text = materails.Code;
                textBoxFullName.Text = materails.Name;
                textBoxDescription.Text = materails.Descritpion;
                comboBoxStore.SelectedItem = materails.Store;
                comboBoxUnit.Text = materails.Unit;
                textBoxQuantity.Text = materails.Quantity.ToString();
                textBoxIncome.Text = materails.InCome.ToString();
                textBoxOutCome.Text = materails.OutCome.ToString();
                textBoxPrice.Text = materails.Price.ToString();
                textBoxTotalPrice.Text = materails.TotalPrice.ToString();
            }
            else
            {
                MessageCollection.ShowServerMessage();

            }
            materails = null;
        }
        private void SetDataForAdd()
        {
            materails = new Materails
            {
                Store = comboBoxStore.SelectedItem.ToString(),
                Code = textBoxCode.Text,
                Name = textBoxFullName.Text,
                Descritpion = textBoxDescription.Text,
                Unit = comboBoxUnit.Text.ToString(),
                Quantity = Convert.ToDouble(textBoxQuantity.Text),
                InCome = Convert.ToDouble(textBoxIncome.Text),
                OutCome = Convert.ToDouble(textBoxOutCome.Text),
                Price = Convert.ToDouble(textBoxPrice.Text),
                TotalPrice = Convert.ToDouble(textBoxTotalPrice.Text),
                AddedDate = DateTime.Now.Date,
                StoreId = StoreId,
               
            };
        }
        private void SetDataForEdit()
        {
            materails = new Materails
            {
                Id = this.id,
                Store = comboBoxStore.SelectedItem.ToString(),
                Code = textBoxCode.Text,
                Name = textBoxFullName.Text,
                Descritpion = textBoxDescription.Text,
                Unit = comboBoxUnit.Text.ToString(),
                Quantity = Convert.ToDouble(textBoxQuantity.Text),
                InCome = Convert.ToDouble(textBoxIncome.Text),
                OutCome = Convert.ToDouble(textBoxOutCome.Text),
                Price = Convert.ToDouble(textBoxPrice.Text),
                TotalPrice = Convert.ToDouble(textBoxTotalPrice.Text),
                AddedDate = DateTime.Now.Date,
                StoreId = StoreId
            };
        }
        private bool IsRequiredFiledEmpty()
        {
            if (textBoxCode.Text == string.Empty
                || textBoxFullName.Text == string.Empty
                || textBoxIncome.Text == string.Empty
                || textBoxOutCome.Text == string.Empty
                || textBoxPrice.Text == string.Empty
                || textBoxQuantity.Text == string.Empty
                || textBoxTotalPrice.Text == string.Empty
                || comboBoxStore.SelectedItem == null
                || comboBoxUnit.Text == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private async void LoadStoresName()
        {
            if (_dataHelperforStore.IsDbConnect())
            {
                comboBoxStore.DataSource = await Task.Run(() => _dataHelperforStore.GetData().Select(x => x.Name).ToList());
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }
        private async void SetStoreId()
        {
            if (comboBoxStore.DataSource != null)
            {
                StoreName = comboBoxStore.SelectedItem.ToString();
                if (_dataHelperforStore.IsDbConnect())
                {
                    StoreId = await Task.Run(() => _dataHelperforStore.GetData()
                    .Where(x => x.Name == StoreName).Select(x => x.Id).First());
                }
                else
                {
                    MessageCollection.ShowServerMessage();
                }
            }
        }
        private void CalcuateTotalPrice()
        {
            double Quantity = Convert.ToDouble(textBoxQuantity.Text);
            double UnitPrice = Convert.ToDouble(textBoxPrice.Text);
            double TotalPrice = Quantity * UnitPrice;
            textBoxTotalPrice.Text = TotalPrice.ToString("0.00");
        }
        private void SetCodeExcit()
        {
            if (_dataHelper.IsDbConnect())
            {
                var NewCode = textBoxCode.Text;
                var Name = textBoxFullName.Text;
                var datacheck = _dataHelper.GetData().Where(x => x.Code == NewCode || x.Name == Name).ToList();
                if (datacheck.Count > 0)
                {
                    IsCodeExcit = true;
                }
                else
                {
                    IsCodeExcit = false;
                }
                materails = null;
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }

        }
        private void GetRandome()
        {
            Random random = new Random();
            textBoxCode.Text = random.Next().ToString();
        }
        private void LoadUnitName()
        {
            if (_dataHelper.IsDbConnect())
            {
                // Load List Of Unit Name
                var ListOfMaterailName =
                _dataHelper.GetData().Select(x => x.Unit).Distinct().ToList();
                // Set List and Enable Auto Complete Featrue
                AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
                autoCompleteString.AddRange(ListOfMaterailName.ToArray());
                comboBoxUnit.AutoCompleteCustomSource = autoCompleteString;
                comboBoxUnit.DataSource = ListOfMaterailName;
                // Clear Variables
                ListOfMaterailName = null;
                autoCompleteString = null;
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }
        #endregion
    }
}
