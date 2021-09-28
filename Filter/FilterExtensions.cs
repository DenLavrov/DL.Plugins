using System.Collections;
using Filter.Base;

namespace Filter
{
    public static class FilterExtensions
    {
        public static IFilterable SetFilter(this IFilterable filterable, string propertyName, IFilter filter,
            bool applyFilter = true, IEnumerable defaultValue = null)
        {
            filterable?.FilteredData?.TryUpdate(propertyName,
                () =>
                {
                    var data = filterable.GetType().GetProperty(propertyName)?.GetValue(filterable) as IEnumerable;
                    return filter?.Apply(data) ?? data;
                }, defaultValue);
            if(applyFilter) filterable?.ApplyFilter(propertyName);
            return filterable;
        }
        
        public static IFilterable ApplyFilter(this IFilterable filterable, string propertyName = null)
        {
            if (filterable?.FilteredData == null)
                return null;
            if (filterable.FilteredData.NotifyPropertiesChangedCommand.CanExecute(null))
                filterable.FilteredData.NotifyPropertiesChangedCommand.Execute(propertyName);
            return filterable;
        }
        
        public static IFilterable ApplyAllFilters(this IFilterable filterable)
        {
            if (filterable?.FilteredData == null)
                return null;
            if (filterable.FilteredData.NotifyPropertiesChangedCommand.CanExecute(null))
                filterable.FilteredData.NotifyPropertiesChangedCommand.Execute(null);
            return filterable;
        }
    }
}