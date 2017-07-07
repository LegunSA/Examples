using Core.Components;
using InterfaceLibrary;

namespace Core.SaladItems
{
    public class Decoration:SaladItem, IDecoration
    {
        public Decoration(string name, double price, double weigth) : base(name, price, weigth)
        {}
    }
}
