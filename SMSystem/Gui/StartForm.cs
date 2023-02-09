using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.UserGui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui
{
    partial class StartForm : Form
    {
        private IDataHelper<User> _dataHelper;
        private int StartState;

        public StartForm()
        {
            InitializeComponent();
            _dataHelper = (IDataHelper<User>)ContainerConfig.ObjectType("User");
        }

        /// <summary>
        /// This Mehod Check connection
        /// </summary>
        /// <returns> 1 for new use , 2 for Log ing , 3 for Erorr</returns>
        private int ConState()
        {
            if (_dataHelper.IsDbConnect())
            {
                var userid = _dataHelper.GetData().Select(x=>x.Id).ToList();

                if (userid.Count>0) 
                {
                    // Login
                    return 2;
                }
                else
                {
                    // New User
                    return 1;
                }
            }
            else
            {
                // Error in Connetion String
                return 3;
            }
        }

        private async void StartForm_Load(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            labelstate.Text = "جاري الاتصال بقاعدة البيانات ...";
             StartState = await Task.Run(() => ConState());
            if (StartState == 1)
            {
                // Add New User
             UserAddForm userAddForm = new UserGui.UserAddForm(0, new UserGui.UserUserControl(), true);
                userAddForm.Show();
                this.Hide();
            }
            else if (StartState == 2)
            {
                // Login
                UserLogin userLogin = new UserLogin();
                userLogin.Show();
                this.Hide();

            }
            else
            {
                // Connection Error
                // Exit Or Setup Connection from settings form
                var Text ="هل تود ضبط الاتصال بالسيرفر ؟";
                var caption = "لا يمكن الاتصال في السيرفر";

              var result=  MessageBox.Show(Text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    Gui.SettingsForm settingsForm = new SettingsForm(true);
                    settingsForm.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
