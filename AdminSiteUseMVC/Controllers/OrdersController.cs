using AdminSiteUseMVC.Models.Services.Orders;
using AdminSiteUseMVC.ViewModel.Orders;
using Domian;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AdminSiteUseMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        //New Comment 
        private readonly OrderRepository _orderRepository;
        private readonly UserManager<User> _userManager;

        public OrdersController(OrderRepository orderRepository,
            UserManager<User> userManager)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var Orders = await _orderRepository.GetAllAsync();

            List<OrderViewModel> orderList = new List<OrderViewModel>();
            foreach (var item in Orders)
            {
                orderList.Add(new OrderViewModel
                {
                    Id = item.Id,
                    Date = item.Date,
                    Total = item.Total,
                    Status = item.Status
                });
            }
            return View(orderList);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (await _orderRepository.GetAllAsync() == null)
            {
                return NotFound();
            }

            var order = (await _orderRepository.GetByIdAllDetailsAsync(id));
            if (order == null)
            {
                return NotFound();
            }
            
            
            
            return View(new DetailsOrderViewModel()
            {
                Id = order.Id,
                Date = order.Date,
                Total = order.Total,
                Status = order.Status,
                

            });
        }

        public async Task<IActionResult> Edit(int id)
        {

            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            ViewBag.Status = Enum.GetNames(typeof(MyStatus));

            return View(new OrderViewModel
            {
                Id = order.Id,
                Date = order.Date,
                Status = order.Status,
                Total = order.Total
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderViewModel orderModel)
        {
            if (id != orderModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var OrderTemp = await _orderRepository.GetByIdAsync(id);
                    if (OrderTemp != null)
                    {
                        OrderTemp.Date = orderModel.Date;
                        OrderTemp.Total = orderModel.Total;
                        OrderTemp.Status = orderModel.Status;

                        await _orderRepository.UpdateAsync(OrderTemp);
                    }
                    else
                    {
                        throw new Exception("error by bind value");
                    }

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderModel);
        }

        public async Task<IActionResult> Delete(int id)
        {

            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(new OrderViewModel
            {
                Id = order.Id,
                Date = order.Date,
                Total = order.Total,
                Status = order.Status
            });
        }

        [HttpPost]
      
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _orderRepository.GetByIdAsync(id) == null)
            {
                return Problem("Entity set order Enity  is null.");
            }
            var order = await _orderRepository.GetByIdAsync(id);
            if (order != null)
            {
                await _orderRepository.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
