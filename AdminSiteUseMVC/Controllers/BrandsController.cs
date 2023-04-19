using AdminSiteUseMVC.Models.Services.Brands;
using AdminSiteUseMVC.Services.Abstract;
using AdminSiteUseMVC.ViewModel.Brands;
using Domian;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AdminSiteUseMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BrandsController : Controller
    {

        private readonly BrandRepository _brandRepository;
        private readonly IImageServices _imageServices;

        public BrandsController(BrandRepository brandRepository,IImageServices imageServices)
        {
            _brandRepository = brandRepository;
            _imageServices = imageServices;
        }
        public async Task<IActionResult> Index()
        {

            List<BrandViewModel> brands = new List<BrandViewModel>();

            var items = await _brandRepository.GetAllAsync();
            if (items == null)
            {
                return NotFound();
            }
            else
            {
                foreach (var item in items)
                {
                    if (item.NameEN != null ||item.NameAR !=null)
                        brands.Add(new BrandViewModel(item.Id, item.NameEN, item.NameAR)
                        {
                            ImageURL= item.ImageURL
                        });
                }
                return View(brands);
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            if (await _brandRepository.GetAllAsync() == null)
            {
                return NotFound();
            }

            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(new BrandViewModel(brand.Id, brand.NameEN, brand.NameAR) { ImageURL = brand.ImageURL });
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandViewModel brandModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var brand = CreateBrand();
                    brand.NameEN = brandModel.NameEN;
                    brand.NameAR = brandModel.NameAR;
                    if (brandModel.ImageFile != null)
                    {
                        var url = await _imageServices.UploadImageToAzure(brandModel.ImageFile);
                        brand.ImageURL = url;
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Image IS Required");
                        return View(brandModel);
                    }

                    await _brandRepository.CreatAsync(brand);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            return View(brandModel);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(new BrandViewModel(brand.Id, brand.NameEN,brand.NameAR));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BrandViewModel brandModel)
        {
            if (id != brandModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var brandTemp = await _brandRepository.GetByIdAsync(id);
                    if (brandTemp != null)
                    {
                        brandTemp.NameEN = brandModel.NameEN;
                        brandTemp.NameAR = brandModel.NameAR;
                        await _brandRepository.UpdateAsync(brandTemp);
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
            return View(brandModel);
        }


        public async Task<IActionResult> Delete(int id)
        {

            var brand = await _brandRepository.GetByIdAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return View(new BrandViewModel(brand.Id, brand.NameEN, brand.NameAR));
        }


        [HttpPost]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _brandRepository.GetByIdAsync(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Roles'  is null.");
            }
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand != null)
            {
                await _brandRepository.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private Brand CreateBrand()
        {
            try
            {
                return Activator.CreateInstance<Brand>();

            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of Brand");
            }
        }

    }
}
