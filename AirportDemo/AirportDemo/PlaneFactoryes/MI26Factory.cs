using AirportDemo.Interfaces;
using AirportDemo.AirCrafts;

namespace AirportDemo.PlaneFactoryes
{
    public class MI26Factory : IAirPlaneFactory
    {
        public IAirCraft Create(string id)
        {
            return new CargoHelicopter("MI-26",id, 800, 120, 40000, Enums.RotorSystem.ClassicRotor);
        }
    }
}
