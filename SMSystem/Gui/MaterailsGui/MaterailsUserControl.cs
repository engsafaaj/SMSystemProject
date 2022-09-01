using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.IncomeGui;
using SMSystem.Gui.OtherGui;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui.MaterailsGui
{
    public partial class MaterailsUserControl : UserControl
    {
        // Fields
        private readonly IDataHelper<Materails> _dataHelper;
        private readonly IDataHelper<Income> _dataHelperForIcome;
        private List<Materails> localData;
        private readonly LoadingUser loading;
        private int RowId;
        private static MaterailsUserControl _materialsUser;
        private List<int> IdList = new List<int>();
        private Label labelEmptyData;
        private string searchItem;
        private Income IncomeTable;

        // Constructores
        public MaterailsUserControl()
        {
            InitializeComponent();
            labelEmptyData = ComponentsObject.Instance().LabelEmptyData();
            _dataHelper = (IDataHelper<Materails>)ContainerConfig.ObjectType("Materails");
            _dataHelperForIcome = (IDataHelper<Income>)ContainerConfig.ObjectType("Income");
            loading = LoadingUser.Instance();
            LoadData();
        }

        #region Events
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            MaterailsAddForm storeAdd = new MaterailsAddForm(0, this);
            storeAdd.Show();
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.RowCount > 0)
            {
                RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
                MaterailsAddForm storeAdd = new MaterailsAddForm(RowId, this);
                storeAdd.Show();
            }
            else
            {
                MessageCollection.ShowEmptyDataMessage();
            }
        }
        private void buttonIncome_Click(object sender, EventArgs e)
        {
            string CurrentMaterialName = dataGridView.CurrentRow.Cells[3].Value.ToString();
            string CurrentCode = dataGridView.CurrentRow.Cells[2].Value.ToString();
            IncomeAddForm IncomeAdd = new IncomeAddForm(0, new IncomeUserControl(), new MaterailsUserControl());
            IncomeAdd.currnetCode = CurrentCode;
            IncomeAdd.currnetMaterialName = CurrentMaterialName;
            IncomeAdd.isAddDirectly = true;
            AutoLoadMaterailData(IncomeAdd);
            IncomeAdd.Show();
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
                dataGridView.DataSource = await Task.Run(() => _dataHelper.GetData());
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
                    dataGridView.DataSource = await Task.Run(() => localData = _dataHelper.Search(searchItem));
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
                    IdList.Add(Convert.ToInt32(row.Cells[0].Value));
                }
            }
        }
        private void SetDataGridViewColumns()
        {
            try
            {
                // Set Title
                dataGridView.Columns[0].HeaderCell.Value = "المعرف";
                dataGridView.Columns[1].HeaderCell.Value = "اسم المخزن";
                dataGridView.Columns[2].HeaderCell.Value = "كود";
                dataGridView.Columns[3].HeaderCell.Value = "الاسم";
                dataGridView.Columns[4].HeaderCell.Value = "الوصف";
                dataGridView.Columns[5].HeaderCell.Value = "الوحدة";
                dataGridView.Columns[6].HeaderCell.Value = "الكمية";
                dataGridView.Columns[7].HeaderCell.Value = "الداخل";
                dataGridView.Columns[8].HeaderCell.Value = "الخارج";
                dataGridView.Columns[9].HeaderCell.Value = "السعر";
                dataGridView.Columns[10].HeaderCell.Value = "الاجمالي";
                dataGridView.Columns[11].HeaderCell.Value = "تاريخ الاضافة";

                // Hide Columns
                dataGridView.Columns[12].Visible = false;
                dataGridView.Columns[13].Visible = false;
            }
            catch { }


        }

        // Singleton Instance
        public static UserControl Instance()
        {
            return _materialsUser ?? (new MaterailsUserControl());
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


        private void AutoLoadMaterailData( IncomeAddForm incomeAdd)
        {

            if (_dataHelper.IsDbConnect())
            {
                RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
                if (RowId > 0)
                {
                    // Load Data
                    var materails = _dataHelper.Find(RowId);
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

        #endregion


    }
}
