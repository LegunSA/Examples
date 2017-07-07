using AirportDemo.Interfaces;
using AirportDemo.AirCrafts;

namespace AirportDemo.PlaneFactories
{
    public class IL86Factory : IAirPlaneFactory
    {
        public IAirCraft Create(string id)
        {
            return new PassengerAirPlane("IL - 86", id, 3500,80,250, Enums.WingType.LowPlan);
        }
    }
}
