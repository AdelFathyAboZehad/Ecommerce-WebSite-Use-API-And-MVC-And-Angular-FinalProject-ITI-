using Domian;
using System.ComponentModel.DataAnnotations;

namespace AdminSiteUseMVC.ViewModel.Products
{
    public class DetailsProductViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Name(English)")]

        [MinLength(3), MaxLength(200)]
        public string? NameEN { get; set; }
      
        [Display(Name = "Name(Arabic)")]

        [MinLength(3), MaxLength(200)]
        public string? NameAR { get; set; }

        [Display(Name = "Name(English)")]

        [MinLength(5), MaxLength(500)]
        public string? DescriptionEN { get; set; }

        [Display(Name = "Name(Arabic)")]

        [MinLength(5), MaxLength(500)]
        public string? DescriptionAR { get; set; }

        [Range(0, 100)]
        [Display(Name ="Discount")]
        public int? DiscountPercentage { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Brand? Brand { get; set; }
        public Stock? Stock { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public IEnumerable<Image>? Images { get; set; }
    }
}
