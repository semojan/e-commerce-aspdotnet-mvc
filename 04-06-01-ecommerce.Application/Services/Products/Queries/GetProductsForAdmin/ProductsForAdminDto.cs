namespace _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductsForAdmin
{
    public class ProductsForAdminDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public List<ProductForAdminListDto> Products { get; set; }
    }
}
