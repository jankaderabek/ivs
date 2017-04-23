using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calculator.Controls.UserControls
{
    /// <summary>
    /// Custom control for functionKey
    /// </summary>
    public partial class FunctionKey : UserControl
    {
        /// <summary>
        /// Custom property KeyValueProperty for key value
        /// </summary>
        public static readonly DependencyProperty KeyValueProperty = DependencyProperty.Register("KeyValue", typeof(object), typeof(FunctionKey));

        /// <summary>
        /// Property for key value
        /// </summary>
        public object KeyValue
        {
            get { return (object)GetValue(KeyValueProperty); }
            set { SetValue(KeyValueProperty, value); }
        }

        public FunctionKey()
        {
            InitializeComponent();
        }
    }
}
