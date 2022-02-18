using System.Collections.Generic;
using System.Linq;
using Validation.Base;

namespace Validation.Implementations
{
    public class LengthIsMoreThenValidationRule<T, TT>: IValidationRule<T>
    where T: IEnumerable<TT>
    {
        public string Message { get; set; }
        
        public int Limit { get; }
        
        public LengthIsMoreThenValidationRule(int limit)
        {
            Limit = limit;
        }
        
        public ValidationResult Validate(T value)
        {
            return value?.Count() >= Limit ? ValidationResult.Valid() : ValidationResult.Invalid(Message);
        }
    }
}