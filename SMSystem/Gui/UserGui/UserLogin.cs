using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui.UserGui
{
    public partial class UserLogin : Form
    {
        // Fileds
        private readonly LoadingUser loading;
        private IDataHelper<User> _dataHelper;
        private User user;
        private int ResultAddOrEdit;
        private bool IsLogin;

        public bool IsUsersEmpty { get; }

        // Constructores
        public UserLogin()
        {
            InitializeComponent();
            // Set Property Instance
            loading = LoadingUser.Instance();
            _dataHelper = (IDataHelper<User>)ContainerConfig.ObjectType("User");

        }

        // Events
        private async void buttonSave_Click(object sender, EventArgs e)
        {
            // check requirments of fileds
            if (IsRequiredFiledEmpty())
            {
                MessageCollection.ShowEmptyFields();
            }
            else
            {
                loading.Show();

                // Login
                var userName = textBoxUserName.Text;
                var Password = textBoxPassword.Text;
                var LoginState = await Task.Run(() => LogIn(userName, Password));
                if (LoginState == 1)
                {
                    // Log in
                    Main main = new Main();
                    Properties.Settings.Default.User = user.FullName;
                    Properties.Settings.Default.Role = user.Role;
                    Properties.Settings.Default.Save();
                    main.Show();
                    IsLogin = true;
                    this.Close();
                }
                else if (LoginState == 2)
                {
                    // Show Login Invalid User
                    MessageBox.Show("معلومات المستخدم التي ادخلتها غير صحيحة. اتصل بمدير النظام لتزويدك بمعلومات تسجيل الدخول", "خطأ في معلومات المستخدم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Server Conncetion Error
                    MessageCollection.ShowServerMessage();

                }
                loading.Hide();
            }
        }
        private void UserAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsLogin)
            {
                Application.Exit();

            }

        }


        #region Methods
        private bool IsRequiredFiledEmpty()
        {
            if (
                 textBoxPassword.Text == string.Empty
                || textBoxUserName.Text == string.Empty
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This Method Check Login State 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns>1 if login, 2 if invalid user login data, 3 server error</returns>
        private int LogIn(string UserName, string Password)
        {
            if (_dataHelper.IsDbConnect())
            {
                try
                {
                    user = _dataHelper.GetData().Where(x => x.UserName == UserName && x.Password == Password).First();
                    if (user.Id > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                catch
                {
                    return 2;

                }

            }
            else
            {
                return 3;
            }

        }
        #endregion

    }
}
