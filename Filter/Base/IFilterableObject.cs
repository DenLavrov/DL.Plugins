using System.Collections.Generic;

namespace Filter.Base
{
    public interface IFilterable
    {
        void Filter();

        void RemoveFiltering();
    }
    
    public interface IFilterableObject<T>: IFilterable
    {
        public IEnumerable<T> Value { get; }
        
        public IEnumerable<T> FilteredValue { get; }
        
        public List<IFilter<T>> Filters { get; }
    }
}