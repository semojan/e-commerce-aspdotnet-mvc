using _04_06_01_ecommerce.Domain.Entities.Commons;
using _04_06_01_ecommerce.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Domain.Entities.Carts
{
    public class Cart : BaseEntity
    {
        public virtual User User { get; set; }
        public int? UserId { get; set; }

        public Guid BrowserId { get; set; }
        public bool Finished { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
