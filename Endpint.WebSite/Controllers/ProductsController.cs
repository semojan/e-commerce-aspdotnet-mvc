using _04_06_01_ecommerce.Application.Interface.FacadPatterns;
using Microsoft.AspNetCore.Mvc;

namespace Endpint.WebSite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        [HttpGet]
        public IActionResult Index(int? CategoryId = null, int page = 1)
        {
            return View(_productFacad.GetProductsForCustomerService.Execute(page, CategoryId).Data);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var data = _productFacad.GetProductDetailForCustomerService.Execute(id).Data;
            return View(data);
        }
    }
}
