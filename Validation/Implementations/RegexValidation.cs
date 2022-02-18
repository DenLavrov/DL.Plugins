using System.Text.RegularExpressions;
using Validation.Base;

namespace Validation.Implementations
{
    public class RegexValidationRule : IValidationRule<string>
    {
        public string Message { get; set; }
        
        readonly Regex _regex;
        
        public RegexValidationRule(string regex)
        {
            _regex = new Regex(regex);
        }
        
        public virtual ValidationResult Validate(string value)
        {
            return !string.IsNullOrEmpty(value) && _regex.IsMatch(value)
                ? ValidationResult.Valid()
                : ValidationResult.Invalid(Message);
        }
    }
}
