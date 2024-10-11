using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common;
using _04_06_01_ecommerce.Common.Dto;
using _04_06_01_ecommerce.Domain.Entities.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace _04_06_01_ecommerce.Application.Services.Products.Commands.AddProduct
{
    public class AddProductService : IAddProductService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddProductService(IDataBaseContext context,
            IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }

        public ResultDto Execute(RequestAddProductDto request)
        {
            try
            {
                var category = _context.Categories.Find(request.CategoryId);

                Product product = new Product()
                {
                    Name = request.Name,
                    Brand = request.Brand,
                    Description = request.Description,
                    Price = request.Price,
                    Inventory = request.Inventory,
                    Display = request.Display,
                    Category = category,
                    CategoryId = request.CategoryId,
                };
                _context.Products.Add(product);
                List<ProductImages> images = new List<ProductImages>();

                Upload upload = new Upload(_environment);
                foreach (var item in request.Images)
                {
                    var uploadResult = upload.UploadFile(item, "productImages");
                    images.Add(new ProductImages
                    {
                        Product = product,
                        Src = uploadResult.FileNameAddress,
                    });
                }

                _context.ProductImages.AddRange(images);

                List<ProductFeatures> features = new List<ProductFeatures>();
                foreach (var item in request.Features)
                {
                    features.Add(new ProductFeatures
                    {
                        Product = product,
                        DisplayName = item.DisplayName,
                        Value = item.Value,
                    });
                }

                _context.ProductFeatures.AddRange(features);

                _context.SaveChanges();

                return new ResultDto()
                {
                    Success = true,
                    Message = "محصول با موفقیت ثبت شد"
                };
            }catch(Exception ex)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "خطا رخ داد ",
                };
            }
            



            throw new NotImplementedException();
        }     
    }
}
