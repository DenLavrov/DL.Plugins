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
                    new ValidatableEntry
                        {
                            ValidateCommandParameter = nameof(ValidationViewModel.Login)
                        }
                        .Bind(ValidatableEntry.ErrorTextProperty, "Validation[Login].Message")
                        .Bind(ValidatableEntry.TextProperty, nameof(ValidationViewModel.Login))
                        .Bind(ValidatableEntry.ValidateCommandProperty, nameof(ValidationViewModel.ValidatePropertyCommand))
                        .Bind(ValidatableEntry.IsValidProperty, "Validation[Login]"),
                    new ValidatableEntry
                        {
                            ValidateCommandParameter = nameof(ValidationViewModel.Password)
                        }
                        .Bind(ValidatableEntry.ErrorTextProperty, "Validation[Password].Message")
                        .Bind(ValidatableEntry.TextProperty, nameof(ValidationViewModel.Password))
                        .Bind(ValidatableEntry.ValidateCommandProperty, nameof(ValidationViewModel.ValidatePropertyCommand))
                        .Bind(ValidatableEntry.IsValidProperty, "Validation[Password]"),
                    new ValidatableEntry
                        {
                            ValidateCommandParameter = nameof(ValidationViewModel.Value),
                            ErrorText = Localization.Wrong_Value_Error
                        }
                        .Bind(ValidatableEntry.TextProperty, nameof(ValidationViewModel.Value))
                        .Bind(ValidatableEntry.ValidateCommandProperty, nameof(ValidationViewModel.ValidatePropertyCommand))
                        .Bind(ValidatableEntry.IsValidProperty, "Validation[Value]"),
                    new Button
                    {
                        Text = "Validate all"
                    }.BindCommand(nameof(ValidationViewModel.ValidateAllCommand), parameterPath: null)
                }
            };
        }
    }
}