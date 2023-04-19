using AdminSiteUseMVC.Models.Services.Categories;
using AdminSiteUseMVC.Services.Abstract;
using AdminSiteUseMVC.ViewModel.Categories;
using Domian;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace AdminSiteUseMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly CategoryReopsitory _categoryReopsitory;
        private readonly IImageServices _imageServices;

        public CategoriesController(CategoryReopsitory categoryReopsitory,
            IImageServices imageServices
            )
        {
            _categoryReopsitory = categoryReopsitory;
            _imageServices = imageServices;
        }
        public async Task<IActionResult> Index()
        {

            List<CategoryViewModel> categories = new List<CategoryViewModel>();

            var items = await _categoryReopsitory.GetAllAsync();
            if (items == null)
            {
                return NotFound();
            }
            else
            {
                foreach (var item in items)
                {
                    if (item.NameEN != null || item.NameAR!=null)
                        categories.Add(new CategoryViewModel(item.Id, item.NameEN, item.NameAR)
                        {
                            ImageURL = item.ImageURL
                        });
                }
                return View(categories);
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            if (await _categoryReopsitory.GetAllAsync() == null)
            {
                return NotFound();
            }

            var category = await _categoryReopsitory.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(new CategoryViewModel(category.Id, category.NameEN,category.NameAR) { ImageURL = category.ImageURL });
        }


        public async Task<IActionResult> Create()
        {
            var categories = await _categoryReopsitory.GetAllAsync();
            ViewBag.CategoriesEN = new SelectList(categories, "Id", "NameEN");
            ViewBag.CategoriesAR = new SelectList(categories, "Id", "NameAR");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel categoryModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var catgory = CreateCategory();

                    catgory.NameEN = categoryModel.NameEN;
                    catgory.NameAR = categoryModel.NameAR;
                    if(categoryModel.ImageFile!= null)
                    {
                        var url = await _imageServices.UploadImageToAzure(categoryModel.ImageFile);
                        catgory.ImageURL = url;
                    }else
                    {
                        ModelState.AddModelError(string.Empty, "Image Is Required");
                        return View(categoryModel);
                    }
                    
                    if(categoryModel.ParentCategoryId != null)
                    {
                        catgory.Parentcategory = await _categoryReopsitory.GetByIdAsync((int)categoryModel.ParentCategoryId);
                    }
                    await _categoryReopsitory.CreatAsync(catgory);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            return View(categoryModel);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var category = await _categoryReopsitory.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(new CategoryViewModel(category.Id, category.NameEN, category.NameAR));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryViewModel categoryModel)
        {
            if (id != categoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var CategoryTemp = await _categoryReopsitory.GetByIdAsync(id);
                    if (CategoryTemp != null)
                    {
                        CategoryTemp.NameEN = categoryModel.NameEN;
                        CategoryTemp.NameAR = categoryModel.NameAR;
                        await _categoryReopsitory.UpdateAsync(CategoryTemp);
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
            return View(categoryModel);
        }


        public async Task<IActionResult> Delete(int id)
        {

            var category = await _categoryReopsitory.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(new CategoryViewModel(category.Id, category.NameEN, category.NameAR));
        }


        [HttpPost]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _categoryReopsitory.GetByIdAsync(id) == null)
            {
                return Problem("Entity set 'category '  is null.");
            }
            var category = await _categoryReopsitory.GetByIdAsync(id);
            if (category != null)
            {
                await _categoryReopsitory.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private Category CreateCategory()
        {
            try
            {
                return Activator.CreateInstance<Category>();
           
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of Ctegory");
            }
        }


    }
}
