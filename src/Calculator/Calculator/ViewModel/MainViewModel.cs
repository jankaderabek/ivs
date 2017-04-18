using System;
using System.Windows;
using System.Windows.Controls;
using Calculator.Model;
using Calculator.Model.Entities;
using Calculator.Model.Enums;
using Calculator.Model.Enums.Helpers;

namespace Calculator.ViewModel
{
    public partial class MainViewModel
    {
        private MainModel model;
        private const int historyLimit = 2;

        public MainViewModel()
        {
            model = new MainModel();
            model.ActualValueChanged += (value) => this.ConsoleText = value;
            model.HistoryChanged += (history) => this.HistoryItemsSource = history;
            model.OperationChanged += (value) => this.SelectedOperation = $"{model.FirstOperand} {value} {model.SecondOperand}";
        }

        #region CommandExecuteMethods

        public void ExecCloseClickCommand(object obj)
        {
            (obj as MainWindow)?.Close();
        }

        public void ExecMinimalizeClickCommand(object obj)
        {
            var mainWindow = obj as MainWindow;

            if (mainWindow != null)
            {
                mainWindow.WindowState = WindowState.Minimized;
            }
        }

        public void ExecHelpClickCommand(object obj)
        {

        }

        public void ExecFunctionKeyClickCommand(object obj)
        {
            var control = obj as ContentControl;

            if (control?.Tag is OperationEnum)
            {
                model.SelectOperation((OperationEnum)control.Tag);
            }
            else if (control?.Tag is FunctionEnum)
            {
                InvokeFunction((FunctionEnum)control.Tag);
            }
            else if (control?.Content is Label)
            {
                model.AddDigit(((Label)control.Content).Content?.ToString());
            }
        }

        public void ExecKeyPressCommand(object obj)
        {
            if (obj is OperationEnum)
            {
                model.SelectOperation((OperationEnum)obj);
            }
            else if (obj is FunctionEnum)
            {
                InvokeFunction((FunctionEnum)obj);
            }
            else if (obj is string)
            {
                model.AddDigit((string) obj);
            }
        }

        public void ExecHistoryClickCommand(object obj)
        {
            if (obj is HistoryItem)
            {
                model.SelectHistory((HistoryItem) obj);
            }
        }

        public void ExecClearClickCommand(object obj)
        {
            model.Clear();
        }

        public void ExecBackClickCommand(object obj)
        {
            model.RemoveLast();
        }

        #endregion

        private void InvokeFunction(FunctionEnum function)
        {
            try
            {
                model.InvokeFunction(function);
            }
            catch (DivideByZeroException)
            {
                this.ConsoleText = "Nulou se nedá dělit.";
            }
        }

        private void CalculateResult()
        {
            try
            {
                model.CalculateResult();
            }
            catch (DivideByZeroException)
            {
                this.ConsoleText = "Nulou se nedá dělit.";
            }
        }
    }
}
