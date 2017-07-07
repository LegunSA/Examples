using MediaFiles.Interfaces;
using Core.Interfaces;
using System.Collections.Generic;
using Player;

namespace Core.MediaItem
{
    public class MediaDisc : IMediaItem
    {
        IEnumerable<IContent> _content;

        public void Play(IPlayer player)
        {
            foreach (var item in _content) { player.Play(item); };
        }

        public MediaDisc(IEnumerable<IDisc> mediafiles)
        {
            _content = mediafiles;
        }
    }
}
