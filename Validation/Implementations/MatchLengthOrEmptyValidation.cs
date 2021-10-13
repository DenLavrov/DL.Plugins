namespace Validation.Implementations
{
    public class MatchLengthOrEmptyValidationAttribute : MatchLengthValidationAttribute
    {
        public MatchLengthOrEmptyValidationAttribute(Symbol[] allowedSymbols, int matchLength,
            string parameterName = null, string errorMessage = null, bool defaultValue = true,
            string errorMessageKey = null) : base(allowedSymbols,
            matchLength, parameterName, errorMessage, defaultValue, errorMessageKey)
        {
        }

        public override bool Validate(object input, object parameter = null)
        {
            var val = input?.ToString();
            return string.IsNullOrEmpty(val) || base.Validate(val, parameter);
        }
    }
}
