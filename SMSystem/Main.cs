using SMSystem.Code;
using SMSystem.Gui.CustomersGui;
using SMSystem.Gui.Home;
using SMSystem.Gui.IncomeGui;
using SMSystem.Gui.MaterailsGui;
using SMSystem.Gui.StoresGui;
using SMSystem.Gui.SuppliersGui;
using System;
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

        private void buttonMaterails_Click(object sender, EventArgs e)
        {
            // Load Materails Page
            mainClass.LoadPage(MaterailsUserControl.Instance());
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
    }
}
