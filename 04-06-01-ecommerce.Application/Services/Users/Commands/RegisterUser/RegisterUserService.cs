using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;
using _04_06_01_ecommerce.Domain.Entities;

namespace _04_06_01_ecommerce.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;


        public RegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            User user = new User()
            {
                Email = request.Email,
                FullName = request.Fullname
            };

            List<UserInRole> userInRoles = new List<UserInRole>();

            foreach (var item in request.Roles)
            {
                var roles = _context.Roles.Find(item.Id);
                userInRoles.Add(new UserInRole
                {
                    Role = roles,
                    RoleId = roles.Id,
                    User = user,
                    UserId = user.Id
                });
            }

            user.UserInRoles = userInRoles;

            _context.Users.Add(user);
            _context.SaveChanges();

            return new ResultDto<ResultRegisterUserDto>()
            {
                Data = new ResultRegisterUserDto()
                {
                    UserId = user.Id,
                },
                Success = true,
                Message = "ثبت نام کاربر با موفقیت انجام شد"
            };
        }
    }
}
