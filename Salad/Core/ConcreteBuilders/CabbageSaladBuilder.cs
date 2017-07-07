using System.Collections.Generic;
using Core.Builder;
using InterfaceLibrary;
using Core.SaladItems;

namespace Core.ConcreteBuilders
{
    public class CabbageSaladBuilder:AbstractBuilder
    {
        private ICollection<ISaladItem> saladItems;
        private ISalad cabbageSalad;
        public override void Construct()
        {
            saladItems = new List<ISaladItem>();
            saladItems.Add(new Vegetable("Cabbage", 10, 300, 150, 270));
            saladItems.Add(new Oil ("Vegetable oil", 5, 15, 100));
            saladItems.Add(new Salt("Salt",7,2, new List<string>() { "sodium chloride" }));

            cabbageSalad = new Salad("Cabbage Salad", saladItems);   
            
        }

        public override ISalad GetResult()
        {
            return cabbageSalad;
        }
    }
}
