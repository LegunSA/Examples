using MediaFiles.Interfaces;
using MediaFiles.Enums;

namespace MediaFiles.ConcreteFile
{
    public class PhotoLocal:BaseFile, IPhoto, IDisc
    {
        public PhotoLocal(string content, string filename, string path) : base(content, filename, path, FileType.photo, FileLocation.local)
        {
        }
    }
}
