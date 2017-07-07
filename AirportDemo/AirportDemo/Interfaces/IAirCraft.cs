namespace AirportDemo.Interfaces
{
    public interface IAirCraft
    {
        string AirCraftName { get; }
        string ID { get; }
        int Range { get; }
        int FuelConsumption { get; }
        int Capacity();
        void Fly();

    }
}
