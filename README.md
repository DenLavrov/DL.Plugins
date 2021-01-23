# PropertiesValidation
Simple lightweight validation for properties in Xamarin.Forms projects with MVVM architecture
# Usage

First thing is to implement IValidatable interface by the object which properties you want to be validated
```

public class BaseViewModel: IValidatable
    {
        public DynamicValuesDictionary<string, bool> Validation { get; set; }

        public BaseViewModel()
        {
            ((IValidatable)this).Init();
        }

        protected bool Validate()
        {
            return ((IValidatable) this).ValidateAll();
        }
    }
    
```
You can validate any property within validatable class by marking it with ValidationAttribute

```

[RegexValidation(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Login
        {
            get => Get<string>();
            set => Set(value);
        }
        
```

And then triiger a validation by command. You can bind to it from your page

```

Validation.NotifyOfPropertiesChanged.Execute("{PropertyName}");

```

You can access the result of validation like this

```

Validation["PropertyName"]

```

Validation implements INotifyProperyChanged so after Notify Command triggered ui gets changes. And you can pass harcoded value 

```

Validation["PropertyName"] = false

```

this will also trigger property changed event

