# DL.Plugin.Validation
Simple lightweight validation for properties in .NET projects
# Usage
Use IValidationObject<T> with ValidationRules to provide a validation to a property

```

public IValidationObject<string> Login { get; } = new ValidationObject<string>
            {
                ValidationRules = { Your list of validation rules }
            };
        
```

Trigger a validation

```

Login.Validate();

```

You can access the result of validation like this.

```

Login.IsValid

```

Binding example

```

.Bind(IsValidProperty, "Login.IsValid");

.Bind(ErrorMessageProperty, "Login.Message");

.Bind(ValueProperty, "Login.Value");

```

# Custom Validation

Simply implement IValidationRule<T>

```
public class NotEmptyValidationRule : IValidationRule<string>
    {
        public string Message { get; set; }

        public ValidationResult Validate(string value)
        {
            return !string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)
                ? ValidationResult.Valid()
                : ValidationResult.Invalid(Message);
        }
    }

```

# Examples

Usage for Xamarin.Forms project with pure MVVM architecture can be found in samples
