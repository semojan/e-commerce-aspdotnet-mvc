using _04_06_01_ecommerce.Application.Services.HomePage.AddSlider;
using Microsoft.AspNetCore.Mvc;

namespace Endpint.WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IAddSliderService _addSliderService;
        public SliderController(IAddSliderService addSliderService)
        {
            _addSliderService = addSliderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile file, string link)
        {
            _addSliderService.Execute(file, link);
            return View();
        }
    }
}
