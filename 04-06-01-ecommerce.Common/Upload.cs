using _04_06_01_ecommerce.Common.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Common
{
    public class Upload
    {
        private readonly IHostingEnvironment _environment;
        public Upload(IHostingEnvironment hostingEnvironment)
        {
            _environment = hostingEnvironment;
        }
        public UploadDto UploadFile(IFormFile file, string destRepo)
        {
            if (file != null)
            { 
                string folder = $@"images/{destRepo}/";
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
