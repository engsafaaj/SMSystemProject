
using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui.CustomersGui
{
    public partial class CustomerUserControl : UserControl
    {
        // Fields
        private readonly IDataHelper<Customers> _dataHelper;
        private readonly LoadingUser loading;
        private int RowId;
        private static CustomerUserControl _customerUser;
        private List<int> IdList = new List<int>();
        private Label labelEmptyData;
        private string searchItem;

        // Constructores
        public CustomerUserControl()
        {
            InitializeComponent();
            labelEmptyData = ComponentsObject.Instance().LabelEmptyData();
            _dataHelper = (IDataHelper<Customers>)ContainerConfig.ObjectType("Customer");
            loading = LoadingUser.Instance();
            LoadData();
        }

        #region Events
        private void buttonShowConsciencesRecords_Click(object sender, EventArgs e)
        {
            RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
            var CustomerName = Convert.ToString(dataGridView.CurrentRow.Cells[1].Value);
            CustomerConscienceCardUserForm customerConscienceCardUserForm = new CustomerConscienceCardUserForm(RowId, CustomerName);
            customerConscienceCardUserForm.Show();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CustomerAddForm customerAdd = new CustomerAddForm(0, this);
            customerAdd.Show();
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.RowCount > 0)
            {
                RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
                CustomerAddForm customerAdd = new CustomerAddForm(RowId, this);
                customerAdd.Show();
            }
            else
            {
                MessageCollection.ShowEmptyDataMessage();
            }
        }

        private  void buttonDelete_Click(object sender, EventArgs e)
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
                // Loading Data
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
            if (textBoxSearch.Text == string.Empty)
            {
                LoadData();
            }
            else
            {
                loading.Show();
                searchItem = textBoxSearch.Text;
                // Check if connection is available
                if (_dataHelper.IsDbConnect())
                {
                    // Loading Data
                    dataGridView.DataSource = await Task.Run(() => _dataHelper.Search(searchItem));
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
                if (row.Selected) IdList.Add(Convert.ToInt32(row.Cells[0].Value));
            }
        }
        private void SetDataGridViewColumns()
        {
            try
            {
                // Set Title
                dataGridView.Columns[0].HeaderCell.Value = "المعرف";
                dataGridView.Columns[1].HeaderCell.Value = "اسم العميل";
                dataGridView.Columns[2].HeaderCell.Value = "العنوان";
                dataGridView.Columns[3].HeaderCell.Value = "الهاتف";
                dataGridView.Columns[4].HeaderCell.Value = "ايميل";
                dataGridView.Columns[5].HeaderCell.Value = "وصف";
            }
            catch { }
            
            // Hide Columns
        }

        // Singleton Instance
        public static UserControl Instance()
        {
            return _customerUser ?? (new CustomerUserControl ());
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

      
    }
}
