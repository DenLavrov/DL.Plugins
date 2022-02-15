using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Validation.Base;
using Xamarin.Forms.Sample.Annotations;
using Xamarin.Forms.Sample.Helpers;

namespace Xamarin.Forms.Sample.BL.Models
{
    public class BindableValidationObject<T>: ValidationObject<T>, INotifyPropertyChanged
    {
        public override void Validate()
        {
            base.Validate();
            OnPropertyChanged(nameof(Message));
            OnPropertyChanged(nameof(IsValid));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}