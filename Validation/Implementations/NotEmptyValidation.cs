using Validation.Base;

namespace Validation.Implementations
{
    public class NotEmptyValidationAttribute : ValidationAttribute
    {
        public NotEmptyValidationAttribute(string parameterName = null, string errorMessage = null,
            bool defaultValue = true, string errorMessageKey = null) : base(parameterName, errorMessage, defaultValue,
            errorMessageKey)
        {
        }

        public override bool Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            return !string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value);
        }
    }
}
