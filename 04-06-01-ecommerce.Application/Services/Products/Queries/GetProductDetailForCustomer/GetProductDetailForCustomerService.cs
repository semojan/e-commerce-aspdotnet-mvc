using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductDetailForCustomer
{
    public class GetProductDetailForCustomerService : IGetProductDetailForCustomerService
    {
        private readonly IDataBaseContext _context;
        public GetProductDetailForCustomerService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProductDetailForCustomerDto> Execute(int Id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductFeatures)
                .Where(p => p.Id == Id)
                .FirstOrDefault();
            if (product == null)
            {
                throw new Exception("Product not found...");
            }

            product.ViewCount++;
            _context.SaveChanges();

            return new ResultDto<ProductDetailForCustomerDto>
            {
                Data = new ProductDetailForCustomerDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Brand = product.Brand,
                    Category = $"{product.Category.ParentCategory.Name } - {product.Category.Name}",
                    Description = product.Description,
                    Price = product.Price,
                    Images = product.ProductImages.Select(p => p.Src).ToList(),
                    Features = product.ProductFeatures.Select(p => new ProductDetailForCustomerFeaturesDto
                    {
                        DisplayName = p.DisplayName,
                        Value = p.Value,
                    }).ToList(),
                },
                Success = true,
                Message = ""
            };
        }
    }
}
