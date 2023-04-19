using AdminSiteUseMVC.Models.IRepository.Admin;
using AdminSiteUseMVC.ViewModel;
using AdminSiteUseMVC.ViewModel.Admin;
using Domian;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace AdminSiteUseMVC.Controllers.Admin.AdminDetails
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminController(IAdminRepository adminRepository, RoleManager<Role> roleManager,UserManager<User> userManager)
        {
            _adminRepository = adminRepository;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _adminRepository.GetAllAsync();
            List<AllUsersviewModel> usersViewModel = new List<AllUsersviewModel>();
            foreach (var user in users)
            {
                usersViewModel.Add(new AllUsersviewModel(user.Id,user.Fname,user.Lname, user.UserName, user.Email));
            }
            return View(usersViewModel);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (!ModelState.IsValid)
                return View(id);
            List<Address> adds = new List<Address>();
            try
            {

                var user = await _adminRepository.GetByIdAsync(id);
                var addresses = await _adminRepository.GetByDetailsAsync(id);
                foreach (var address in addresses.UserAddresses)
                {
                    adds.Add(address.Address);
                }
                ViewBag.AddressesEN = new SelectList(adds, "Id", "AddressEN1");
                ViewBag.AddressesAR = new SelectList(adds, "Id", "AddressAR1");

                ViewBag.roles = await _userManager.GetRolesAsync(user);
               
                UserDetailsViewModel userDetailsViewModel = new UserDetailsViewModel(user.Id, user.Fname, user.Lname, user.UserName!, user.Email!);
                return View(userDetailsViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }

        }
        //public async Task<IActionResult> Details(int id)
        //{
        //    if (!ModelState.IsValid)
        //        return View(id);
        //    List<Address> adds = new List<Address>();
        //    try
        //    {

        //        var user=await _adminRepository.GetByIdAsync(id);
        //        var addresses =await  _adminRepository.GetByDetailsAsync(id);
        //        foreach(var address in addresses.UserAddresses)
        //        {
        //            adds.Add(address.Address);
        //        }
        //        ViewBag.Addresses = adds;
        //        ViewBag.roles =await _adminRepository.GetAllRoleAsync(id);
        //        UserDetailsViewModel userDetailsViewModel = new UserDetailsViewModel(user.Id,user.Fname,user.Lname,user.UserName!,user.Email!);
        //        return View(userDetailsViewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex.Message);
        //        return View(id);
        //    }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
                return View(id);
            try
            {
                var user = await _adminRepository.GetByIdAsync(id);
                EditeUserViewModel editUserViewModel = new EditeUserViewModel(user.Id, user.Fname, user.Lname, user.UserName!, user.Email!);
                ViewBag.Roles = new SelectList(_roleManager.Roles, "Id", "Name");

                return View(editUserViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditeUserViewModel editUserViewModel)
        {
            if (!ModelState.IsValid)
                return View(editUserViewModel);
            try
            {
                var userUpdate = await _adminRepository.GetByIdAsync(editUserViewModel.Id);
                //var user = new User()
                //{
                //    Fname = userDetailsViewModel.FirstName,
                //    Lname = userDetailsViewModel.LastName,
                //    UserName = userDetailsViewModel.UserName,
                //    Email = userDetailsViewModel.Email,

                //};

                //edit address and role 
                userUpdate.Fname = editUserViewModel.FirstName;
                userUpdate.Lname = editUserViewModel.LastName;
                userUpdate.UserName = editUserViewModel.UserName;
                userUpdate.Email = editUserViewModel.Email;
                if(editUserViewModel.RoleId!= null)
                {
                    userUpdate.Roles = _roleManager.Roles.Where(x => editUserViewModel.RoleId.Contains(x.Id)).ToList();
                }
                

                var resualt = await _adminRepository.UpdateAsync(userUpdate);
                if (!resualt)
                {
                    ModelState.AddModelError(string.Empty, "Not Update");
                    return View(editUserViewModel);
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(editUserViewModel);
            }
        }
        public async Task<IActionResult> Delete(int id) 
        {
            if (!ModelState.IsValid)
            {
                return View(id);
            }
            try
            {
               await _adminRepository.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }

        }
    }
    
}
