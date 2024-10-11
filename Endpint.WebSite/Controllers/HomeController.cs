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
using _04_06_01_ecommerce.Application.Services.Common.Queries.GetHomeImages;
using _04_06_01_ecommerce.Application.Interface.FacadPatterns;
using _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductsForCustomer;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSlidersService _getSlidersService;
        private readonly IGetHomeImagesService _getHomeImagesService;
        private readonly IProductFacad _productFacad;

        public HomeController(ILogger<HomeController> logger,
            IGetSlidersService getSlidersService,
            IGetHomeImagesService getHomeImagesService,
            IProductFacad productFacad)
        {
            _logger = logger;
            _getSlidersService = getSlidersService;
            _getHomeImagesService = getHomeImagesService;
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _getSlidersService.Execute().Data,
                HomeImages = _getHomeImagesService.Execute().Data,
                Digital = _productFacad.GetProductsForCustomerService.Execute(
                    Ordering.Newest,
                    null, 1, 6, 3).Data.Products,
                Clothes = _productFacad.GetProductsForCustomerService.Execute(
                    Ordering.Newest,
                    null, 1, 6, 2).Data.Products,
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
