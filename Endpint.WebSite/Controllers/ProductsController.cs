using _04_06_01_ecommerce.Application.Interface.FacadPatterns;
using _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductsForCustomer;
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
        public IActionResult Index(Ordering ordering, string SearchKey, int? CategoryId = null, int page = 1, int pageSize = 20)
        {
            return View(_productFacad.GetProductsForCustomerService.Execute(ordering , SearchKey, page, pageSize, CategoryId).Data);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var data = _productFacad.GetProductDetailForCustomerService.Execute(id).Data;
            return View(data);
        }
    }
}
