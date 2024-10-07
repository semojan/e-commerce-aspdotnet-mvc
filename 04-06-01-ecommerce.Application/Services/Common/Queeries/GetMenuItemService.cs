using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace _04_06_01_ecommerce.Application.Services.Common.Queeries
{
    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDataBaseContext _context;
        public GetMenuItemService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<MenuItemDto>> Execute()
        {
            var categories = _context.Categories
                .Include(p => p.SubCategories)
                .Where(p => p.ParentCategoryId == null)
                .ToList()
                .Select(p => new MenuItemDto
                {
                    CategoryId = p.Id,
                    Name = p.Name,
                    Children = p.SubCategories.ToList().Select(child => new MenuItemDto
                    {
                        CategoryId = child.Id,
                        Name = child.Name
                    }).ToList(),
                }).ToList();

            return new ResultDto<List<MenuItemDto>>()
            {
                Data = categories,
                Success = true,
                Message = ""
            };
        }
    }
}

