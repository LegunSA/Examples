using StructureMap;
using AirportDemo.Interfaces;
using AirportDemo.PlaneFactories;
using AirportDemo.Enums;

namespace AirportDemo
{
    public class FactoryRegistry: Registry
    {
        public FactoryRegistry()
        {
            For<IAirPlaneFactory>().Use<MI8Factory>().Named(AirPlaneNames.MI8.ToString());
            For<IAirPlaneFactory>().Use<IL76Factory>().Named(AirPlaneNames.IL76.ToString());
            For<IAirPlaneFactory>().Use<IL86Factory>().Named(AirPlaneNames.IL86.ToString());
            For<IAirPlaneFactory>().Use<JAK40Factory>().Named(AirPlaneNames.JAK40.ToString());
            For<IAirPlaneFactory>().Use<MI26Factory>().Named(AirPlaneNames.MI26.ToString());
            For<IAirPlaneFactory>().Use<An124Factory>().Named(AirPlaneNames.AN124.ToString());

            For<IClientFactory>().Use<ClientFactory>();
        }

    }
}
