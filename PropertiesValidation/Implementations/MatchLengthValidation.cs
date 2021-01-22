using PropertiesValidation.Base;

namespace PropertiesValidation.Implementations
{
    public class MatchLengthValidationAttribute: ValidationAttribute
    {
        public int MatchLength { get; }

        public MatchLengthValidationAttribute(int matchLength, string parameterName = null, bool defaultValue = true) : base(parameterName, defaultValue)
        {
            MatchLength = matchLength;
        }

        public override bool Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            return value?.Length == MatchLength;
        }
    }
}
