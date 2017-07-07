using MediaFiles.ConcreteFile;
using MediaFiles.Interfaces;

namespace Player
{
    public interface IPlayer
    {
        void Play(IContent file);
    }
}
