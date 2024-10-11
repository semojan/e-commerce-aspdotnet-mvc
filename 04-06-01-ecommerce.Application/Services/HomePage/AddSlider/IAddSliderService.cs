using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common;
using _04_06_01_ecommerce.Common.Dto;
using _04_06_01_ecommerce.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Application.Services.HomePage.AddSlider
{
    public interface IAddSliderService
    {
        ResultDto Execute(IFormFile file, string link);
    }

    public class AddSliderService : IAddSliderService
    {
        private readonly IHostingEnvironment _environment;
        private readonly IDataBaseContext _context;
        public AddSliderService(IHostingEnvironment hostingEnvironment,
            IDataBaseContext context)
        {
            _context = context;
            _environment = hostingEnvironment;
        }

        public ResultDto Execute(IFormFile file, string link)
        {
            Upload upload = new Upload(_environment);

            var uploadResult = upload.UploadFile(file, "HomePage/Slider");

            Slider slider = new Slider()
            {
                Src = uploadResult.FileNameAddress,
                Link = link
            };
            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return new ResultDto
            {
                Success = true,
                Message = ""
            };
        }
    }
}
