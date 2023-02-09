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

namespace SMSystem.Gui.CustomersGui
{
    public partial class CustomerConscienceCardUserForm : Form
    {
        // Fields
        private readonly IDataHelper<ConscienceCard> _dataHelper;
        private readonly LoadingUser loading;
        private readonly int customerId;
        private readonly string customerName;
        private int MaterialId;
        private List<int> IdList = new List<int>();
        private Label labelEmptyData;
        private string searchItem;
        private DataTable dataTable;

        public int RowId { get; private set; }
        private ConscienceCard conscienceCard;
        private Materails material;

        // Constructores
        public CustomerConscienceCardUserForm(int CustomerId, string CustomerName)
        {
            InitializeComponent();
            labelEmptyData = ComponentsObject.Instance().LabelEmptyData();
            _dataHelper = (IDataHelper<ConscienceCard>)ContainerConfig.ObjectType("ConscienceCard");
            loading = LoadingUser.Instance();
            LoadData();
            customerId = CustomerId;
            customerName = CustomerName;

            // Set Customer Id and Name to View
            labelCustomerId.Text = customerId.ToString();
            labelFullName.Text = customerName;
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
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            buttonEdit_Click(sender, e);
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {

            AddCustomerConscienceCard customerAdd = new AddCustomerConscienceCard(0, this, customerId, customerName);
            customerAdd.Show();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.RowCount > 0)
            {
                RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
                AddCustomerConscienceCard customerAdd = new AddCustomerConscienceCard(RowId, this, customerId, customerName);
                customerAdd.Show();
            }
            else
            {
                MessageCollection.ShowEmptyDataMessage();
            }
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
                dataGridView.DataSource = await Task.Run(() => _dataHelper.GetData().Where(x=>x.CustomerId==customerId)
                .Select(x => new
                {
                    x.Id,
                    x.MaterialName,
                    x.Quantity,
                    x.OutComeNo,
                    x.OutComeDate,
                    x.ReciverName,
                    x.ReciverDate,
                    x.ReciverSign,
                    x.DepTransportName,
                    x.DepTransportReciverName,
                    x.DepTransportReciverDate,
                    x.DepTransportReciverSign,
                    x.AddDate
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
                    dataGridView.DataSource = await Task.Run(() => _dataHelper.Search(searchItem).Where(x => x.CustomerId == customerId).Select(x => new
                    {
                        x.Id,
                        x.MaterialName,
                        x.Quantity,
                        x.OutComeNo,
                        x.OutComeDate,
                        x.ReciverName,
                        x.ReciverDate,
                        x.ReciverSign,
                        x.DepTransportName,
                        x.DepTransportReciverName,
                        x.DepTransportReciverDate,
                        x.DepTransportReciverSign,
                        x.AddDate
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
                dataGridView.Columns[1].HeaderCell.Value = "اسم المادة";
                dataGridView.Columns[2].HeaderCell.Value = "الكمية";
                dataGridView.Columns[3].HeaderCell.Value = "رقم مستتند الادخال";
                dataGridView.Columns[4].HeaderCell.Value = "تاريخ مستند الادخال";
                dataGridView.Columns[5].HeaderCell.Value = "اسم المستلم";
                dataGridView.Columns[6].HeaderCell.Value = "تاريخ الاستلام";
                dataGridView.Columns[7].HeaderCell.Value = "التوقيع";
                dataGridView.Columns[8].HeaderCell.Value = "المنقول لها";
                dataGridView.Columns[9].HeaderCell.Value = "اسم المستلم";
                dataGridView.Columns[10].HeaderCell.Value = "تاريخ الاستلام";
                dataGridView.Columns[11].HeaderCell.Value = "التوقيع";
                dataGridView.Columns[12].HeaderCell.Value = "تاريخ الاضافة";

            }
            catch { }
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
            dataTable.Columns["DepName"].SetOrdinal(1);
            dataTable.Columns["DepName"].ColumnName = "اسم الوحدة";
            dataTable.Columns["MaterialName"].SetOrdinal(2);
            dataTable.Columns["MaterialName"].ColumnName = "اسم المادة";
            dataTable.Columns["Quantity"].SetOrdinal(3);
            dataTable.Columns["Quantity"].ColumnName = "الكمية";
            dataTable.Columns["OutComeNo"].SetOrdinal(4);
            dataTable.Columns["OutComeNo"].ColumnName = "رقم مستند الادخال";
            dataTable.Columns["OutComeDate"].SetOrdinal(5);
            dataTable.Columns["OutComeDate"].ColumnName = "تاريخ مستند الادخال";
            dataTable.Columns["ReciverName"].SetOrdinal(6);
            dataTable.Columns["ReciverName"].ColumnName = "اسم المستلم";
            dataTable.Columns["ReciverDate"].SetOrdinal(7);
            dataTable.Columns["ReciverDate"].ColumnName = "تاريخ الاستلام";
            dataTable.Columns["ReciverSign"].SetOrdinal(8);
            dataTable.Columns["ReciverSign"].ColumnName = "التوقيع";
            dataTable.Columns["DepTransportName"].SetOrdinal(9);
            dataTable.Columns["DepTransportName"].ColumnName = "الاسم المنقول له";
            dataTable.Columns["DepTransportReciverName"].SetOrdinal(10);
            dataTable.Columns["DepTransportReciverName"].ColumnName = "اسم المستلم  المنقول";
            dataTable.Columns["DepTransportReciverDate"].SetOrdinal(11);
            dataTable.Columns["DepTransportReciverDate"].ColumnName = "تاريخ الاستلام المنقول";
            dataTable.Columns["DepTransportReciverSign"].SetOrdinal(12);
            dataTable.Columns["DepTransportReciverSign"].ColumnName = "التوقيع المنقول ";
            dataTable.Columns["AddDate"].SetOrdinal(13);
            dataTable.Columns["AddDate"].ColumnName = "تاريخ الاضافة";


            // Remove unnesessary columns
            dataTable.Columns.Remove("CustomerId");
            dataTable.Columns.Remove("customers");
            // Accept Changes
            dataTable.AcceptChanges();
        }





        #endregion

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonEdit_Click(sender, e);
        }
    }
}
