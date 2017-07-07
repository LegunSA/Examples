using AirportDemo.Enums;
using AirportDemo.Interfaces;

namespace AirportDemo.AirCrafts
{
    public class PassengerHelicopter : AbstractHelicopter, IPassengerAirCraft
    {
        public int PassengerCapacity { get; private set; }

        public override int Capacity() { return PassengerCapacity; }

        public PassengerHelicopter(string aircraftname, string id, int range, int fuelconsumption, int passengercapacity, RotorSystem rotorsystem): base(aircraftname, id, range, fuelconsumption, rotorsystem)
        {
            PassengerCapacity = passengercapacity;            
        }
    }
}
