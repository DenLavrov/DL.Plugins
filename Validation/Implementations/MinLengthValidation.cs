using Validation.Base;

namespace Validation.Implementations
{
    public class MinLengthValidationAttribute : ValidationAttribute
    {
        public int MinLength { get; }

        public MinLengthValidationAttribute(int minLength, string parameterName = null, string errorMessage = null,
            bool defaultValue = true, string errorMessageKey = null) : base(parameterName, errorMessage, defaultValue,
            errorMessageKey)
        {
            MinLength = minLength;
        }

        public override ValidationResult Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            return value?.Length >= MinLength;
        }
    }
}
