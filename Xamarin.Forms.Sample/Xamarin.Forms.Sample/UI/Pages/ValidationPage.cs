using Xamarin.Forms.Markup;
using Xamarin.Forms.Sample.BL.ViewModels;
using Xamarin.Forms.Sample.UI.Controls;

namespace Xamarin.Forms.Sample.UI.Pages
{
    public class ValidationPage : ContentPage
    {
        public ValidationPage()
        {
            Title = "Validation";
            BindingContext = new ValidationViewModel();
            Content = new StackLayout
            {
                Children =
                {
                    new ValidatableEntry
                        {
                            ValidateCommandParameter = "Login"
                        }
                        .Bind(ValidatableEntry.ErrorTextProperty, "Validation[Login].Message")
                        .Bind(ValidatableEntry.TextProperty, "Login")
                        .Bind(ValidatableEntry.ValidateCommandProperty, "ValidatePropertyCommand")
                        .Bind(ValidatableEntry.IsValidProperty, "Validation[Login]"),
                    new ValidatableEntry
                        {
                            ValidateCommandParameter = "Password"
                        }
                        .Bind(ValidatableEntry.ErrorTextProperty, "Validation[Password].Message")
                        .Bind(ValidatableEntry.TextProperty, "Password")
                        .Bind(ValidatableEntry.ValidateCommandProperty, "ValidatePropertyCommand")
                        .Bind(ValidatableEntry.IsValidProperty, "Validation[Password]"),
                    new Button
                    {
                        Text = "Validate all"
                    }.BindCommand("ValidateAllCommand", parameterPath: null)
                }
            };
        }
    }
}