using System.ComponentModel.DataAnnotations;

namespace Dtos.Product
{
    public class ProductMinimalDTO
    {
        public long Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }
        //Globalization
        [MinLength(3), MaxLength(200)]
        public string NameAR { get; set; }
        [MinLength(5), MaxLength(500)]
        public string? DescriptionEN { get; set; }
        //Globalization
        [MinLength(5), MaxLength(500)]
        public string? DescriptionAR { get; set; }
        [Range(0, 100)]
        public int? DiscountPercentage { get; set; }
        public decimal Price { get; set; }
        [Range(0, 50)]
        public int Quantity { get; set; }
        public List<string> Images { get; set; } = new List<string>();

    }
}
