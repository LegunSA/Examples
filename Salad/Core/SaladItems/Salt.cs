using System.Collections.Generic;
using Core.Components;
using InterfaceLibrary;

namespace Core.SaladItems
{
    public class Salt:SaladItem, IMicroelements
    {
        public ICollection<string> Microelements
        {
            get;
            private set;
        }

        public Salt(string name, double price, double weigth, ICollection<string> microelements) : base(name, price, weigth)
        {
            Microelements = microelements;
        }

        
    }
}
