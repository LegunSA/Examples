using Core.Elements;
using Core.Interfaces;
using StructureMap;

namespace Demo
{
    public class FactoryRegistry : Registry
    {
        public FactoryRegistry()
        {
            For<IReader>().Use<Reader>();
            For<IParser>().Use<Parser>();
            For<IBuffer<ILineItem>>().Use<BufferLine>();
            //9) попробовать сделать фабрику как в AirPlane
        }
    }
}
