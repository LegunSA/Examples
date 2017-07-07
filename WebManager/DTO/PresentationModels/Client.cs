using System.Collections.Generic;
using DTO.Interfaces;

namespace DTO.PresentationModels
{
    public class Client 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SaleLog> SaleLog { get; set; }
    }
}
