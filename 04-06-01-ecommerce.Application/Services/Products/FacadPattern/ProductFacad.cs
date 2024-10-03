using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Application.Interface.FacadPatterns;
using _04_06_01_ecommerce.Application.Services.Products.Commands.AddCategory;
using _04_06_01_ecommerce.Application.Services.Products.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Application.Services.Products.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDataBaseContext _context;
        public ProductFacad(IDataBaseContext context)
        {
            _context = context;
        }

        private IAddCategoryService _addCategory;
        public IAddCategoryService AddCategoryService
        {
            get
            {
                return _addCategory = _addCategory ?? new AddCategoryService(_context);
            }
        }

        private IGetCategoriesService _getCategories;
        public IGetCategoriesService GetCategoriesService
        {
            get
            {
                return _getCategories ?? new GetCategoriesService(_context);
            }
        }
    }
}
