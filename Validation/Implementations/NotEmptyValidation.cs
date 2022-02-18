using Validation.Base;

namespace Validation.Implementations
{
    public class IsNotNullValidationRule<T> : IValidationRule<T>
    where T: class
    {
        public string Message { get; set; }

        public ValidationResult Validate(T value)
        {
            return value != null
                ? ValidationResult.Valid()
                : ValidationResult.Invalid(Message);
        }
    }
}
