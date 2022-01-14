using System.Linq;
using Validation.Base;
using Validation.Implementations;

namespace Validation.Extensions
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

        public static ValidationResult Validate(this IValidatable validatable, string propertyName)
        {
            if (validatable?.Validation == null) 
                return null;
            if (validatable.Validation.NotifyPropertiesChangedCommand.CanExecute(null))
                validatable.Validation.NotifyPropertiesChangedCommand.Execute(propertyName);
            validatable.Validation.TryGetValue(propertyName, out var value);
            return value;
        }
        
        public static ValidationResult ValidateAll(this IValidatable validatable)
        {
            if (validatable?.Validation == null)
                return null;
            if (validatable.Validation.NotifyPropertiesChangedCommand.CanExecute(null))
                validatable.Validation.NotifyPropertiesChangedCommand.Execute(null);
            return validatable.Validation.Any(x => !x.Value.IsValid)
                ? validatable.Validation.First(x => !x.Value.IsValid).Value
                : validatable.Validation.First().Value;
        }
    }
}
