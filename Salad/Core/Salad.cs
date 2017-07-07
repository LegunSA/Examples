using System;
using System.Collections.Generic;
using System.Linq;
using InterfaceLibrary;

namespace Core
{
    public class Salad : ISaladItem, ISalad
    {

        public string Name
        {
            get;
            private set;
        }

        public double Price
        {
            get
            {
                if (SaladItems != null)
                { return SaladItems.Sum(x => x.Price); }
                else throw new InvalidOperationException("Container in Salad cannot be null");
            }
        }

        public ICollection<ISaladItem> SaladItems
        {
            get;
            private set;
        }

        public double Weight
        {
            get
            {
                if (SaladItems != null)
                { return SaladItems.Sum(x => x.Weight); }
                else throw new InvalidOperationException("Container in Salad cannot be null");
            }
        }

        public Salad(string name, ICollection<ISaladItem> salatItems)
        {
            Name = name;
            SaladItems = salatItems;
        }
    }
}
