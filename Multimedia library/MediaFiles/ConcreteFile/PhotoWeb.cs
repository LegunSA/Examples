using MediaFiles.Interfaces;
using MediaFiles.Enums;

namespace MediaFiles.ConcreteFile
{
    public class PhotoWeb:BaseFile, IPhoto, IInternet
    {
        public PhotoWeb(string content, string filename, string path) : base(content, filename, path, FileType.photo, FileLocation.internet)
        {
        }
    }
}
