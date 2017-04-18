using Calculator.Model.Enums;
using Calculator.Model.Enums.Helpers;

namespace Calculator.Model.Entities
{
    public class HistoryItem
    {
        public double FirstOperand { get; set; }
        public double? SecondOperand { get; set; }
        public OperationEnum Function { get; set; }
        public double Result { get; set; }

        public HistoryItem(double firstOperand, OperationEnum function, double result)
        {
            this.FirstOperand = firstOperand;
            this.Function = function;
            this.Result = result;
        }

        public HistoryItem(double firstOperand, double secondOperand, OperationEnum function, double result)
        {
            this.FirstOperand = firstOperand;
            this.SecondOperand = secondOperand;
            this.Function = function;
            this.Result = result;
        }

        public string DisplayString
        {
            get
            {
                if (this.SecondOperand.HasValue)
                {
                    return $"{this.FirstOperand} {StringEnum.GetStringValue(this.Function)} {this.SecondOperand} = {this.Result}";
                }

                return $"{this.FirstOperand}{StringEnum.GetStringValue(this.Function)} = {this.Result}";
            }
        }
    }
}
