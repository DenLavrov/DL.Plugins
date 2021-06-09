using System;
using System.Collections;
using System.Runtime.CompilerServices;
using PropertiesValidation.Base;

namespace Xam.Plugin.Filter.Base
{
    public interface IFilterable
    {
        public DynamicValuesDictionary<string, IEnumerable> FilteredData { get; }
        
        public IFilter Filter { get; set; }

        public void ApplyFilter([CallerMemberName]string propertyName = null)
        {
            if (FilteredData == null)
                throw new NullReferenceException("Call Init() first");
            FilteredData.NotifyPropertiesChangedCommand.Execute(propertyName);
        }
    }
}