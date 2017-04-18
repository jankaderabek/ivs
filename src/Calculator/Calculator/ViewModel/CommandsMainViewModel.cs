using System.Windows.Input;
using Calculator.ViewModel.Commands;

namespace Calculator.ViewModel
{
    public partial class MainViewModel
    {
        private ICommand closeClickCommand;
        private ICommand minimalizeClickCommand;
        private ICommand helpClickCommand;
        private ICommand specialKeyClickCommand;
        private ICommand functionKeyClickCommand;
        private ICommand keyPressCommand;
        private ICommand historyClickCommand;
        private ICommand clearClickCommand;
        private ICommand backClickCommand;

        public ICommand CloseClickCommand => this.closeClickCommand ?? (this.closeClickCommand = new RelayCommand(this.ExecCloseClickCommand));
        public ICommand MinimalizeClickCommand => this.minimalizeClickCommand ?? (this.minimalizeClickCommand = new RelayCommand(this.ExecMinimalizeClickCommand));
        public ICommand HelpClickCommand => this.helpClickCommand ?? (this.helpClickCommand = new RelayCommand(this.ExecHelpClickCommand));
        public ICommand SpecialKeyClickCommand => this.specialKeyClickCommand ?? (this.specialKeyClickCommand = new RelayCommand(this.ExecSpecialKeyClickCommand));
        public ICommand FunctionKeyClickCommand => this.functionKeyClickCommand ?? (this.functionKeyClickCommand = new RelayCommand(this.ExecFunctionKeyClickCommand));
        public ICommand KeyPressCommand => this.keyPressCommand ?? (this.keyPressCommand = new RelayCommand(this.ExecKeyPressCommand));
        public ICommand HistoryClickCommand => this.historyClickCommand ?? (this.historyClickCommand = new RelayCommand(this.ExecHistoryClickCommand));
        public ICommand ClearClickCommand => this.clearClickCommand ?? (this.clearClickCommand = new RelayCommand(this.ExecClearClickCommand));
        public ICommand BackClickCommand => this.backClickCommand ?? (this.backClickCommand = new RelayCommand(this.ExecBackClickCommand));
    }
}
