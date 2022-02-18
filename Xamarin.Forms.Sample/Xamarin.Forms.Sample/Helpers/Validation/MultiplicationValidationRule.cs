using Validation.Base;

namespace Xamarin.Forms.Sample.Helpers.Validation
{
    public class MultiplicationValidationRule: IValidationRule<int?>
    {
        public string Message { get; set; }
        
        public int Divider { get; }

        public MultiplicationValidationRule(int divider)
        {
            Divider = divider;
        }
        
        public ValidationResult Validate(int? value)
        {
            return Divider != 0 && value % Divider == 0 ? ValidationResult.Valid() : ValidationResult.Invalid(Message);
        }
    }
}