using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui.IncomeGui
{
    public partial class IncomeUserControl : UserControl
    {
        // Fields
        private readonly IDataHelper<Income> _dataHelper;
        private readonly IDataHelper<Materails> _dataHelperForMaterial;
        private readonly LoadingUser loading;
        private int MaterialId;
        private static IncomeUserControl _incomelsUser;
        private List<int> IdList = new List<int>();
        private Label labelEmptyData;
        private string searchItem;

        public int RowId { get; private set; }

        // Constructores
        public IncomeUserControl()
        {
            InitializeComponent();
            labelEmptyData = ComponentsObject.Instance().LabelEmptyData();
            _dataHelper = (IDataHelper<Income>)ContainerConfig.ObjectType("Income");
            _dataHelperForMaterial = (IDataHelper<Materails>)ContainerConfig.ObjectType("Materails");
            loading = LoadingUser.Instance();
            LoadData();
        }

        #region Events
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            IncomeAddForm IncomeAdd = new IncomeAddForm(0, this, new MaterailsGui.MaterailsUserControl());
            IncomeAdd.Show();
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.RowCount > 0)
            {
                RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[10].Value);
                IncomeAddForm IncomeAdd = new IncomeAddForm(RowId, this, new MaterailsGui.MaterailsUserControl());
                string CurrentMaterialName = dataGridView.CurrentRow.Cells[1].Value.ToString();
                AutoLoadMaterailData(IncomeAdd);
                IncomeAdd.currnetMaterialName = CurrentMaterialName;
                IncomeAdd.isAddDirectly = true;
                IncomeAdd.Show();
                IncomeAdd.Show();

            }
            else
            {
                MessageCollection.ShowEmptyDataMessage();
            }
        }
        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.RowCount > 0)
                {
                    SetIDSelcted();
                    var result = MessageCollection.DeleteActtion();
                    if (result == true)
                    {
                        loading.Show();
                        if (await Task.Run(() => _dataHelper.IsDbConnect()))
                        {
                            if (IdList.Count > 0)
                            {
                                for (int i = 0; i < IdList.Count; i++)
                                {
                                    RowId = IdList[i];
                                    await Task.Run(() => _dataHelper.Delete(RowId));
                                }
                                LoadData();
                                MessageCollection.ShowDeletNotification();
                            }
                            else
                            {
                                MessageCollection.ShowSlectRowsNotification();

                            }
                        }
                        else
                        {
                            MessageCollection.ShowServerMessage();
                        }
                    }
                }
                else
                {
                    MessageCollection.ShowEmptyDataMessage();

                }
            }
            catch
            {
                MessageCollection.ShowServerMessage();
            }
            loading.Hide();
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {


        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadDataForSearch();

        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataForSearch();
        }
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            buttonEdit_Click(sender, e);
        }
        #endregion

        // Methods
        #region Methods
        public async void LoadData()
        {

            loading.Show();
            // Check if connection is available
            if (await Task.Run(() => _dataHelper.IsDbConnect()))
            {
                // Loading Data and Set Data
                dataGridView.DataSource = await Task.Run(() => _dataHelper.GetData()
                .Select(x => new
                {
                    x.Code,
                    x.Name,
                    x.Store,
                    x.Unit,
                    x.Price,
                    x.Quantity,
                    x.TotalPrice,
                    x.Supplier,
                    x.ReciptNo,
                    x.ExpDate,
                    x.Id,
                    x.State,
                    x.AddedDate
                }
                ).ToList());
                SetDataGridViewColumns();
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
            loading.Hide();

            // Show Empty Label Data
            ShowLabelIfEmptyData();
        }
        public async void LoadDataForSearch()
        {
            // show All Data
            if (textBoxSearch.Text == string.Empty)
            {
                LoadData();
            }
            else
            {
                // Show Data by Search Item
                loading.Show();
                searchItem = textBoxSearch.Text;
                // Check if connection is available
                if (await Task.Run(() => _dataHelper.IsDbConnect()))
                {
                    // Loading Data
                    dataGridView.DataSource = await Task.Run(() => _dataHelper.Search(searchItem).Select(x => new
                    {
                        x.Code,
                        x.Name,
                        x.Store,
                        x.Unit,
                        x.Price,
                        x.Quantity,
                        x.TotalPrice,
                        x.Supplier,
                        x.ReciptNo,
                        x.ExpDate,
                        x.Id,
                        x.State,
                        x.AddedDate
                    }
                     ).ToList());
                    //Set Columns Labelk
                    SetDataGridViewColumns();
                }
                else
                {
                    MessageCollection.ShowServerMessage();
                }
                loading.Hide();
            }
            // Show Empty Label Data
            ShowLabelIfEmptyData();

        }
        // Get a List of Id for selcted rows
        private void SetIDSelcted()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Selected)
                {
                    IdList.Add(Convert.ToInt32(row.Cells[10].Value));
                }
            }
        }
        private void SetDataGridViewColumns()
        {
            try
            {
                // Set Title
                dataGridView.Columns[0].HeaderCell.Value = "الكود";
                dataGridView.Columns[1].HeaderCell.Value = "الاسم";
                dataGridView.Columns[2].HeaderCell.Value = "اسم المخزن";
                dataGridView.Columns[3].HeaderCell.Value = "الوحدة";
                dataGridView.Columns[4].HeaderCell.Value = "السعر";
                dataGridView.Columns[5].HeaderCell.Value = "الكمية";
                dataGridView.Columns[6].HeaderCell.Value = "الاجمالي";
                dataGridView.Columns[7].HeaderCell.Value = "المورد";
                dataGridView.Columns[8].HeaderCell.Value = "رقم الوصل";
                dataGridView.Columns[9].HeaderCell.Value = "تاريخ الانتهاء";
                dataGridView.Columns[11].HeaderCell.Value = "الحالة";
                dataGridView.Columns[12].HeaderCell.Value = "تاريخ الاضافة";

                // Hide Columns
                dataGridView.Columns[10].Visible = false;
                dataGridView.Columns[9].Visible = false;
            }
            catch { }
        }
        // Singleton Instance
        public static UserControl Instance()
        {
            return _incomelsUser ?? (new IncomeUserControl());
        }
        //Add and Show Empty Label 
        private void ShowLabelIfEmptyData()
        {
            dataGridView.Controls.Add(labelEmptyData);
            if (dataGridView.Rows.Count > 0)
            {
                labelEmptyData.Visible = false;
            }
            else
            {
                labelEmptyData.Visible = true;
            }
        }

        #endregion

        private async void buttonDeleteFromMaterials_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.RowCount > 0)
                {
                    SetIDSelcted();
                    var result = MessageCollection.DeleteActtion();
                    if (result == true)
                    {
                        loading.Show();
                        if (await Task.Run(() => _dataHelper.IsDbConnect()))
                        {
                            if (IdList.Count > 0)
                            {
                                for (int i = 0; i < IdList.Count; i++)
                                {
                                    RowId = IdList[i];
                                    var income = await Task.Run(() => _dataHelper.GetData().Where(x => x.Id == RowId).First());
                                    var material= await Task.Run(() => _dataHelperForMaterial.GetData().Where(x => x.Id == income.MaterailId).First());
                                    material.Quantity = material.Quantity - income.Quantity;
                                    material.InCome = material.InCome - income.Quantity;
                                    material.TotalPrice = material.TotalPrice - income.TotalPrice;
                                    await Task.Run(() => _dataHelperForMaterial.Edit(material));
                                    await Task.Run(() => _dataHelper.Delete(RowId));
                                }
                                LoadData();
                                MessageCollection.ShowDeletNotification();
                            }
                            else
                            {
                                MessageCollection.ShowSlectRowsNotification();

                            }
                        }
                        else
                        {
                            MessageCollection.ShowServerMessage();
                        }
                    }
                }
                else
                {
                    MessageCollection.ShowEmptyDataMessage();

                }
            }
            catch
            {
                MessageCollection.ShowServerMessage();
            }
            loading.Hide();
        }

        private void AutoLoadMaterailData(IncomeAddForm incomeAdd)
        {

            if (_dataHelper.IsDbConnect())
            {
               var RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[10].Value);
                var MaterialId = _dataHelper.GetData().Where(x => x.Id == RowId).Select(x => x.MaterailId).First();
                if (MaterialId > 0)
                {
                    // Load Data
                    var materails = _dataHelperForMaterial.Find(MaterialId);
                    // Assign Data
                    if (materails != null)
                    {
                        incomeAdd.textBoxCode.Text = materails.Code;
                        incomeAdd.textBoxPrice.Text = materails.Price.ToString();
                        incomeAdd.textBoxNewPrice.Text = materails.Price.ToString();
                        incomeAdd.textBoxStore.Text = materails.Store;
                        incomeAdd.textBoxCurrentQuanttiy.Text = materails.Quantity.ToString();
                        incomeAdd.textBoxUnit.Text = materails.Unit;
                        incomeAdd.textBoxIncome.Text = materails.InCome.ToString();
                    }
                }
            }
        }
    }
}
