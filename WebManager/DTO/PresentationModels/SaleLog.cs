using System;
using DTO.Interfaces;

namespace DTO.PresentationModels
{
    public class SaleLog 
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Report Report { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
    }
}
