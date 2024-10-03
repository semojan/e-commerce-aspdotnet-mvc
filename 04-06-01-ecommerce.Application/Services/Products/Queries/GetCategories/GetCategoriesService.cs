using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace _04_06_01_ecommerce.Application.Services.Products.Queries.GetCategories
{
    public class GetCategoriesService : IGetCategoriesService
    {
        private readonly IDataBaseContext _context;

        public GetCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<CategoriesDto>> Execute(int? parentId)
        {
            var categories  = _context.Categories
                .Include(p => p.ParentCategory)
                .Include(p => p.SubCategories)
                .Where(p => p.ParentCategoryId == parentId)
                .ToList()
                .Select(p => new CategoriesDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Parent = p.ParentCategory != null ? new 
                    ParentCategoryDto
                    {
                        Id = p.ParentCategory.Id,
                        Name = p.ParentCategory.Name,
                    }
                    : null,
                    HasChild = p.SubCategories.Count() > 0 ? true : false
                })
                .ToList();

            return new ResultDto<List<CategoriesDto>>()
            {
                Data = categories,
                Success = true,
                Message = " دسته بندی ها با موفقیت گرفته شد"
            };
        }
    }
}
