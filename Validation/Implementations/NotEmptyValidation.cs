using Validation.Base;

namespace Validation.Implementations
{
    public class NotEmptyValidationRule : IValidationRule<string>
    {
        public string Message { get; set; }

        public ValidationResult Validate(string value)
        {
            return !string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value) ? ValidationResult.Valid() : ValidationResult.Invalid(Message);
        }
    }
}
