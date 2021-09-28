using System.Collections;
using System.Linq;
using Filter.Base;

namespace Xamarin.Forms.Sample.BL.Models.Filters
{
    public class AlphabetFilter: IFilter
    {
        static AlphabetFilter _instance;

        public static AlphabetFilter Instance => _instance ??= new AlphabetFilter();
        
        public IEnumerable Apply(IEnumerable data)
        {
            return data?.OfType<object>().OrderBy(x => x.ToString()).ToList();
        }
    }
}