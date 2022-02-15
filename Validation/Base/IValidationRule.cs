namespace Validation.Base
{
    public interface IValidationRule<in T>
    {
        string Message { get; set; }
        ValidationResult Validate(T value);
    }
}