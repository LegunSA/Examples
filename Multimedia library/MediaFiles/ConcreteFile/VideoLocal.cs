using MediaFiles.Interfaces;
using MediaFiles.Enums;

namespace MediaFiles.ConcreteFile
{
    public class VideoLocal:BaseFile, IVideo, IDisc
    {
        public VideoLocal(string content, string filename, string path) : base(content, filename, path, FileType.video, FileLocation.local)
        {
        }
    }
}
