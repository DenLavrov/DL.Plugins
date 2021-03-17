using System;
using System.Collections.Generic;
using System.Text;
using PropertiesValidation.Base;

namespace PropertiesValidation.Implementations
{
    public class MinLengthValidationAttribute: ValidationAttribute
    {
        public int MinLength { get; }

        public MinLengthValidationAttribute(int minLength, string parameterName = null, string errorMessage = null, bool defaultValue = true): base(parameterName, errorMessage, defaultValue)
        {
            MinLength = minLength;
        }

        public override bool Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            return value?.Length >= MinLength;
        }
    }
}
