using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui.CustomersGui
{
    public partial class CustomerAddForm : Form
    {
        // Fileds
        private readonly int id;
        private readonly CustomerUserControl customerUserControl;
        private readonly LoadingUser loading;
        private IDataHelper<Customers> _dataHelper;
        private Customers customer;
        private int ResultAddOrEdit;
        // Constructores
        public CustomerAddForm(int Id, CustomerUserControl customerUserControl)
        {
            InitializeComponent();
            // Set Property Instance
            id = Id;
            this.customerUserControl = customerUserControl;
            loading = LoadingUser.Instance();
            _dataHelper = (IDataHelper<Customers>)ContainerConfig.ObjectType("Customer");
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
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Add(customer));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Show Notifiction
                MessageCollection.ShowAddNotification();
                ClearFileds();
                // Updat View
                customerUserControl.LoadData();
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
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Edit(customer));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Show Notification
                MessageCollection.ShowEditNotification();
                // Updat View
                customerUserControl.LoadData();
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
                customer = await Task.Run(() => _dataHelper.Find(id));
                textBoxName.Text = customer.Name;
                textBoxDescriptions.Text = customer.Description;
                textBoxLocation.Text = customer.location;
                textBoxPhone.Text = customer.Phone;
                textBoxEmail.Text = customer.Email;
            }
            else
            {
                MessageCollection.ShowServerMessage();

            }
            customer = null;
        }
        private void SetDataForAdd()
        {
            customer = new Customers
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
            customer = new Customers
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
