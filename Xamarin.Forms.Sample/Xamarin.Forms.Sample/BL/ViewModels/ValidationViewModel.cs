using System.Windows.Input;
using Core;
using Validation.Base;
using Validation.Extensions;
using Validation.Implementations;
using Xamarin.Forms.Sample.BL.Models;
using Xamarin.Forms.Sample.Helpers;

namespace Xamarin.Forms.Sample.BL.ViewModels
{
    public class ValidationViewModel: Bindable, IValidatable
    {
        public ICommand ValidatePropertyCommand { get; }
        public ICommand ValidateAllCommand { get; }
        
        public ValidationList Validation { get; } = new ValidationList();
        
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

        [ValueMultiplicationValidation("Wallet.MoneyAmount.Amount")]
        public int? Value
        {
            get => Get<int?>();
            set => Set(value);
        }
        
        public Wallet Wallet { get; } = new Wallet
        {
            MoneyAmount = new MoneyAmount
            {
                Type = "RUB",
                Amount = 100
            }
        };
        
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