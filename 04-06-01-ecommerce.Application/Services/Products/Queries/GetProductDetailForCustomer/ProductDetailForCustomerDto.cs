namespace _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductDetailForCustomer
{
    public class ProductDetailForCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public List<string> Images { get; set; }
        public List<ProductDetailForCustomerFeaturesDto> Features { get; set; }
    }
}
