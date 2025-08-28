using System;
using System.Windows;

namespace WinView.Services
{
    class DialogManager
    {
        private static Window Owner => Application.Current.MainWindow;

        public void HandleError(Exception ex)
        {
            if (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            var text = ex.Message;
            if (Owner != null)
            {
                MessageBox.Show(Owner, text, Owner.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(text, null, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
