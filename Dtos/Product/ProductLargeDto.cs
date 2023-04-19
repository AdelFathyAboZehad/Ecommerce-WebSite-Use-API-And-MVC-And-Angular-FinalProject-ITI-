using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Product
{
    public class ProductLargeDto
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
        public List<string> CategoriesNames { get; set; } = new List<string>();
        public List<string> Images { get; set; } = new List<string>();
        public string BrandNameEN { get; set; }
        public string BrandNameAR { get; set; }
    }
 
}
