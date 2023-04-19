using AdminSiteUseMVC.Models.Services.Stocks;
using AdminSiteUseMVC.ViewModel.Stocks;
using Domian;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AdminSiteUseMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StocksController : Controller
    {

        private readonly StockRepository _stockRepository;

        public StocksController(StockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task<IActionResult> Index()
        {

            List<StockViewModel> stocks = new List<StockViewModel>();

            var items = await _stockRepository.GetAllAsync();
            if (items == null)
            {
                return NotFound();
            }
            else
            {
                foreach (var item in items)
                {
                    if (item.Name != null)
                        stocks.Add(new StockViewModel(item.Id, item.Name, item.Address));
                }
                return View(stocks);
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            if (await _stockRepository.GetAllAsync() == null)
            {
                return NotFound();
            }

            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(new StockViewModel(stock.Id, stock.Name, stock.Address));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] StockViewModel stockModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var stock = Createstock();
                    stock.Name = stockModel.Name;
                    stock.Address = stockModel.Address;

                    await _stockRepository.CreatAsync(stock);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            return View(stockModel);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return View(new StockViewModel(stock.Id, stock.Name, stock.Address));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] StockViewModel stockModel)
        {
            if (id != stockModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var stockTemp = await _stockRepository.GetByIdAsync(id);
                    if (stockTemp != null)
                    {
                        stockTemp.Name = stockModel.Name;
                        stockTemp.Address = stockModel.Address;
                        await _stockRepository.UpdateAsync(stockTemp);
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
            return View(stockModel);
        }


        public async Task<IActionResult> Delete(int id)
        {

            var stock = await _stockRepository.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return View(new StockViewModel(stock.Id, stock.Name, stock.Address));
        }


        [HttpPost]
     
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _stockRepository.GetByIdAsync(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Roles'  is null.");
            }
            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock != null)
            {
                await _stockRepository.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private Stock Createstock()
        {
            try
            {
                return Activator.CreateInstance<Stock>();

            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of Stock");
            }
        }

    }
}
