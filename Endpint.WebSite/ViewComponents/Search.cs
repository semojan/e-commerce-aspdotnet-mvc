using _04_06_01_ecommerce.Application.Services.Common.Queeries.GetCategories;
using Microsoft.AspNetCore.Mvc;

namespace Endpint.WebSite.ViewComponents
{
    public class Search : ViewComponent
    {
        private readonly IGetSearchCategoriesService _getSearchCategoriesService;
        public Search(IGetSearchCategoriesService getSearchCategoriesService)
        {
            _getSearchCategoriesService = getSearchCategoriesService;
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName: "Search", _getSearchCategoriesService.Execute().Data);   
        }
    }
}
