using System;
using System.Collections.Generic;

namespace WebManager.Models
{
    public class ReportModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ManagerId { get; set; }
        public ManagerModel Manager { get; set; }
        public ICollection<SaleLogModel> SaleLog { get; set; }

        public ReportModel()
        {
            SaleLog = new List<SaleLogModel>();
        }
    }
}
