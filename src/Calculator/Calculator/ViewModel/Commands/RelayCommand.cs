using System;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands
{
    /// <summary>
    /// Relay command for MVVVM communication
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        /// <summary>
        /// Constructor for relay command
        /// </summary>
        /// <param name="execute">Action to execute</param>
        public RelayCommand(Action<object> execute)
            : this(_ => true, execute)
        {
        }

        /// <summary>
        /// Extended constructor for relay command
        /// </summary>
        /// <param name="canExecute">rule to enable execution of execute action</param>
        /// <param name="execute">Action to execute</param>
        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        /// <summary>
        /// EventHandler for canExecute predicate
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Manual execution of execute action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        /// <summary>
        /// Check if execute action can be executed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute(parameter);
        }

        /// <summary>
        /// Method to check if can be executed
        /// </summary>
        public void OnCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
