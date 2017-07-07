using MediaFiles.Interfaces;
using MediaFiles.Enums;

namespace MediaFiles.ConcreteFile
{
    public abstract class BaseFile : IContent, IFileInfo, IFilePath
    {
        public string Content
        {
            get;
            private set;
        }

        public string FileName
        {
            get;
            private set;
        }

        public string Path
        {
            get;
            private set;
        }

        public FileLocation LocationFile
        {
            get;
            private set;
        }

        public FileType TypeFile
        {
            get;
            private set;
        }

        public BaseFile(string content, string filename, string path, FileType filetype, FileLocation filelocation)
        {
            TypeFile = filetype;
            LocationFile = filelocation;
            Content = content;
            FileName = filename;
            Path = path;
        }
    }
}
