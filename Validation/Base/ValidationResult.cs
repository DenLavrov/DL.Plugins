namespace Validation.Base
{
    public readonly struct ValidationResult
    {
        public bool IsValid { get; }
        
        public string Message { get; }

        ValidationResult(bool isValid, string message = null)
        {
            IsValid = isValid;
            Message = message;
        }

        static ValidationResult ValidResult { get; } = new ValidationResult(true);
        
        static ValidationResult InvalidResult { get; } = new ValidationResult(false);
        
        public static implicit operator bool(ValidationResult validationResult) => validationResult.IsValid;

        public static implicit operator ValidationResult(bool isValid) => isValid ? Valid() : Invalid();

        public static ValidationResult Valid() => ValidResult;

        public static ValidationResult Invalid(string errorMessage = null) => string.IsNullOrEmpty(errorMessage)
            ? InvalidResult
            : new ValidationResult(false, errorMessage);
    }
}