using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PropertiesValidation.Implementations;
using Xamarin.Forms;

namespace Xamarin.Forms.Sample.BL.ViewModels
{
    public class PropertiesValidationViewModel : BaseViewModel
    {
        [NotEmptyValidation("Login cannot be empty")]
        [RegexValidation(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", errorMessage: "Regex error")]
        public string Login
        {
            get => Get<string>();
            set => Set(value);
        }

        [NotEmptyValidation("Password cannot be empty")]
        [MinLengthValidation(6, errorMessage: "Password has to be 6 letters long")]
        public string Password
        {
            get => Get<string>();
            set => Set(value);
        }
    }
}