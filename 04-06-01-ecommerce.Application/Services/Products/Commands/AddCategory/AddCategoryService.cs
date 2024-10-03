using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;
using _04_06_01_ecommerce.Domain.Entities.Products;

namespace _04_06_01_ecommerce.Application.Services.Products.Commands.AddCategory
{
    public class AddCategoryService : IAddCategoryService
    {
        private readonly IDataBaseContext _context;

        public AddCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int? parentId, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new ResultDto()
                {
                    Success = false,
                    Message = "نام دسته را وارد کنید"
                };
            }

            Category category = new Category()
            {
                Name = name,
                ParentCategory = GetParent(parentId)
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
            return new ResultDto()
            {
                Success = true,
                Message = "دسته بندی با موفقیت اضافه شد"
            };
        }

        private Category GetParent(int? parentId)
        {
            return _context.Categories.Find(parentId);
        }
    }
}
