using System.Collections.Concurrent;

namespace Core.Interfaces
{
    public interface IBuffer<T>
    {
        ConcurrentQueue<T> ConBag { get; set; }
        bool LoadConpleted { get; set; }
        bool ReaderMayWork  { get; set; }
        bool ParserMayWork { get; set; }
    }
}
