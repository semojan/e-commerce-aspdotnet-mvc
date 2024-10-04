using _04_06_01_ecommerce.Domain.Entities.Commons;

namespace _04_06_01_ecommerce.Domain.Entities.Products
{
    public class ProductImages : BaseEntity
    {
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public string Src { get; set; }
    }
}
