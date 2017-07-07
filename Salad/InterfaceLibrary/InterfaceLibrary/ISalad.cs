using System.Collections.Generic;

namespace InterfaceLibrary
{
    public interface ISalad
    {
        ICollection<ISaladItem> SaladItems { get; }
    }
}
