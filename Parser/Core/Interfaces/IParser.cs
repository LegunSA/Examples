using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IParser
    {
        Dictionary<string, List<int>> Parse(IBuffer<ILineItem> inputbuffer);        
    }
}
