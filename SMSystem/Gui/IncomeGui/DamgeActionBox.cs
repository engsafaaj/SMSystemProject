using SMSystem.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SMSystem.Gui.IncomeGui
{
    partial class DamgeActionBox : Form
    {
        private readonly IncomeUserControl incomeUserControl;
        private readonly double quntity;

        public DamgeActionBox(IncomeUserControl incomeUserControl, double Quntity)
        {
            InitializeComponent();
            this.incomeUserControl = incomeUserControl;
            quntity = Quntity;
            textBox1.Text = quntity.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            incomeUserControl.Quantity = Convert.ToDouble(textBox1.Text);
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[0-9]"))
            {
                MessageCollection.ShowInvalidValue();
                textBox1.Text = "1";
            }
        }
    }
}
