using System.Windows;
using System.Windows.Controls;

namespace Calculator.Controls
{
    public partial class Display : UserControl
    {
        /// <summary>
        /// Custom property MainLineProperty for consoleline value
        /// </summary>
        public static readonly DependencyProperty MainLineProperty = DependencyProperty.Register("MainLine", typeof(object), typeof(Display));

        /// <summary>
        /// Custom property HistoryProperty for history list value
        /// </summary>
        public static readonly DependencyProperty HistoryProperty = DependencyProperty.Register("History", typeof(object), typeof(Display));

        /// <summary>
        /// Property MainLine for consoleline value
        /// </summary>
        public object MainLine
        {
            get { return (string)GetValue(MainLineProperty); }
            set { SetValue(MainLineProperty, value); }
        }

        /// <summary>
        /// Property HistoryProperty for history list value
        /// </summary>
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
