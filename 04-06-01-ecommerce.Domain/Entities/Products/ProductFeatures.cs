using _04_06_01_ecommerce.Domain.Entities.Commons;

namespace _04_06_01_ecommerce.Domain.Entities.Products
{
    public class ProductFeatures : BaseEntity
    {
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
