using Microsoft.AspNetCore.Http;

namespace _04_06_01_ecommerce.Application.Services.Products.Commands.AddProduct
{
    public class RequestAddProductDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public int CategoryId { get; set; }
        public bool Display { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<AddProductFeatures> Features { get; set; }
    }
}
