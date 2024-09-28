using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common;

namespace _04_06_01_ecommerce.Application.Services.Users.Queries.GetUsers
{
    public class GetUserService : IGetUsersService
    {
        readonly IDataBaseContext _context;

        public GetUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultGetUserDto Execute(RequestGetUserDto request)
        {
            var users = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(u => u.FullName.Contains(request.SearchKey) && u.Email.Contains(request.SearchKey));
            }

            int rowsCount = 0;

            var userList = users.ToPaged(request.Page, 10, out rowsCount).Select( p => new GetUserDto
            {
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id,
                IsActive = p.IsActive,  
            }).ToList();

            return new ResultGetUserDto
            {
                Rows = rowsCount,
                Users = userList
            };
        }
    }
}
