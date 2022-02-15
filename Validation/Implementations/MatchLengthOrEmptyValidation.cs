using Validation.Base;

namespace Validation.Implementations
{
    public class MatchLengthOrEmptyValidationRule : MatchLengthValidationRule
    {
        public MatchLengthOrEmptyValidationRule(Symbol[] allowedSymbols, int matchLength) :
            base(allowedSymbols, matchLength)
        {
        }

        public override ValidationResult Validate(string value)
        {
            return string.IsNullOrEmpty(value) || base.Validate(value);
        }
    }
}
