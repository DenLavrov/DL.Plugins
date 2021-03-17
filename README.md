# PropertiesValidation
Simple lightweight validation for properties in Xamarin.Forms projects with MVVM architecture
# Usage

First thing is to implement IValidatable interface by the object which properties you want to be validated.
```

public class BaseViewModel: IValidatable
    {
        public DynamicValuesDictionary<string, ValidationResult> Validation { get; set; }

        public BaseViewModel()
        {
            ((IValidatable)this).Init();
        }

        protected ValidationResult Validate()
        {
            return ((IValidatable) this).ValidateAll();
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

You can access the result of validation like this.

```

Validation["PropertyName"]

```

Validation implements INotifyProperyChanged so after Notify Command is triggered ui gets changes. And you can pass harcoded value

```

Validation["PropertyName"] = new ValidationResult { IsValid = false }

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

# Examples

Usage with pure MVVM architecture can be found in samples
