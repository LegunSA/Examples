using AirportDemo.Interfaces;
using AirportDemo.Enums;

namespace AirportDemo.AirCrafts
{
    public class PassengerAirPlane : AbstractAirPlane, IPassengerAirCraft
    {
        public int PassengerCapacity { get; private set; }

        public override int Capacity() { return PassengerCapacity; }

        public PassengerAirPlane(string aircraftname, string id, int range, int fuelconsumption, int passengercapacity, WingType wingtype):base(aircraftname, id, range, fuelconsumption, wingtype)
        {
            PassengerCapacity = passengercapacity;
        }
    }
}
