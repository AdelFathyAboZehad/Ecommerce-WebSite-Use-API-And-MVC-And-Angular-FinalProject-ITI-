using AdminSiteUseMVC.Models.Services.Brands;
using AdminSiteUseMVC.Models.Services.Categories;
using AdminSiteUseMVC.Models.Services.Products;
using AdminSiteUseMVC.Models.Services.Stocks;
using AdminSiteUseMVC.Services.Abstract;
using AdminSiteUseMVC.ViewModel.Products;
using Domian;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminSiteUseMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {

        private readonly ProductRepository _productRepository;
        private readonly BrandRepository _brandRepository;
        private readonly StockRepository _stockRepository;
        private readonly CategoryReopsitory _categoryReopsitory;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ProductsController> _logger;
        private readonly IImageServices _imageServices;

        public ProductsController(ProductRepository productRepository,
            BrandRepository brandRepository, StockRepository stockRepository,
            CategoryReopsitory categoryReopsitory,
            IWebHostEnvironment webHostEnvironment,
            ILogger<ProductsController> logger,
            IImageServices imageServices)
        {

            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _stockRepository = stockRepository;
            _categoryReopsitory = categoryReopsitory;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _imageServices = imageServices;
        }

        public async Task<IActionResult> Index()
        {

            List<ProductViewModel> products = new List<ProductViewModel>();

            //var items = await _productRepository.GetAllAsync();
            var items = await _productRepository.GetAllProductsWithImagesAsync();
            if (items == null)
            {
                return NotFound();
            }
            else
            {
                foreach (var item in items)
                {
                    if (item.NameEN != null || item.NameAR != null)
                        products.Add(new ProductViewModel(item.Id, item.NameEN, item.NameAR, item.DescriptionEN, item.DescriptionAR, item.DiscountPercentage, item.Price, item.Quantity)
                        {
                            Images = item.Images,
                        });
                }
                return View(products);
            }
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categoryReopsitory.GetAllAsync(), "Id", "NameEN");
            ViewBag.Brands = new SelectList(await _brandRepository.GetAllAsync(), "Id", "NameEN");
            ViewBag.Stocks = new SelectList(await _stockRepository.GetAllAsync(), "Id", "Name");
            ViewBag.CategoriesAR = new SelectList(await _categoryReopsitory.GetAllAsync(), "Id", "NameAR");
            ViewBag.BrandsAR = new SelectList(await _brandRepository.GetAllAsync(), "Id", "NameAR");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var product = CreateProduct();
                    product.NameEN = productModel.NameEN;
                    product.NameAR = productModel.NameAR;

                    product.DescriptionEN = productModel.DescriptionEN;
                    product.DescriptionAR = productModel.DescriptionAR;

                    product.DiscountPercentage = productModel.DiscountPercentage;
                    product.Price = productModel.Price;
                    product.Quantity = productModel.Quantity;
                    product.Brand = await _brandRepository.GetByIdAsync(productModel.BrandId);
                    product.Stock = await _stockRepository.GetByIdAsync(productModel.StockId);

                    product.Categories = (await _categoryReopsitory.GetAllAsync()).Where(c => productModel.CategoriesId.Contains(c.Id)).ToList();

                    List<Image> images = new List<Image>();
                    if (productModel.ImagesFile != null)
                    {
                        foreach (var item in productModel.ImagesFile)
                        {
                            string StringFileNameURl = await _imageServices.UploadImageToAzure(item);
                            var productImage = CreateImage();
                            productImage.ImageURL = StringFileNameURl;
                            productImage.Product = product;
                            images.Add(productImage);

                        }
                    }
                    product.Images = images;

                    await _productRepository.CreatAsync(product);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            return View(productModel);
        }

        //private string UploadFile(IFormFile formFile)
        //{
        //    string FileName = string.Empty;
        //    if(formFile != null)
        //    {
        //       // string FileDir = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
        //        string FileDir = Path.Combine("Resources","Images");
        //        FileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
        //        string FilePath= Path.Combine(FileDir, FileName);
        //        using (var fileStream = new FileStream(FilePath, FileMode.Create))
        //        {
        //            formFile.CopyTo(fileStream);
        //        }
        //        FileName = FilePath;
        //    }
        //    return FileName;
        //}
        public async Task<IActionResult> Details(long id)
        {
            if (await _productRepository.GetAllAsync() == null)
            {
                return NotFound();
            }

            var product = (await _productRepository.GetByIdAllDetailsAsync(id));
            if (product == null)
            {
                return NotFound();
            }

            return View(new DetailsProductViewModel()
            {
                Id = product.Id,
                NameEN = product.NameEN,
                NameAR = product.NameAR,
                DescriptionEN = product.DescriptionEN,
                DescriptionAR = product.DescriptionAR,
                DiscountPercentage = product.DiscountPercentage,
                Price = product.Price,
                Quantity = product.Quantity,
                Brand = product.Brand,
                Stock = product.Stock,
                Categories = product.Categories,
                Images = product.Images
            });
        }



        public async Task<IActionResult> Edit(long id)
        {

            var product = await _productRepository.GetByIdAllDetailsAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Brands = new SelectList(await _brandRepository.GetAllAsync(), "Id", "NameEN");
            ViewBag.Stocks = new SelectList(await _stockRepository.GetAllAsync(), "Id", "Name");
            ViewBag.Categories = new SelectList(await _categoryReopsitory.GetAllAsync(), "Id", "NameEN");
            ViewBag.CategoriesAR = new SelectList(await _categoryReopsitory.GetAllAsync(), "Id", "NameAR");
            ViewBag.BrandsAR = new SelectList(await _brandRepository.GetAllAsync(), "Id", "NameAR");

            return View(new EditProductViewModel(product.Id,
                product.NameEN,
                product.NameAR,
                product.DescriptionEN,
                product.DescriptionAR,
                product.DiscountPercentage,
                product.Price, product.Quantity)
            { BrandId = product.Brand.Id, StockId = product.Stock.Id, CategoriesId = product.Categories.Select(x => x.Id).ToList() });

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProductViewModel productModel)
        {
            if (id != productModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ProductTemp = await _productRepository.GetByIdAsync(id);
                    if (ProductTemp != null)
                    {
                        ProductTemp.NameEN = productModel.NameEN;
                        ProductTemp.NameAR = productModel.NameAR;
                        ProductTemp.DescriptionEN = productModel.DescriptionEN;
                        ProductTemp.DescriptionAR = productModel.DescriptionAR;
                        ProductTemp.DiscountPercentage = productModel.DiscountPercentage;
                        ProductTemp.Price = productModel.Price;
                        ProductTemp.Quantity = productModel.Quantity;
                        ProductTemp.Brand = await _brandRepository.GetByIdAsync(productModel.BrandId);
                        ProductTemp.Stock = await _stockRepository.GetByIdAsync(productModel.StockId);
                        ProductTemp.Categories = (await _categoryReopsitory.GetAllAsync()).Where(c => productModel.CategoriesId.Contains(c.Id)).ToList();

                        await _productRepository.UpdateAsync(ProductTemp);
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
            return View(productModel);
        }


        public async Task<IActionResult> Delete(long id)
        {

            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(new ProductViewModel(product.Id, product.NameEN, product.NameEN, product.DescriptionEN, product.DescriptionAR, product.DiscountPercentage, product.Price, product.Quantity));
        }


        [HttpPost]
        
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (await _productRepository.GetByIdAsync(id) == null)
            {
                return Problem("Entity set Product Enity  is null.");
            }
            var Product = await _productRepository.GetByIdAsync(id);
            if (Product != null)
            {
                await _productRepository.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private Product CreateProduct()
        {
            try
            {
                return Activator.CreateInstance<Product>();

            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of Product");
            }
        }

        private Image CreateImage()
        {
            try
            {
                return Activator.CreateInstance<Image>();

            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of Image");
            }
        }


    }
}
