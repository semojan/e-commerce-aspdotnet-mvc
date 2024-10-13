using _04_06_01_ecommerce.Domain.Entities.Commons;
using _04_06_01_ecommerce.Domain.Entities.Products;

namespace _04_06_01_ecommerce.Domain.Entities.Carts
{
    public class CartItem : BaseEntity
    { 
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }

        public int Count { get; set; }
        public int Price { get; set; }

        public virtual Cart Cart { get; set; }
        public int CartId { get; set; }
    }
}
