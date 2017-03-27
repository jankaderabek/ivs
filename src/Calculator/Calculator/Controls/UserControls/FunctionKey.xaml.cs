using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calculator.Controls.UserControls
{
    public partial class FunctionKey : UserControl
    {
        public static readonly DependencyProperty KeyValueProperty = DependencyProperty.Register("KeyValue", typeof(object), typeof(FunctionKey));

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
