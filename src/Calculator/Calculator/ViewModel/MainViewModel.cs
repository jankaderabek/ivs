using System.Windows.Controls;

namespace Calculator.ViewModel
{
    public partial class MainViewModel
    {
        #region CommandExecuteMethods

        public void ExecCloseClickCommand(object obj)
        {
            (obj as MainWindow)?.Close();
        }

        public void ExecHelpClickCommand(object obj)
        {

        }

        public void ExecFunctionKeyClickCommand(object obj)
        {
            var key = (obj as Label)?.Content?.ToString();

            switch (key)
            {
                default:
                    break;
            }
        }

        #endregion
    }
}
