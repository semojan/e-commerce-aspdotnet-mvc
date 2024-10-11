using _04_06_01_ecommerce.Application.Services.Common.Queries.GetHomeImages;
using _04_06_01_ecommerce.Application.Services.Common.Queries.GetSliders;
using _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductsForCustomer;

namespace Endpint.WebSite.Models.ViewModels.HomePage
{
    public class HomePageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
        public List<HomeImagesDto> HomeImages { get; set; }
        public List<ProductsForCustomerDto> Digital { get; set; }
        public List<ProductsForCustomerDto> Clothes { get; set; }
    }
}
