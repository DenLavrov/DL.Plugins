using System;
using System.Collections;
using PropertiesValidation.Base;

namespace Filter.Base
{
    public interface IFilterable
    {
        public DynamicValuesDictionary<string, IEnumerable> FilteredData { get; }

        public void Init(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
                this.SetFilter(propertyName, null);
        }
    }
}