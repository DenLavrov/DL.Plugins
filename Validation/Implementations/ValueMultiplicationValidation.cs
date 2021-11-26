using Validation.Base;

namespace Validation.Implementations
{
    public class ValueMultiplicationValidationAttribute : ValidationAttribute
    {
        public ValueMultiplicationValidationAttribute(string parameterName = null, string errorMessage = null,
            bool defaultValue = true, string errorMessageKey = null) : base(parameterName, errorMessage, defaultValue,
            errorMessageKey)
        {
        }

        public override ValidationResult Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            if (parameter is int divider)
                return int.TryParse(value, out var price) && price % divider == 0;
            return false;
        }
    }
}
