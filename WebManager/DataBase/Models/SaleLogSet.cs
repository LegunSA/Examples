using System;
using System.Collections.Generic;

namespace DataBase.Models
{
    public partial class SaleLogSet
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ReportId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }

        public virtual ClientSet Client { get; set; }
        public virtual ProductSet Product { get; set; }
        public virtual ReportSet Report { get; set; }
    }
}
