using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebManager.Models
{
    public class SaleLogModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ReportModel Report { get; set; }
        public ClientModel Client { get; set; }
        public ProductModel Product { get; set; }
    }
}
