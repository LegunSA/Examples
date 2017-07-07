using MediaFiles.ConcreteFile;
using MediaFiles.Interfaces;
using System;

namespace Player
{
    public abstract class AbstractPlayer:IPlayer
    {
        public void Play(IContent file)
        {
            Console.WriteLine("Content - {0}, who called - {1}", file.Content, GetType());
        }
    }
}
