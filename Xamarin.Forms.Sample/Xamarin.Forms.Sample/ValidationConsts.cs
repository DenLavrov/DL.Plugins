using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Sample.Resources;

namespace Xamarin.Forms.Sample
{
    public static class ValidationConsts
    {
        public const string LoginIsEmptyValidationMessageKey = nameof(LoginIsEmptyValidationMessageKey);
        public const string PassLengthErrorValidationMessageKey = nameof(PassLengthErrorValidationMessageKey);
        public const string PassIsEmptyValidationMessageKey = nameof(PassIsEmptyValidationMessageKey);

        public static readonly ReadOnlyDictionary<string, string> ValidationMessages =
            new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
            {
                {LoginIsEmptyValidationMessageKey, Localization.Login_Is_Empty_Error_Message},
                {PassIsEmptyValidationMessageKey, Localization.Pass_Is_Empty_Error_Message},
                {PassLengthErrorValidationMessageKey, Localization.Pass_Length_Error_Message}
            });
    }
}