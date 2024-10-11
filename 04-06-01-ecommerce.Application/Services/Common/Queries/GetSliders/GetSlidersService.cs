using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;

namespace _04_06_01_ecommerce.Application.Services.Common.Queries.GetSliders
{
    public class GetSlidersService : IGetSlidersService
    {
        private readonly IDataBaseContext _context;
        public GetSlidersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<SliderDto>> Execute()
        {
            var sliders = _context.Sliders.OrderByDescending(p => p.Id).ToList()
                .Select(p => new SliderDto
                {
                    Id = p.Id,
                    Src = p.Src,
                    Link = p.Link,
                }).ToList();

            return new ResultDto<List<SliderDto>>
            {
                Data = sliders,
                Success = true
            };
        }
    }
}
