using AirportDemo.Interfaces;

namespace AirportDemo.AirCrafts
{
    public abstract class AbstractAirCraft:IAirCraft
    {
        public string AirCraftName { get; private set; }

        public string ID { get; private set; }

        public int FuelConsumption { get; private set; }

        public int Range { get; private set; }

        public abstract int Capacity();

        public abstract void Fly();

        public AbstractAirCraft(string aircraftname, string id, int range, int fuelconsumption)
        {
            AirCraftName = aircraftname;
            ID = id;
            Range = range;
            FuelConsumption = fuelconsumption;            
        }
    }
}
