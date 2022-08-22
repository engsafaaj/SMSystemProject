using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMSystem.Gui.OtherGui
{
    public partial class LoadingUser : Form
    {
        private static LoadingUser _Instacne;
        protected  LoadingUser()
        {
            InitializeComponent();
        }
        public static LoadingUser Instance()
        {
            return _Instacne ?? (_Instacne = new LoadingUser());
        }
    }
}
