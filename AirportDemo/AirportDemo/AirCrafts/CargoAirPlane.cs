using AirportDemo.Enums;
using AirportDemo.Interfaces;

namespace AirportDemo.AirCrafts
{
    public class CargoAirPlane: AbstractAirPlane, ICargoAirCraft
    {        
        public int CarryingCapacity { get; private set; }

        public override int Capacity() { return CarryingCapacity; }

        public CargoAirPlane(string aircraftname, string id, int range, int fuelconsumption, int carryingcapacity, WingType wingtype):base(aircraftname, id, range, fuelconsumption, wingtype)
        {          
            CarryingCapacity = carryingcapacity;          
        }
    }
}
    