using System.Collections.Generic;
using DTO.Interfaces;

namespace DTO.PresentationModels
{
    public class Product 
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Cost { get; set; }
        public ICollection<SaleLog> SaleLog { get; set; }
    }
}
