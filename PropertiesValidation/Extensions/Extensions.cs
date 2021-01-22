using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PropertiesValidation.Implementations;

namespace PropertiesValidation.Extensions
{
    public static class Extensions
    {
        public static bool Contain(this MatchLengthValidationAttribute.Symbol[] @enum, char symbol)
        {
            if (@enum.Any(x => x == MatchLengthValidationAttribute.Symbol.Any)) return true;

            var contains = false;

            foreach (var enumSymbol in @enum)
            {
                contains = enumSymbol switch
                {
                    MatchLengthValidationAttribute.Symbol.Digit => char.IsDigit(symbol),
                    MatchLengthValidationAttribute.Symbol.Char => char.IsLetter(symbol),
                    MatchLengthValidationAttribute.Symbol.Symbol => char.IsSymbol(symbol),
                    _ => contains
                };
            }

            return contains;
        }
    }
}
