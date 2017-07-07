using StructureMap;
using MediaFiles.ConcreteFile;
using Player.Players;
using MediaFiles.Interfaces;

namespace Player
{
    public class Player:IPlayer
    {
        private Container _container;

        public void Play(IContent file)
        {
            var _player = Changer(file);
            _player.Play(file);
        }

        private IPlayer Changer(IContent file)
        {
            return _container.GetInstance<IPlayer>(file.GetType().ToString());
        }

        public Player()
        {
            _container= new Container(x => {
                x.For<IPlayer>().Use<MusicLocalPlayer>().Named("MediaFiles.ConcreteFile.MusicLocal");
                x.For<IPlayer>().Add<MusicInternetPlayer>().Named("MediaFiles.ConcreteFile.MusicWeb");
                x.For<IPlayer>().Add<PhotoLocalPlayer>().Named("MediaFiles.ConcreteFile.PhotoLocal");
                x.For<IPlayer>().Add<PhotoInternetPlayer>().Named("MediaFiles.ConcreteFile.PhotoWeb");
                x.For<IPlayer>().Add<VideoLocalPlayer>().Named("MediaFiles.ConcreteFile.VideoLocal");
                x.For<IPlayer>().Add<VideoInternetPlayer>().Named("MediaFiles.ConcreteFile.VideoWeb");
            });
        }

    }
}
