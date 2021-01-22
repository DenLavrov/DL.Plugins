using PropertiesValidation.Base;

namespace PropertiesValidation.Implementations
{
    class ValueMultiplicationValidationAttribute: ValidationAttribute
    {
        public ValueMultiplicationValidationAttribute(string parameterName = null, bool defaultValue = true) : base(parameterName, defaultValue)
        {
        }

        public override bool Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            return int.TryParse(value, out var price) && price % (int)(parameter ?? -1) == 0;
        }
    }
}
