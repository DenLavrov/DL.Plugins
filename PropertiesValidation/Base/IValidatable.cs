using System;
using System.Linq;

namespace PropertiesValidation.Base
{
    public interface IValidatable
    {
        public DynamicValuesDictionary<string, ValidationResult> Validation { get; set; }

        public void Init()
        {
            ValidationAttribute.SetFor(this);
        }

        public ValidationResult ValidateAll()
        {
            if (Validation == null)
                throw new NullReferenceException("Call Init() first");
            Validation.NotifyPropertiesChangedCommand.Execute(null);
            return Validation.Any(x => !x.Value.IsValid)
                ? Validation.First(x => !x.Value.IsValid).Value
                : Validation.First().Value;
        }
    }
}
