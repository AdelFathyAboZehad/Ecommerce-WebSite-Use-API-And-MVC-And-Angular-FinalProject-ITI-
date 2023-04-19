using AdminSiteUseMVC.Models.Services.ShoppingMethods;
using AdminSiteUseMVC.ViewModel.ShoppingMethods;
using Domian;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AdminSiteUseMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShoppingMethodsController : Controller
    {
        private readonly ShoppingMethodRepository _shoppingMethodRepository;

        public ShoppingMethodsController(ShoppingMethodRepository shoppingMethodRepository)
        {
            _shoppingMethodRepository = shoppingMethodRepository;

        }
        public async Task<IActionResult> Index()
        {

            List<ShoppingMethodViewModel> shoppingMethods = new List<ShoppingMethodViewModel>();

            var items = await _shoppingMethodRepository.GetAllAsync();
            if (items == null)
            {
                return NotFound();
            }
            else
            {
                foreach (var item in items)
                {
                    if (item.Name != null)
                        shoppingMethods.Add(new ShoppingMethodViewModel()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Price = item.Price
                        });
                }
                return View(shoppingMethods);
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            if (await _shoppingMethodRepository.GetAllAsync() == null)
            {
                return NotFound();
            }

            var shoppingMethod = await _shoppingMethodRepository.GetByIdAsync(id);
            if (shoppingMethod == null)
            {
                return NotFound();
            }

            return View(new ShoppingMethodViewModel
            {
                Id = shoppingMethod.Id,
                Name = shoppingMethod.Name,
                Price = shoppingMethod.Price
            });
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShoppingMethodViewModel shoppingMethodModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var shoppingMethod = CreateshoppingMethod();
                    shoppingMethod.Name = shoppingMethodModel.Name;
                    shoppingMethod.Price = shoppingMethodModel.Price;
                    await _shoppingMethodRepository.CreatAsync(shoppingMethod);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            return View(shoppingMethodModel);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var shoppingMethod = await _shoppingMethodRepository.GetByIdAsync(id);
            if (shoppingMethod == null)
            {
                return NotFound();
            }
            return View(new ShoppingMethodViewModel
            {
                Id = shoppingMethod.Id,
                Name = shoppingMethod.Name,
                Price = shoppingMethod.Price
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ShoppingMethodViewModel shoppingMethodModel)
        {
            if (id != shoppingMethodModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var shoppingMethodTemp = await _shoppingMethodRepository.GetByIdAsync(id);
                    if (shoppingMethodTemp != null)
                    {
                        shoppingMethodTemp.Name = shoppingMethodModel.Name;
                        shoppingMethodTemp.Price = shoppingMethodModel.Price;
                        await _shoppingMethodRepository.UpdateAsync(shoppingMethodTemp);
                    }
                    else
                    {
                        throw new Exception("Error by Bind Value");
                    }

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingMethodModel);
        }


        public async Task<IActionResult> Delete(int id)
        {

            var shoppingMethod = await _shoppingMethodRepository.GetByIdAsync(id);

            if (shoppingMethod == null)
            {
                return NotFound();
            }

            return View(new ShoppingMethodViewModel
            {
                Id = shoppingMethod.Id,
                Name = shoppingMethod.Name,
                Price = shoppingMethod.Price
            });
        }


        [HttpPost]
         
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _shoppingMethodRepository.GetByIdAsync(id) == null)
            {
                return Problem("Entity set 'shoppingMethod'  is null.");
            }
            var shoppingMethod = await _shoppingMethodRepository.GetByIdAsync(id);
            if (shoppingMethod != null)
            {
                await _shoppingMethodRepository.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private ShoppingMethod CreateshoppingMethod()
        {
            try
            {
                return Activator.CreateInstance<ShoppingMethod>();

            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of shoppingMethod");
            }
        }

    }
}
