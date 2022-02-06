using System.ComponentModel.DataAnnotations;

namespace MarketRESTfulAPI.Models
{
    public class Product
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        [Range(1,1000)]
        public decimal Cost { get; set; }
    }
}
