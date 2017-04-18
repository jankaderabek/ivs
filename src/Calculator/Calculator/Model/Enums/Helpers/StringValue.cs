namespace Calculator.Model.Enums.Helpers
{
    public class StringValue : System.Attribute
    {
        public StringValue(string value)
        {
            this.Value = value;
        }

        public string Value { get; }
    }
}