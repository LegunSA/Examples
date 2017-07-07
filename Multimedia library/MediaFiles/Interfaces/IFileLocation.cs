using MediaFiles.Enums;

namespace MediaFiles.Interfaces
{
    public interface IFilePath
    {
        FileLocation LocationFile { get; }
        string Path{ get; }
    }
}
