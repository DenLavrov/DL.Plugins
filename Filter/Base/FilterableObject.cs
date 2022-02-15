using System.Collections.Generic;
using System.Linq;

namespace Filter.Base
{
    public class FilterableObject<T>: IFilterableObject<T>
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
        
        public List<IFilter<T>> Filters { get; } = new List<IFilter<T>>();

        public virtual void Filter()
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
        }

        public virtual void RemoveFiltering()
        {
            FilteredValue = Value;
        }
    }
}