using Validation.Base;

namespace Validation.Implementations
{
    public class MatchOrLessLengthValidationRule : IValidationRule<string>
    {
        public int Length { get; }

        public MatchOrLessLengthValidationRule(int length)
        {
            Length = length;
        }

        public string Message { get; set; }

        public ValidationResult Validate(string value)
        {
            return value == null || value.Length <= Length ? ValidationResult.Valid() : ValidationResult.Invalid(Message);
        }
    }
}
