using _04_06_01_ecommerce.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductsForAdmin
{
    public interface IGetProductsForAdminService
    {
        ResultDto<ProductsForAdminDto> Execute(int page = 1, int pageSize = 20);
    }
}
