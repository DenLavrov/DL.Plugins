using Validation.Base;

namespace Validation.Implementations
{
    public class MatchOrLessLengthValidationAttribute : ValidationAttribute
    {
        public int Length { get; }

        public MatchOrLessLengthValidationAttribute(int length, string parameterName = null, string errorMessage = null,
            bool defaultValue = true, string errorMessageKey = null) : base(parameterName, errorMessage, defaultValue,
            errorMessageKey)
        {
            Length = length;
        }

        public override ValidationResult Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            return value == null || value.Length <= Length;
        }
    }
}
