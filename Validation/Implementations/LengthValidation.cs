using System.Collections.Generic;
using System.Linq;
using Validation.Base;

namespace Validation.Implementations
{
    public class LengthValidationRule<T, TT> : IValidationRule<T>
    where T : IEnumerable<TT>
    {
        public int Length { get; }
        
        public string Message { get; set; }

        public LengthValidationRule(int length)
        {
            Length = length;
        }

        public ValidationResult Validate(T value)
        {
            return value.Count() <= Length ? ValidationResult.Valid() : ValidationResult.Invalid(Message);
        }
    }
}
