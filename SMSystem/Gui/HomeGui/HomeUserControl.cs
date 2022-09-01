using System.Windows.Forms;

namespace SMSystem.Gui.Home
{
    public partial class HomeUserControl : UserControl
    {

        private static HomeUserControl _HomeUserControl;
        public HomeUserControl()
        {
            InitializeComponent();
        }
        public static HomeUserControl Instance()
        {
            return _HomeUserControl ?? (new HomeUserControl());
        }
    }
}
