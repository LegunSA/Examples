using Core.Interfaces;
using Player;
using System.Collections.Generic;


namespace Core.Mediateka
{
    public abstract class AbstractFactory
    {
        public abstract IPlayer Player();
        public abstract IEnumerable<IMediaItem> MediaItems ();
    }
}
