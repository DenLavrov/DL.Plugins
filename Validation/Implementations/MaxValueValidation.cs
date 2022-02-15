using Validation.Base;

namespace Validation.Implementations
{
    public class MaxValueValidationRule : IValidationRule<float>
    {
        public float MaxValue { get; }

        public MaxValueValidationRule(float maxValue)
        {
            MaxValue = maxValue;
        }

        public string Message { get; set; }

        public ValidationResult Validate(float value)
        {
            return value <= MaxValue ? ValidationResult.Valid() : ValidationResult.Invalid(Message);
        }
    }
}
