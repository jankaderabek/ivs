using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Calculator.ViewModel
{
    public partial class MainViewModel
    {
        #region CommandExecuteMethods

        public void ExecCloseClickCommand(object obj)
        {
            (obj as MainWindow)?.Close();
        }

        public void ExecMinimalizeClickCommand(object obj)
        {
            var mainWindow = obj as MainWindow;

            if (mainWindow != null)
            {
                mainWindow.WindowState = WindowState.Minimized;
            }
        }

        public void ExecHelpClickCommand(object obj)
        {

        }

        public void ExecSpecialKeyClickCommand(object obj)
        {
            this.ConsoleText += (obj as Label)?.Content?.ToString();
        }

        public void ExecFunctionKeyClickCommand(object obj)
        {
            var control = (ContentControl) obj;

            if (control?.Content is Label)
            {
                this.ConsoleText += ((Label)control.Content)?.Content?.ToString();
            }

            if(control?.Content is Path)
            {
                this.ConsoleText += ((Path)control.Content)?.Tag?.ToString();
            }
        }

        public void ExecKeyPressCommand(object obj)
        {
            this.ConsoleText += obj?.ToString();
        }

        public void ExecHistoryClickCommand(object obj)
        {

        }

        public void ExecCopyClickCommand(object obj)
        {
            this.ConsoleText = string.Empty;
        }

        public void ExecBackClickCommand(object obj)
        {
            if (this.ConsoleText.Length > 0)
            {
                this.ConsoleText = this.ConsoleText.Remove(this.ConsoleText.Length - 1);
            }
        }

        #endregion
    }
}
