using System.Collections.Generic;

namespace AirportDemo.Interfaces
{
    public interface IAirPort
    {
        IEnumerable<IAirCraft> AirCrafts { get; }
        IAirCraft GetAirCraft(string id);
        void AddAirCraft(IAirCraft aircraft);
        void DeleteAirCraft(IAirCraft aircraft);
        void DeleteAirCraft(string id);
    }
}
