using System.Windows;
using System.Windows.Controls;

namespace Calculator.Controls.UserControls
{   
    /// <summary>
     /// Custom control for specialKey
     /// </summary>
    public partial class SpecialKey : UserControl
    {
        /// <summary>
        /// Custom property KeyValueProperty for key value
        /// </summary>
        public static readonly DependencyProperty KeyValueProperty = DependencyProperty.Register("KeyValueProperty", typeof(object), typeof(SpecialKey));

        /// <summary>
        /// Custom property KeyValueProperty for key value
        /// </summary>
        public object KeyValue
        {
            get { return (string)GetValue(KeyValueProperty); }
            set { SetValue(KeyValueProperty, value); }
        }

        public SpecialKey()
        {
            InitializeComponent();
        }
    }
}
