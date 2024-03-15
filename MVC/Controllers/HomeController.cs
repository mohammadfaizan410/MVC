using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService; 

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();    
            return View(products);
        }

        public IActionResult Delete(int Id)
        {   bool result = _productService.DeleteProduct(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {   ProductModel model = _productService.GetProduct(id);
            return View(model);

        }

        [HttpPost]
        public IActionResult Update(ProductModel model)
        {
            if(ModelState.IsValid)
            {
                bool result = _productService.UpdateProduct(model);
                _logger.LogInformation("Update result: {Result}", result); if 
                    (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }

            }
            

            return View(model); 

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                bool result = _productService.AddProduct(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }



        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
