using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebManager.Models
{
    public class ManagerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ReportModel> Report { get; set; }

        public ManagerModel()
        {
            Report = new List<ReportModel>();
        }
    }
}
