using System;
using Validation.Base;

namespace Validation.Implementations
{
    public class IsLessThenValidationRule<T> : IValidationRule<T>
    where T: IComparable<T>
    {
        public T Comparable { get; }

        public IsLessThenValidationRule(T comparable)
        {
            Comparable = comparable;
        }

        public string Message { get; set; }

        public ValidationResult Validate(T value)
        {
            return value.CompareTo(Comparable) <= 0 ? ValidationResult.Valid() : ValidationResult.Invalid(Message);
        }
    }
}
