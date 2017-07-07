using MediaFiles.Interfaces;
using Core.Interfaces;
using Player;

namespace Core.MediaItem
{
    public class MediaFile<T> : IMediaItem where T : IContent
    {
        private T _item;
        public void Play(IPlayer player)
        {
            player.Play(_item);
        }

        public MediaFile(T item)
        {
            _item = item;
        }
    }
}
