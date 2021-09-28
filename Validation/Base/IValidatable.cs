using System;
using System.Linq;
using System.Runtime.CompilerServices;
using PropertiesValidation.Base;

namespace Validation.Base
{
    public interface IValidatable
    {
        public DynamicValuesDictionary<string, ValidationResult> Validation { get; }

        public void Init()
        {
            ValidationAttribute.SetFor(this);
        }
    }
}
