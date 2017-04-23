using System;
using System.Collections.ObjectModel;
using System.Linq;
using Calculator.Model.Entities;
using Calculator.Model.Enums;
using Calculator.Model.Enums.Helpers;
using MathLib.Functions.Advanced;
using MathLib.Functions.Basic;

namespace Calculator.Model
{
    /// <summary>
    /// Delegate for actual value
    /// </summary>
    /// <param name="value">Changed actual value</param>
    public delegate void ActualValueChangedHandler(string value);

    /// <summary>
    /// Delegate for formula changes
    /// </summary>
    /// <param name="value">String value of actual formula</param>
    public delegate void FormulaChangedHandler(string value);

    /// <summary>
    /// Delegate for history items changes
    /// </summary>
    /// <param name="history">List of actual history items</param>
    public delegate void HistoryItemsChangedHandler(ObservableCollection<HistoryItem> history);

    /// <summary>
    /// MainModel class for Calculator app
    /// </summary>
    internal class MainModel
    {
        private readonly MemoryItem memory;
        private readonly ObservableCollection<HistoryItem> history;
        private OperationEnum? selectedOperation;
        private string firstOperandString;
        private string secondOperandString;
        private double result;

        /// <summary>
        /// Property for first operand
        /// </summary>
        public double? FirstOperand => ConvertStringToDouble(firstOperandString);

        /// <summary>
        /// Property for second operand
        /// </summary>
        public double? SecondOperand => ConvertStringToDouble(secondOperandString);

        /// <summary>
        /// Property for calculation formula
        /// </summary>
        public string Formula
        {
            get
            {
                string operation = (selectedOperation == null
                    ? string.Empty
                    : StringEnum.GetStringValue(selectedOperation));
                return $"{FirstOperand} {operation} {SecondOperand}";
            }
        }

        /// <summary>
        /// Property for selected operation
        /// </summary>
        private OperationEnum? SelectedOperation
        {
            get { return selectedOperation; }
            set
            {
                selectedOperation = value;
                FormulaChanged?.Invoke(Formula);
            }
        }

        /// <summary>
        /// Event for actual value changes
        /// </summary>
        public event ActualValueChangedHandler ActualValueChanged;

        /// <summary>
        /// Event for formula changes
        /// </summary>
        public event FormulaChangedHandler FormulaChanged;

        /// <summary>
        /// Event for history changes
        /// </summary>
        public event HistoryItemsChangedHandler HistoryChanged;

        private double Result
        {
            get { return result; }

            set
            {
                this.result = value;
                ActualValueChanged?.Invoke(Result.ToString());
            }
        }

        /// <summary>
        /// Property for first operand to string
        /// </summary>
        public string FirstOperandString
        {
            get { return firstOperandString; }

            set
            {
                firstOperandString = value;
                ActualValueChanged?.Invoke(FirstOperandString);
                FormulaChanged?.Invoke(Formula);
            }
        }

        /// <summary>
        /// Property for second operand to string
        /// </summary>
        public string SecondOperandString
        {
            get { return secondOperandString; }

            set
            {
                secondOperandString = value;
                ActualValueChanged?.Invoke(SecondOperandString);
                FormulaChanged?.Invoke(Formula);
            }
        }

        /// <summary>
        /// Property for console actual value to string
        /// </summary>
        public string ActualValue => SelectedOperation.HasValue ? SecondOperandString : FirstOperandString;

        /// <summary>
        /// MainModel constructor
        /// </summary>
        public MainModel()
        {
            history = new ObservableCollection<HistoryItem>();
            history.CollectionChanged += (sender, e) => HistoryChanged?.Invoke(history);

            memory = new MemoryItem();

            Clear();
        }

