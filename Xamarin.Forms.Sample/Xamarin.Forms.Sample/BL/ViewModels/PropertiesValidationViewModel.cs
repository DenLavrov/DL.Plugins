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
        [RegexValidation(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Login
        {
            get => Get<string>();
            set => Set(value);
        }

        [MinLengthValidation(6)]
        public string Password
        {
            get => Get<string>();
            set => Set(value);
        }
    }
}