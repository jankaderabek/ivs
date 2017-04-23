using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Activate drag and move functionality for window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowDragAndMove(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
