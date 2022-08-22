﻿using SMSystem.Code;
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
        private readonly IDataHelper<Stores> _dataHelper;
        private List<Stores> localData;
        private readonly LoadingUser loading;
        private int RowId;
        private static StoreUserControl _storeUser;
        private List<int> IdList = new List<int>();
        private Label labelEmptyData;

        // Constructores
        protected StoreUserControl()
        {
            InitializeComponent();
            labelEmptyData = ComponentsObject.Instance().LabelEmptyData();
            _dataHelper = (IDataHelper<Stores>)ContainerConfig.ObjectType("Store");
            loading = LoadingUser.Instance();
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
                    SetIDSelcted();
                    var result = MessageCollection.DeleteActtion();
                    if (result == true)
                    {
                        loading.Show();
                        if (await Task.Run(() => _dataHelper.IsDbConnect()))
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
            // Show Empty Label Data
            ShowLabelIfEmptyData();

        }

        // Get a List of Id for selcted rows
        private void SetIDSelcted()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                IdList.Add(Convert.ToInt32(row.Cells[0].Value));
            }
        }
        private void SetDataGridViewColumns()
        {
            // Set Title
            dataGridView.Columns[0].HeaderCell.Value = "المعرف";
            dataGridView.Columns[1].HeaderCell.Value = "اسم المخزن";
            dataGridView.Columns[2].HeaderCell.Value = "الوصف";
            // Hide Columns
        }

        // Singleton Instance
        public static UserControl Instance()
        {
            return _storeUser ?? (new StoreUserControl());
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
