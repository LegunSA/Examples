using AirportDemo.Enums;

namespace AirportDemo.Interfaces
{
    public interface IAirPlane:IAirCraft
    {
        WingType WingType { get; }
    }
}
