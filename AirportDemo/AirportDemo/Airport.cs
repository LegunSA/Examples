using AirportDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirportDemo
{
    public class Airport : IAirPort
    {

        IList<IAirCraft> _aircraftlist;

        public IEnumerable<IAirCraft> AirCrafts => _aircraftlist.ToList();

        public void AddAirCraft(IAirCraft aircraft)
        {
            if (aircraft != null)
            {
                _aircraftlist.Add(aircraft);
            }
        }

        public IAirCraft GetAirCraft(string id)
        {
            IAirCraft _item = null;
            try
            {
                _item = _aircraftlist.Where(x => x.ID == id).First();
            }
           
            catch (InvalidOperationException)
            {
                Console.WriteLine("Aircraft with index {0} is not found", id);                
            }            
            return _item;
        }

        public void DeleteAirCraft(IAirCraft aircraft) => _aircraftlist.Remove(aircraft);

        public void DeleteAirCraft(string id) => DeleteAirCraft(GetAirCraft(id));
                
        public Airport()
        {
            _aircraftlist = new List<IAirCraft>();
        }    
    }
}
