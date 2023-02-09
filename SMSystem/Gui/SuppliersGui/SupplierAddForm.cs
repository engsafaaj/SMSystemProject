using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui.SuppliersGui
{
    public partial class SupplierAddForm : Form
    {
        // Fileds
        private readonly int id;
        private readonly SupplierUserControl supplierUserControl;
        private readonly LoadingUser loading;
        private IDataHelper<Suppliers> _dataHelper;
        private Suppliers suppliers;
        private int ResultAddOrEdit;
        // Constructores
        public SupplierAddForm(int Id, SupplierUserControl supplierUserControl)
        {
            InitializeComponent();
            // Set Property Instance
            id = Id;
            this.supplierUserControl = supplierUserControl;
            loading = LoadingUser.Instance();
            _dataHelper = (IDataHelper<Suppliers>)ContainerConfig.ObjectType("Supplier");
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
                // Check if add or edit
                if (id == 0)
                {
                    // Add
                    AddData();
                }
                else
                {
                    // Edit
                    EditData();
                }
                loading.Hide();
            }
        }
        #region Methods
        private async void AddData()
        {
            // Set Data
            SetDataForAdd();
            // Send data and get result
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Add(suppliers));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Show Notifiction
                MessageCollection.ShowAddNotification();
                ClearFileds();
                // Updat View
                supplierUserControl.LoadData();
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
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Edit(suppliers));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Show Notification
                MessageCollection.ShowEditNotification();
                // Updat View
                supplierUserControl.LoadData();
            }
            else // End with database error
            {
                MessageCollection.ShowServerMessage();
            }
        }

        private void ClearFileds()
        {
            textBoxName.Text = textBoxDescriptions.Text = string.Empty;
        }

        private async void SetDataToFileds()
        {
            if (_dataHelper.IsDbConnect())
            {
                suppliers = await Task.Run(() => _dataHelper.Find(id));
                textBoxName.Text = suppliers.Name;
                textBoxDescriptions.Text = suppliers.Description;
                textBoxLocation.Text = suppliers.location;
                textBoxPhone.Text = suppliers.Phone;
                textBoxEmail.Text = suppliers.Email;
            }
            else
            {
                MessageCollection.ShowServerMessage();

            }
            suppliers = null;
        }
        private void SetDataForAdd()
        {
            suppliers = new Suppliers
            {
                Name = textBoxName.Text,
                Description = textBoxDescriptions.Text,
                location=textBoxLocation.Text,
                Email=textBoxEmail.Text,
                Phone=textBoxEmail.Text
            };
        }
        private void SetDataForEdit()
        {
            suppliers = new Suppliers
            {
                Id = this.id,
                Name = textBoxName.Text,
                Description = textBoxDescriptions.Text,
                location = textBoxLocation.Text,
                Email = textBoxEmail.Text,
                Phone = textBoxEmail.Text
            };
        }
        private bool IsRequiredFiledEmpty()
        {
            if (textBoxName.Text == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
