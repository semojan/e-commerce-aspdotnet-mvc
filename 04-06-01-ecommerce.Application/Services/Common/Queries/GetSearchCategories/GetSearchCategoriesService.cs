using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;

namespace _04_06_01_ecommerce.Application.Services.Common.Queeries.GetCategories
{
    public class GetSearchCategoriesService : IGetSearchCategoriesService
    {
        private readonly IDataBaseContext _context;
        public GetSearchCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<SearchCategoriesDto>> Execute()
        {
            var categories = _context.Categories
                .Where(p => p.ParentCategoryId == null)
                .ToList()
                .Select(p => new SearchCategoriesDto
                {
                    CategoryId = p.Id,
                    CategoryName = p.Name,
                }).ToList();

            return new ResultDto<List<SearchCategoriesDto>>()
            {
                Data = categories,
                Success = true,
                Message = ""
            };
        }
    }
}
