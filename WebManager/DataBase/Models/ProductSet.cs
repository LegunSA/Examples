using System;
using System.Collections.Generic;

namespace DataBase.Models
{
    public partial class ProductSet
    {
        public ProductSet()
        {
            SaleLogSet = new HashSet<SaleLogSet>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Cost { get; set; }

        public virtual ICollection<SaleLogSet> SaleLogSet { get; set; }
    }
}
