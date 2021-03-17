using System.Text.RegularExpressions;
using PropertiesValidation.Base;

namespace PropertiesValidation.Implementations
{
    public class RegexValidationAttribute: ValidationAttribute
    {
        public string Regex { get; }

        public RegexValidationAttribute(string regex, string parameterName = null, string errorMessage = null, bool defaultValue = true) : base(parameterName, errorMessage, defaultValue)
        {
            Regex = regex;
        }

        public override bool Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            return !string.IsNullOrEmpty(value) && new Regex(Regex).IsMatch(value);
        }
    }
}
