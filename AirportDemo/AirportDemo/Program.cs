using System;
using AirportDemo.Interfaces;
using StructureMap;
using AirportDemo.Enums;

namespace AirportDemo
{
    class Program
    {
        public static IContainer Container { get; private set; }

        static void Main(string[] args)
        {
            Container = StructureMap.Container.For<FactoryRegistry>();
            IClientFactory client = Container.GetInstance<IClientFactory>();

            IAirPort MyAirport = new Airport();

            MyAirport.AddAirCraft(client.GetAirCraft(AirPlaneNames.MI8, "1"));
            MyAirport.AddAirCraft(client.GetAirCraft(AirPlaneNames.MI8, "2"));
            MyAirport.AddAirCraft(client.GetAirCraft(AirPlaneNames.MI26, "3"));
            MyAirport.AddAirCraft(client.GetAirCraft(AirPlaneNames.MI26, "4"));
            MyAirport.AddAirCraft(client.GetAirCraft(AirPlaneNames.AN124, "5"));
            MyAirport.AddAirCraft(client.GetAirCraft(AirPlaneNames.AN124, "6"));
            MyAirport.AddAirCraft(client.GetAirCraft(AirPlaneNames.IL76, "7"));
            MyAirport.AddAirCraft(client.GetAirCraft(AirPlaneNames.IL76, "8"));
            MyAirport.AddAirCraft(client.GetAirCraft(AirPlaneNames.JAK40, "9"));
            MyAirport.AddAirCraft(client.GetAirCraft(AirPlaneNames.JAK40, "10"));
            MyAirport.AddAirCraft(client.GetAirCraft(AirPlaneNames.IL86, "11"));
            MyAirport.AddAirCraft(client.GetAirCraft(AirPlaneNames.IL86, "12"));

            var result = MyAirport.AirCrafts.Order(x => x.Range);
            foreach (var item in result)
            {
                Console.WriteLine("Aircraft name - {0}; range - {1};", item.AirCraftName, item.Range);
            }

            var result2 = MyAirport.AirCrafts.OrderDSC(x => x.Range);
            foreach (var item in result2)
            {
                Console.WriteLine("Aircraft name - {0} range {1}", item.AirCraftName, item.Range);
            }

            MyAirport.AirCrafts.ShowTotalCapacity();

            var result3 = MyAirport.AirCrafts.FindByFuelConsumptionRange(50, 100);

            foreach (var item in result3)
            {
                Console.WriteLine("Aircraft name - {0}; fuel consumption - {1};", item.AirCraftName, item.FuelConsumption);
            }
        }
    }
}
