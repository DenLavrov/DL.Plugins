using System.Collections.Generic;
using Core;

namespace Validation.Base
{
    public interface IValidatable
    {
        public ValidationList Validation { get; }

        public void Init(IReadOnlyDictionary<string, string> errorMessages = null)
        {
            ValidationAttribute.SetFor(this, errorMessages);
        }
    }
}
