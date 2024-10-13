using _04_06_01_ecommerce.Application.Services.Carts;
using Endpint.WebSite.Utilities;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Endpint.WebSite.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        private readonly CookiesManeger cookiesManeger;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
            cookiesManeger = new CookiesManeger();
        }

        public IActionResult Index()
        {
            var userId = ClaimUtility.GetUserId(User);
            var resultData = _cartService.GetMyCart(cookiesManeger.GetBrowserId(HttpContext), userId).Data;
            return View(resultData);
        }

        public IActionResult AddToCart(int ProductId)
        {
            var result = _cartService.AddToCart(ProductId, cookiesManeger.GetBrowserId(HttpContext));
            return RedirectToAction("Index");
        }

        public IActionResult Add(int CartItemId)
        {
            _cartService.Add(CartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult LowOff(int CartItemId)
        {
            _cartService.LowOff(CartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int ProductId)
        {
            _cartService.RemoveFromCart(ProductId, cookiesManeger.GetBrowserId(HttpContext));
            return RedirectToAction("Index");
        }
    }
}
