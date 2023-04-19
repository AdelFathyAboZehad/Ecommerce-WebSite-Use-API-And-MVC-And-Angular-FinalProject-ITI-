using AdminSiteUseMVC.Models;
using AdminSiteUseMVC.Models.Services.Email;
using AdminSiteUseMVC.Models.Services.UserEmailOption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminSiteUseMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger,IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            //UserEmailOptions options = new UserEmailOptions
            //{
            //    ToEmails=new List<string>() { "sa5586050@gmail.com" },
            //    PlaceHolders=new List<KeyValuePair<string,string>>() 
            //    {
            //        new KeyValuePair<string,string>("{{UserName}}","Adel")
            //    }


            //};
            //await _emailService.SendTestEmail(options);
            // return RedirectToAction("SignUp","AdminAccount");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}