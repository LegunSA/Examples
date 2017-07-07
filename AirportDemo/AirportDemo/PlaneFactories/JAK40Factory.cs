using AirportDemo.Interfaces;
using AirportDemo.AirCrafts;

namespace AirportDemo.PlaneFactories
{
    public class JAK40Factory : IAirPlaneFactory
    {
        public IAirCraft Create(string id)
        {
            return new PassengerAirPlane("JAK - 40", id, 1700, 40, 20, Enums.WingType.LowPlan);
        }
    }
}
