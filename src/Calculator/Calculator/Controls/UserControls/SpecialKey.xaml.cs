using System.Windows;
using System.Windows.Controls;

namespace Calculator.Controls.UserControls
{
    public partial class SpecialKey : UserControl
    {
        public static readonly DependencyProperty KeyValueProperty = DependencyProperty.Register("KeyValueProperty", typeof(object), typeof(SpecialKey));

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
