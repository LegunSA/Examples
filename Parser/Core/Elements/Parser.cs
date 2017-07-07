using Core.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Elements
{  
    public class Parser : IParser
    {
        private static string[] separators = { ",", ".", "!", "?", ";", ":", " " };

        public object StringBilder { get; private set; }

        private void Parse(ILineItem lineitem, ConcurrentBag<ILineItem> wordsLocations)
        {
            string[] words = lineitem.TextLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in words)
            {
                wordsLocations.Add(new LineItem(text: item, number: lineitem.Number));
            }
        }


        public Dictionary<string, List<int>> Parse(IBuffer<ILineItem> inputbuffer)
        {
            bool _exit = false;
            Dictionary<string, List<int>> parseResult = new Dictionary<string, List<int>>();

            while (!_exit)
            {
                if (inputbuffer.ParserMayWork)
                {
                    var linesToProcess = new List<ILineItem>();
                    while (!inputbuffer.ConBag.IsEmpty && linesToProcess.Count < 30)
                    {
                        ILineItem itm;
                        inputbuffer.ConBag.TryDequeue(out itm);
                        linesToProcess.Add(itm);
                    }

                    var wordsLocations = new ConcurrentBag<ILineItem>();
                    Parallel.ForEach(linesToProcess, line =>
                    {
                        Parse(line, wordsLocations);
                    });

                    var res =  wordsLocations.GroupBy(x => new { word = x.TextLine }).Select(x => new { word = x.Key.word, list = x.Select(c => c.Number) })
                            .OrderBy(x => x.word);

                    foreach (var re in res)
                    {
                        List<int> positions;
                        if (parseResult.TryGetValue(re.word, out positions))
                        {
                            parseResult[re.word] = positions.Concat(re.list).ToList();
                        }
                        else
                        {
                            parseResult.Add(re.word, re.list.ToList());
                        }
                    }
                }

                if (inputbuffer.ConBag.IsEmpty && inputbuffer.LoadConpleted)
                {
                    _exit = true;
                    inputbuffer.ParserMayWork = false;

                }
                else if (inputbuffer.ConBag.IsEmpty)
                {
                    inputbuffer.ReaderMayWork = true;
                    inputbuffer.ParserMayWork = false;

                }

                if (!_exit)
                {
                    Thread.Sleep(50);
                }

            }

            return parseResult;
        }      
    }
}
