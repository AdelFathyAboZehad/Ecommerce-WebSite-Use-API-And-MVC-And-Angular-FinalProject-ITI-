using System.ComponentModel.DataAnnotations;

namespace AdminSiteUseMVC.ViewModel.ShoppingMethods
{
    public class ShoppingMethodViewModel
    {
        public int Id { get; set; }
      
        [MinLength(3), MaxLength(100)]
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
      
    }
}
