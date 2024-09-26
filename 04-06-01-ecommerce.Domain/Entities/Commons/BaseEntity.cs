using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Domain.Entities.Commons
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeleteTime { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int> { }
}
