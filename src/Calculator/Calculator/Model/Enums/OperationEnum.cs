using Calculator.Model.Enums.Helpers;

namespace Calculator.Model.Enums
{
    /// <summary>
    /// OperationEnum enumeration for operations
    /// </summary>
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
