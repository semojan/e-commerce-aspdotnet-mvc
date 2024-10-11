using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;

namespace _04_06_01_ecommerce.Application.Services.Common.Queries.GetHomeImages
{
    public class GetHomeImagesService : IGetHomeImagesService
    {
        private readonly IDataBaseContext _context;
        public GetHomeImagesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<HomeImagesDto>> Execute()
        {
            var images = _context.HomePageImages.OrderByDescending(p => p.Id)
                .Select(p => new HomeImagesDto
                {
                    Id = p.Id,
                    Src = p.Src,
                    Link = p.link,
                    Location = p.ImageLocation
                }).ToList();

            return new ResultDto<List<HomeImagesDto>>()
            {
                Data = images,
                Success = true,
                Message = ""
            };
        }
    }
}
