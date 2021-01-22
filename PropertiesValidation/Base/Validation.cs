using System;
using System.Linq;
using System.Reflection;

namespace PropertiesValidation.Base
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ValidationAttribute : Attribute
    {
        public bool DefaultValue { get; }

        public string ParameterName { get; }

        protected ValidationAttribute(string parameterName = null, bool defaultValue = true)
        {
            ParameterName = parameterName;
            DefaultValue = defaultValue;
        }

        public abstract bool Validate(object input, object parameter = null);

        public static void SetFor(IValidatable validatable)
        {
            var type = validatable.GetType();
            var properties = type.GetProperties();
            var customAttributes = properties.Where(x => IsDefined(x, typeof(ValidationAttribute)))
                .ToDictionary(x => x.Name, info => info.GetCustomAttributes<ValidationAttribute>().ToList());
            if (!customAttributes.Any()) return;
            validatable.Validation = new DynamicValuesDictionary<string, bool>();
            foreach (var (key, value) in customAttributes)
            {
                validatable.Validation.TryAdd(key,
                    () =>
                    {
                        var val = type.GetProperty(key)?.GetValue(validatable);
                        return value.All(x => x.Validate(val,
                            string.IsNullOrEmpty(x.ParameterName)
                                ? null
                                : type.GetProperty(x.ParameterName)?.GetValue(validatable)));
                    },
                    value.All(x => x.DefaultValue));
            }
        }
    }
}
