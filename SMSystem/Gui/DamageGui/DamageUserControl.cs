using FastMember;
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

namespace SMSystem.Gui.DamageGui
{
    public partial class DamageUserControl : UserControl
    {
        // Fields
        private readonly IDataHelper<Damage> _dataHelper;
        private readonly LoadingUser loading;
        private int MaterialId;
        private static DamageUserControl _DamageUser;
        private List<int> IdList = new List<int>();
        private Label labelEmptyData;
        private string searchItem;
        private DataTable dataTable;
        private Damage damage;

        public int RowId { get; private set; }

        // Constructores
        public DamageUserControl()
        {
            InitializeComponent();
            labelEmptyData = ComponentsObject.Instance().LabelEmptyData();
            _dataHelper = (IDataHelper<Damage>)ContainerConfig.ObjectType("Damage");
            loading = LoadingUser.Instance();
            LoadData();
        }

        #region Events

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

        #endregion

        // Methods
        #region Methods
        public async void LoadData()
        {

            loading.Show();
            // Update Exp Date 
            // Check if connection is available
            if (_dataHelper.IsDbConnect())
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
                if (_dataHelper.IsDbConnect())
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
                dataGridView.Columns[4].HeaderCell.Value = "السعر" + Properties.Settings.Default.Currency;
                dataGridView.Columns[5].HeaderCell.Value = "الكمية";
                dataGridView.Columns[6].HeaderCell.Value = "الاجمالي" + Properties.Settings.Default.Currency;
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
        public static UserControl Instance()
        {
            return _DamageUser ?? (new DamageUserControl());
        }
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



        private void RearrangeDataTableColumns(DataTable dataTable)
        {
            dataTable.Columns["Id"].SetOrdinal(0);
            dataTable.Columns["Id"].ColumnName = "المعرف";
            dataTable.Columns["Code"].SetOrdinal(1);
            dataTable.Columns["Code"].ColumnName = "الكود";
            dataTable.Columns["Name"].SetOrdinal(2);
            dataTable.Columns["Name"].ColumnName = "اسم المادة";
            dataTable.Columns["Store"].SetOrdinal(3);
            dataTable.Columns["Store"].ColumnName = "المخزن";
            dataTable.Columns["Unit"].SetOrdinal(4);
            dataTable.Columns["Unit"].ColumnName = "الوحدة";
            dataTable.Columns["Quantity"].SetOrdinal(5);
            dataTable.Columns["Quantity"].ColumnName = "الكمية";
            dataTable.Columns["Price"].SetOrdinal(6);
            dataTable.Columns["Price"].ColumnName = "السعر";
            dataTable.Columns["TotalPrice"].SetOrdinal(7);
            dataTable.Columns["TotalPrice"].ColumnName = "الاجمالي";
            dataTable.Columns["RectipName"].SetOrdinal(8);
            dataTable.Columns["RectipName"].ColumnName = "اسم الوصل";
            dataTable.Columns["ReciptNo"].SetOrdinal(9);
            dataTable.Columns["ReciptNo"].ColumnName = "رقم الوصل";
            dataTable.Columns["RectipDate"].SetOrdinal(10);
            dataTable.Columns["RectipDate"].ColumnName = "تاريخ الوصل";
            dataTable.Columns["Supplier"].SetOrdinal(11);
            dataTable.Columns["Supplier"].ColumnName = "المورد";
            dataTable.Columns["InterNo"].SetOrdinal(12);
            dataTable.Columns["InterNo"].ColumnName = "رقم مستند الادخال";
            dataTable.Columns["State"].SetOrdinal(13);
            dataTable.Columns["State"].ColumnName = "الحالة";
            dataTable.Columns["User"].SetOrdinal(14);
            dataTable.Columns["User"].ColumnName = "المستخدم";
            dataTable.Columns["AddedDate"].SetOrdinal(15);
            dataTable.Columns["AddedDate"].ColumnName = "تاريخ الاضافة";
            dataTable.Columns["ExpDate"].SetOrdinal(16);
            dataTable.Columns["ExpDate"].ColumnName = "تاريخ الانتهاء";

            // Remove unnesessary columns
            dataTable.Columns.Remove("RectipImg");
            // Accept Changes
            dataTable.AcceptChanges();
        }




        #endregion

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DamageAddForm IncomeAdd = new DamageAddForm(0, this, new MaterailsGui.MaterailsUserControl());
            IncomeAdd.Show();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            if (dataGridView.RowCount > 0)
            {
                RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[10].Value);
                DamageAddForm IncomeAdd = new DamageAddForm(RowId, this, new MaterailsGui.MaterailsUserControl());
                string CurrentMaterialName = dataGridView.CurrentRow.Cells[1].Value.ToString();
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

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonEdit_Click(sender, e);
        }
    }
}
