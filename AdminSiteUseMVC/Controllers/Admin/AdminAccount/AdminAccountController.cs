using AdminSiteUseMVC.Models.IRepository.Admin;
using AdminSiteUseMVC.Models.Services.Email;
using AdminSiteUseMVC.Models.Services.UserEmailOption;
using AdminSiteUseMVC.ViewModel.Admin;
using Domian;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminSiteUseMVC.Controllers.Admin.AdminAccount
{
    public class AdminAccountController : Controller
    {
        private readonly UserManager<User> _adminManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        // private readonly IUserService _userService;

        // private readonly IAdminAccountRepository _adminAccountRepository;

        public AdminAccountController(UserManager<User> adminManager, RoleManager<Role> roleManager,SignInManager<User> signInManager,IEmailService emailService,IConfiguration configuration)//, IAdminAccountRepository adminAccountRepository)
        {
             _adminManager = adminManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _configuration = configuration;
            // _userService = userService;
            // _adminAccountRepository = adminAccountRepository;
        }
     
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
      
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SignUp([FromForm] RegistrationModel registrationModel)
        //{
        //  if(!ModelState.IsValid)
        //        return View(registrationModel);
        //    try
        //    {
        //        if (await _adminManager.FindByEmailAsync(registrationModel.Email) != null)
        //        {
        //            ModelState.AddModelError(string.Empty, "Email Is Already Registered!");
        //            return View(registrationModel);
        //        }

        //        if (await _adminManager.FindByNameAsync(registrationModel.UserName) != null)
        //        {
        //            ModelState.AddModelError(string.Empty, "UserName Is Already Registered!");
        //            return View(registrationModel);
        //        }
        //        User _user = registrationModel.ToModel();
        //        var result = await _adminManager.CreateAsync(_user, registrationModel.Password);
        //        if (!result.Succeeded)
        //        {
        //            //var errors = string.Empty;
        //            foreach (var error in result.Errors)
        //            {
        //                //errors += $"{error.Description},";
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }

        //            return View(registrationModel);
        //        }
        //       await _signInManager.SignInAsync(_user, true);

        //        await _adminManager.AddToRoleAsync(_user, "Admin");
        //        return RedirectToAction("Index", "Home");

        //    }
        //    catch(Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex.Message);
        //        return View(registrationModel);
        //    }
        //}
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([FromForm] RegistrationModel registrationModel)
         {
            if (!ModelState.IsValid)
                return View(registrationModel);
            try
            {
                if (await _adminManager.FindByEmailAsync(registrationModel.Email) != null)
                {
                    ModelState.AddModelError(string.Empty, "Email Is Already Registered!");
                    return View(registrationModel);
                }

                if (await _adminManager.FindByNameAsync(registrationModel.UserName) != null)
                {
                    ModelState.AddModelError(string.Empty, "UserName Is Already Registered!");
                    return View(registrationModel);
                }
                User _user = registrationModel.ToModel();
                var result = await _adminManager.CreateAsync(_user, registrationModel.Password);
                if (result.Succeeded)
                {
                    await _adminManager.AddToRoleAsync(_user, "Admin");
                    var token = await _adminManager.GenerateEmailConfirmationTokenAsync(_user);
                    if(!string.IsNullOrEmpty(token))
                    {
                       await SendEmailConfirmationEmail(_user, token);
                    }
                    return View(nameof(GOToEmailToConfirm));
                    //return View (registrationModel);
                    
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        //errors += $"{error.Description},";
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return View(registrationModel);

                }
             

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(registrationModel);
            }
        }
        [HttpGet]
        public IActionResult GOToEmailToConfirm()
        {
            return View();
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(int id, string token)
        {
          
            if (id!=null && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(' ', '+');
                var result = await _adminManager.ConfirmEmailAsync(await _adminManager.Users.FirstOrDefaultAsync(u=>u.Id==id), token);
                if (result.Succeeded)
                {
                  return  RedirectToAction(nameof(LogIN));
                   // ViewBag.ISSuccess = true;
                }
            }

            return View();
        }
    


        //public async Task<IActionResult> SignUp([FromBody] RegistrationModel registrationModel)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    string resulat = await _adminAccountRepository.Registration(registrationModel);
        //    if (resulat.Equals("Email Is Already Registered!"))
        //        return BadRequest(resulat);
        //    else if (resulat.Equals("UserName Is Already Registered!"))
        //        return BadRequest(resulat);
        //    return Ok(resulat);

        //}
        // [Route("login")]
        [HttpGet]
        public IActionResult LogIN()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIN([FromForm] LoginModel loginModel)
        {
          if(!ModelState.IsValid)
                return View(loginModel);
            try
            {
                var _user = await _adminManager.FindByNameAsync(loginModel.UserName);


                if (_user is null || !await _adminManager.CheckPasswordAsync(_user, loginModel.Password))
                {
                    ModelState.AddModelError(string.Empty, "UserName or Password Is Incorrect!");
                    return View(loginModel);

                }
                var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, true, true);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(_user, loginModel.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login");
                    return View(loginModel);
                }

            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                return View(loginModel);
            }
           
        }
        //public async Task<IActionResult> LogIN([FromBody] LoginModel loginModel)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    string resulat = await _adminAccountRepository.Login(loginModel);
        //    if (resulat.Equals("Email or Password is incorrect!"))
        //        return BadRequest(resulat);

        //    return Ok(resulat);

        //}
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public  IActionResult AddRole()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] AddRoleModel addRoleModel)
        {
            var _user = await _adminManager.FindByIdAsync(addRoleModel.UserId.ToString());
            if (_user is null || !await _roleManager.RoleExistsAsync(addRoleModel.RoleName))
                return View("Invalid User Id or Role Nmae");

            if (await _adminManager.IsInRoleAsync(_user, addRoleModel.RoleName))
                return View("User already assigned to this role");

            var result = await _adminManager.AddToRoleAsync(_user, addRoleModel.RoleName);
            if (!result.Succeeded)
                return View("Sonething went wrong");

            return RedirectToAction("Index", "Home");

        }
        //public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var result = await _adminAccountRepository.AddRoleAsync(model);

        //    if (!string.IsNullOrEmpty(result))
        //        return BadRequest(result);

        //    return Ok(model);
        //}
    
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(LogIN));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _adminManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction(nameof(LogIN));
                }
                var result = await _adminManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                    foreach (var error in result.Errors)
                {
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(user);
                model.IsSuccess = true;
                return View(model);

            }
            return View(model);
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                // code here
                var user = await _adminManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await _adminManager.GeneratePasswordResetTokenAsync(user);
                    if (!string.IsNullOrEmpty(token))
                    {
                        await SendForgotPasswordEmail(user, token);
                    }
                }

                ModelState.Clear();
                model.EmailSent = true;
            }
            return View(model);
        }
        private async Task SendEmailConfirmationEmail(User user, string token1)
        {
            // string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            //string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "AdminAccount", new { id = user.Id, token = token1 }, Request.Scheme);

            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.UserName),
                   new KeyValuePair<string, string>("{{Link}}",confirmationLink)
                       // string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };

            await _emailService.SendEmailForEmailConfirmation(options);
        }
        private async Task SendForgotPasswordEmail(User user, string token1)
        {
            // string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            // string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;
            var ForgotPasswordLink = Url.Action(nameof(ResetPassword), "AdminAccount", new { id = user.Id, token = token1 }, Request.Scheme);

            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.UserName),
                    new KeyValuePair<string, string>("{{Link}}",ForgotPasswordLink)
                       // string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };

            await _emailService.SendEmailForForgotPassword(options);
        }
        [HttpGet("reset-password")]
        public IActionResult ResetPassword(int id, string token)
        {
            ResetPasswordModel resetPasswordModel = new ResetPasswordModel
            {
                Token = token,
                UserId = id
            };
            return View(resetPasswordModel); 

        }
       // [Authorize(Roles = "Admin")]
        [ HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                model.Token = model.Token.Replace(' ', '+');
                var result = await _adminManager.ResetPasswordAsync(await _adminManager.Users.FirstOrDefaultAsync(u=>u.Id==model.UserId), model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                    return View(model);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        //public async Task GenerateForgotPasswordTokenAsync(User  user)
        //{
        //    var token = await _adminManager.GeneratePasswordResetTokenAsync(user);
        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        await SendForgotPasswordEmail(user, token);
        //    }
        //}

    //    public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model)
    //    {
    //        return await _adminManager.ResetPasswordAsync(await _adminManager.FindByIdAsync(model.UserId), model.Token, model.NewPassword);
    //    }
    }

}
