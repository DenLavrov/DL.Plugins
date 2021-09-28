using System.Collections;

namespace Filter.Base
{
    public interface IFilter
    {
        IEnumerable Apply(IEnumerable data);
    }
}