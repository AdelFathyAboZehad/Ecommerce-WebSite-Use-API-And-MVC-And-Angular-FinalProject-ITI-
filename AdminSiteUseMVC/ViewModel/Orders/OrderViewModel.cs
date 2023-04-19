using System.ComponentModel.DataAnnotations;
namespace AdminSiteUseMVC.ViewModel.Orders
  
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
         [Display(Name = "Total")]
    public decimal Total { get; set; }

       [Display(Name = "Status")]
    public string? Status { get; set; }
    }
}
