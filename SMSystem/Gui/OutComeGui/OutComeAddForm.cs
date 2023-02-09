using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using SMSystem.Gui.MaterailsGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SMSystem.Gui.SuppliersGui;
using SMSystem.Gui.CustomersGui;

namespace SMSystem.Gui.OutComeGui
{
    public partial class OutComeAddForm : Form
    {
        // Fileds
        #region Fileds
        private int id;
        private readonly OutComeUserControl OutComeUserControl;
        private readonly MaterailsUserControl materailsUserControl;
        private readonly Label labelEmptyData;
        private readonly LoadingUser loading;
        public string currnetCode;
        public string currnetMaterialName;
        public bool isAddDirectly;
        private IDataHelper<OutCome> _dataHelper;
        private IDataHelper<Materails> _dataHelperforMaterail;
        private IDataHelper<Customers> _dataHelperforCustomer;
        private IDataHelper<OutComeMaterail> _dataHelperforOutComeMaterials;
        private IDataHelper<ConscienceCard> _dataHelperforConscincesSelf;
        private OutCome income;
        private int ResultAddOrEdit;
        private string MaterailName;
        private bool IsCodeExcit;
        public int MaterialId;
        private Materails materails;
        private OutComeMaterail outComeMaterail;
        private List<int> IdList = new List<int>();
        private int RowId;
        public int OutComeMaterialId;
        private OutCome outCome;
        bool IsSaved;
        private ConscienceCard conscienceCard;
        private int CustomerId;
        #endregion

        // Constructores
        public OutComeAddForm(int Id, OutComeUserControl outComeUserControl, MaterailsUserControl materailsUserControl)
        {
            InitializeComponent();
            // Set Property Instance
            id = Id;
            this.OutComeUserControl = outComeUserControl;
            this.materailsUserControl = materailsUserControl;
            labelEmptyData = ComponentsObject.Instance().LabelEmptyData();
            loading = LoadingUser.Instance();
            _dataHelper = (IDataHelper<OutCome>)ContainerConfig.ObjectType("OutCome");
            _dataHelperforMaterail = (IDataHelper<Materails>)ContainerConfig.ObjectType("Materails");
            _dataHelperforCustomer = (IDataHelper<Customers>)ContainerConfig.ObjectType("Customer");
            _dataHelperforOutComeMaterials = (IDataHelper<OutComeMaterail>)ContainerConfig.ObjectType("OutComeMaterail");
            _dataHelperforConscincesSelf = (IDataHelper<ConscienceCard>)ContainerConfig.ObjectType("ConscienceCard");

            label16.Text = label16.Text + Properties.Settings.Default.Currency;
            // Set DataFileds for Edit void
            if (id > 0)
            {
                SetDataToFileds();
                AutoLoadMaterailData();
                OutComeMaterialId = id;
            }
        }

        // Events
        #region Events
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // check requirments of fileds
            if (IsRequiredFiledEmpty())
            {
                MessageCollection.ShowEmptyFields();
            }
            else
            {
                loading.Show();
                // Check if add or edit
                SetCodeExcit();
                if (id == 0)
                {
                    // Check if Code is Excit
                    if (IsCodeExcit == true)
                    {
                        MessageCollection.ShowDuplicateData();
                    }
                    else
                    {
                        // Add
                        AddData();
                    }
                }
                else
                {
                    // Edit
                    EditData();
                }
                loading.Hide();
                IsCodeExcit = false;
            }
        }

        private void buttonAddMaterial_Click(object sender, EventArgs e)
        {
            // check requirments of fileds
            if (textBoxQuantity.Text == "")
            {
                MessageCollection.ShowEmptyFields();
            }
            else
            {
                loading.Show();

                // Add
                AddDataMaterial();

              

                loading.Hide();
            }
        }

