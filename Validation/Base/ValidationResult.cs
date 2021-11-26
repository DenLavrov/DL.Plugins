namespace Validation.Base
{
    public class ValidationResult
    {
        public bool IsValid { get; private set; }
        
        public string Message { get; private set; }
        
        static ValidationResult ValidResult { get; } = new ValidationResult
        {
            IsValid = true
        };

        static ValidationResult InvalidResult { get; } = new ValidationResult
        {
            IsValid = false
        };

        ValidationResult()
        {
        }

        public static implicit operator bool(ValidationResult validationResult) => validationResult.IsValid;

        public static implicit operator ValidationResult(bool isValid) => isValid ? Valid() : Invalid();

        public static ValidationResult Valid() => ValidResult;

        public static ValidationResult Invalid(string errorMessage = null) => string.IsNullOrEmpty(errorMessage)
            ? InvalidResult
            : new ValidationResult
            {
                IsValid = false,
                Message = errorMessage
            };
    }
}