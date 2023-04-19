namespace AdminSiteUseMVC.ViewModel.Orders
{
    public class DetailsOrderViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string? Status { get; set; }
        public string? UserName { get; set; }
    }
}
