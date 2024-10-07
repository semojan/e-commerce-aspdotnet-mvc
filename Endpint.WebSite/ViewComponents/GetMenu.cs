using _04_06_01_ecommerce.Application.Services.Common.Queeries;
using Microsoft.AspNetCore.Mvc;

namespace Endpint.WebSite.ViewComponents
{
    public class GetMenu : ViewComponent
    {
        private readonly IGetMenuItemService _getMenuItem;
        public GetMenu(IGetMenuItemService getMenuItem)
        {
            _getMenuItem = getMenuItem;
        } 


        public IViewComponentResult Invoke()
        {
            var menuItems = _getMenuItem.Execute().Data;
            return View(viewName: "GetMenu", menuItems);
        }
    }
}
