using Core.Interfaces;
using System.IO;
using System.Threading;

namespace Core.Elements
{
   
    public class Reader : IReader
    {
        public int LineInPage { get; set; }
        public int SleepTime { get; set; }

        public void Read(string path, IBuffer<ILineItem> result)
        {
            int _lineNumber = 1; 
            int _pageNumber = 1; 

            using (var reader = new StreamReader(path))
            {
                while (reader.Peek() >= 0)
                {
                    if (result.ReaderMayWork)
                    {
                        result.ConBag.Enqueue(new LineItem(_pageNumber, reader.ReadLine().ToLower()));
                        _lineNumber++;
                        if (_lineNumber % LineInPage == 0)
                        {
                            _pageNumber++;
                            
                            while (!result.ConBag.IsEmpty)
                            {
                                result.ParserMayWork = true;
                                result.ReaderMayWork = false;                               
                            }
                        }
                    }
                    else { Thread.Sleep(1); }
                }
                result.LoadConpleted = true;
                result.ReaderMayWork = false;
                result.ParserMayWork = true;
            }
        }

        public Reader()
        {
            SleepTime = 0;
            LineInPage = 1;
        }
    }
}
