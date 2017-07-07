using MediaFiles.Interfaces;
using MediaFiles.Enums;

namespace MediaFiles.ConcreteFile
{
    public class MusicWeb : BaseFile, IMusic, IInternet
    {
        public MusicWeb(string content, string filename, string path) : base(content, filename, path, FileType.music, FileLocation.internet)
        {
        }
    }
}
