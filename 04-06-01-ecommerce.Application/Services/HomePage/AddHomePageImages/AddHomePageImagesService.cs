using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common;
using _04_06_01_ecommerce.Common.Dto;
using _04_06_01_ecommerce.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Hosting;

namespace _04_06_01_ecommerce.Application.Services.HomePage.AddHomePageImages
{
    public class AddHomePageImagesService : IAddHomePageImagesService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddHomePageImagesService(IDataBaseContext context,
            IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }
        public ResultDto Execute(RequestAddHomeImagesDto request)
        {
            Upload upload = new Upload(_environment);
            var resultUpload = upload.UploadFile(request.File, "HomePage/Images");
            HomePageImage homePageImage = new HomePageImage()
            {
                link = request.Link,
                Src = resultUpload.FileNameAddress,
                ImageLocation = request.Location,
            };

            _context.HomePageImages.Add(homePageImage);
            _context.SaveChanges();

            return new ResultDto()
            {
                Success = true,
                Message = ""
            };
        }
    }
}
