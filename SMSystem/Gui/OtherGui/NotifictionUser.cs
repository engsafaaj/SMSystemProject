using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMSystem.Gui.OtherGui
{
    public partial class NotifictionUser : Form
    {
        public NotifictionUser(string Caption)
        {
            InitializeComponent();
            labelNotifictionCatption.Text = Caption;
            timerhide.Interval = Properties.Settings.Default.NotificationTime;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
