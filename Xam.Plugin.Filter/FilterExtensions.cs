using System.Collections;
using Xam.Plugin.Filter.Base;

namespace Xam.Plugin.Filter
{
    public static class FilterExtensions
    {
        public static IFilterable SetFilter(this IFilterable filterable, string propertyName, IFilter filter,
            bool applyFilter = true, IEnumerable defaultValue = null)
        {
            if (filterable?.FilteredData == null) return null;
            filterable.FilteredData.TryUpdate(propertyName,
                () => filter?.Apply(
                    filterable.GetType().GetProperty(propertyName)?.GetValue(filterable) as IEnumerable), defaultValue);
            filterable.Filter = filter;
            if(applyFilter) filterable.ApplyFilter(propertyName);
            return filterable;
        }
    }
}