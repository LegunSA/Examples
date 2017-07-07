using Core.Components;
using InterfaceLibrary;

namespace Core.SaladItems
{
    public class Meat:SaladItem, IProteins,ICalories, IFat
    {
        public double Calories
        {
            get;
            private set;
        }

        public double Fat
        {
            get;
            private set;
        }

        public double Proteins
        {
            get;
            private set;
        }

        public Meat(string name, double price, double weigth, double calories, double fat, double proteins) : base(name, price, weigth)
        {
            Calories = calories;
            Fat = fat;
            Proteins = proteins;
        }
    }
}
