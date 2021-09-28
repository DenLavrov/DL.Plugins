using Validation.Base;

namespace Validation.Implementations
{
    public class ValueMultiplicationValidationAttribute : ValidationAttribute
    {
        public ValueMultiplicationValidationAttribute(string parameterName = null, string errorMessage = null,
            bool defaultValue = true) : base(parameterName, errorMessage, defaultValue)
        {
        }

        public override bool Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            if (parameter is int divider)
                return int.TryParse(value, out var price) && price % divider == 0;
            return false;
        }
    }
}
