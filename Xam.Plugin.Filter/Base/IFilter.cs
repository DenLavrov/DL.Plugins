using System.Collections;

namespace Xam.Plugin.Filter.Base
{
    public interface IFilter
    {
        IEnumerable Apply(IEnumerable data);
    }
}