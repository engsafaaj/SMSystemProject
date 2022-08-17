using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui.StoresGui
{
    public partial class StoreUserControl : UserControl
    {
        // Fields
        private IDataHelper<Stores> _dataHelper;
        private List<Stores> localData;
        private LoadingUser loading;
        private int RowId;

        // Constructores
        public StoreUserControl()
        {
            InitializeComponent();
            loading = new LoadingUser();
            _dataHelper = (IDataHelper<Stores>)ContainerConfig.ObjectType("Store");
            LoadData();
        }

        #region Events
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            StoreAddForm storeAdd = new StoreAddForm(0, this);
            storeAdd.Show();
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.RowCount > 0)
            {
                RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);

                StoreAddForm storeAdd = new StoreAddForm(RowId, this);
                storeAdd.Show();
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
                    RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
                    var result = MessageCollection.DeleteActtion();
                    if (result == true)
                    {
                        loading.Show();
                        if (await Task.Run(() => _dataHelper.IsDbConnect()))
                        {
                            await Task.Run(() => _dataHelper.Delete(RowId));
                            LoadData();
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

        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        // Methods
        public async void LoadData()
        {
            loading.Show();
            // Check if connection is available
            if (await Task.Run(() => _dataHelper.IsDbConnect()))
            {
                // Loading Data
                await Task.Run(() =>
                {
                    localData = _dataHelper.GetData();
                });
                // Set Data to view
                dataGridView.DataSource = localData;
                localData = null;
                SetDataGridViewColumns();
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
            loading.Hide();
        }

        public async void LoadDataForSearch()
        {
            loading.Show();
            var searchItem = textBoxSearch.Text;
            // Check if connection is available
            if (await Task.Run(() => _dataHelper.IsDbConnect()))
            {
                // Loading Data
                await Task.Run(() =>
                {
                    localData = _dataHelper.Search(searchItem);
                });
                // Set Data to view
                dataGridView.DataSource = localData;
                localData = null;
                SetDataGridViewColumns();
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
            loading.Hide();
        }
        private void SetDataGridViewColumns()
        {
            // Set Title
            dataGridView.Columns[0].HeaderCell.Value = "المعرف";
            dataGridView.Columns[1].HeaderCell.Value = "اسم المخزن";
            dataGridView.Columns[2].HeaderCell.Value = "الوصف";
            // Hide Columns
        }


    }
}
