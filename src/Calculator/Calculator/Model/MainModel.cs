using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Calculator.Model.Entities;
using Calculator.Model.Enums;
using MathLib.Functions.Advanced;
using MathLib.Functions.Basic;

namespace Calculator.Model
{
    public delegate void ResultValueChangedHandler(double value);
    public delegate void HistoryItemsChangedHandler(ObservableCollection<HistoryItem> history);

    internal class MainModel
    {
        private MemoryItem memory;
        private ObservableCollection<HistoryItem> history;
        private OperationEnum? selectedOperation;
        private string firstOperand;
        private string secondOperand;
        private double result;

        public double? FirstOperand => ConvertStringToDouble(firstOperand);
        public double? SecondOperand => ConvertStringToDouble(secondOperand);

        public event ResultValueChangedHandler ResultValueChanged;
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
                ResultValueChanged?.Invoke(Result);
            }
        }

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
                    if (selectedOperation.HasValue)
                    {
                        secondOperand = memory.Memory.ToString(CultureInfo.InvariantCulture);

                        if (SecondOperand != null)
                        {
                            Result = SecondOperand.Value;
                        }
                    }
                    else
                    {
                        firstOperand = memory.Memory.ToString(CultureInfo.InvariantCulture);

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
            if (selectedOperation.HasValue)
            {
                secondOperand = RemoveLastDigit(secondOperand);

                if (SecondOperand != null)
                {
                    Result = SecondOperand.Value;
                }
            }
            else
            {
                firstOperand = RemoveLastDigit(firstOperand);

                if (FirstOperand != null)
                {
                    Result = FirstOperand.Value;
                }
            }
        }

        public void Clear()
        {
            Result = 0;
            NewMathProblem();
        }

        public void CalculateResult()
        {
            CalculateFunction();
        }

        public void SelectOperation(OperationEnum function)
        {
            if (FirstOperand.HasValue)
            {
                this.selectedOperation = function;

                if (IsSingleOperandOperation(function))
                {
                    CalculateFunction();
                }
            }
        }

        public bool AddDigit(string value)
        {
            if (this.selectedOperation.HasValue)
            {
                if (CheckNumberExtensibility(secondOperand, value))
                {
                    secondOperand += value;

                    if (SecondOperand != null)
                    {
                        Result = SecondOperand.Value;
                    }

                    return true;
                }
            }
            else
            {
                if (CheckNumberExtensibility(firstOperand, value))
                {
                    firstOperand += value;

                    if (FirstOperand != null)
                    {
                        Result = FirstOperand.Value;
                    }

                    return true;
                }
            }

            return false;
        }

        public void SelectHistory(HistoryItem item)
        {
            item = history.First((h) => h == item);

            if (selectedOperation.HasValue)
            {
                secondOperand = item.Result.ToString(CultureInfo.InvariantCulture);

                if (SecondOperand != null)
                {
                    Result = SecondOperand.Value;
                }
            }
            else
            {
                firstOperand = item.Result.ToString(CultureInfo.InvariantCulture);

                if (FirstOperand != null)
                {
                    Result = FirstOperand.Value;
                }
            }
        }

        private void NewMathProblem()
        {
            firstOperand = string.Empty;
            secondOperand = string.Empty;
            selectedOperation = null;
        }

        private void AddToHistory(HistoryItem item)
        {
            history.Add(item);
        }

        private void CalculateFunction()
        {
            if (selectedOperation == null ||
                !FirstOperand.HasValue)
            {
                return;
            }

            if (!IsSingleOperandOperation(selectedOperation.Value))
            {
                if (!SecondOperand.HasValue)
                {
                    return;
                }
            }

            switch (selectedOperation.Value)
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

            AddToHistory(IsSingleOperandOperation(selectedOperation.Value)
                        ? new HistoryItem(FirstOperand.Value, selectedOperation.Value, Result)
                        : new HistoryItem(FirstOperand.Value, SecondOperand.Value, selectedOperation.Value, Result));

            NewMathProblem();
            firstOperand = Result.ToString(CultureInfo.InvariantCulture);
        }

        private static string RemoveLastDigit(string value)
        {
            return value.Length > 1 ? value.Substring(0, value.Length - 1) : 0.ToString();
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

            return double.Parse(stringValue.Trim('.'), CultureInfo.InvariantCulture);
        }

        private static bool CheckNumberExtensibility(string value, string addition)
        {
            var number = 0;

            if (!int.TryParse(addition, out number))
            {
                return false;
            }

            return !(number == 0 && value == "0");
        }
    }
}
