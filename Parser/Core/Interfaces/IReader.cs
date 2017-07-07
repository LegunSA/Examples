namespace Core.Interfaces
{
    public interface IReader
    {
        void Read(string path, IBuffer<ILineItem> result);
    }
}
