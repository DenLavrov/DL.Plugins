using System.Collections.Generic;
using System.Linq;

namespace Validation.Base
{
    public class ValidationObject<T>: IValidationObject<T>
    {
        public T Value { get; set; }
        public virtual bool IsValid { get; private set; } = true;
        public string Message { get; private set; }
        public string DefaultMessage { get; set; }
        public List<IValidationRule<T>> ValidationRules { get; } = new List<IValidationRule<T>>();
        
        public virtual bool Validate()
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
                return IsValid = true;
            
            Message = message ?? DefaultMessage;
            return IsValid = false;
        }

        public static implicit operator T(ValidationObject<T> validationObject) => validationObject.Value;
    }
}