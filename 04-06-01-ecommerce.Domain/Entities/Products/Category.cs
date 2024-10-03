using _04_06_01_ecommerce.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Domain.Entities.Products
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
    }
}
