using System;
using System.Collections.Generic;

namespace DataBase.Models
{
    public partial class ReportSet
    {
        public ReportSet()
        {
            SaleLogSet = new HashSet<SaleLogSet>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ManagerId { get; set; }

        public virtual ICollection<SaleLogSet> SaleLogSet { get; set; }
        public virtual ManagerSet Manager { get; set; }
    }
}
