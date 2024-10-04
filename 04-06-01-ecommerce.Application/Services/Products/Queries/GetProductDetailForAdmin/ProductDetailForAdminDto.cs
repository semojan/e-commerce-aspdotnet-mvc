namespace _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductDetailForAdmin
{
    public class ProductDetailForAdminDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Display { get; set; }
        public List<ProductDetailFeaturesDto> Features { get; set; }
        public List<ProductDetailImagesDto> Images { get; set; }
    }
}
