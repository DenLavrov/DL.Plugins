using System.Linq;
using Validation.Base;
using Validation.Extensions;

namespace Validation.Implementations
{
    public class MatchLengthValidationRule: IValidationRule<string>
    {
        public enum Symbol: byte
        {
            Digit,
            Char,
            Symbol,
            Any
        }

        public Symbol[] AllowedSymbols { get; }

        public int MatchLength { get; }

        public MatchLengthValidationRule(Symbol[] allowedSymbols, int matchLength)
        {
            AllowedSymbols = allowedSymbols;
            MatchLength = matchLength;
        }

        public string Message { get; set; }

        public virtual ValidationResult Validate(string value)
        {
            return value?.Length == MatchLength && value.All(x => AllowedSymbols.Contain(x))
                ? ValidationResult.Valid()
                : ValidationResult.Invalid(Message);
        }
    }
}
