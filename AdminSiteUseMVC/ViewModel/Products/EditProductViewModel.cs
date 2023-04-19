using System.ComponentModel.DataAnnotations;

namespace AdminSiteUseMVC.ViewModel.Products
{
    public class EditProductViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Name(EN)")]

        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }

        [Display(Name = "Name(AR)")]

        [MinLength(3), MaxLength(200)]
        public string NameAR { get; set; }

        [Display(Name = "Description(EN)")]

        [MinLength(5), MaxLength(500)]
        public string? DescriptionEN { get; set; }


        [Display(Name = "Description(AR)")]

        [MinLength(5), MaxLength(500)]
        public string? DescriptionAR { get; set; }
        [Range(0, 100)]
        [Display(Name = "Discount")]
        public int? DiscountPercentage { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Brand")]

        public int BrandId { get; set; }
        [Display(Name = "Stock")]

        public int StockId { get; set; }

        [Display(Name = "Category")]

        public List<int>? CategoriesId { get; set; }

        public EditProductViewModel(long id, string nameEN, string nameAR, string? descriptionEN, string? descriptionAR, int? discountPercentage, decimal price, int quantity)
        {
            Id = id;
            NameEN = nameEN;
            NameAR = nameAR;
            DescriptionEN = descriptionEN;
            DescriptionAR = descriptionAR;
            DiscountPercentage = discountPercentage;
            Price = price;
            Quantity = quantity;
        }
        public EditProductViewModel()
        {
            
        }
    }
}
