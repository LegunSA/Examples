using MediaFiles.Enums;

namespace MediaFiles.Interfaces
{
    public interface IContent
    { 
        FileType TypeFile {get;}
        string Content { get; }
    }
}
