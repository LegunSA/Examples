using MediaFiles.Interfaces;
using MediaFiles.Enums;

namespace MediaFiles.ConcreteFile
{
    public class VideoWeb:BaseFile, IVideo, IInternet
    {
        public VideoWeb(string content, string filename, string path) : base(content, filename, path, FileType.video, FileLocation.internet)
        {
        }
    }
}
