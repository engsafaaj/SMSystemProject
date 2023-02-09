using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Gui;
using SMSystem.Gui.Analyze;
using SMSystem.Gui.CustomersGui;
using SMSystem.Gui.DamageGui;
using SMSystem.Gui.Home;
using SMSystem.Gui.IncomeGui;
using SMSystem.Gui.MaterailsGui;
using SMSystem.Gui.OutComeGui;
using SMSystem.Gui.StoresGui;
using SMSystem.Gui.SuppliersGui;
using SMSystem.Gui.UserGui;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem
{
    public partial class Main : Form
    {
        // Fields
        MainClass mainClass;

        // Constructors
        public Main()
        {
            InitializeComponent();
            mainClass = new MainClass(this);
        }

        // Events
        private void Main_Load(object sender, EventArgs e)
        {
            // Load Home Page
            mainClass.LoadPage(HomeUserControl.Instance());

            SetUserRole();
        }

        private void buttonhome_Click(object sender, EventArgs e)
        {
            // Load Home Page
            mainClass.LoadPage(HomeUserControl.Instance());
        }

        private void buttonStore_Click(object sender, EventArgs e)
        {
            // Load Store Page
            mainClass.LoadPage(StoreUserControl.Instance());
        }

        private async void buttonMaterails_Click(object sender, EventArgs e)
        {
            // Load Materails Page
            mainClass.LoadPage(MaterailsUserControl.Instance());
            // Update Data
            Code.UpdateData updateData = new UpdateData();
          await Task.Run(()=>  updateData.UpdateIncome());
        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            // Load Customers Page
            mainClass.LoadPage(CustomerUserControl.Instance());
        }

        private void buttonSuppliers_Click(object sender, EventArgs e)
        {
            // Load Suupliers Page
            mainClass.LoadPage(SupplierUserControl.Instance());
        }

        private void buttonIncome_Click(object sender, EventArgs e)
        {
            // Load Income Materails Page
            mainClass.LoadPage(IncomeUserControl.Instance());
        }

        private void buttonOutCome_Click(object sender, EventArgs e)
        {
            // Load Income OutCome Materials Page
            mainClass.LoadPage(OutComeUserControl.Instance());
        }

        private void buttonDamage_Click(object sender, EventArgs e)
        {
            // Load Income OutCome Materials Page
            mainClass.LoadPage(DamageUserControl.Instance());
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            mainClass.LoadPage(UserUserControl.Instance());
        }

        private void buttonAnalysis_Click(object sender, EventArgs e)
        {
            mainClass.LoadPage(AnalyzeUserControl.Instance());

        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
           SettingsForm settingsForm = new SettingsForm(false);
            settingsForm.Show();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void SetUserRole()
        {
            if (Properties.Settings.Default.Role == "مستخدم")
            {
                buttonUsers.Visible = false;
            }
        }

        private void buttonOutOfConscneine_Click(object sender, EventArgs e)
        {
            // Load Income OutCome Materials Page
            mainClass.LoadPage(Gui.OutOfConscince.OutOfConscenseUserControl.Instance());
        }
    }
}
