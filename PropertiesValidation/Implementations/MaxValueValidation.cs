using PropertiesValidation.Base;

namespace PropertiesValidation.Implementations
{
    public class MaxValueValidation: ValidationAttribute
    {
        public float MaxValue { get; }

        public MaxValueValidation(float maxValue, string parameterName = null, bool defaultValue = true) : base(parameterName, defaultValue)
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
