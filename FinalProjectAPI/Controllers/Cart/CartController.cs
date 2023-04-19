using DbContextL;
using Domian;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly Context _context;

        public CartController(UserManager<User> userManager,Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        public ActionResult GetCart() 
        { 
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(Cart model)
        {
            var product=_context.Products.FirstOrDefault(p=>p.Id==model.Id);
            var user = await _userManager.GetUserIdAsync(model.User);
            var cart = new Cart
            {
                Id = model.Id,
                Quantity = model.Quantity,

            };
            var shopCart=_context.Carts.FirstOrDefault(u=>u.Id==model.Id);
            if(model.Quantity <= 0) 
            {
                cart.Quantity = 1;
            }
            if(shopCart!=null) 
            {
               shopCart.Quantity += model.Quantity;
            }else
            {
                _context.Carts.Add(cart);
               
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        

        //[HttpPost]
        //public async Task<IActionResult> RemoveItem(int id)
        //{
        //  //  var product = _context.Products.FirstOrDefault(p => p.Id == model.Id);
        //   // var user = await _userManager.GetUserIdAsync(User);
           
        //    var shopCart = _context.Carts.FirstOrDefault(u => u.Id == user.Id &&CartId=id);
           
        //    if (shopCart != null)
        //    {
        //        _context.Carts.Remove(shopCart);
        //    }
          
        //    _context.SaveChanges();

        //    return RedirectToAction(nameof(GetCart));
        //}
    }
}
