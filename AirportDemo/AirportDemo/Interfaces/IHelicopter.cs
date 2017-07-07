using AirportDemo.Enums;

namespace AirportDemo.Interfaces
{
    public interface IHelicopter : IAirCraft
    {
         RotorSystem RotorSystem { get;}
    }
}
