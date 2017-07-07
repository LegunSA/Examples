using System;
using System.Collections.Generic;
using Core.MediaItem;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Player;

namespace Core.Mediateka
{
    public class MediatekaFactory : AbstractFactory
    {
        public override IEnumerable<IMediaItem> MediaItems()
        {
            return new Initialize().InitializeComponent();
        }

        public override IPlayer Player()
        {
            return new Player.Player();
        }
    }
}
