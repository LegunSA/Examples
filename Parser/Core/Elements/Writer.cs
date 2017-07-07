using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;


namespace Core.Elements
{
    public class Writer : IWriter
    {
        public void Write(string path, Dictionary<string, List<int>> concorddance)
        {
            using (StreamWriter streamwriter = new StreamWriter(path))
            {
                streamwriter.Write(concorddance.ResultToString());
            }               
        }
    }
}