        private void OutComeAddForm_Load(object sender, EventArgs e)
        {
            LoadMaterailsName();
            LoadSupplierName();
            LoadMaterailsCode();

            // Set Last Enter Number
            if (id == 0)
            {
                SetOutComeMaterialId();
            }

            textBoxInterNo.Text = GetLastEnterNumber().ToString();

            UpdateOutComeMaterailData();

            CalcuateTotalPrice();

        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxQuantity.Text, "^[0-9]"))
            {
                MessageCollection.ShowInvalidValue();
                textBoxQuantity.Text = "1";
            }
            else
            {
                CalcuateTotalPrice();
            }

        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxPrice.Text, "^[0-9]"))
            {
                MessageCollection.ShowInvalidValue();
                textBoxPrice.Text = "0";
            }
            else
            {
                CalcuateTotalPrice();
            }
        }

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            SetMaterailIdByName();
            AutoLoadMaterailData();
        }

        private void textBoxCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isAddDirectly)
            {
                SetMaterailIdByCode();
                AutoLoadMaterailData();
            }
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isAddDirectly)
            {
                SetMaterailIdByName();
                AutoLoadMaterailData();
            }
        }

        private void textBoxInterNo_TextChanged_1(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxInterNo.Text, "^[0-9]"))
            {
                MessageCollection.ShowInvalidValue();
                textBoxInterNo.Text = "0";
            }
        }

        private void linkLabelNewSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerAddForm customerAddForm = new CustomerAddForm(0, new CustomerUserControl());
            customerAddForm.Show();
            customerAddForm.FormClosed += (sender, EventArgs) =>
              {
                  LoadSupplierName();
              };

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

                        RowId =Convert.ToInt32( dataGridView.CurrentRow.Cells[0].Value);
                        _dataHelperforOutComeMaterials.Delete(RowId);

                        try
                        {
                            var materialName = dataGridView.CurrentRow.Cells[1].Value.ToString();
                            MaterialId = _dataHelperforMaterail.GetData().Where(x => x.Name == materialName).Select(x => x.Id).First();
                        }
                        catch { }

                        double RecQuanttiy = Convert.ToDouble(dataGridView.CurrentRow.Cells[2].Value);
                        RecoverQuantityToMaterial(RecQuanttiy, MaterialId);
                        UpdateOutComeMaterailData();
                        MessageCollection.ShowDeletNotification();

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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            UpdateOutComeMaterailData();
        }

        private void OutComeAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsSaved && dataGridView.RowCount > 0 && id == 0)
            {
                MessageCollection.ShowIsSavedData();
            }
        }

        #endregion

        // Methods
        #region Methods
        private void AddData()
        {
            // Set Data
            SetDataForAdd();
            // Send data and get result
            ResultAddOrEdit = _dataHelper.Add(outCome);
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfully
            {
                // Upate Material Data
                // Show Notifiction
                MessageCollection.ShowAddNotification();
                ClearFileds();
                // Updat View
                OutComeUserControl.LoadData();
                // Set Last Enter Number
                textBoxInterNo.Text = GetLastEnterNumber().ToString();
                IsSaved = true;
                Close();
            }
            else // End with database error
            {
                MessageCollection.ShowServerMessage();
            }
        }

        private void EditData()
        {
            // Set Data
            SetDataForEdit();
            ResultAddOrEdit = _dataHelper.Edit(outCome);
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Show Notification
                MessageCollection.ShowEditNotification();
                // Updat View
                OutComeUserControl.LoadData();
                IsSaved = true;
                Close();
            }
            else // End with database error
            {
                MessageCollection.ShowServerMessage();
            }
        }

        private void ClearFileds()
        {
            //textBoxNewCode.Text = string.Empty;
        }

        private  void SetDataToFileds()
        {
            if (_dataHelper.IsDbConnect())
            {
                outCome = _dataHelper.Find(id);
                if (outCome != null)
                {
                    // Set Data
                    comboBoxSupplier.SelectedItem = outCome.Customer;
                    OutComeMaterialId = outCome.Id;
                    dateTimePickerReciptDate.Value = outCome.OutDate;
                    textBoxInterNo.Text = outCome.OuterNo.ToString();
                }

            }
            else
            {
                MessageCollection.ShowServerMessage();

            }
            income = null;
        }

        private void SetDataForAdd()
        {
            outCome = new OutCome
            {
                AddedDate = DateTime.Now.Date,
                Customer = comboBoxSupplier.Text.ToString(),
                OuterNo = Convert.ToInt32(textBoxInterNo.Text),
                OutDate = dateTimePickerReciptDate.Value.Date,
                MaterialNo = Convert.ToInt32(dataGridView.RowCount),
                User = Properties.Settings.Default.User
            };
        }

        private void SetDataForEdit()
        {
            outCome = new OutCome
            {
                Id = this.id,
                AddedDate = DateTime.Now.Date,
                Customer = comboBoxSupplier.Text.ToString(),
                OuterNo = Convert.ToInt32(textBoxInterNo.Text),
                OutDate = dateTimePickerReciptDate.Value.Date,
                MaterialNo = Convert.ToInt32(dataGridView.RowCount),
                User = Properties.Settings.Default.User
            };
        }

        private bool IsRequiredFiledEmpty()
        {
            if (textBoxCode.Text == string.Empty
                || comboBoxName.SelectedItem == null
                || textBoxInterNo.Text == string.Empty
                || comboBoxSupplier.SelectedItem == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LoadMaterailsName()
        {
            if (_dataHelperforMaterail.IsDbConnect())
            {
                // Load List Of Materails Name
                var ListOfMaterailName =
                _dataHelperforMaterail.GetData().Select(x => x.Name).ToList();
                // Set List and Enable Auto Complete Featrue
                AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
                autoCompleteString.AddRange(ListOfMaterailName.ToArray());
                comboBoxName.AutoCompleteCustomSource = autoCompleteString;
                comboBoxName.DataSource = ListOfMaterailName;
                // Clear Variables
                ListOfMaterailName = null;
                autoCompleteString = null;
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }

        private  void LoadMaterailsCode()
        {
            if (_dataHelperforMaterail.IsDbConnect())
            {
                // Load List Of Code Name
                var ListOfMaterailCode =
                _dataHelperforMaterail.GetData().Select(x => x.Code).ToList();
                // Set List and Enable Auto Complete Featrue
                AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
                autoCompleteString.AddRange(ListOfMaterailCode.ToArray());
                textBoxCode.AutoCompleteCustomSource = autoCompleteString;
                textBoxCode.DataSource = ListOfMaterailCode;
                // Clear Variables
                ListOfMaterailCode = null;
                autoCompleteString = null;
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }

        private void LoadSupplierName()
        {
            if (_dataHelperforCustomer.IsDbConnect())
            {
                // Load List Of Materails Name
                var ListOfMaterailName =
                _dataHelperforCustomer.GetData().Select(x => x.Name).ToList();
                // Set List and Enable Auto Complete Feature
                AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
                autoCompleteString.AddRange(ListOfMaterailName.ToArray());
                comboBoxSupplier.AutoCompleteCustomSource = autoCompleteString;
                comboBoxSupplier.DataSource = ListOfMaterailName;
                // Clear Variables
                ListOfMaterailName = null;
                autoCompleteString = null;
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }

        private void SetMaterailIdByName()
        {
            MaterailName = comboBoxName.SelectedItem.ToString();
            if (_dataHelperforMaterail.IsDbConnect())
            {
                MaterialId = _dataHelperforMaterail.GetData()
                .Where(x => x.Name == MaterailName).Select(x => x.Id).First();
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
        }

        private void SetMaterailIdByCode()
        {
            if (comboBoxName.DataSource != null)
            {
                var Code = textBoxCode.Text;
                if (_dataHelperforMaterail.IsDbConnect())
                {
                    MaterialId = _dataHelperforMaterail.GetData()
                    .Where(x => x.Code == Code).Select(x => x.Id).First();
                }
                else
                {
                    MessageCollection.ShowServerMessage();
                }
            }
        }

        private void CalcuateTotalPrice()
        {
            try
            {
                double Quantity = Convert.ToDouble(textBoxQuantity.Text);
                double UnitPrice = Convert.ToDouble(textBoxPrice.Text);
                double TotalPrice = Quantity * UnitPrice;
                textBoxTotalPrice.Text = TotalPrice.ToString("0.00");
            }
            catch { }

        }

        private void SetCodeExcit()
        {
            if (_dataHelper.IsDbConnect())
            {
                if (_dataHelper.IsDbConnect())
                {
                    var NewCode = Convert.ToInt32(textBoxInterNo.Text);
                    var datacheck = _dataHelper.GetData().Where(x => x.OuterNo == NewCode).ToList();
                    if (datacheck.Count > 0)
                    {
                        IsCodeExcit = true;
                    }
                    else
                    {
                        IsCodeExcit = false;
                    }
                    datacheck = null;
                }
                else
                {
                    MessageCollection.ShowServerMessage();
                }
            }
            else
            {
                MessageCollection.ShowServerMessage();
                IsCodeExcit = false;
            }
        }

        private void AutoLoadMaterailData()
        {
            if (_dataHelperforMaterail.IsDbConnect())
            {
                if (MaterialId > 0)
                {
                    // Load Data
                    materails = _dataHelperforMaterail.Find(MaterialId);
                    // Assign Data
                    if (materails != null)
                    {
                        textBoxCode.Text = materails.Code;
                        textBoxPrice.Text = materails.Price.ToString();
                        textBoxStore.Text = materails.Store;
                        textBoxCurrentQuanttiy.Text = materails.Quantity.ToString();
                        textBoxUnit.Text = materails.Unit;
                        comboBoxName.SelectedItem = materails.Name;
                        textBoxIncome.Text = materails.InCome.ToString();
                    }
                }
            }
        }

        private int GetLastEnterNumber()
        {
            if (_dataHelper.IsDbConnect())
            {
                return _dataHelper.GetData().Select(x => x.OuterNo).LastOrDefault() + 1;
            }
            else { return 0; }
        }

        #endregion


        #region OutCome Materials Methods
        private void AddDataMaterial()
        {
            // Check of Materials if Exict
            if (IsMaterialAvailable())
            {
                // Set Data
                SetDataForAddMaterial();
                // Send data and get result
                ResultAddOrEdit =  _dataHelperforOutComeMaterials.Add(outComeMaterail);
                // check the result of proccess
                if (ResultAddOrEdit == 1) // Seccessfully
                {
                    // Upate Material Data
                    RecoverQuantityToMaterial(Convert.ToDouble(textBoxQuantity.Text) * -1, MaterialId);
                    UpdateOutComeMaterailData();
                    // Show Notifiction
                    MessageCollection.ShowAddNotification();
                    // Add to Consciense Card
                    if (checkBoxSelfCard.Checked == false)
                    {
                        AddToConscienceCard();
                    }
                }
                else // End with database error
                {
                    MessageCollection.ShowServerMessage();
                }
            }
            else
            {
                MessageCollection.ShowQuantityMessage();
            }


        }

        private void UpdateOutComeMaterailData()
        {
            loading.Show();
            // Check if connection is available
            if ( _dataHelperforOutComeMaterials.IsDbConnect())
            {
                // Loading Data and Set Data
                dataGridView.DataSource =  _dataHelperforOutComeMaterials.GetData().Where(x => x.MaterialId == OutComeMaterialId)
                .Select(x => new
                {
                    x.Id,
                    x.MaterialName,
                    x.Quantity,
                    x.Price,
                    x.TotalPrice
                }
                ).ToList();
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

        private void SetDataForAddMaterial()
        {
            outComeMaterail = new OutComeMaterail
            {
                MaterialId = OutComeMaterialId,
                MaterialName = comboBoxName.Text,
                Quantity = Convert.ToDouble(textBoxQuantity.Text),
                Price = Convert.ToDouble(textBoxPrice.Text),
                TotalPrice = Convert.ToDouble(textBoxTotalPrice.Text),

            };
        }

        private void SetDataGridViewColumns()
        {
            try
            {
                // Set Title
                dataGridView.Columns[1].HeaderCell.Value = "اسم المادة";
                dataGridView.Columns[2].HeaderCell.Value = "الكمية";
                dataGridView.Columns[3].HeaderCell.Value = "السعر"+Properties.Settings.Default.Currency;
                dataGridView.Columns[4].HeaderCell.Value = "الاجمالي" + Properties.Settings.Default.Currency;

                // Hide Columns
                dataGridView.Columns[0].Visible = false;

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

        private bool IsMaterialAvailable()
        {
            double availabeQuantity = Convert.ToDouble(textBoxCurrentQuanttiy.Text);
            double NewQuantity = Convert.ToDouble(textBoxQuantity.Text);
            if (textBoxCurrentQuanttiy.Text == "0" || NewQuantity > availabeQuantity)
            {
                return false;
            }
            else
            {
                return true;
            }
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

        private void RecoverQuantityToMaterial(double Quantity, int materialId)
        {
            materails = _dataHelperforMaterail.Find(materialId);
            materails.Quantity = materails.Quantity + Quantity;
            materails.OutCome = materails.OutCome + (Quantity * -1);
            materails.TotalPrice = materails.Price * materails.Quantity;
            ResultAddOrEdit = _dataHelperforMaterail.Edit(materails);
            if (ResultAddOrEdit == 1)
            {
                MessageCollection.ShowDeletNotification();
                AutoLoadMaterailData();
            }
        }

        private void SetOutComeMaterialId()
        {
            var localid = _dataHelper.GetData().Select(x => x.Id).FirstOrDefault();
            if (localid > 0)
            {
                OutComeMaterialId = _dataHelper.GetData().Select(x => x.Id).LastOrDefault() + 1;
            }
            else
            {
                var oucome = new OutCome
                {
                    Customer = " ",
                    AddedDate = DateTime.Now.Date,
                    MaterialNo = 0,
                    OutDate = DateTime.Now.Date,
                    OuterNo = 0,
                    User = "",
                };
                _dataHelper.Add(oucome);
                OutComeMaterialId = _dataHelper.GetData().Select(x => x.Id).LastOrDefault();
                id = OutComeMaterialId;
            }
        }

        #endregion

        private void checkBoxSelfCard_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelfCard.Checked == true)
            {
                ComboBoxCard.Enabled = false;

            }
            else
            {
                ComboBoxCard.Enabled = true;

            }
        }

        private async void AddToConscienceCard()
        {
            // Set Data
            SetDataForAddConscienceCard();
            // Send data and get result
            ResultAddOrEdit = await Task.Run(() => _dataHelperforConscincesSelf.Add(conscienceCard));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfully
            {

                // Show Notifiction
                MessageCollection.ShowAddNotification();
                ClearFileds();

            }
            else // End with database error
            {
                MessageCollection.ShowServerMessage();
            }
        }

        private void SetDataForAddConscienceCard()
        {
            var customerName = comboBoxSupplier.SelectedItem.ToString();
            CustomerId = _dataHelperforCustomer.GetData().Where(x => x.Name == customerName).Select(x => x.Id).First();
            conscienceCard = new ConscienceCard
            {
                AddDate = DateTime.Now.Date,
                CustomerId = CustomerId,
                DepName = comboBoxSupplier.Text,
                DepTransportName = "",
                DepTransportReciverDate = DateTime.Now.Date,
                DepTransportReciverName = "",
                DepTransportReciverSign = "",
                MaterialName = comboBoxName.Text,
                OutComeDate = dateTimePickerReciptDate.Value.Date,
                OutComeNo = Convert.ToInt32(textBoxInterNo.Text),
                Quantity = Convert.ToInt32(textBoxQuantity.Text),
                ReciverDate = DateTime.Now.Date,
                ReciverName = ComboBoxCard.Text,
                ReciverSign = ComboBoxCard.Text,
            };
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
