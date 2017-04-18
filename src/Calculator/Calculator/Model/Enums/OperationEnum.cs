using Calculator.Model.Enums.Helpers;

namespace Calculator.Model.Enums
{
    public enum OperationEnum
    {
        [StringValue("+")]
        Plus,
        [StringValue("-")]
        Minus,
        [StringValue("×")]
        Multiply,
        [StringValue("÷")]
        Divide,
        [StringValue("!")]
        Factorial,
        [StringValue("√")]
        Root,
        [StringValue("^")]
        Power,
        [StringValue("±")]
        Negation
    }
}
