
using System.Linq;
using System.Windows.Forms;

namespace SMSystem.Code
{
    public class MainClass
    {
        // Fields
        Main _main;
        // Constructore
        public MainClass(Main main)
        {
            _main = main;

        }

        // Methods
        public void LoadPage(UserControl Page)
        {
            // Select Old Page to clear it
            var oldPage = _main.panelContainer.Controls.OfType<UserControl>().FirstOrDefault();
            if (oldPage != null)
            {
                _main.Controls.Remove(oldPage);
                oldPage.Dispose();
            }
            // Add New Page
            Page.Dock = DockStyle.Fill;
            _main.panelContainer.Controls.Add(Page);
        }

      
    }
}
