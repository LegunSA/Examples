using AirportDemo.Interfaces;
using AirportDemo.AirCrafts;

namespace AirportDemo.PlaneFactories
{
    public class IL76Factory:IAirPlaneFactory
    {
        public IAirCraft Create(string id)
        {
            return new CargoAirPlane("IL - 76", id, 3000, 80, 80000, Enums.WingType.HighPlan);
        }        
    }

}
