using Core.Components;
using InterfaceLibrary;

namespace Core.SaladItems
{
    public class Oil:SaladItem, IFat
    {
        public double Fat
        {
            get;
            private set;
        }

        public Oil(string name, double price, double weigth, double fat) : base(name, price, weigth)
        {
            Fat = fat;
        }
    }
}
