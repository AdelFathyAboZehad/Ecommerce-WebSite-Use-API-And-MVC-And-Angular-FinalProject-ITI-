namespace AdminSiteUseMVC.ViewModel.Admin
{
    public class AuthModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public List<string> Roles { get; set; }

        public AuthModel(string message, bool isAuthenticated, string username, string email, string token, DateTime expiresOn)
        {
            Message = message;
            IsAuthenticated = isAuthenticated;
            Username = username;
            Email = email;
            Token = token;
            ExpiresOn = expiresOn;
            Roles = new List<string>();
        }
        public AuthModel() { }
    }
}
