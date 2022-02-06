using System.ComponentModel.DataAnnotations;

namespace MarketRESTfulAPI.Dtos
{
    public class CreateProductDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1, 1000)]
        public decimal Cost { get; set; }
    }
}
