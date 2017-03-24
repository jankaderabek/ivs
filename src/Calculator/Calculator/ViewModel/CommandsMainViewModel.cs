using System.Windows.Input;
using Calculator.ViewModel.Commands;

namespace Calculator.ViewModel
{
    public partial class MainViewModel
    {
        private ICommand closeClickCommand;
        private ICommand helpClickCommand;
        private ICommand specialKeyClickCommand;
        private ICommand functionKeyClickCommand;

        public ICommand CloseClickCommand => this.closeClickCommand ?? (this.closeClickCommand = new RelayCommand(this.ExecCloseClickCommand));
        public ICommand HelpClickCommand => this.helpClickCommand ?? (this.helpClickCommand = new RelayCommand(this.ExecHelpClickCommand));
        public ICommand SpecialKeyClickCommand => this.specialKeyClickCommand ?? (this.specialKeyClickCommand = new RelayCommand(this.ExecFunctionKeyClickCommand));
        public ICommand FunctionKeyClickCommand => this.functionKeyClickCommand ?? (this.functionKeyClickCommand = new RelayCommand(this.ExecFunctionKeyClickCommand));
    }
}
