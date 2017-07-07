using InterfaceLibrary;

namespace Core.Builder
{
    public abstract class AbstractBuilder
    {
        public abstract void Construct();
        public abstract ISalad GetResult();
    }
}
