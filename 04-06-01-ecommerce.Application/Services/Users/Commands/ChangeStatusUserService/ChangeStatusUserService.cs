using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;

namespace _04_06_01_ecommerce.Application.Services.Users.Commands.ChangeStatusUser
{
    public class ChangeStatusUserService : IChangeStatusUserService
    {
        private readonly IDataBaseContext _context;
        public ChangeStatusUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int UserId)
        {
            var user = _context.Users.Find(UserId);
            if (user == null)
            {
                return new ResultDto()
                {
                    Success = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            string userState = user.IsActive ? "فعال" : "غیرفعال";
            return new ResultDto()
            {
                Success = true,
                Message = $"کاربر با موفقیت {userState} شد!"
            };
        }
    }
}
