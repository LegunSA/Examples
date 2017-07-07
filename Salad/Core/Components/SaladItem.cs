using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary;

namespace Core.Components
{
    public abstract class SaladItem : ISaladItem
    {
        public string Name
        {
            get;
            private set;            
        }

        public double Price
        {
            get;
            private set;
        }

        public double Weight
        {
            get;
            private set;
        }

        public SaladItem(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
    }
}
