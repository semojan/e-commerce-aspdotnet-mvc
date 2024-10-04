using _04_06_01_ecommerce.Application.Interface.Context;
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

                foreach (var item in request.Images)
                {
                    var uploadResult = UploadFile(item);
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

        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images/productImages/";
                var uploadRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadRootFolder))
                {
                    Directory.CreateDirectory(uploadRootFolder);
                }

                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }
}
