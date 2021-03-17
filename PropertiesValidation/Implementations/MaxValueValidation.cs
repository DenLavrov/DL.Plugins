using PropertiesValidation.Base;

namespace PropertiesValidation.Implementations
{
    public class MaxValueValidationAttribute: ValidationAttribute
    {
        public float MaxValue { get; }

        public MaxValueValidationAttribute(float maxValue, string parameterName = null, string errorMessage = null, bool defaultValue = true) : base(parameterName, errorMessage, defaultValue)
        {
            MaxValue = maxValue;
        }

        public override bool Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            return float.TryParse(value, out var number) && number <= MaxValue;
        }
    }
}
