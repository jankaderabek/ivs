using System.Globalization;
using Calculator.Model.Enums;
using Calculator.Model.Enums.Helpers;

namespace Calculator.Model.Entities
{    
    /// <summary>
    /// History item object with operands and results
    /// </summary>
    public class HistoryItem
    {

        public double FirstOperand { get; set; }
        public double? SecondOperand { get; set; }
        public OperationEnum Function { get; set; }
        public double Result { get; set; }

        /// <summary>
        /// Constructor for unary operand operation
        /// </summary>
        /// <param name="firstOperand"></param>
        /// <param name="function"></param>
        /// <param name="result"></param>
        public HistoryItem(double firstOperand, OperationEnum function, double result)
        {
            this.FirstOperand = firstOperand;
            this.Function = function;
            this.Result = result;
        }

        /// <summary>
        /// Constructor for binary operation
        /// </summary>
        /// <param name="firstOperand"></param>
        /// <param name="secondOperand"></param>
        /// <param name="function"></param>
        /// <param name="result"></param>
        public HistoryItem(double firstOperand, double secondOperand, OperationEnum function, double result)
        {
            this.FirstOperand = firstOperand;
            this.SecondOperand = secondOperand;
            this.Function = function;
            this.Result = result;
        }

        /// <summary>
        /// Getter for history display string
        /// </summary>
        public string DisplayString
        {
            get
            {
                if (this.SecondOperand.HasValue)
                {
                    if ($"{this.FirstOperand} {StringEnum.GetStringValue(this.Function)} {this.SecondOperand.Value} = {this.Result}".Length > 25)
                    {
                        return this.Result.ToString();
                    }
                    return $"{this.FirstOperand} {StringEnum.GetStringValue(this.Function)} {this.SecondOperand.Value} = {this.Result}";
                }

                return $"{this.FirstOperand}{StringEnum.GetStringValue(this.Function)} = {this.Result}";
            }
        }
    }
}
