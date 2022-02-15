using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Filter.Base;

namespace Xamarin.Forms.Sample.BL.Models.Filters
{
    public class AlphabetFilter<T>: IFilter<T>
    {
        public IEnumerable<T> Apply(IEnumerable<T> data)
        {
            return data?.OrderBy(x => x.ToString()).ToList();
        }
    }
}