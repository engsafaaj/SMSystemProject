using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui.UserGui
{
    public partial class UserAddForm : Form
    {
        // Fileds
        private readonly int id;
        private readonly UserUserControl userUserControl;
        private readonly LoadingUser loading;
        private IDataHelper<User> _dataHelper;
        private User user;
        private int ResultAddOrEdit;

        public bool IsUsersEmpty { get; }

        // Constructores
        public UserAddForm(int Id, UserUserControl userUserControl,bool IsUsersEmpty)
        {
            InitializeComponent();
            // Set Property Instance
            id = Id;
            this.userUserControl = userUserControl;
            this.IsUsersEmpty = IsUsersEmpty;
            loading = LoadingUser.Instance();
            _dataHelper = (IDataHelper<User>)ContainerConfig.ObjectType("User");
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
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Add(user));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Show Notifiction
                MessageCollection.ShowAddNotification();
                ClearFileds();
                // Updat View
                userUserControl.LoadData();
                Close();
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
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Edit(user));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Show Notification
                MessageCollection.ShowEditNotification();
                // Updat View
                userUserControl.LoadData();
                Close();
            }
            else // End with database error
            {
                MessageCollection.ShowServerMessage();
            }
        }

        private void ClearFileds()
        {
        }

        private async void SetDataToFileds()
        {
            if (_dataHelper.IsDbConnect())
            {
                user = await Task.Run(() => _dataHelper.Find(id));
                textBoxName.Text = user.FullName;
                textBoxPassword.Text = user.Password;
                textBoxUserName.Text = user.UserName;
                textBoxPassword.Text = user.Password;
                comboBoxRole.SelectedItem = user.Role;
            }
            else
            {
                MessageCollection.ShowServerMessage();

            }
            user = null;
        }
        private void SetDataForAdd()
        {
            user = new User
            {
                FullName = textBoxName.Text,
                UserName = textBoxUserName.Text,
                Password=textBoxPassword.Text,
                Role=comboBoxRole.SelectedItem.ToString(),
            };
        }
        private void SetDataForEdit()
        {
            user = new User
            {
                Id = this.id,
                FullName = textBoxName.Text,
                UserName = textBoxUserName.Text,
                Password = textBoxPassword.Text,
                Role = comboBoxRole.SelectedItem.ToString()
            };
        }
        private bool IsRequiredFiledEmpty()
        {
            if (textBoxName.Text == string.Empty 
                || textBoxPassword.Text == string.Empty
                || textBoxUserName.Text == string.Empty
                || comboBoxRole.SelectedItem == null
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        private void UserAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsUsersEmpty)
            {
                Application.Exit();
                MessageBox.Show("اعد تشغيل البرنامج لطفا");
            }
        }
    }
}
