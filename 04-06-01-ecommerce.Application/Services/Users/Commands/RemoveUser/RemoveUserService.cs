using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;

namespace _04_06_01_ecommerce.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private IDataBaseContext _context;

        public RemoveUserService(IDataBaseContext context)
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

            user.DeleteTime = DateTime.Now;
            user.IsDeleted = true;

            _context.SaveChanges();


            return new ResultDto()
            {
                Success = true,
                Message = "کاربر حذف شد"
            };
        }
    }
}
