﻿using System;
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
            foreach (var (propertyName, validationAttributes) in customAttributes)
            {
                validatable.Validation?.TryUpdate(propertyName,
                    () =>
                    {
                        var valueToValidate = type.GetProperty(propertyName)?.GetValue(validatable);
                        var firstIsNotValid = validationAttributes.FirstOrDefault(validationAttribute =>
                        {
                            var parameterPath = validationAttribute.ParameterName?.Split('.');
                            if (!parameterPath?.Any() ?? true) return !validationAttribute.Validate(valueToValidate);
                            var parameterValue = type.GetProperty(parameterPath[0])?.GetValue(validatable);
                            foreach (var pathPart in parameterPath.Skip(1))
                            {
                                parameterValue = parameterValue?.GetType().GetProperty(pathPart)
                                    ?.GetValue(parameterValue);
                            }
                            return !validationAttribute.Validate(valueToValidate, parameterValue);
                        });
                        if (firstIsNotValid == null)
                            return true;
                        if (errorMessages != null && !string.IsNullOrEmpty(firstIsNotValid.ErrorMessageKey) &&
                            errorMessages.TryGetValue(firstIsNotValid.ErrorMessageKey, out var errorMessage))
                            return new ValidationResult
                            {
                                Message = errorMessage
                            };
                        return new ValidationResult
                        {
                            Message = firstIsNotValid.ErrorMessage
                        };
                    },
                    validationAttributes.All(x => x.DefaultValue));
            }
        }
    }
}
