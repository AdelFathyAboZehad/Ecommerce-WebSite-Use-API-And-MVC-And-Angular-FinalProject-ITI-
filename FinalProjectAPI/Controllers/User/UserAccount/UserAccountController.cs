
using Application.Contracts.User;
using Application.Features.Users.Commands.UpdateUsersPassword;
using Domian;
using Dtos.Account;
using Dtos.EmailServices;
using Dtos.UserEmailOption;
using Dtos.Users;
using InfraStructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectAPI.Controllers//.User.UserAccount
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public UserAccountController(IUserAccountRepository userRepository, IMediator mediator, UserManager<User> userManager, IEmailService emailService, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _userManager = userManager;
            _emailService = emailService;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return Ok();

        }
        [HttpPost("Register")]
        public async Task<IActionResult> SigUP([FromBody] RegistrationModel registrationModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userRepository.Registration(registrationModel);
            // var user = registrationModel.ToModel();


            if (result.IsAuthenticated)
            {
                var user = await _userManager.FindByEmailAsync(registrationModel.Email);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if (!string.IsNullOrEmpty(token))
                {
                    await SendEmailConfirmationEmail(user, token);
                }
                // return View(nameof(GOToEmailToConfirm));
                return Ok(result);
            }
            return BadRequest(result.Message);


        }
        [HttpGet]
        public IActionResult LogIN()
        {
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LogIN([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userRepository.Login(loginModel);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpPost("ChangePassword")]
        //[Route("Profile/ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] UpdateUsersPasswordCommandQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(query);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok("password Successfully Changed");

        }
        [HttpPost]
        public async Task<IActionResult> logOut()
        {
            _userRepository.logout();
            return RedirectToAction(nameof(LogIN));
        }
        //[HttpPost]
        //public async Task<IActionResult> ForgetPassword(string email)
        //{
        //    var user=await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
        //    if(user!=null)
        //    {
        //        var token =await _userManager.GeneratePasswordResetTokenAsync(user);
        //        var link = Url.Action("RestPassword", "UserAccount", new { token, email = user.Email, }, Request.Scheme);
        //        //var massage=new Message()
        //    }
        //    return Ok();
        //}
        // [HttpGet]
        // public IActionResult SignUp()
        // {
        //     return Ok();
        // }
        //[HttpPost]
        // public async Task<IActionResult> SignUp([FromForm] RegistrationModel registrationModel)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //     var resulat = await _userRepository.Registration(registrationModel);
        //     if (resulat.Equals("Email Is Already Registered!"))
        //         return BadRequest(resulat);
        //     else if (resulat.Equals("UserName Is Already Registered!"))
        //         return BadRequest(resulat);
        //     return Ok(resulat);

        // }
        // [HttpGet]
        // public IActionResult LogIN()
        // {
        //     return Ok();
        // }
        // [HttpPost]
        // public async Task<IActionResult> LogIN([FromForm] LoginModel loginModel)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //     var resulat = await _userRepository.Login(loginModel);
        //     if (resulat.Equals("Email or Password is incorrect!"))
        //         return BadRequest(resulat);

        //     return Ok(resulat);

        // }
        //[HttpPost("addrole")]
        //public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var result = await _userRepository.AddRoleAsync(model);

        //    if (!string.IsNullOrEmpty(result))
        //        return BadRequest(result);

        //    return Ok(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> logOut()
        //{
        //    _userRepository.logout();
        //    return RedirectToAction(nameof(LogIN));
        //}
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(int id, string token)
        {

            if (id != null && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(' ', '+');
                var result = await _userManager.ConfirmEmailAsync(await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id), token);
                if (result.Succeeded)
                {
                    //return RedirectToAction(nameof(LogIN));
                    // ViewBag.ISSuccess = true;
                    return Ok("Email Comfirm Sucessfully");
                }
            }

            return BadRequest("Email Comfirm Not Sucessfully");
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return Ok();
        }
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)//([Required]string Email)
        {
            if (ModelState.IsValid)
            {
                // code here
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    if (!string.IsNullOrEmpty(token))
                    {
                        await SendForgotPasswordEmail(user, token);
                        return Ok($"Password Changed Request Is Sent On Email {user.Email}.Please Open Your Email & Click The Link  ");
                    }
                }


            }
            return BadRequest("Can not Send Link To Email.Plase Try Again ");
        }
        [HttpGet("reset-password")]
        public IActionResult ResetPassword(int id, string token)
        {
            /////
            ResetPasswordModel resetPasswordModel = new ResetPasswordModel
            {
                Token = token,
                UserId = id
            };
            return Ok(resetPasswordModel);

        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                model.Token = model.Token.Replace(' ', '+');
                var result = await _userManager.ResetPasswordAsync(await _userManager.Users.FirstOrDefaultAsync(u => u.Id == model.UserId), model.Token, model.NewPassword);
                if (result.Succeeded)
                {

                    return Ok("Password has Been Changed");//////
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return BadRequest(ModelState);
        }
        private async Task SendEmailConfirmationEmail(User user, string token1)
        {
            // string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            //string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "UserAccount", new { id = user.Id, token = token1 }, Request.Scheme);

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
            var ForgotPasswordLink = Url.Action(nameof(ResetPassword), "UserAccount", new { id = user.Id, token = token1 }, Request.Scheme);

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
    }
}
