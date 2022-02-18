using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Filter.Base;
using Xamarin.Forms.Sample.Annotations;

namespace Xamarin.Forms.Sample.BL.Models
{
    public class BindableFilterableObject<T>: IFilterableObject<T>, INotifyPropertyChanged
    {
        IEnumerable<T> _value;

        public IEnumerable<T> Value
        {
            get => _value;
            set
            {
                _value = value;
                Filter();
            }
        }

        public IEnumerable<T> FilteredValue { get; private set; }
        
        public List<IFilter<T>> Filters { get; } = new();

        public void Filter()
        {
            if (!Filters.Any())
            {
                FilteredValue = Value;
                return;
            }
            var result = Filters[0].Apply(Value);
            foreach (var filter in Filters.Skip(1))
                result = filter.Apply(result);
            FilteredValue = result;
            OnPropertyChanged(nameof(FilteredValue));
        }

        public void RemoveFiltering()
        {
            FilteredValue = Value;
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