        /// <summary>
        /// Method invoking functions
        /// </summary>
        /// <param name="function"></param>
        public void InvokeFunction(FunctionEnum function)
        {
            switch (function)
            {
                case FunctionEnum.Result:
                    CalculateResult();
                    break;
                case FunctionEnum.Clear:
                    Clear();
                    break;
                case FunctionEnum.RemoveLastDigit:
                    RemoveLast();
                    break;
                case FunctionEnum.MemorySave:
                    memory.SaveToMemory(Result);
                    break;
                case FunctionEnum.MemoryRecall:
                    if (SelectedOperation.HasValue)
                    {
                        SecondOperandString = memory.Memory.ToString();

                        if (SecondOperand != null)
                        {
                            Result = SecondOperand.Value;
                        }
                    }
                    else
                    {
                        FirstOperandString = memory.Memory.ToString();

                        if (FirstOperand != null)
                        {
                            Result = FirstOperand.Value;
                        }
                    }
                    break;
                case FunctionEnum.MemoryAddition:
                    memory.AddMemory(Result);
                    break;
                case FunctionEnum.MemorySubstraction:
                    memory.SubMemory(Result);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Remove last digit from actual value
        /// </summary>
        public void RemoveLast()
        {
            if (SelectedOperation.HasValue && !IsSingleOperandOperation(SelectedOperation.Value))
            {
                SecondOperandString = RemoveLastDigit(SecondOperandString);

                if (SecondOperand != null)
                {
                    Result = SecondOperand.Value;
                }
            }
            else
            {
                FirstOperandString = RemoveLastDigit(FirstOperandString);

                if (FirstOperand != null)
                {
                    Result = FirstOperand.Value;
                }
            }
        }

        /// <summary>
        /// Clear console text
        /// </summary>
        public void Clear()
        {
            result = 0;
            FirstOperandString = string.Empty;
            SecondOperandString = string.Empty;
            SelectedOperation = null;
        }

        /// <summary>
        /// Calculate result
        /// </summary>
        public void CalculateResult()
        {
            CalculateFunction();
        }

        /// <summary>
        /// Select operation
        /// </summary>
        /// <param name="function">operation to select</param>
        public void SelectOperation(OperationEnum function)
        {
            if (!FirstOperand.HasValue)
            {
                FirstOperandString = Result.ToString();
            }

            if (IsSingleOperandOperation(function))
            {
                secondOperandString = string.Empty;
            }

            if (SecondOperand.HasValue)
            {
                CalculateAndSelectOperation(function);
            }
            else
            {
                this.SelectedOperation = function;
            }
        }

        /// <summary>
        /// Calculate formula and select next operation
        /// </summary>
        /// <param name="function"></param>
        private void CalculateAndSelectOperation(OperationEnum function)
        {
            CalculateFunction();

            FirstOperandString = Result.ToString();
            SelectedOperation = function;
        }

        /// <summary>
        /// Add digit to console value
        /// </summary>
        /// <param name="value">digit to add</param>
        public void AddDigit(string value)
        {
            if (this.SelectedOperation.HasValue && !IsSingleOperandOperation(SelectedOperation.Value))
            {
                SecondOperandString = AddDigit(SecondOperandString, value);
            }
            else
            {
                FirstOperandString = AddDigit(FirstOperandString, value);
            }
        }

        /// <summary>
        /// Select history item and prints to console
        /// </summary>
        /// <param name="item">History item to select</param>
        public void SelectHistory(HistoryItem item)
        {
            item = history.First((h) => h == item);

            if (SelectedOperation.HasValue)
            {
                SecondOperandString = item.Result.ToString();

                if (SecondOperand != null)
                {
                    Result = SecondOperand.Value;
                }
            }
            else
            {
                FirstOperandString = item.Result.ToString();

                if (FirstOperand != null)
                {
                    Result = FirstOperand.Value;
                }
            }
        }

        /// <summary>
        /// Clear properties for new calculation
        /// </summary>
        private void NewMathProblem()
        {
            firstOperandString = string.Empty;
            secondOperandString = string.Empty;
            SelectedOperation = null;
        }

        /// <summary>
        /// Add actual formula to history list
        /// </summary>
        /// <param name="item"></param>
        private void AddToHistory(HistoryItem item)
        {
            history.Insert(0, item);
        }

        /// <summary>
        /// Calculation of furmula
        /// </summary>
        private void CalculateFunction()
        {
            if (SelectedOperation == null ||
                !FirstOperand.HasValue)
            {
                return;
            }

            if (!IsSingleOperandOperation(SelectedOperation.Value))
            {
                if (!SecondOperand.HasValue)
                {
                    return;
                }
            }

            switch (SelectedOperation.Value)
            {
                case OperationEnum.Negation:
                    Result = new Negation().Calculate(FirstOperand.Value);
                    break;
                case OperationEnum.Factorial:
                    Result = new Factorial().Calculate(FirstOperand.Value);
                    break;
                case OperationEnum.Plus:
                    Result = new Addition().Calculate(FirstOperand.Value, SecondOperand.Value);
                    break;
                case OperationEnum.Minus:
                    Result = new Substraction().Calculate(FirstOperand.Value, SecondOperand.Value);
                    break;
                case OperationEnum.Multiply:
                    Result = new Multiplication().Calculate(FirstOperand.Value, SecondOperand.Value);
                    break;
                case OperationEnum.Divide:
                    try
                    {
                        Result = new Division().Calculate(FirstOperand.Value, SecondOperand.Value);
                    }
                    catch (DivideByZeroException)
                    {
                        Clear();
                        throw;
                    }
                    break;
                case OperationEnum.Power:
                    Result = new Power().Calculate(FirstOperand.Value, SecondOperand.Value);
                    break;
                case OperationEnum.Root:
                    Result = new Root().Calculate(FirstOperand.Value, Convert.ToInt32(SecondOperand.Value));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            AddToHistory(IsSingleOperandOperation(SelectedOperation.Value)
                        ? new HistoryItem(FirstOperand.Value, SelectedOperation.Value, Result)
                        : new HistoryItem(FirstOperand.Value, SecondOperand.Value, SelectedOperation.Value, Result));

            NewMathProblem();
        }

        /// <summary>
        /// Remove last digit from console
        /// </summary>
        /// <param name="value">Value to remove</param>
        /// <returns></returns>
        private static string RemoveLastDigit(string value)
        {
            return value.Length > 1 ? value.Substring(0, value.Length - 1) : string.Empty;
        }

        /// <summary>
        /// Check if operation is unary type
        /// </summary>
        /// <param name="function">Operation to check</param>
        /// <returns></returns>
        private static bool IsSingleOperandOperation(OperationEnum function)
        {
            return function == OperationEnum.Factorial || function == OperationEnum.Negation;
        }

        /// <summary>
        /// Convert string to double
        /// </summary>
        /// <param name="stringValue">String to convert</param>
        /// <returns>Return double if success, otherwise returns null</returns>
        private static double? ConvertStringToDouble(string stringValue)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return null;
            }

            return double.Parse(stringValue.Trim(','));
        }

        /// <summary>
        /// Check double value extensibility
        /// </summary>
        /// <param name="value">String value of double number</param>
        /// <param name="addition">string to add</param>
        /// <returns>Return true if value can be extends otherwise false</returns>
        private static bool CheckNumberExtensibility(string value, string addition)
        {
            var number = 0;

            if (!int.TryParse(addition, out number))
            {
                if (addition == "," && 
                    !value.Contains(","))
                {
                    return true;
                }
                return false;
            }

            return !(number == 0 && value == "0");
        }

        /// <summary>
        /// Add digit to value
        /// </summary>
        /// <param name="value">String number to be extends</param>
        /// <param name="addition">Addition value</param>
        /// <returns></returns>
        private static string AddDigit(string value, string addition)
        {
            if (CheckNumberExtensibility(value, addition))
            {
                if (value.Length == 0 &&
                    addition == ",")
                {
                    addition = "0" + addition;
                }

                value += addition;
            }

            return value;
        }
    }
}
