using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui.StoresGui
{
    public partial class StoreAddForm : Form
    {
        // Fileds
        private readonly int id;
        private readonly StoreUserControl storeUserControl;
        private readonly LoadingUser loading;
        private IDataHelper<Stores> _dataHelper;
        private Stores stores;
        private int ResultAddOrEdit;
        // Constructores
        public StoreAddForm(int Id, StoreUserControl storeUserControl)
        {
            InitializeComponent();
            // Set Property Instance
            id = Id;
            this.storeUserControl = storeUserControl;
            loading = LoadingUser.Instance();
            _dataHelper = (IDataHelper<Stores>)ContainerConfig.ObjectType("Store");
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
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Add(stores));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Show Notifiction
                MessageCollection.ShowAddNotification();
                ClearFileds();
                // Updat View
                storeUserControl.LoadData();
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
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Edit(stores));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Show Notification
                MessageCollection.ShowEditNotification();
                // Updat View
                storeUserControl.LoadData();
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
                stores = await Task.Run(() => _dataHelper.Find(id));
                textBoxName.Text = stores.Name;
                textBoxDescriptions.Text = stores.Description;
            }
            else
            {
                MessageCollection.ShowServerMessage();

            }
            stores = null;
        }
        private void SetDataForAdd()
        {
            stores = new Stores
            {
                Name = textBoxName.Text,
                Description = textBoxDescriptions.Text
            };
        }
        private void SetDataForEdit()
        {
            stores = new Stores
            {
                Id = this.id,
                Name = textBoxName.Text,
                Description = textBoxDescriptions.Text
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
