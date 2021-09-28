namespace Validation.Base
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        
        public string Message { get; set; }

        public static implicit operator bool(ValidationResult validationResult) => validationResult.IsValid;

        public static implicit operator ValidationResult(bool isValid) => new ValidationResult { IsValid = isValid };
    }
}