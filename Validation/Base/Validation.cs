using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Validation.Base
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ValidationAttribute : Attribute
    {
        public bool DefaultValue { get; }
        
        public string ErrorMessage { get; }
        
        public string ErrorMessageKey { get; }
        
        public string ParameterName { get; }

        protected ValidationAttribute(string parameterName = null, string errorMessage = null, bool defaultValue = true,
            string errorMessageKey = null)
        {
            ParameterName = parameterName;
            DefaultValue = defaultValue;
            ErrorMessage = errorMessage;
            ErrorMessageKey = errorMessageKey;
        }

        public abstract bool Validate(object input, object parameter = null);

        public static void SetFor(IValidatable validatable, IDictionary<string, string> errorMessages = null)
        {
            var type = validatable.GetType();
            var properties = type.GetProperties();
            var customAttributes = properties.Where(x => IsDefined(x, typeof(ValidationAttribute)))
                .ToDictionary(x => x.Name, info => info.GetCustomAttributes<ValidationAttribute>().ToList());
            if (!customAttributes.Any()) return;
            foreach (var (key, validationAttributes) in customAttributes)
            {
                validatable.Validation?.TryUpdate(key,
                    () =>
                    {
                        var valueToValidate = type.GetProperty(key)?.GetValue(validatable);
                        var firstIsNotValid = validationAttributes.FirstOrDefault(validationAttribute =>
                            !validationAttribute.Validate(valueToValidate,
                                string.IsNullOrEmpty(validationAttribute.ParameterName)
                                    ? null
                                    : type.GetProperty(validationAttribute.ParameterName)?.GetValue(validatable))
                        );
                        if (firstIsNotValid == null)
                            return new ValidationResult { IsValid = true };
                        if (errorMessages != null && !string.IsNullOrEmpty(firstIsNotValid.ErrorMessageKey) &&
                            errorMessages.TryGetValue(firstIsNotValid.ErrorMessageKey, out var errorMessage))
                            return new ValidationResult
                            {
                                IsValid = false,
                                Message = errorMessage
                            };
                        return new ValidationResult
                        {
                            IsValid = false,
                            Message = firstIsNotValid.ErrorMessage
                        };
                    },
                    validationAttributes.All(x => x.DefaultValue));
            }
        }
    }
}
