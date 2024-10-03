using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;
using Bugeto_Store.Common;
using Microsoft.EntityFrameworkCore;

namespace _04_06_01_ecommerce.Application.Services.Users.Commands.LoginUser
{
    public class LoginUserService : ILoginUserService
    {
        private readonly IDataBaseContext _context;
        public LoginUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultLoginUserDto> Execute(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return new ResultDto<ResultLoginUserDto>()
                {
                    Data = new ResultLoginUserDto()
                    {

                    },
                    Success = false,
                    Message = "نام کاربری و رمز عبور را وارد نمایید",
                };
            }

            var user = _context.Users
                .Include(p => p.UserInRoles)
                .ThenInclude(p => p.Role)
                .Where(p => p.Email.Equals(username)
            && p.IsActive == true)
            .FirstOrDefault();

            if (user == null)
            {
                return new ResultDto<ResultLoginUserDto>()
                {
                    Data = new ResultLoginUserDto()
                    {

                    },
                    Success = false,
                    Message = "کاربری با این ایمیل در فروشگاه ثبت نام نکرده",
                };
            }

            var passwordHasher = new PasswordHasher();
            bool resultVerifyPassword = passwordHasher.VerifyPassword(user.Password, password);

            if (resultVerifyPassword == false)
            {
                return new ResultDto<ResultLoginUserDto>()
                {
                    Data = new ResultLoginUserDto()
                    {

                    },
                    Success = false,
                    Message = "رمز عبور اشتباه است",
                };
            }

            var roles = "";
            foreach (var item in user.UserInRoles)
            {
                roles += $"{item.Role.Name}";
            }


            return new ResultDto<ResultLoginUserDto>()
            {
                Data = new ResultLoginUserDto()
                {
                    Roles = roles,
                    UserId = user.Id,
                    Name = user.FullName
                },
                Success = true,
                Message = "ورود به سایت با موفقیت انجام شد",
            };

        }
    }
}