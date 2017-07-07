using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Builder;
using Core.ConcreteBuilders;
using InterfaceLibrary;
using Core;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractBuilder builder = new CabbageSaladBuilder();
            Director director = new Director(builder);
            director.Build();
            Salad salad = (Salad)builder.GetResult();

            Console.Write("{0} name {1} prace",salad.Name, salad.Price );

        }
    }
}
