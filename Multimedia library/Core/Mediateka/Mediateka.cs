using Core.Interfaces;
using Player;
using System.Collections.Generic;

namespace Core.Mediateka
{
    public class Mediateka
    {
        private IPlayer _player;
        private IEnumerable<IMediaItem> _mediafiles;

        public void Play()
        {
            foreach(var item in _mediafiles)
            {
                item.Play(_player);
            }
        }
        public Mediateka(AbstractFactory factory)
        {
            _player = factory.Player();
            _mediafiles = factory.MediaItems();
        }
    }
}
