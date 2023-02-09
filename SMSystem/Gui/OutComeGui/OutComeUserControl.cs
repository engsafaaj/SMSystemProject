using FastMember;
using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using SMSystem.Gui.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui.OutComeGui
{
    public partial class OutComeUserControl : UserControl
    {
        // Fields
        private readonly IDataHelper<OutCome> _dataHelper;
        private readonly IDataHelper<Materails> _dataHelperForMaterial;
        private readonly LoadingUser loading;
        private static OutComeUserControl _iutComelsUser;
        private List<int> IdList = new List<int>();
        private Label labelEmptyData;
        private string searchItem;
        private DataTable dataTable;

        public int RowId { get; private set; }

        // Constructores
        public OutComeUserControl()
        {
            InitializeComponent();
            labelEmptyData = ComponentsObject.Instance().LabelEmptyData();
            _dataHelper = (IDataHelper<OutCome>)ContainerConfig.ObjectType("OutCome");
            _dataHelperForMaterial = (IDataHelper<Materails>)ContainerConfig.ObjectType("Materails");
            loading = LoadingUser.Instance();
            LoadData();
        }

        #region Events
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OutComeAddForm OutComeAdd = new OutComeAddForm(0, this, new MaterailsGui.MaterailsUserControl());
            OutComeAdd.Show();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.RowCount > 0)
            {
                RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
                OutComeAddForm OutComeAdd = new OutComeAddForm(RowId, this, new MaterailsGui.MaterailsUserControl());
                OutComeAdd.Show();
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
                    var result = MessageCollection.DeleteActtionForOutCome();
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

        private void buttonDamge_Click(object sender, EventArgs e)
        {
            if (dataGridView.RowCount > 0)
            {
                RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
                ReceiptUserControl receiptUserControl = new ReceiptUserControl(RowId);
                receiptUserControl.Show();
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
            // Update Exp Date 
            // Check if connection is available
            if (_dataHelper.IsDbConnect())
            {
                // Loading Data and Set Data
                dataGridView.DataSource = await Task.Run(() => _dataHelper.GetData()
                .Select(x => new
                {
                    x.Id,
                    x.OuterNo,
                    x.OutDate,
                    x.Customer,
                    x.MaterialNo,
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
                        x.Id,
                        x.OuterNo,
                        x.OutDate,
                        x.Customer,
                        x.MaterialNo,
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
                dataGridView.Columns[1].HeaderCell.Value = "رقم مستند الاخراج";
                dataGridView.Columns[2].HeaderCell.Value = "تاريخ مستند الاخراج";
                dataGridView.Columns[3].HeaderCell.Value = "المستلم";
                dataGridView.Columns[4].HeaderCell.Value = "المواد";
                dataGridView.Columns[5].HeaderCell.Value = "تاريخ الاضافة";

                // Hide Columns

            }
            catch { }
        }

        public static UserControl Instance()
        {
            return _iutComelsUser ?? (new OutComeUserControl());
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
            dataTable.Columns["OuterNo"].SetOrdinal(1);
            dataTable.Columns["OuterNo"].ColumnName = "رقم مستند الاخراج";
            dataTable.Columns["OutDate"].SetOrdinal(2);
            dataTable.Columns["OutDate"].ColumnName = "تاريخ مستند الاخراج";
            dataTable.Columns["Customer"].SetOrdinal(3);
            dataTable.Columns["Customer"].ColumnName = "العميل/ المستلم";
            dataTable.Columns["MaterialNo"].SetOrdinal(4);
            dataTable.Columns["MaterialNo"].ColumnName = "عدد المواد";
            dataTable.Columns["AddedDate"].SetOrdinal(5);
            dataTable.Columns["AddedDate"].ColumnName = "تاريخ الاضافة";
            dataTable.Columns["User"].SetOrdinal(6);
            dataTable.Columns["User"].ColumnName = "المستخدم ";
        
            // Remove unnesessary columns
            dataTable.Columns.Remove("OutComeMaterails");
            // Accept Changes
            dataTable.AcceptChanges();
        }

        #endregion


    }
}
