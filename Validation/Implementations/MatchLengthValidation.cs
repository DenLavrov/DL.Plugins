using System.Linq;
using Validation.Base;
using Validation.Extensions;

namespace Validation.Implementations
{
    public class MatchLengthValidationAttribute: ValidationAttribute
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

        public MatchLengthValidationAttribute(Symbol[] allowedSymbols, int matchLength, string parameterName = null,
            string errorMessage = null, bool defaultValue = true, string errorMessageKey = null) : base(parameterName,
            errorMessage, defaultValue,
            errorMessageKey)
        {
            AllowedSymbols = allowedSymbols;
            MatchLength = matchLength;
        }

        public override bool Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            return value?.Length == MatchLength && value.All(x => AllowedSymbols.Contain(x));
        }
    }
}
