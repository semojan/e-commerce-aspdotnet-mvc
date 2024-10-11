using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EndPoint.Site.Models;
using _04_06_01_ecommerce.Application.Services.Common.Queries.GetSliders;
using Endpint.WebSite.Models.ViewModels.HomePage;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSlidersService _getSlidersService;

        public HomeController(ILogger<HomeController> logger,
            IGetSlidersService getSliders)
        {
            _logger = logger;
            _getSlidersService = getSliders;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _getSlidersService.Execute().Data,
            };
            return View(homePage);
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
