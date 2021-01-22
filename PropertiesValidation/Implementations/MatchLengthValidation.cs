using System.Linq;
using PropertiesValidation.Base;
using PropertiesValidation.Extensions;

namespace PropertiesValidation.Implementations
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

        public MatchLengthValidationAttribute(Symbol[] allowedSymbols, int matchLength, string parameterName = null, bool defaultValue = true) : base(parameterName, defaultValue)
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
