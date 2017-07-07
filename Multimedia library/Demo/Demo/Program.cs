using Core.Mediateka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory factory = new MediatekaFactory();
            Mediateka media = new Mediateka(factory);
            media.Play();
        }
    }
}
