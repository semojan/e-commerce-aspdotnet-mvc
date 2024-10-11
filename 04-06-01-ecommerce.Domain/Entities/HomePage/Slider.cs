using _04_06_01_ecommerce.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Domain.Entities.HomePage
{
    public class Slider : BaseEntity
    {
        public string Src { get; set; }
        public string Link { get; set; }
    }
}
