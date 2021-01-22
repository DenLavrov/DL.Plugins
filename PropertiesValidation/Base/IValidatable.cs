using System;
using System.Linq;

namespace PropertiesValidation.Base
{
    public interface IValidatable
    {
        public DynamicValuesDictionary<string, bool> Validation { get; set; }

        public void Init()
        {
            ValidationAttribute.SetFor(this);
        }

        public bool ValidateAll()
        {
            if(Validation == null)
                throw new NullReferenceException("Call Init() first");
            Validation.NotifyPropertiesChangedCommand.Execute(null);
            return Validation.All(x => x.Value);
        }
    }
}
