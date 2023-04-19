using Application.Contracts.User;
using Domian;
using Dtos.Users;
using InfraStructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InfraStructure.Users
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly UserManager<User> UserManager;
        private readonly IConfiguration Configuration;
        private readonly RoleManager<Role> RoleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly Jwt _jwt;

        public UserAccountRepository(UserManager<User> userManager, IConfiguration configuration, IOptions<Jwt> jwt, RoleManager<Role> roleManager,SignInManager<User> signInManager)
        {
            UserManager = userManager;
            Configuration = configuration;
            RoleManager = roleManager;
            _signInManager = signInManager;
            _jwt = jwt.Value;
        }

        public async Task<AuthModel> Registration(RegistrationModel registrationModel)
        {
            if (await UserManager.FindByEmailAsync(registrationModel.Email) != null)
                // return "Email Is Already Registered!";
                return new AuthModel { Message = "Email Is Already Registered!" };
            if (await UserManager.FindByNameAsync(registrationModel.UserName) != null)
                //return "UserName Is Already Registered!";
                return new AuthModel { Message ="UserName Is Already Registered!" };
            User _user = registrationModel.ToModel();
            var result = await UserManager.CreateAsync(_user, registrationModel.Password);
            //var x = await UserManager.GetUserAsync(HttpContext.u);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }

                return new AuthModel { Message = errors.ToString() };

                // return errors;
            }
          

            await UserManager.AddToRoleAsync(_user, "User");
            //var SigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));

            //var UserClaims = new List<Claim>()
            //{
            //	new Claim(ClaimTypes.Name,registrationModel.Email),
            //	new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //};

            //var Token = new JwtSecurityToken
            //	(
            //		issuer: _jwt.ValidIssuer, //Configuration["JWT:ValidIssuer"],
            //		audience:_jwt.ValidAudience, //Configuration["JWT:ValidAudience"],
            //		expires: DateTime.Now.AddDays(_jwt.DurtionInDays),
            //		signingCredentials: new SigningCredentials(SigninKey, SecurityAlgorithms.HmacSha256Signature),
            //		claims: UserClaims
            //	); ;
           // UserManager.GetUserId
            var jwtSecurityToken = await CreateJwtToken(_user);
            var userId = UserManager.Users.FirstOrDefault(e => e.Email == _user.Email);
            int id = userId.Id;
            var autnModel = new AuthModel
            {
                Id = id,
                Email = _user.Email!,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Username = _user.UserName!,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
                
            };
            return autnModel;
            // return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
           // return await AuthModel;




        }
       
        public async Task<AuthModel> Login(LoginModel loginModel)
        {
            AuthModel authModel = new AuthModel();
            var _user = await UserManager.FindByEmailAsync(loginModel.Email);

            if (_user is null || !await UserManager.CheckPasswordAsync(_user, loginModel.Password))
            {
                //return "Email or Password is incorrect!";
                authModel.Message= "Email or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(_user);
            var rollist=await UserManager.GetRolesAsync(_user);
            authModel.Id=_user.Id;
            authModel.IsAuthenticated= true;
            authModel.Email = _user.Email;
            authModel.Username = _user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Token= new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken); 
            authModel.Roles=rollist.ToList();
            return authModel;

            //var jwtSecurityToken = await CreateJwtToken(_user);

           // return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        }
        public async void logout()
        {
            await _signInManager.SignOutAsync();
        }
        //public async Task<string> AddRoleAsync(AddRoleModel addRoleModel)
        //{
        //    var _user = await UserManager.FindByIdAsync(addRoleModel.UserId.ToString());
        //    if (_user is null || !await RoleManager.RoleExistsAsync(addRoleModel.RoleName))
        //        return "Invalid User Id or Role Nmae";

        //    if (await UserManager.IsInRoleAsync(_user, addRoleModel.RoleName))
        //        return "User already assigned to this role";

        //    var result = await UserManager.AddToRoleAsync(_user, addRoleModel.RoleName);

        //    return result.Succeeded ? string.Empty : "Sonething went wrong";




        //}
        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await UserManager.GetClaimsAsync(user);
            var roles = await UserManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),

            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.ValidIssuer,
                audience: _jwt.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurtionInDays),
                signingCredentials: signingCredentials);


            return jwtSecurityToken;
        }
        public void Logout()
        {

            // UserManager.RemoveLoginAsync()
        }
    }
}
