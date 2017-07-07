using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebManager.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Cost { get; set; }
        public ICollection<SaleLogModel> SaleLog { get; set; }

        public ProductModel()
        {
            SaleLog = new List<SaleLogModel>();
        }
    }
}
