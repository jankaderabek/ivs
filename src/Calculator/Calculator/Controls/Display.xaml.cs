using System.Windows;
using System.Windows.Controls;

namespace Calculator.Controls
{
    public partial class Display : UserControl
    {
        public static readonly DependencyProperty MainLineProperty = DependencyProperty.Register("MainLine", typeof(object), typeof(Display));
        public static readonly DependencyProperty HistoryProperty = DependencyProperty.Register("History", typeof(object), typeof(Display));

        public object MainLine
        {
            get { return (string)GetValue(MainLineProperty); }
            set { SetValue(MainLineProperty, value); }
        }

        public object History
        {
            get { return (string)GetValue(HistoryProperty); }
            set { SetValue(HistoryProperty, value); }
        }

        public Display()
        {
            InitializeComponent();
        }
    }
}
