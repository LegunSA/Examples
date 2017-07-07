using AirportDemo.Interfaces;
using AirportDemo.AirCrafts;

namespace AirportDemo.PlaneFactories
{
    public class An124Factory : IAirPlaneFactory
    {
        public IAirCraft Create(string id)
        {
            return new CargoAirPlane("An - 124",id,5000,100,150000, Enums.WingType.HighPlan);
        }
    }
}
