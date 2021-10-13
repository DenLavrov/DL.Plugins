using System.Text.RegularExpressions;
using Validation.Base;

namespace Validation.Implementations
{
    public class RegexValidationAttribute : ValidationAttribute
    {
        public string Regex { get; }

        public RegexValidationAttribute(string regex, string parameterName = null, string errorMessage = null,
            bool defaultValue = true, string errorMessageKey = null) : base(parameterName, errorMessage, defaultValue,
            errorMessageKey)
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
