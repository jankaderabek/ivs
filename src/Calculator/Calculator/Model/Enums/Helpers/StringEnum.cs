using System;
using System.Reflection;

namespace Calculator.Model.Enums.Helpers
{
    /// <summary>
    /// StringEnum helper class for work with string flags in enums
    /// </summary>
    public static class StringEnum
    {
        /// <summary>
        /// Returns string from "StringValue" flag from enum value
        /// </summary>
        /// <param name="value">Enum value with "StringValue" flag</param>
        /// <returns>Returns string from "StringValue" flag from enum value</returns>
        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attrs = fi.GetCustomAttributes(typeof(StringValue), false) as StringValue[];

            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }
    }
}