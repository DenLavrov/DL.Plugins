using Validation.Base;

namespace Validation.Implementations
{
    public class NotEmptyValidationAttribute : ValidationAttribute
    {
        public NotEmptyValidationAttribute(string parameterName = null, string errorMessage = null,
            bool defaultValue = true) : base(parameterName, errorMessage, defaultValue)
        {
        }

        public override bool Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            return !string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value);
        }
    }
}
