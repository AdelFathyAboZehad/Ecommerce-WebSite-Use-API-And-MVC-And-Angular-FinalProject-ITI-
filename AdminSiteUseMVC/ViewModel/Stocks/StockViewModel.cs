using System.ComponentModel.DataAnnotations;

namespace AdminSiteUseMVC.ViewModel.Stocks
{
    public class StockViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [MinLength(3), MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [MinLength(3), MaxLength(200)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        public StockViewModel(int id,string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
        public StockViewModel()
        {
            
        }
    }
}
