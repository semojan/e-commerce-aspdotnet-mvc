using _04_06_01_ecommerce.Common.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Application.Services.Products.Commands.AddProduct
{
    public interface IAddProductService
    {
        ResultDto Execute(RequestAddProductDto request);
    }
}
