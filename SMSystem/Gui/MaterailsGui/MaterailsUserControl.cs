using FastMember;
using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.IncomeGui;
using SMSystem.Gui.OtherGui;
using SMSystem.Gui.OutComeGui;
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
        private DataTable dataTable;

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
        private void buttonOucome_Click(object sender, EventArgs e)
        {
            OutComeAddForm OutComeAdd = new OutComeAddForm(0, new OutComeUserControl(), this);
            OutComeAdd.Show();
        }

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

        private void buttonDelete_Click(object sender, EventArgs e)
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
                        if (_dataHelper.IsDbConnect())
                        {
                            if (IdList.Count > 0)
                            {
                                for (int i = 0; i < IdList.Count; i++)
                                {
                                    RowId = IdList[i];
                                    _dataHelper.Delete(RowId);
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
            dataTable = new DataTable();
            using (var reader = ObjectReader.Create(_dataHelper.GetData()))
            {
                dataTable.Load(reader);
            }
            RearrangeDataTableColumns(dataTable);
            PrintDialogForm printDialog = new PrintDialogForm(dataTable);
            printDialog.Show();

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
            if (_dataHelper.IsDbConnect())
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
                if (_dataHelper.IsDbConnect())
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
                dataGridView.Columns[6].HeaderCell.Value = "المتوفر";
                dataGridView.Columns[7].HeaderCell.Value = "الداخل";
                dataGridView.Columns[8].HeaderCell.Value = "الخارج";
                dataGridView.Columns[9].HeaderCell.Value = "التالف";
                dataGridView.Columns[10].HeaderCell.Value = "خارج الذمة";
                dataGridView.Columns[11].HeaderCell.Value = "بطاقة الذمة";
                dataGridView.Columns[12].HeaderCell.Value = "السعر" + Properties.Settings.Default.Currency;
                dataGridView.Columns[13].HeaderCell.Value = "الاجمالي" + Properties.Settings.Default.Currency;
                dataGridView.Columns[14].HeaderCell.Value = "تاريخ الاضافة";
                // Hide Columns
                dataGridView.Columns[15].Visible = false;
                dataGridView.Columns[16].Visible = false;
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

        private void AutoLoadMaterailData(IncomeAddForm incomeAdd)
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

        private void RearrangeDataTableColumns(DataTable dataTable)
        {


            dataTable.Columns["Id"].SetOrdinal(0);
            dataTable.Columns["Id"].ColumnName = "المعرف";
            dataTable.Columns["Store"].SetOrdinal(1);
            dataTable.Columns["Store"].ColumnName = "المخزن";
            dataTable.Columns["Code"].SetOrdinal(2);
            dataTable.Columns["Code"].ColumnName = "الكود";
            dataTable.Columns["Name"].SetOrdinal(3);
            dataTable.Columns["Name"].ColumnName = "اسم المادة";
            dataTable.Columns["Descritpion"].SetOrdinal(4);
            dataTable.Columns["Descritpion"].ColumnName = "الوصف";
            dataTable.Columns["Unit"].SetOrdinal(5);
            dataTable.Columns["Unit"].ColumnName = "الوحدة";
            dataTable.Columns["Quantity"].SetOrdinal(6);
            dataTable.Columns["Quantity"].ColumnName = "الكمية";
            dataTable.Columns["InCome1"].SetOrdinal(7);
            dataTable.Columns["InCome1"].ColumnName = "الداخل";
            dataTable.Columns["OutCome"].SetOrdinal(8);
            dataTable.Columns["OutCome"].ColumnName = "الخارج";
            dataTable.Columns["Damge"].SetOrdinal(9);
            dataTable.Columns["Damge"].ColumnName = "التالف";
            dataTable.Columns["OutConscience"].SetOrdinal(10);
            dataTable.Columns["OutConscience"].ColumnName = "خارج الذمة";
            dataTable.Columns["ConscinceCard"].SetOrdinal(11);
            dataTable.Columns["ConscinceCard"].ColumnName = "بطاقة الذمة";
            dataTable.Columns["Price"].SetOrdinal(12);
            dataTable.Columns["Price"].ColumnName = "السعر" + Properties.Settings.Default.Currency;
            dataTable.Columns["TotalPrice"].SetOrdinal(13);
            dataTable.Columns["TotalPrice"].ColumnName = "الاجمالي" + Properties.Settings.Default.Currency;
            dataTable.Columns["AddedDate"].SetOrdinal(14);
            dataTable.Columns["AddedDate"].ColumnName = "تاريخ الاضافة";

            // Remove unnesessary columns
            dataTable.Columns.Remove("StoreId");
            dataTable.Columns.Remove("Stores");
            dataTable.Columns.Remove("InCome");
            // Accept Changes
            dataTable.AcceptChanges();
        }
        #endregion


    }
}
