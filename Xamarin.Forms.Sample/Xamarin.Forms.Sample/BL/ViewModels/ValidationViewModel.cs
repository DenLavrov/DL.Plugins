using System.Collections.Generic;
using System.Windows.Input;
using Validation.Base;
using Validation.Extensions;
using Validation.Implementations;
using Xamarin.Forms.Sample.BL.Models;
using Xamarin.Forms.Sample.Helpers;
using Xamarin.Forms.Sample.Helpers.Validation;
using Xamarin.Forms.Sample.Resources;

namespace Xamarin.Forms.Sample.BL.ViewModels
{
    public class ValidationViewModel: Bindable
    {
        public ICommand ValidateCommand { get; }
        public ICommand ValidateAllCommand { get; }

        public IValidationObject<string> Login { get; } = new BindableValidationObject<string>
        {
            ValidationRules =
            {
                new IsNotEmptyValidationRule { Message = Localization.Login_Is_Empty_Error_Message },
                new RegexValidationRule(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                {
                    Message = "Regex error"
                }
            }
        };

        public IValidationObject<string> Password { get; } = new BindableValidationObject<string>
        {
            ValidationRules =
            {
                new IsNotEmptyValidationRule
                {
                    Message = Localization.Pass_Is_Empty_Error_Message
                },
                new LengthIsMoreThenValidationRule<string, char>(6)
                {
                    Message = Localization.Pass_Length_Error_Message
                }
            }
        };

        public IValidationObject<int?> Value { get; } = new BindableValidationObject<int?>();

        public Wallet Wallet { get; } = new()
        {
            MoneyAmount = new MoneyAmount
            {
                Type = "RUB",
                Amount = 100
            }
        };
        
        public ValidationViewModel()
        {
            ValidateCommand = new Command<IValidatable>(Validate);
            ValidateAllCommand = new Command(ValidateAllProperties);
            Value.ValidationRules.Add(new MultiplicationValidationRule(Wallet.MoneyAmount.Amount));
        }

        void ValidateAllProperties()
        {
            Login.Validate();
            Password.Validate();
            Value.Validate();
        }

        void Validate(IValidatable obj)
        {
            obj.Validate();
        }
    }
}