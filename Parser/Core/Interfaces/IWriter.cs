using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IWriter
    {
        void Write(string path, Dictionary<string, List<int>> concorddance);
    }
}
