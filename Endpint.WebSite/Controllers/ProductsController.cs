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
        public IActionResult Index(int page = 1)
        {
            return View(_productFacad.GetProductsForCustomerService.Execute(page).Data);
        }
    }
}
