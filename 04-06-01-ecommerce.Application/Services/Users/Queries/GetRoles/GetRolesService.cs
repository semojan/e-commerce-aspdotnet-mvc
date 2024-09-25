using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Dto;

namespace _04_06_01_ecommerce.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDataBaseContext _context;

        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<RolesDto>> Execute()
        {
            var roles = _context.Roles.Select(p => new RolesDto
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();

            return new ResultDto<List<RolesDto>>()
            {
                Data = roles,
                Success = true,
                Message = ""
            };
        }
    }
}
