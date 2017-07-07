using Core.Components;
using InterfaceLibrary;


namespace Core.SaladItems
{
    public class Vegetable:SaladItem, ICalories, ICarbohydrates
    {
        public double Calories
        {
            get;
            private set;
        }

        public double Carbohydrates
        {
            get;
            private set;
        }

        public Vegetable(string name, double price, double weigth, double calories, double carohydrates) : base(name, price, weigth)
        {
            Calories = calories;
            Carbohydrates = carohydrates;
        }
    }
}
