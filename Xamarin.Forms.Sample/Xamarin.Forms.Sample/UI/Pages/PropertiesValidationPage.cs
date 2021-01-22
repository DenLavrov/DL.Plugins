using Xamarin.Forms.Markup;
using Xamarin.Forms.Sample.BL.ViewModels;
using Xamarin.Forms.Sample.UI.Controls;

namespace Xamarin.Forms.Sample.UI.Pages
{
    public class PropertiesValidationPage : ContentPage
    {
        public PropertiesValidationPage()
        {
            BindingContext = new PropertiesValidationViewModel();
            Content = new StackLayout
            {
                Children = {
                    new ValidatableEntry
                    {
                        ValidateCommandParameter = "Login",
                        ErrorText = "Wrong login"
                    }
                        .Bind(ValidatableEntry.TextProperty, "Login")
                        .Bind(ValidatableEntry.ValidateCommandProperty, "Validation.NotifyPropertiesChangedCommand")
                        .Bind(ValidatableEntry.IsValidProperty, "Validation[Login]"),
                    new ValidatableEntry
                        {
                            ValidateCommandParameter = "Password",
                            ErrorText = "Wrong password"
                        }
                        .Bind(ValidatableEntry.TextProperty, "Password")
                        .Bind(ValidatableEntry.ValidateCommandProperty, "Validation.NotifyPropertiesChangedCommand")
                        .Bind(ValidatableEntry.IsValidProperty, "Validation[Password]"),
                    new Button
                    {
                        Text = "Validate all"
                    }.BindCommand("Validation.NotifyPropertiesChangedCommand", parameterPath: null)
                }
            };
        }
    }
}