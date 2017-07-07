using System;
using System.Collections.Generic;

namespace DTO.PresentationModels
{
    public class Report 
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public ICollection<SaleLog> SaleLog { get; set; }
    }
}
