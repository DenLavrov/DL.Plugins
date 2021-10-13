using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using PropertiesValidation.Base;
using Validation.Base;
using Validation.Extensions;
using Validation.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Sample.Helpers;

namespace Xamarin.Forms.Sample.BL.ViewModels
{
    public class ValidationViewModel: Bindable, IValidatable
    {
        public ICommand ValidatePropertyCommand { get; }
        public ICommand ValidateAllCommand { get; }
        
        public DynamicValuesDictionary<string, ValidationResult> Validation { get; } =
            new DynamicValuesDictionary<string, ValidationResult>();
        
        [NotEmptyValidation(errorMessageKey: ValidationConsts.LoginIsEmptyValidationMessageKey)]
        [RegexValidation(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", errorMessage: "Regex error")]
        public string Login
        {
            get => Get<string>();
            set => Set(value);
        }

        [NotEmptyValidation(errorMessageKey: ValidationConsts.PassIsEmptyValidationMessageKey)]
        [MinLengthValidation(6, errorMessageKey: ValidationConsts.PassLengthErrorValidationMessageKey)]
        public string Password
        {
            get => Get<string>();
            set => Set(value);
        }

        public ValidationViewModel()
        {
            ValidatePropertyCommand = new Command(ValidateProperty);
            ValidateAllCommand = new Command(ValidateAllProperties);
            ((IValidatable)this).Init(ValidationConsts.ValidationMessages);
        }

        void ValidateAllProperties()
        {
            this.ValidateAll();
        }

        void ValidateProperty(object obj)
        {
            this.Validate(obj?.ToString());
        }
    }
}