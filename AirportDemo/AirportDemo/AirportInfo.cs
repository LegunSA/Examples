using AirportDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirportDemo
{
    public static class AirportInfo
    {
        public static void ShowTotalCapacity(this IEnumerable<IAirCraft> aircraftlist)
        {
            var totalcargo = aircraftlist.Where(x => x is ICargoAirCraft).Sum(x => x.Capacity());
            var totalpassenger = aircraftlist.Where(x => x is IPassengerAirCraft).Sum(x => x.Capacity());

            Console.WriteLine("Total cargo capacity - {0}; total passenger capacity - {1}", totalcargo, totalpassenger);
        }

        public static IEnumerable<IAirCraft> FindByFuelConsumptionRange (this IEnumerable<IAirCraft> aircraftlist, int minfuelconsumption, int maxfuelconsumption)
        {
            return aircraftlist.Where(x => x.FuelConsumption > minfuelconsumption & x.FuelConsumption>maxfuelconsumption);
        }

        #region Order
        public static IEnumerable<IAirCraft> Order(this IEnumerable<IAirCraft> aircraftlist, Func<IAirCraft,int> param)
        {
            return aircraftlist.OrderBy(param);            
        }

        public static IEnumerable<IAirCraft> OrderDSC(this IEnumerable<IAirCraft> aircraftlist, Func<IAirCraft, int> param)
        {
            return aircraftlist.OrderByDescending(param);
        }

        public static IEnumerable<IAirCraft> Order(this IEnumerable<IAirCraft> aircraftlist, Func<IAirCraft, string> param)
        {
            return aircraftlist.OrderBy(param);
        }

        public static IEnumerable<IAirCraft> OrderDSC(this IEnumerable<IAirCraft> aircraftlist, Func<IAirCraft, string> param)
        {
            return aircraftlist.OrderByDescending(param);
        }
        #endregion Order
    }
}
