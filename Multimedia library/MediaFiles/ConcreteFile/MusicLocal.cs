using MediaFiles.Interfaces;
using MediaFiles.Enums;

namespace MediaFiles.ConcreteFile
{
    public class MusicLocal : BaseFile, IMusic, IDisc
    {
        public MusicLocal(string content, string filename, string path) : base(content, filename, path, FileType.music, FileLocation.local)
        {
        }
    }
}