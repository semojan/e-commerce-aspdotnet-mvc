using _04_06_01_ecommerce.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Application.Services.Users.Commands.UserLoginService
{
    public interface IUserLoginService
    {
        public ResultDto<ResultUserloginDto> Execute(string username, string password);
    }
}
