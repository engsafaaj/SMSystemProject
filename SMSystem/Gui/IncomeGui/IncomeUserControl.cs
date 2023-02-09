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

namespace SMSystem.Gui.IncomeGui
{
    public partial class IncomeUserControl : UserControl
    {
        // Fields
        private readonly IDataHelper<Income> _dataHelper;
        private readonly IDataHelper<Materails> _dataHelperForMaterial;
        private readonly IDataHelper<Damage> _dataHelperForDamag;
        private readonly IDataHelper<OutOfConscinesMaterials> _dataHelperForOutOfConscince;
        private readonly LoadingUser loading;
        private int MaterialId;
        private static IncomeUserControl _incomelsUser;
        private List<int> IdList = new List<int>();
        private Label labelEmptyData;
        private string searchItem;
        private DataTable dataTable;
        private Damage damage;

        public int RowId { get; private set; }
        public double Quantity { get; set; }

        private Income income;
        private Materails material;

        // Constructores
        public IncomeUserControl()
        {
            InitializeComponent();
            labelEmptyData = ComponentsObject.Instance().LabelEmptyData();
            _dataHelper = (IDataHelper<Income>)ContainerConfig.ObjectType("Income");
            _dataHelperForMaterial = (IDataHelper<Materails>)ContainerConfig.ObjectType("Materails");
            _dataHelperForDamag = (IDataHelper<Damage>)ContainerConfig.ObjectType("Damage");
            _dataHelperForOutOfConscince = (IDataHelper<OutOfConscinesMaterials>)ContainerConfig.ObjectType("OutOfConscinesMaterials");
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
        private void buttonDeleteFromMaterials_Click(object sender, EventArgs e)
        {
            try
            {
                SetIDSelcted();
                if (dataGridView.RowCount > 0)
                {
                    var result = MessageCollection.DeleteCompletedData();
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
                                    income = _dataHelper.GetData().Where(x => x.Id == RowId).First();
                                    material = _dataHelperForMaterial.GetData().Where(x => x.Id == income.MaterailId).First();
                                    material.Quantity = material.Quantity - income.Quantity;
                                    material.InCome = material.InCome - income.Quantity;
                                    material.TotalPrice = material.TotalPrice - income.TotalPrice;
                                    _dataHelperForMaterial.Edit(material);
                                    _dataHelper.Delete(RowId);
                                }

                            }
                            MessageCollection.ShowDeletNotification();
                            LoadData();
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
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.RowCount > 0)
                {
                    SetIDSelcted();
                    var result = MessageCollection.DamageAction();
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
            var qunatity = Convert.ToDouble(dataGridView.CurrentRow.Cells[5].Value);

            DamgeActionBox box = new DamgeActionBox(this, qunatity);
            var rs = box.ShowDialog();
            if (rs == DialogResult.OK)
            {
                MoveToDamge(Quantity);

            }

        }
        #endregion

        // Methods
        #region Methods
        public async void LoadData()
        {

            loading.Show();
            // Update Exp Date 
            UpdateExpDate();
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
            return _incomelsUser ?? (new IncomeUserControl());
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
                        incomeAdd.dateTimePickerExpData.Value = Convert.ToDateTime(dataGridView.CurrentRow.Cells[9].Value);
                    }
                }
            }
        }
        private void UpdateExpDate()
        {
            // Get List Icome Table Need To Update
            var currentData = DateTime.Now.Date;
            var IcomeNeedToUpdate = _dataHelper.GetData().Where(x => x.State == "متوفر" && x.ExpDate != x.AddedDate
              && Convert.ToDateTime(x.ExpDate) < currentData).ToList();
            // Loop into Incom Need To Update
            foreach (var IncomeTable in IcomeNeedToUpdate)
            {
                IncomeTable.State = "منتهي الصلاحية";
                _dataHelper.Edit(IncomeTable);
            }

        }
        private void MoveToDamgeTable()
        {
            if (_dataHelper.IsDbConnect())
            {
                // Get All info
                RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[10].Value);
                Income income = _dataHelper.Find(RowId);
                // Move it to damge table

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
            dataTable.Columns["Price"].ColumnName = "السعر" + Properties.Settings.Default.Currency;
            dataTable.Columns["TotalPrice"].SetOrdinal(7);
            dataTable.Columns["TotalPrice"].ColumnName = "الاجمالي" + Properties.Settings.Default.Currency;
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
            dataTable.Columns["IncomeDate"].SetOrdinal(13);
            dataTable.Columns["IncomeDate"].ColumnName = "تاريخ مستند الادخال";
            dataTable.Columns["State"].SetOrdinal(14);
            dataTable.Columns["State"].ColumnName = "الحالة";
            dataTable.Columns["User"].SetOrdinal(15);
            dataTable.Columns["User"].ColumnName = "المستخدم";
            dataTable.Columns["AddedDate"].SetOrdinal(16);
            dataTable.Columns["AddedDate"].ColumnName = "تاريخ الاضافة";
            dataTable.Columns["ExpDate"].SetOrdinal(17);
            dataTable.Columns["ExpDate"].ColumnName = "تاريخ الانتهاء";

            // Remove unnesessary columns
            dataTable.Columns.Remove("MaterailId");
            dataTable.Columns.Remove("Materails");
            dataTable.Columns.Remove("RectipImg");
            // Accept Changes
            dataTable.AcceptChanges();
        }




        #endregion

        private void buttonOutConsceince_Click(object sender, EventArgs e)
        {
            var qunatity = Convert.ToDouble(dataGridView.CurrentRow.Cells[5].Value);

            DamgeActionBox box = new DamgeActionBox(this, qunatity);
            var rs = box.ShowDialog();
            if (rs == DialogResult.OK)
            {
                MoveToOutOfConscince(Quantity);

            }
        }


        public void MoveToDamge(double Quantity)
        {
            try
            {
                if (dataGridView.RowCount > 0)
                {
                    var result = MessageCollection.OnDamgeAction();
                    if (result == true)
                    {
                        loading.Show();
                        if (_dataHelper.IsDbConnect())
                        {
                            RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[10].Value);

                            income = _dataHelper.GetData().Where(x => x.Id == RowId).First();
                            damage = new Damage
                            {
                                AddedDate = income.AddedDate,
                                Code = income.Code,
                                ExpDate = income.ExpDate,
                                InterNo = income.InterNo,
                                Name = income.Name,
                                Price = income.Price,
                                Quantity = Quantity,
                                ReciptNo = income.ReciptNo,
                                RectipDate = income.RectipDate,
                                RectipImg = income.RectipImg,
                                RectipName = income.RectipName,
                                State = "تالف",
                                Supplier = income.Supplier,
                                Store = income.Store,
                                TotalPrice = income.TotalPrice,
                                Unit = income.Unit,
                                User = income.User
                            };
                            _dataHelperForDamag.Add(damage);
                            income.Quantity = income.Quantity - Quantity;
                            if (income.Quantity <= 0)
                            {
                                _dataHelper.Delete(RowId);

                            }
                            else
                            {
                                _dataHelper.Edit(income);

                            }


                            MessageCollection.ShowDeletNotification();
                            LoadData();


                        }

                        else
                        {
                            MessageCollection.ShowSlectRowsNotification();

                        }
                    }
                    else
                    {
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

        public void MoveToOutOfConscince(double Quantity)
        {
            try
            {
                if (dataGridView.RowCount > 0)
                {
                    var result = MessageCollection.OnConscinceAction();
                    if (result == true)
                    {
                        loading.Show();
                        if (_dataHelper.IsDbConnect())
                        {
                            RowId = Convert.ToInt32(dataGridView.CurrentRow.Cells[10].Value);

                            income = _dataHelper.GetData().Where(x => x.Id == RowId).First();
                            var outOfConscince = new OutOfConscinesMaterials
                            {
                                AddedDate = income.AddedDate,
                                Code = income.Code,
                                ExpDate = income.ExpDate,
                                InterNo = income.InterNo,
                                Name = income.Name,
                                Price = income.Price,
                                Quantity = Quantity,
                                ReciptNo = income.ReciptNo,
                                RectipDate = income.RectipDate,
                                RectipImg = income.RectipImg,
                                RectipName = income.RectipName,
                                State = "خارج الذمة",
                                Supplier = income.Supplier,
                                Store = income.Store,
                                TotalPrice = income.TotalPrice,
                                Unit = income.Unit,
                                User = income.User
                            };
                            _dataHelperForOutOfConscince.Add(outOfConscince);
                            income.Quantity = income.Quantity - Quantity;
                            if (income.Quantity <= 0)
                            {
                                _dataHelper.Delete(RowId);

                            }
                            else
                            {
                                _dataHelper.Edit(income);

                            }


                            MessageCollection.ShowDeletNotification();
                            LoadData();


                        }

                        else
                        {
                            MessageCollection.ShowSlectRowsNotification();

                        }
                    }
                    else
                    {
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

    }
}

