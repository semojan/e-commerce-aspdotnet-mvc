﻿using _04_06_01_ecommerce.Application.Services.Carts;
using Endpint.WebSite.Utilities;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Endpint.WebSite.ViewComponents
{
    public class Cart : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly CookiesManeger cookiesManager;
        public Cart(ICartService cartService)
        {
            _cartService = cartService;
            cookiesManager = new CookiesManeger();
        }

        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            return View(viewName: "Cart", _cartService.GetMyCart(cookiesManager.GetBrowserId(HttpContext), userId).Data);
        }
    }
}
