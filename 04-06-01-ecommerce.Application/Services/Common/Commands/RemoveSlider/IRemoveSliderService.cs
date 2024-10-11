using _04_06_01_ecommerce.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Application.Services.Common.Commands.RemoveSlider
{
    public interface IRemoveSliderService
    {
        ResultDto Execute(int SliderId);
    }
}
