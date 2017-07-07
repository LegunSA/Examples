using System;
using System.Collections.Generic;

namespace DataBase.Models
{
    public partial class ClientSet
    {
        public ClientSet()
        {
            SaleLogSet = new HashSet<SaleLogSet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SaleLogSet> SaleLogSet { get; set; }
    }
}
