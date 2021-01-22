using PropertiesValidation.Base;

namespace PropertiesValidation.Implementations
{
    public class NotEmptyValidationAttribute: ValidationAttribute
    {
        public override bool Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            return !string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value);
        }
    }
}
