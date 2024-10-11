using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;

namespace _04_06_01_ecommerce.Application.Services.Common.Commands.RemoveSlider
{
    public class RemoveSliderService : IRemoveSliderService
    {
        private IDataBaseContext _context;

        public RemoveSliderService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(int SliderId)
        {
            var slider = _context.Sliders.Find(SliderId);
            if (slider == null)
            {
                return new ResultDto()
                {
                    Success = false,
                    Message = "اسلاید یافت نشد"
                };
            }

            slider.DeleteTime = DateTime.Now;
            slider.IsDeleted = true;

            _context.SaveChanges();


            return new ResultDto()
            {
                Success = true,
                Message = "اسلاید حذف شد"
            };
        }
    }
}
