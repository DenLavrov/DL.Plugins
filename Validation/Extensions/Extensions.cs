using System.Linq;
using Validation.Base;
using Validation.Implementations;

namespace Validation.Extensions
{
    public static class Extensions
    {
        public static bool Contain(this MatchLengthValidationRule.Symbol[] @enum, char symbol)
        {
            if (@enum.Any(x => x == MatchLengthValidationRule.Symbol.Any)) return true;

            var contains = false;

            foreach (var enumSymbol in @enum)
            {
                contains = enumSymbol switch
                {
                    MatchLengthValidationRule.Symbol.Digit => char.IsDigit(symbol),
                    MatchLengthValidationRule.Symbol.Char => char.IsLetter(symbol),
                    MatchLengthValidationRule.Symbol.Symbol => char.IsSymbol(symbol),
                    _ => contains
                };
            }

            return contains;
        }
    }
}
