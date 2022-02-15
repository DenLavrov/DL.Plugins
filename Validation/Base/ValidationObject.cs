using System.Collections.Generic;
using System.Linq;

namespace Validation.Base
{
    public class ValidationObject<T>: IValidationObject<T>
    {
        public T Value { get; set; }
        public bool IsValid { get; private set; } = true;
        public string Message { get; private set; }
        public string DefaultMessage { get; set; }
        public List<IValidationRule<T>> ValidationRules { get; } = new List<IValidationRule<T>>();
        
        public virtual void Validate()
        {
            string message = null;
            var isValid = ValidationRules.All(x =>
            {
                var validationResult = x.Validate(Value);
                if (!validationResult)
                    message = validationResult.Message;
                return validationResult;
            });
            if (isValid)
            {
                IsValid = true;
                return;
            }
            IsValid = false;
            Message = message ?? DefaultMessage;
        }

        public static implicit operator T(ValidationObject<T> validationObject) => validationObject.Value;
    }
}