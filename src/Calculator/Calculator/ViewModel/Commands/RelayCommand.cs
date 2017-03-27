using System;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public RelayCommand(Action<object> execute)
            : this(_ => true, execute)
        {
        }

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute(parameter);
        }

        public void OnCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
