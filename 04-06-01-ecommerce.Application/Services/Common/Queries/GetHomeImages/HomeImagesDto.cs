using _04_06_01_ecommerce.Domain.Entities.HomePage;

namespace _04_06_01_ecommerce.Application.Services.Common.Queries.GetHomeImages
{
    public class HomeImagesDto
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation Location { get; set; }
    }
}
