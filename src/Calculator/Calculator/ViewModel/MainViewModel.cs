﻿using System;
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

        /// <summary>
        /// Constructor for MainViewModel
        /// </summary>
        public MainViewModel()
        {
            model = new MainModel();
            model.ActualValueChanged += (value) => this.ConsoleText = value;
            model.HistoryChanged += (history) => this.HistoryItemsSource = history;
            model.FormulaChanged += (value) => this.SelectedOperation = value;
        }

        #region CommandExecuteMethods

        /// <summary>
        /// Close click method
        /// </summary>
        /// <param name="obj"></param>
        public void ExecCloseClickCommand(object obj)
        {
            (obj as MainWindow)?.Close();
        }

        /// <summary>
        /// Method for minimalize window
        /// </summary>
        /// <param name="obj"></param>
        public void ExecMinimalizeClickCommand(object obj)
        {
            var mainWindow = obj as MainWindow;

            if (mainWindow != null)
            {
                mainWindow.WindowState = WindowState.Minimized;
            }
        }

        /// <summary>
        /// Method for open help dialog
        /// </summary>
        /// <param name="obj"></param>
        public void ExecHelpClickCommand(object obj)
        {

        }

        /// <summary>
        /// Mehtod for function click
        /// </summary>
        /// <param name="obj"></param>
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

        /// <summary>
        /// Method for key press
        /// </summary>
        /// <param name="obj"></param>
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

        /// <summary>
        /// Method for history click command
        /// </summary>
        /// <param name="obj"></param>
        public void ExecHistoryClickCommand(object obj)
        {
            if (obj is HistoryItem)
            {
                model.SelectHistory((HistoryItem) obj);
            }
        }

        /// <summary>
        /// Method fot clear button command
        /// </summary>
        /// <param name="obj"></param>
        public void ExecClearClickCommand(object obj)
        {
            model.Clear();
        }

        /// <summary>
        /// Method for back button click command
        /// </summary>
        /// <param name="obj"></param>
        public void ExecBackClickCommand(object obj)
        {
            model.RemoveLast();
        }

        #endregion

        /// <summary>
        /// Invoke function
        /// </summary>
        /// <param name="function">function to invoke</param>
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

        /// <summary>
        /// Calculate result
        /// </summary>
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
