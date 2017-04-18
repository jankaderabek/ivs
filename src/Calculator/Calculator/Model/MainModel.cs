using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Calculator.Model.Entities;
using Calculator.Model.Enums;
using Calculator.Model.Enums.Helpers;
using MathLib.Functions.Advanced;
using MathLib.Functions.Basic;

namespace Calculator.Model
{
    public delegate void ActualValueChangedHandler(string value);
    public delegate void FormulaChangedHandler(string value);
    public delegate void HistoryItemsChangedHandler(ObservableCollection<HistoryItem> history);

    internal class MainModel
    {
        private readonly MemoryItem memory;
        private readonly ObservableCollection<HistoryItem> history;
        private OperationEnum? selectedOperation;
        private string firstOperandString;
        private string secondOperandString;
        private double result;

        public double? FirstOperand => ConvertStringToDouble(firstOperandString);
        public double? SecondOperand => ConvertStringToDouble(secondOperandString);
        public string Formula
        {
            get
            {
                string operation = (selectedOperation == null ? string.Empty : StringEnum.GetStringValue(selectedOperation));
                return $"{FirstOperand} {operation} {SecondOperand}";
            }
        }

        private OperationEnum? SelectedOperation
        {
            get { return selectedOperation; }
            set
            {
                selectedOperation = value;
                FormulaChanged?.Invoke(Formula);
            }
        }

        public event ActualValueChangedHandler ActualValueChanged;
        public event FormulaChangedHandler FormulaChanged;
        public event HistoryItemsChangedHandler HistoryChanged;

        private double Result
        {
            get
            {
                return result;
            }

            set
            {
                this.result = value;
                ActualValueChanged?.Invoke(Result.ToString());
            }
        }
        public string FirstOperandString
        {
            get
            {
                return firstOperandString;
            }

            set
            {
                firstOperandString = value;
                ActualValueChanged?.Invoke(FirstOperandString);
                FormulaChanged?.Invoke(Formula);
            }
        }
        public string SecondOperandString
        {
            get
            {
                return secondOperandString;
            }

            set
            {
                secondOperandString = value;
                ActualValueChanged?.Invoke(SecondOperandString);
                FormulaChanged?.Invoke(Formula);
            }
        }

        public string ActualValue => SelectedOperation.HasValue ? SecondOperandString : FirstOperandString;


        public MainModel()
        {
            history = new ObservableCollection<HistoryItem>();
            history.CollectionChanged += (sender, e) => HistoryChanged?.Invoke(history);

            memory = new MemoryItem();

            Clear();
        }

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

        public void Clear()
        {
            result = 0;
            FirstOperandString = string.Empty;
            SecondOperandString = string.Empty;
            SelectedOperation = null;
        }

        public void CalculateResult()
        {
            CalculateFunction();
        }

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

            this.SelectedOperation = function;
        }

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

        private void NewMathProblem()
        {
            firstOperandString = string.Empty;
            secondOperandString = string.Empty;
            SelectedOperation = null;
        }

        private void AddToHistory(HistoryItem item)
        {
            history.Insert(0, item);
        }

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

        private static string RemoveLastDigit(string value)
        {
            return value.Length > 1 ? value.Substring(0, value.Length - 1) : string.Empty;
        }

        private static bool IsSingleOperandOperation(OperationEnum function)
        {
            return function == OperationEnum.Factorial || function == OperationEnum.Negation;
        }

        private static double? ConvertStringToDouble(string stringValue)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return null;
            }

            return double.Parse(stringValue.Trim(','));
        }

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
