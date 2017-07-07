using Core.Interfaces;
using System.Collections.Concurrent;

namespace Core.Elements
{
    public class BufferLine : IBuffer<ILineItem>
    {
        public ConcurrentQueue<ILineItem> ConBag
        {
            get;
            set;
        }

        public bool LoadConpleted
        {
            get;
            set;
        }

        public bool ReaderMayWork
        {
            get;
            set;
        }

        public bool ParserMayWork
        {
            get;
            set;
        }

        public BufferLine()
        {
            ConBag = new ConcurrentQueue<ILineItem>();
            LoadConpleted = false;
            ReaderMayWork = true;
            ParserMayWork = false;
        }
    }
}
