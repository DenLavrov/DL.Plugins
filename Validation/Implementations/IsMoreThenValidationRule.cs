using System;
using System.Collections.Generic;
using System.Linq;
using Validation.Base;

namespace Validation.Implementations
{
    public class IsMoreThenValidationRule<T> : IValidationRule<T>
    where T: IComparable<T>
    {
        public string Message { get; set; }
        
        public T Comparable { get; }

        public IsMoreThenValidationRule(T comparable)
        {
            Comparable = comparable;
        }

        public ValidationResult Validate(T value)
        {
            return value?.CompareTo(Comparable) >= 0 ? ValidationResult.Valid() : ValidationResult.Invalid(Message);
        }
    }
}
