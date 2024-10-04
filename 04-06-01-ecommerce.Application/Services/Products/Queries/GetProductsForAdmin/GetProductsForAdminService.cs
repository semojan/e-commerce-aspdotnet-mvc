using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common;
using _04_06_01_ecommerce.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductsForAdmin
{
    public class GetProductsForAdminService : IGetProductsForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetProductsForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductsForAdminDto> Execute(int page = 1, int pageSize = 20)
        {
            int rowCount = 0;
            var products = _context.Products
                .Include(p => p.Category)
                .ToPaged(page, pageSize, out rowCount)
                .Select(p => new ProductForAdminListDto
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Category = p.Category.Name,
                    Description = p.Description,
                    Display = p.Display,
                    Inventory = p.Inventory,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList();

            return new ResultDto<ProductsForAdminDto>
            {
                Data = new ProductsForAdminDto
                {
                    Products = products,
                    RowCount = rowCount,
                    CurrentPage = page,
                    PageSize = pageSize
                },
                Success = true,
                Message = ""
            };
        }
    }
}
