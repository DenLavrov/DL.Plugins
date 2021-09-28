namespace Validation.Implementations
{
    public class MatchOrEmptyValidationAttribute : RegexValidationAttribute
    {
        public MatchOrEmptyValidationAttribute(string regex, string parameterName = null, string errorMessage = null,
            bool defaultValue = true) : base(regex, errorMessage, parameterName, defaultValue)
        {
        }
        
        public override bool Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            return string.IsNullOrEmpty(value) || base.Validate(value, parameter);
        }
    }
}
