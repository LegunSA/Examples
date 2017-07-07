using AirportDemo.Enums;
using AirportDemo.Interfaces;
using System;

namespace AirportDemo
{
    public class ClientFactory: IClientFactory
    {
        public IAirCraft GetAirCraft(AirPlaneNames name, string id)
        {
            try
            {
                return Program.Container.GetInstance<IAirPlaneFactory>(name.ToString()).Create(id);
            }
            catch (StructureMap.StructureMapConfigurationException)
            {
                Console.WriteLine("Wrong factory parameters {0}", name);
                return null;
            }           
        }
    }
}
