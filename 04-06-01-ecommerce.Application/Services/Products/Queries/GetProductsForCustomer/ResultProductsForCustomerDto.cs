namespace _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductsForCustomer
{
    public class ResultProductsForCustomerDto
    {
        public int TotalRow { get; set; }
        public List<ProductsForCustomerDto> Products { get; set; }
    }
}
