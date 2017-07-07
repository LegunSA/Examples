using System.Collections.Generic;
using DTO.Interfaces;

namespace DTO.PresentationModels
{
    public class Manager 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Report> Report { get; set; }
    }
}
