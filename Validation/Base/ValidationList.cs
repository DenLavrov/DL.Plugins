using System;
using Core;

namespace Validation.Base
{
    public class ValidationList: DynamicValuesDictionary<string, ValidationResult>
    {
        public event Action<string, ValidationResult> Validated;

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            var barePropertyName = propertyName?.Replace("Item[", string.Empty).Replace("]", string.Empty);
            Validated?.Invoke(barePropertyName, this[barePropertyName]);
        }
    }
}