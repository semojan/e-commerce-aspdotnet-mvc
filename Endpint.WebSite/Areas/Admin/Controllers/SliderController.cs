using _04_06_01_ecommerce.Application.Services.Common.Commands.RemoveSlider;
using _04_06_01_ecommerce.Application.Services.Common.Queries.GetSliders;
using _04_06_01_ecommerce.Application.Services.HomePage.AddSlider;
using Microsoft.AspNetCore.Mvc;

namespace Endpint.WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IAddSliderService _addSliderService;
        private readonly IGetSlidersService _getSlidersService;
        private readonly IRemoveSliderService _removeSliderService;
        public SliderController(IAddSliderService addSliderService,
            IRemoveSliderService removeSliderService,
            IGetSlidersService getSlidersService)
        {
            _addSliderService = addSliderService;
            _removeSliderService = removeSliderService;
            _getSlidersService = getSlidersService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_getSlidersService.Execute().Data);
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

        [HttpPost]
        public IActionResult Delete(int SliderId)
        {
            return Json(_removeSliderService.Execute(SliderId));
        }
    }
}
