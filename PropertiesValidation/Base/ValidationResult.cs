namespace PropertiesValidation.Base
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        
        public string Message { get; set; }

        public static implicit operator bool(ValidationResult validationResult) => validationResult.IsValid;
    }
}