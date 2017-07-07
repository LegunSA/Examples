using System;
using System.Collections.Generic;

namespace DataBase.Models
{
    public partial class ManagerSet
    {
        public ManagerSet()
        {
            ReportSet = new HashSet<ReportSet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ReportSet> ReportSet { get; set; }
    }
}
