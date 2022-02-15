using System;
using System.Collections.Generic;
using System.Linq;

namespace Validation.Base
{
    public interface IValidatable
    {
        void Validate();
    }
    
    public interface IValidationObject<T>: IValidatable
    {
        public T Value { get; }
        
        public bool IsValid { get; }
        
        public string Message { get; }
        
        public string DefaultMessage { get; }
        
        public List<IValidationRule<T>> ValidationRules { get; }
    }
}