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

namespace SMSystem.Gui.CustomersGui
{
    public partial class AddCustomerConscienceCard : Form
    {
        // Fileds
        #region Fileds
        private readonly int id;
        private readonly CustomerConscienceCardUserForm conscienceCard;
        private readonly MaterailsUserControl materailsUserControl;
        private readonly LoadingUser loading;
        public string currnetCode;
        public string currnetMaterialName;
        public bool isAddDirectly;
        private IDataHelper<ConscienceCard> _dataHelper;
        private IDataHelper<Materails> _dataHelperForMaterials;
        private IDataHelper<Customers> _dataHelperForSuppliers;
        private ConscienceCard income;
        private int ResultAddOrEdit;
        private string MaterailName;
        private bool IsCodeExcit;
        private byte[] recitpImage;
        public int MaterialId;
        private Materails materails;

        private int CustomerId;
        private string DepName;

        #endregion

        // Constructores
        public AddCustomerConscienceCard(int Id, CustomerConscienceCardUserForm MaterialUserControl,int CustomerId, string DepName)
        {
            InitializeComponent();
            // Set Property Instance
            id = Id;
            this.conscienceCard = MaterialUserControl;
            this.CustomerId = CustomerId;
            this.DepName = DepName;
            loading = LoadingUser.Instance();
            _dataHelper = (IDataHelper<ConscienceCard>)ContainerConfig.ObjectType("ConscienceCard");
            _dataHelperForMaterials = (IDataHelper<Materails>)ContainerConfig.ObjectType("Materails");
            _dataHelperForSuppliers = (IDataHelper<Customers>)ContainerConfig.ObjectType("Customer");

            // Set DataFileds for Edit void
            if (id > 0)
            {
                SetDataToFileds();
            }
        }

        // Events
        #region Events
        private void AddCustomerConscienceCard_Load(object sender, EventArgs e)
        {
            LoadMaterailsName();
            LoadReciverNames();
          
        }

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

        private void ConscienceCardAddForm_Load(object sender, EventArgs e)
        {
            LoadMaterailsName();
            LoadSupplierName();
          
        }

