using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;
using _04_06_01_ecommerce.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductDetailForAdmin
{
    public class GetProductDetailForAdminService : IGetProductDetailForAdminService
    {
        private readonly IDataBaseContext _context;

        public GetProductDetailForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductDetailForAdminDto> Execute(int Id)
        {
            var product = _context
                .Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .Where(p => p.Id == Id)
                .FirstOrDefault();

            return new ResultDto<ProductDetailForAdminDto>
            {
                Data = new ProductDetailForAdminDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Brand = product.Brand,
                    Description = product.Description,
                    Price = product.Price,
                    Inventory = product.Inventory,
                    Display = product.Display,
                    Category = GetCategory(product.Category),
                    Features = product.ProductFeatures.ToList().Select(p => new ProductDetailFeaturesDto
                    {
                        Id = p.Id,
                        DisplayName = p.DisplayName,
                        Value = p.Value
                    }).ToList(),
                    Images = product.ProductImages.ToList().Select(p => new ProductDetailImagesDto
                    {
                        Id= p.Id,
                        Src = p.Src
                    }).ToList(),
                },
                Success = true,
                Message = ""
            };
        }

        private string GetCategory(Category category)
        {
            string result = category.ParentCategory != null ? $"{category.ParentCategory.Name} - " : "";
            return result += category.Name;
        }
    }
}
