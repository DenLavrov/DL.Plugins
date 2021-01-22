namespace PropertiesValidation.Implementations
{
    public class MatchLengthOrEmptyValidationAttribute: MatchLengthValidationAttribute
    {
        public override bool Validate(object input, object parameter = null)
        {
            var val = input?.ToString();
            return string.IsNullOrEmpty(val) || base.Validate(val);
        }

        public MatchLengthOrEmptyValidationAttribute(Symbol[] allowedSymbols, int matchLength, string parameterName = null, bool defaultValue = true) : base(allowedSymbols, matchLength, parameterName, defaultValue)
        {
        }
    }
}
