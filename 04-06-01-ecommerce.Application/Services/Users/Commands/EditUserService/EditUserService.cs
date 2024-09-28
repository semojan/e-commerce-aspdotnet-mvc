using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;
using _04_06_01_ecommerce.Domain.Entities.Users;

namespace _04_06_01_ecommerce.Application.Services.Users.Commands.EditUserService
{
    public class EditUserService : IEditUserService
    {
        private readonly IDataBaseContext _context;
        public EditUserService(IDataBaseContext context) 
        {
            _context = context; 
        }
        public ResultDto<User> Execute(RequestEditUserDto request)
        {
            var user = _context.Users.Find(request.UserId);
            if (user == null)
            {
                return new ResultDto<User>()
                {
                    Success = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.FullName = request.FullName;
            _context.SaveChanges();

            return new ResultDto<User>()
            {
                Success =  true,
                Message = "ویرایش کاربر با موفقیت انجام شد."
            };
        }
    }

}
