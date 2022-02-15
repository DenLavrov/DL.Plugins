using Validation.Base;

namespace Validation.Implementations
{
    public class MatchOrEmptyValidationRule : RegexValidationRule
    {
        public MatchOrEmptyValidationRule(string regex) : base(regex)
        {
        }

        public override ValidationResult Validate(string value)
        {
            return string.IsNullOrEmpty(value) || base.Validate(value);
        }
    }
}
