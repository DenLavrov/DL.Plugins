using System;
using System.Linq;
using System.Reflection;

namespace PropertiesValidation.Base
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ValidationAttribute : Attribute
    {
        public bool DefaultValue { get; }
        
        public string ErrorMessage { get; }
        
        public string ParameterName { get; }

        protected ValidationAttribute(string parameterName = null, string errorMessage = null, bool defaultValue = true)
        {
            ParameterName = parameterName;
            DefaultValue = defaultValue;
            ErrorMessage = errorMessage;
        }

        public abstract bool Validate(object input, object parameter = null);

        public static void SetFor(IValidatable validatable)
        {
            var type = validatable.GetType();
            var properties = type.GetProperties();
            var customAttributes = properties.Where(x => IsDefined(x, typeof(ValidationAttribute)))
                .ToDictionary(x => x.Name, info => info.GetCustomAttributes<ValidationAttribute>().ToList());
            if (!customAttributes.Any()) return;
            validatable.Validation = new DynamicValuesDictionary<string, ValidationResult>();
            foreach (var (key, validationAttributes) in customAttributes)
            {
                validatable.Validation.TryAdd(key,
                    () =>
                    {
                        var val = type.GetProperty(key)?.GetValue(validatable);
                        var firstIsNotValid = validationAttributes.FirstOrDefault(validationAttribute =>
                            !validationAttribute.Validate(val,
                                string.IsNullOrEmpty(validationAttribute.ParameterName)
                                    ? null
                                    : type.GetProperty(validationAttribute.ParameterName)?.GetValue(validatable))
                        );
                        return firstIsNotValid == null
                            ? new ValidationResult {IsValid = true}
                            : new ValidationResult
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
