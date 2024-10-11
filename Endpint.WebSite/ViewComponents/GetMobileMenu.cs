using _04_06_01_ecommerce.Application.Services.Common.Queeries.GetMenuItem;
using Microsoft.AspNetCore.Mvc;

namespace Endpint.WebSite.ViewComponents
{
    public class GetMobileMenu : ViewComponent
    {
        private readonly IGetMenuItemService _getMenuItem;
        public GetMobileMenu(IGetMenuItemService getMenuItem)
        {
            _getMenuItem = getMenuItem;
        }


        public IViewComponentResult Invoke()
        {
            var menuItems = _getMenuItem.Execute().Data;
            return View(viewName: "GetMobileMenu", menuItems);
        }
    }
}
