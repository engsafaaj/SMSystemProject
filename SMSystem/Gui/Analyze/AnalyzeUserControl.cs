using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui.Analyze
{
    public partial class AnalyzeUserControl : UserControl
    {
        IDataHelper<Stores> StoreData;
        IDataHelper<Materails> MaterialData;
        IDataHelper<Customers> CustomerData;
        IDataHelper<Suppliers> SupplierData;
        IDataHelper<Income> IncomeData;
        IDataHelper<OutCome> OutCome;
        IDataHelper<Damage> Damage;
        IDataHelper<User> User;

        private static AnalyzeUserControl analyzeUserControl;
        private OtherGui.LoadingUser loading;
        public AnalyzeUserControl()
        {
            InitializeComponent();
            StoreData= (IDataHelper<Stores>)ContainerConfig.ObjectType("Store");
            MaterialData = (IDataHelper<Materails>)ContainerConfig.ObjectType("Materails");
            CustomerData = (IDataHelper<Customers>)ContainerConfig.ObjectType("Customer");
            SupplierData = (IDataHelper<Suppliers>)ContainerConfig.ObjectType("Supplier");
            IncomeData = (IDataHelper<Income>)ContainerConfig.ObjectType("Income");
            OutCome = (IDataHelper<OutCome>)ContainerConfig.ObjectType("OutCome");
            Damage = (IDataHelper<Damage>)ContainerConfig.ObjectType("Damage");
            User = (IDataHelper<User>)ContainerConfig.ObjectType("User");
            loading = OtherGui.LoadingUser.Instance();
            SetDataToView();
        }

        private async void SetDataToView()
        {
            loading.Show();
            
            labelStore.Text = await Task.Run(()=> StoreData.GetData().Select(x => x.Id).ToArray().Count().ToString());
            labelTotalMaterials.Text = await Task.Run(() => MaterialData.GetData().Select(x => x.Id).ToArray().Count().ToString());
            labelIncome.Text = await Task.Run(() => IncomeData.GetData().Select(x => x.Id).ToArray().Count().ToString());
            labelOutCome.Text = await Task.Run(() => OutCome.GetData().Select(x => x.Id).ToArray().Count().ToString());
            labelAvalible.Text = await Task.Run(() => MaterialData.GetData().Select(x => x.Quantity).ToArray().Sum().ToString());
            labelUsers.Text = await Task.Run(() => User.GetData().Select(x => x.Id).ToArray().Count().ToString());
            labelUsers.Text = await Task.Run(() => User.GetData().Select(x => x.Id).ToArray().Count().ToString());
            labelCustomers.Text = await Task.Run(() => CustomerData.GetData().Select(x => x.Id).ToArray().Count().ToString());
            labelSuppliers.Text = await Task.Run(() => SupplierData.GetData().Select(x => x.Id).ToArray().Count().ToString());
            loading.Hide();
        }

        internal static UserControl Instance()
        {
            return analyzeUserControl ?? (new AnalyzeUserControl());
        }
    }
}
