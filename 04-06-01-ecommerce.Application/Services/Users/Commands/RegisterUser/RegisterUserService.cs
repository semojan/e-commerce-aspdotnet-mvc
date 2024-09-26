using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;
using _04_06_01_ecommerce.Domain.Entities.Users;

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
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0
                        },
                        Success = false,
                        Message = "ایمیل را وارد کنید."
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Fullname))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0
                        },
                        Success = false,
                        Message = "نام خود را وارد کنید."
                    };
                }
                if (string.IsNullOrEmpty(request.Password))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0
                        },
                        Success = false,
                        Message = "رمز عبور را وارد کنید."
                    };
                }
                if (request.Password != request.RePassword)
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0
                        },
                        Success = false,
                        Message = "رمز عبور و تکرار آن مطابقت ندارند."
                    };
                }

                User user = new User()
                {
                    Email = request.Email,
                    FullName = request.Fullname,
                    Password = request.Password,
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
            catch (Exception ex)
            {
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = 0,
                    },
                    Success = false,
                    //Message = "ثبت نام کاربر انجام نشد"
                    Message= ex.InnerException?.Message ?? ex.Message
                };
            }
            
        }
    }
}
