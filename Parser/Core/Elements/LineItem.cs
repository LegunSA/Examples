using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Elements
{
    public class LineItem : ILineItem
    {
        public int Number
        {
            get; private set;
        }

        public string TextLine
        {
            get; private set;
        }

        public LineItem(int number, string text)
        {
            Number = number;
            TextLine = text;
        }

    }
}
