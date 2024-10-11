using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common;
using _04_06_01_ecommerce.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace _04_06_01_ecommerce.Application.Services.Products.Queries.GetProductsForCustomer
{
    public class GetProductsForCustomerService : IGetProductsForCustomerService
    {
        private readonly IDataBaseContext _context;
        public GetProductsForCustomerService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultProductsForCustomerDto> Execute(Ordering ordering, string SearchKey, int page, int pageSize, int? CategoryId)
        {
            int totalRow = 0;
            Random random = new Random();
            var productsQuery = _context.Products
                .Include(p => p.ProductImages)
                .AsQueryable();
            if(CategoryId != null)
            {
                productsQuery = productsQuery.Where(p => p.CategoryId == CategoryId || p.Category.ParentCategoryId == CategoryId).AsQueryable();
            }
            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                productsQuery = productsQuery.Where(p => p.Name.Contains(SearchKey) || p.Brand.Contains(SearchKey)).AsQueryable();
            }

            switch (ordering)
            {
                case Ordering.NoOrder:
                    productsQuery = productsQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.MostVisited:
                    productsQuery = productsQuery.OrderByDescending(p => p.ViewCount).AsQueryable();
                    break;
                case Ordering.BestSelling:
                    break;
                case Ordering.MostPopular:
                    break;
                case Ordering.Newest:
                    productsQuery = productsQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.Cheapest:
                    productsQuery = productsQuery.OrderBy(p => p.Price).AsQueryable();
                    break;
                case Ordering.MostExpensive:
                    productsQuery = productsQuery.OrderByDescending(p => p.Price).AsQueryable();
                    break;
            }

            var products = productsQuery
                .ToPaged(page, pageSize, out totalRow)
                .Select(p => new ProductsForCustomerDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageSrc = p.ProductImages.FirstOrDefault().Src,
                    Price = p.Price,
                    Score = random.Next(1,5)
                }).ToList();

            return new ResultDto<ResultProductsForCustomerDto>
            {
                Data = new ResultProductsForCustomerDto
                {
                    TotalRow = totalRow,
                    Products = products,
                },
                Success = true,
                Message = ""
            };

        }
    }
}
