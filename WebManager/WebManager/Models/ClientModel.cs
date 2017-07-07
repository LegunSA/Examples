using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebManager.Models
{
    public class ClientModel
    {
        public int Id { get; set; }

        [Required]
        //[RegularExpression(@"[A-Za-z]", ErrorMessage = "The Name field must contain A-Z and a-z ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The length of the string must be between 3 and 50 characters")]
        [Remote(action: "CheckUser", controller: "Client", ErrorMessage = "Busy name")]
        public string Name { get; set; }

        public ICollection<SaleLogModel> SaleLog { get; set; }

        public ClientModel()
        {
            SaleLog = new List<SaleLogModel>();
        }
    }
}
