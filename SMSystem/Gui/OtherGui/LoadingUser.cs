using System.Windows.Forms;

namespace SMSystem.Gui.OtherGui
{
    public partial class LoadingUser : Form
    {
        private static LoadingUser _Instacne;
        protected LoadingUser()
        {
            InitializeComponent();
        }
        public static LoadingUser Instance()
        {
            return _Instacne ?? (_Instacne = new LoadingUser());
        }
    }
}
