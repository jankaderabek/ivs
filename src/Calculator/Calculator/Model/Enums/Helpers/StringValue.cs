namespace Calculator.Model.Enums.Helpers
{
    /// <summary>
    /// StringValue class for optional enum attribute
    /// </summary>
    public class StringValue : System.Attribute
    {
        public StringValue(string value)
        {
            this.Value = value;
        }

        public string Value { get; }
    }
}