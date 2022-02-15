using Validation.Base;

namespace Validation.Implementations
{
    public class MinLengthValidationRule : IValidationRule<string>
    {
        public int MinLength { get; }

        public MinLengthValidationRule(int minLength)
        {
            MinLength = minLength;
        }

        public string Message { get; set; }

        public ValidationResult Validate(string value)
        {
            return value?.Length >= MinLength ? ValidationResult.Valid() : ValidationResult.Invalid(Message);
        }
    }
}
