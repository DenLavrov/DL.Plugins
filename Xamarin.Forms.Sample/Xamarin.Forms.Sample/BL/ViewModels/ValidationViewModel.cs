using System.Windows.Input;
using Validation.Base;
using Validation.Extensions;
using Validation.Implementations;
using Xamarin.Forms.Sample.BL.Models;
using Xamarin.Forms.Sample.Helpers;
using Xamarin.Forms.Sample.Resources;

namespace Xamarin.Forms.Sample.BL.ViewModels
{
    public class ValidationViewModel: Bindable
    {
        public ICommand ValidateCommand { get; }
        public ICommand ValidateAllCommand { get; }

        public IValidationObject<string> Login
        {
            get => Get(new BindableValidationObject<string>
            {
                ValidationRules =
                {
                    new NotEmptyValidationRule { Message = Localization.Login_Is_Empty_Error_Message },
                    new RegexValidationRule(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                    {
                        Message = "Regex error"
                    }
                }
            });
            set => Set(value);
        }
        
        public IValidationObject<string> Password
        {
            get => Get(new BindableValidationObject<string>
            {
                ValidationRules =
                {
                    new NotEmptyValidationRule
                    {
                        Message = Localization.Pass_Is_Empty_Error_Message
                    },
                    new MinLengthValidationRule(6)
                    {
                        Message = Localization.Pass_Length_Error_Message
                    }
                }
            });
            set => Set(value);
        }

        public IValidationObject<int?> Value
        {
            get => Get(new BindableValidationObject<int?>
            {
                ValidationRules =
                {
                    new ValueMultiplicationValidationRule(() => Wallet.MoneyAmount.Amount)
                }
            });
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
            ValidateCommand = new Command<IValidatable>(Validate);
            ValidateAllCommand = new Command(ValidateAllProperties);
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