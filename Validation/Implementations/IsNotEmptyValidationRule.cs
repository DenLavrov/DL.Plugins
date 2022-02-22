using Validation.Base;

namespace Validation.Implementations
{
    public class IsNotEmptyValidationRule: IValidationRule<string>
    {
        public string Message { get; set; }

        public ValidationResult Validate(string value)
        {
            return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value)
                ? ValidationResult.Valid()
                : ValidationResult.Invalid(Message);
        }
    }
}