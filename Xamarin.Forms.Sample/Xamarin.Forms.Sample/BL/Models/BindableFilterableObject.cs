using System.ComponentModel;
using System.Runtime.CompilerServices;
using Filter.Base;
using Xamarin.Forms.Sample.Annotations;

namespace Xamarin.Forms.Sample.BL.Models
{
    public class BindableFilterableObject<T>: FilterableObject<T>, INotifyPropertyChanged
    {
        public override void Filter()
        {
            base.Filter();
            OnPropertyChanged(nameof(FilteredValue));
        }

        public override void RemoveFiltering()
        {
            base.RemoveFiltering();
            OnPropertyChanged(nameof(FilteredValue));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}