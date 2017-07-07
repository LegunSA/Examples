using AirportDemo.Enums;
using AirportDemo.Interfaces;

namespace AirportDemo.AirCrafts
{
    public class CargoHelicopter: AbstractHelicopter, ICargoAirCraft
    {
        public int CarryingCapacity { get; private set; }

        public override int Capacity() { return CarryingCapacity; }

        public CargoHelicopter(string aircraftname, string id, int range,  int fuelconsumption, int carryingcapacity, RotorSystem rotorsystem) : base(aircraftname, id, range, fuelconsumption, rotorsystem)
        {
            CarryingCapacity = carryingcapacity;            
        }        
    }
}
