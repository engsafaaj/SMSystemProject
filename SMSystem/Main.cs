using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMSystem.Code;
using SMSystem.Gui.Home;
using SMSystem.Gui.StoresGui;

namespace SMSystem
{
    public partial class Main : Form
    {
        // Fields
        MainClass mainClass;

        // Constructors
        public Main()
        {
            InitializeComponent();
            mainClass = new MainClass(this);
        }

        // Events
        private void Main_Load(object sender, EventArgs e)
        {
            // Load Home Page
            mainClass.LoadPage(new HomeUserControl());
        }

        private void buttonhome_Click(object sender, EventArgs e)
        {
            // Load Home Page
            mainClass.LoadPage(new HomeUserControl());
        }

        private void buttonStore_Click(object sender, EventArgs e)
        {
            // Load Store Page
            mainClass.LoadPage(new StoreUserControl());
        }
    }
}
