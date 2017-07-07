using AirportDemo.Enums;

namespace AirportDemo.Interfaces
{
    public  interface IClientFactory
    {
        IAirCraft GetAirCraft(AirPlaneNames name, string id);        
    }
}
