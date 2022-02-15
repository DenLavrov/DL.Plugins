using System.Text.RegularExpressions;
using Validation.Base;

namespace Validation.Implementations
{
    public class RegexValidationRule : IValidationRule<string>
    {
        public string Regex { get; }

        public RegexValidationRule(string regex)
        {
            Regex = regex;
        }

        public string Message { get; set; }

        public virtual ValidationResult Validate(string value)
        {
            return !string.IsNullOrEmpty(value) && new Regex(Regex).IsMatch(value) ? ValidationResult.Valid() : ValidationResult.Invalid(Message);
        }
    }
}
