using Core.Elements;
using Core.Interfaces;
using Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo
{ 
    class Program
    {
        

        static async Task<Dictionary<string, List<int>>> Run(string[] args)
        {
            IBuffer<ILineItem> _buffer = new BufferLine(); 
            IReader _reader = new Reader();
            IParser _parser = new Parser();

            var readerTask = Task.Run(() => _reader.Read(@"d:/grom2.txt", _buffer));
            var parserTask = Task.Run(() => _parser.Parse(_buffer));

            await Task.WhenAll(readerTask, parserTask);

            return parserTask.Result;
           

        }
        static void Main(string[] args)
        {
            var res = Task.Run(()=>Run(args)).Result;

            Parser par = new Parser();
            Console.WriteLine(res.ResultToString());

            IWriter _writer = new Writer();

            _writer.Write(@"d:/mytext.txt", res);                
        }
    }
}
