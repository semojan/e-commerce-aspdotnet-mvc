using _04_06_01_ecommerce.Application.Services.Products.Commands.AddCategory;
using _04_06_01_ecommerce.Application.Services.Products.Commands.AddProduct;
using _04_06_01_ecommerce.Application.Services.Products.Queries.GetAllCategory;
using _04_06_01_ecommerce.Application.Services.Products.Queries.GetCategories;
using _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductDetailForAdmin;
using _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductsForAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Application.Interface.FacadPatterns
{
    public interface IProductFacad
    {
        IAddCategoryService AddCategoryService { get; }

        IGetCategoriesService GetCategoriesService { get; }

        IGetAllCategoriesService GetAllCategoriesService { get; }

        IAddProductService AddProductService { get; }

        IGetProductsForAdminService GetProductsForAdminService { get; }

        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }
    }
}
