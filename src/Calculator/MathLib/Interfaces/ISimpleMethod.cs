namespace MathLib.Interfaces
{
    public interface ISimpleMethod
    {
        double Calculate();

        double Calculate(double firstOperand, double secondOperand);

        void AddOperand(double operand);
    }
}
