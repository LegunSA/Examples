namespace AirportDemo.Interfaces
{
    public interface IAirPlaneFactory
    {
        IAirCraft Create(string id);
    }
}
