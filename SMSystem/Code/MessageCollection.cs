using SMSystem.Gui.OtherGui;
using SMSystem.Properties;
using System.Windows.Forms;

namespace SMSystem.Code
{
    public static class MessageCollection
    {
        // Fields
        private static bool dialogResult;
        private static NotifictionUser notifictionUser;

        // Message Box 
        #region Message Box
        public static void ShowServerMessage()
        {
            MessageBox.Show(Resources.ServerConnectionCaption,
                    Resources.ServerConnectionText, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        public static void ShowEmptyDataMessage()
        {
            MessageBox.Show(Resources.EmptyGridViewCaption,
                      Resources.EmptyGridViewText, MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
        }
        public static void ShowQuantityMessage()
        {
            MessageBox.Show(Resources.QuantityMaterialCaption,
                      Resources.QuantityMaterialText, MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
        }

        public static bool DeleteActtion()
        {
            var result = MessageBox.Show(Resources.DeleteActionCaption,
                        Resources.DeleteActionText, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dialogResult = true;
            }
            else
            {
                dialogResult = false;
            }
            return dialogResult;
        }
        public static bool OnConscinceAction()
        {
            var result = MessageBox.Show(Resources.OutOfConscinceCaption,
                        Resources.OutOfConscinceText, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dialogResult = true;
            }
            else
            {
                dialogResult = false;
            }
            return dialogResult;
        }
        public static bool OnDamgeAction()
        {
            var result = MessageBox.Show(Resources.OnDamgeCaption,
                        Resources.OnDamgeText, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dialogResult = true;
            }
            else
            {
                dialogResult = false;
            }
            return dialogResult;
        }
        public static bool DeleteActtionForOutCome()
        {
            var result = MessageBox.Show(Resources.DeletOutComeCaption,
                        Resources.DeleteOutComeText, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dialogResult = true;
            }
            else
            {
                dialogResult = false;
            }
            return dialogResult;
        }

        public static bool DeleteCompletedData()
        {
            var result = MessageBox.Show(Resources.ShowDeleteMaterialCaption,
                        Resources.DeleteActionText, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dialogResult = true;
            }
            else
            {
                dialogResult = false;
            }
            return dialogResult;
        }

        public static bool DamageAction()
        {
            var result = MessageBox.Show(Resources.ShowMoveDamgeCaption,
                        Resources.ShowMoveDamgeText, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dialogResult = true;
            }
            else
            {
                dialogResult = false;
            }
            return dialogResult;
        }

        public static void ShowEmptyFields()
        {
            MessageBox.Show(Resources.FiledsEmptyCaption,
                    Resources.FiledsEmptyText, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
        public static void ShowIsSavedData()
        {
            MessageBox.Show(Resources.SavedDataCaption,
                    Resources.SavedDataText, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        public static void ShowSlectRowsNotification()
        {
            MessageBox.Show(Resources.ShowRowsCaption,
                    Resources.ShowRowText, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        public static void ShowInvalidValue()
        {
            MessageBox.Show(Resources.InvalidInputCaption,
                    Resources.InvalidIputText, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        public static void ShowDuplicateData()
        {
            MessageBox.Show(Resources.DuplicateDataCaption,
                    Resources.DuplicateDataText, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
        #endregion

        // Notifications
        #region Notifications
        public static void ShowAddNotification()
        {
            notifictionUser = new NotifictionUser(Resources.AddNotificationText);
            notifictionUser.Show();
        }

        public static void ShowEditNotification()
        {
            notifictionUser = new NotifictionUser(Resources.EditNotificationText);
            notifictionUser.Show();
        }

        public static void ShowDeletNotification()
        {
            notifictionUser = new NotifictionUser(Resources.DeleteNotificationText);
            notifictionUser.Show();
        }
        #endregion

    }
}
