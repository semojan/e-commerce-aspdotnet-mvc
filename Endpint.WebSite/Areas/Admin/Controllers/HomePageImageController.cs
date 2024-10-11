using _04_06_01_ecommerce.Application.Services.HomePage.AddHomePageImages;
using _04_06_01_ecommerce.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Mvc;

namespace Endpint.WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageImageController : Controller
    {
        private readonly IAddHomePageImagesService _addImagesService;
        public HomePageImageController(IAddHomePageImagesService addHomePageImagesService)
        {
            _addImagesService = addHomePageImagesService;
        }
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
        public IActionResult Add(IFormFile file, string link, ImageLocation imageLocation)
        {
            _addImagesService.Execute(new RequestAddHomeImagesDto
            {
                File = file,
                Link = link,
                Location = imageLocation
            });
            return View();
        }
    }
}
