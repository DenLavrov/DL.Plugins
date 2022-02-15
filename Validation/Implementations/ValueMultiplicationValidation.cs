using System;
using Validation.Base;

namespace Validation.Implementations
{
    public class ValueMultiplicationValidationRule : IValidationRule<int?>
    {
        public Func<int> GetDivider { get; }
        
        public ValueMultiplicationValidationRule(Func<int> getDivider)
        {
            GetDivider = getDivider;
        }

        public string Message { get; set; }

        public ValidationResult Validate(int? value)
        {
            var divider = GetDivider();
            return value != null && divider != 0 && value % divider == 0 ? ValidationResult.Valid() : ValidationResult.Invalid(Message);
        }
    }
}
