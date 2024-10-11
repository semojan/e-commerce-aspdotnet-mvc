using _04_06_01_ecommerce.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Http;

namespace _04_06_01_ecommerce.Application.Services.HomePage.AddHomePageImages
{
    public class RequestAddHomeImagesDto
    {
        public IFormFile File { get; set; }
        public string Link { get; set; }
        public ImageLocation Location { get; set; }
    }
}
