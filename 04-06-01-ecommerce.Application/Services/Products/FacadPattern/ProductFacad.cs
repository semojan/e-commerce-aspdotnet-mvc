using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Application.Interface.FacadPatterns;
using _04_06_01_ecommerce.Application.Services.Products.Commands.AddCategory;
using _04_06_01_ecommerce.Application.Services.Products.Commands.AddProduct;
using _04_06_01_ecommerce.Application.Services.Products.Queries.GetAllCategory;
using _04_06_01_ecommerce.Application.Services.Products.Queries.GetCategories;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IHostingEnvironment _environment;
        public ProductFacad(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
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

        private IGetAllCategoriesService _getAllCategories;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _getAllCategories ?? new GetAllCategoriesService(_context);
            }
        }

        private IAddProductService _addProduct;
        public IAddProductService AddProductService
        {
            get
            {
                return _addProduct ?? new AddProductService(_context, _environment);
            }
        }
    }
}
