# Xam.Plugin.Validation
Simple lightweight validation for properties in Xamarin.Forms projects with MVVM architecture
# Usage

First thing is to implement IValidatable interface by the object which properties you want to be validated.
```

public class BaseViewModel: IValidatable
    {
        public ValidationList Validation { get; } = new ValidationList();

        public BaseViewModel()
        {
            ((IValidatable)this).Init();
        }
    }
    
    
```
You can validate any property within validatable class by marking it with ValidationAttribute.
If there are more than one attribute, then property will be valid if all of the conditions are matched.

```

[NotEmptyValidation("Login cannot be empty")]
[RegexValidation(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", errorMessage: "Regex error")]
public string Login
{
    get => Get<string>();
    set => Set(value);
}
        
```

Triger a validation by command. You can bind to it from your page passing a property name as a command parameter.
You can pass IEnumerable of PropertyNames, to validate a set of properties, or null to validate all of proprties.

```

Validation.NotifyOfPropertiesChanged.Execute("{PropertyName}");

```
There are two extension methods Validate(string propertyName) and ValidateAll() which return ValidationResult and trigger validation

```

var validationResult = (Some class instance which implements IValidatable).Validate("PropertyName");

```

You can access the result of validation like this.

```

Validation["PropertyName"]

```

Validation implements INotifyProperyChanged so after Notify Command is triggered ui gets changes.
Binding example

```

.Bind(IsValidProperty, "Validation['PropertyName'].IsValid"); or .Bind(IsValidProperty, "Validation['PropertyName']");

.Bind(ErrorMessageProperty, "Validation['PropertyName'].Message");

```

And you can pass harcoded value

```

Validation["PropertyName"] = new ValidationResult { IsValid = false } or Validation["PropertyName"] = false;

```

this will also trigger property changed event

# Custom Validation

Simply derive from ValidationAttribute

```
public class NotEmptyValidationAttribute: ValidationAttribute
    {
        public NotEmptyValidationAttribute(string errorMessage = null): base(errorMessage: errorMessage)
        {
        }
        
        public override bool Validate(object input, object parameter = null)
        {
            var value = input?.ToString();
            return !string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value);
        }
    }

```

# Error messages from resource file

```
Each attribute has errorMessageKey parameter:

[SomeValidation(errorMessageKey: Error message key)]

Just provide 'IReadOnlyDictionary<string, string> errorMessages', whose keys then will be used as errorMessageKey parameter, to Init(errorMessages) method:

((IValidatable)this).Init(new Dictionary<string, string>{
{Error message key, Error message from resources}
});

```

# Examples

Usage with pure MVVM architecture can be found in samples
