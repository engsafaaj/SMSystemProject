using ClosedXML.Excel;
using FastMember;
using SMSystem.Core;
using SMSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMSystem.Gui.OtherGui
{
    public partial class PrintDialogForm : Form
    {
        // For Test
        private readonly IDataHelper<Income> _dataHelper;

        //
        private readonly DataTable dataTable;
        private MemoryStream ma;

        public PrintDialogForm(DataTable dataTable)
        {
            InitializeComponent();
            _dataHelper = new IncomeEntity();
            this.dataTable = dataTable;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonExportExel_Click(object sender, EventArgs e)
        {
            ExportCSVFile(dataTable);
        }

        private void buttonPrintView_Click(object sender, EventArgs e)
        {
            ExportWordFile(dataTable);
        }


        private void ExportCSVFile(DataTable dTable)
        {
            // Define Open File Dialog
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "xlsx";
            saveFile.AddExtension = true;
            saveFile.Filter = "Excel File (.xlsx)|*.xlsx";
            saveFile.Title = "تصدير ملف اكسل";
            saveFile.RestoreDirectory = true;
            var result = saveFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook xLWorkbook = new XLWorkbook())
                    {
                        xLWorkbook.AddWorksheet(dTable, "Data");
                        using (MemoryStream ma = new MemoryStream())
                        {
                            xLWorkbook.SaveAs(ma);
                            File.WriteAllBytes(saveFile.FileName, ma.ToArray());
                        }

                    }
                }
                catch { }
            }

        }

        private void ExportWordFile(DataTable dTable)
        {
            // Define Open File Dialog
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "doc";
            saveFile.AddExtension = true;
            saveFile.Filter = "Word File (.doc)|*.doc";
            saveFile.Title = "تصدير ملف ورد";
            saveFile.RestoreDirectory = true;
            var result = saveFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook xLWorkbook = new XLWorkbook())
                    {
                        xLWorkbook.AddWorksheet(dTable, "Data");
                        using (MemoryStream ma = new MemoryStream())
                        {
                            xLWorkbook.SaveAs(ma);
                            File.WriteAllBytes(saveFile.FileName, ma.ToArray());
                        }

                    }
                }
                catch { }
            }

        }

    }
}
