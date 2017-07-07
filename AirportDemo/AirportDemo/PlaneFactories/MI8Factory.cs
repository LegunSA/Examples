using AirportDemo.Interfaces;
using AirportDemo.AirCrafts;

namespace AirportDemo.PlaneFactories
{
    public class MI8Factory : IAirPlaneFactory
    {
        public IAirCraft Create(string id)
        {
            return new CargoHelicopter("MI-8", id, 800, 90, 20, Enums.RotorSystem.ClassicRotor);
        }
    }
}