        private void textBoxCurrentQuanttiy_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxCurrentQuanttiy.Text, "^[0-9]"))
            {
                MessageCollection.ShowInvalidValue();
                textBoxCurrentQuanttiy.Text = "1";
            }

        }

        private void TextBoxInterNo_TextChanged_2(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(TextBoxInterNo.Text, "^[0-9]"))
            {
                MessageCollection.ShowInvalidValue();
                TextBoxInterNo.Text = "1";
            }

        }

        private void checkBoxMoveToAnotherDep_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMoveToAnotherDep.Checked == true)
            {
                groupBoxMoveToAnotherDep.Enabled = true;
                LoadSupplierName();
            }
            else
            {
                groupBoxMoveToAnotherDep.Enabled = false;

            }
        }
        #endregion
        // Methods
        #region Methods
        private async void AddData()
        {
            // Set Data
            SetDataForAdd();
            // Send data and get result
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Add(income));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfully
            {
             
                // Show Notifiction
                MessageCollection.ShowAddNotification();
                ClearFileds();
                // Updat View
                conscienceCard.LoadData();
                // Set Last Enter Number

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
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Edit(income));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                
                // Show Notification
                MessageCollection.ShowEditNotification();
                // Updat View
                conscienceCard.LoadData();
            }
            else // End with database error
            {
                MessageCollection.ShowServerMessage();
            }
        }

        private void ClearFileds()
        {
            // textBoxNewCode.Text = string.Empty;
        }

        private async void SetDataToFileds()
        {
            if (_dataHelper.IsDbConnect())
            {
                income = await Task.Run(() => _dataHelper.Find(id));
                if (income != null)
                {
                    // Set Data
                    CustomerId = income.CustomerId;
                    DepName = income.DepName;
                    comboBoxDepName.Text = income.DepTransportName;
                    dateTimePickerTransprotReciverDate.Value = income.DepTransportReciverDate;
                    comboBoxTransportReciverName.Text = income.DepTransportReciverName;
                    textBoxTransportReciverSign.Text = income.DepTransportReciverSign;
                    comboBoxMaterialName.Text = income.MaterialName;
                    dateTimePickerInterDateTime.Value = income.OutComeDate;
                    TextBoxInterNo.Text = income.OutComeNo.ToString();
                    textBoxCurrentQuanttiy.Text = income.Quantity.ToString();
                    dateTimePickerRecive.Value = income.ReciverDate;
                    comboBoxReciverName.Text = income.ReciverName;
                    textBoxReciverSign.Text = income.ReciverSign;

                }

            }
            else
            {
                MessageCollection.ShowServerMessage();

            }
            income = null;
        }

        private void SetDataForAdd()
        {
            income = new ConscienceCard
            {
                AddDate = DateTime.Now.Date,
                CustomerId = CustomerId,
                DepName = DepName,
                DepTransportName = comboBoxDepName.Text,
                DepTransportReciverDate = dateTimePickerTransprotReciverDate.Value.Date,
                DepTransportReciverName = comboBoxTransportReciverName.Text,
                DepTransportReciverSign = textBoxTransportReciverSign.Text,
                MaterialName = comboBoxMaterialName.Text,
                OutComeDate = dateTimePickerInterDateTime.Value.Date,
                OutComeNo = Convert.ToInt32(TextBoxInterNo.Text),
                Quantity = Convert.ToInt32(textBoxCurrentQuanttiy.Text),
                ReciverDate = dateTimePickerRecive.Value.Date,
                ReciverName = comboBoxReciverName.Text,
                ReciverSign = textBoxReciverSign.Text,
            };
        }

        private void SetDataForEdit()
        {
            income = new ConscienceCard
            {
                Id = this.id,
                AddDate = DateTime.Now.Date,
                CustomerId = CustomerId,
                DepName = DepName,
                DepTransportName = comboBoxDepName.Text,
                DepTransportReciverDate = dateTimePickerTransprotReciverDate.Value.Date,
                DepTransportReciverName = comboBoxTransportReciverName.Text,
                DepTransportReciverSign = textBoxTransportReciverSign.Text,
                MaterialName = comboBoxMaterialName.Text,
                OutComeDate = dateTimePickerInterDateTime.Value.Date,
                OutComeNo = Convert.ToInt32(TextBoxInterNo.Text),
                Quantity = Convert.ToInt32(textBoxCurrentQuanttiy.Text),
                ReciverDate = dateTimePickerRecive.Value.Date,
                ReciverName = comboBoxReciverName.Text,
                ReciverSign = textBoxReciverSign.Text,

            };
        }

        private bool IsRequiredFiledEmpty()
        {
            if (comboBoxMaterialName.Text == string.Empty
                || comboBoxReciverName.Text == null
                || textBoxCurrentQuanttiy.Text == string.Empty
                || TextBoxInterNo.Text == string.Empty
                )
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
            if (_dataHelper.IsDbConnect())
            {
                // Load List Of Materails Name
                var ListOfMaterailName =
                _dataHelperForMaterials.GetData().Select(x => x.Name).ToList();
                // Set List and Enable Auto Complete Featrue
                AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
                autoCompleteString.AddRange(ListOfMaterailName.ToArray());
                comboBoxMaterialName.AutoCompleteCustomSource = autoCompleteString;
                comboBoxMaterialName.DataSource = ListOfMaterailName;
                // Clear Variables
                ListOfMaterailName = null;
                autoCompleteString = null;
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }  

        private async void LoadSupplierName()
        {
            if (_dataHelperForMaterials.IsDbConnect())
            {
                // Load List Of Materails Name
                var ListOfMaterailName = await Task.Run(() =>
                _dataHelperForSuppliers.GetData().Select(x => x.Name).ToList());
                // Set List and Enable Auto Complete Feature
                AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
                autoCompleteString.AddRange(ListOfMaterailName.ToArray());
                comboBoxDepName.AutoCompleteCustomSource = autoCompleteString;
                comboBoxDepName.DataSource = ListOfMaterailName;
                // Clear Variables
                ListOfMaterailName = null;
                autoCompleteString = null;
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }

        private async void LoadReciverNames()
        {
            if (_dataHelperForMaterials.IsDbConnect())
            {
                // Load List Of Materails Name
                var ListOfMaterailName = await Task.Run(() =>
                _dataHelper.GetData().Select(x => x.ReciverName).ToList());
                // Set List and Enable Auto Complete Feature
                AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
                autoCompleteString.AddRange(ListOfMaterailName.ToArray());
                comboBoxTransportReciverName.AutoCompleteCustomSource = autoCompleteString;
                comboBoxTransportReciverName.DataSource = ListOfMaterailName;
                comboBoxTransportReciverName.Text = "";
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
