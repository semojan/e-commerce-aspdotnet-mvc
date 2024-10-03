using _04_06_01_ecommerce.Application.Interface.FacadPatterns;
using Microsoft.AspNetCore.Mvc;

namespace Endpint.WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IProductFacad _productFacad;
        public CategoriesController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        public IActionResult Index(int? parentId)
        { 
            return View(_productFacad.GetCategoriesService.Execute(parentId).Data);
        }

        [HttpGet]
        public IActionResult addCategory(int? parentId)
        {
            ViewBag.ParentId = parentId;
            return View();
        }

        [HttpPost]
        public IActionResult addCategory(int? parentId, string name)
        {
            var result = _productFacad.AddCategoryService.Execute(parentId, name);
            return Json(result);
        }
    }
}
