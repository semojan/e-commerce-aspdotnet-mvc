namespace _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductsForAdmin
{
    public class ProductForAdminListDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Display { get; set; }
    }
}
