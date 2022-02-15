using Xamarin.Forms.Markup;
using Xamarin.Forms.Sample.BL.ViewModels;
using Xamarin.Forms.Sample.Resources;
using Xamarin.Forms.Sample.UI.Controls;

namespace Xamarin.Forms.Sample.UI.Pages
{
    public class ValidationPage : ContentPage
    {
        public ValidationPage()
        {
            Title = "Validation";
            BindingContext = new ValidationViewModel();
            Padding = 20;
            Content = new StackLayout
            {
                Spacing = 20,
                Children =
                {
                    new ValidatableEntry()
                        .Bind(ValidatableEntry.ErrorTextProperty, "Login.Message")
                        .Bind(ValidatableEntry.TextProperty, "Login.Value")
                        .Bind(ValidatableEntry.ValidateCommandProperty, nameof(ValidationViewModel.ValidateCommand))
                        .Bind(ValidatableEntry.ValidateCommandParameterProperty, nameof(ValidationViewModel.Login))
                        .Bind(ValidatableEntry.IsValidProperty, "Login.IsValid"),
                    new ValidatableEntry()
                        .Bind(ValidatableEntry.ErrorTextProperty, "Password.Message")
                        .Bind(ValidatableEntry.TextProperty, "Password.Value")
                        .Bind(ValidatableEntry.ValidateCommandProperty, nameof(ValidationViewModel.ValidateCommand))
                        .Bind(ValidatableEntry.ValidateCommandParameterProperty, nameof(ValidationViewModel.Password))
                        .Bind(ValidatableEntry.IsValidProperty, "Password.IsValid"),
                    new ValidatableEntry
                        {
                            ErrorText = Localization.Wrong_Value_Error
                        }
                        .Bind(ValidatableEntry.TextProperty, "Value.Value")
                        .Bind(ValidatableEntry.ValidateCommandProperty, nameof(ValidationViewModel.ValidateCommand))
                        .Bind(ValidatableEntry.ValidateCommandParameterProperty, nameof(ValidationViewModel.Value))
                        .Bind(ValidatableEntry.IsValidProperty, "Value.IsValid"),
                    new Button
                    {
                        Text = "Validate all"
                    }.BindCommand(nameof(ValidationViewModel.ValidateAllCommand), parameterPath: null)
                }
            };
        }
    }
}