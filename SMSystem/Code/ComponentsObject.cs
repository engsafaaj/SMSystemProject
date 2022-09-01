using System.Windows.Forms;

namespace SMSystem.Code
{
    public class ComponentsObject
    {
        private static ComponentsObject _ClassObject;
        private Label labelEmptyData;
        protected ComponentsObject()
        {

        }
        // Singleton Instance
        public static ComponentsObject Instance()
        {
            return _ClassObject ?? (new ComponentsObject());
        }
        // Create Label for Empty Value
        public Label LabelEmptyData()
        {
            labelEmptyData = new Label();
            labelEmptyData.Visible = false;
            labelEmptyData.AutoSize = false;
            labelEmptyData.Dock = DockStyle.Bottom;
            labelEmptyData.Size = new System.Drawing.Size(300, 80);
            labelEmptyData.Text = Properties.Resources.EmptyDataText;
            labelEmptyData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelEmptyData.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            return labelEmptyData;
        }
    }
}
