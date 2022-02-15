using System.Collections;
using System.Collections.Generic;

namespace Filter.Base
{
    public interface IFilter<T>
    {
        IEnumerable<T> Apply(IEnumerable<T> data);
    }
}