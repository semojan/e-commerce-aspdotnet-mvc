using _04_06_01_ecommerce.Common.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductDetailForCustomer
{
    public interface IGetProductDetailForCustomerService
    {
        ResultDto<ProductDetailForCustomerDto> Execute(int Id);
    }
}
