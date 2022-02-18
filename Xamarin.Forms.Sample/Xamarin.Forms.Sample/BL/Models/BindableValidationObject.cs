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
    public class BindableValidationObject<T>: IValidationObject<T>, INotifyPropertyChanged
    {
        T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public bool IsValid { get; private set; } = true;
        public string Message { get; private set; }
        public string DefaultMessage { get; set; }
        public List<IValidationRule<T>> ValidationRules { get; } = new List<IValidationRule<T>>();
        
        public bool Validate()
        {
            string message = null;
            var isValid = ValidationRules.All(x =>
            {
                var validationResult = x.Validate(Value);
                if (!validationResult)
                    message = validationResult.Message;
                return validationResult;
            });
            if (isValid)
            {
                IsValid = true;
                OnPropertyChanged(nameof(IsValid));
                return true;
            }
            
            Message = message ?? DefaultMessage;
            IsValid = false;
            OnPropertyChanged(nameof(Message));
            OnPropertyChanged(nameof(IsValid));
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}