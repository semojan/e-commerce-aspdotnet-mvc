using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _04_06_01_ecommerce.Application.Services.Users.Queries.GetRoles;
using _04_06_01_ecommerce.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;

        public UsersController(IGetUsersService getUsersService, IGetRolesService getRolesService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
        }

        [Area("Admin")]
        public IActionResult Index(String SearchKey, int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto
            {
                SearchKey = SearchKey,
                Page = page
            }));
        }

        [Area("Admin")]
        public IActionResult Create()
        {
            var result = _getRolesService.Execute();

            ViewBag.Roles = new SelectList(result.Data, "Id", "Name");
            //ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "name");
            return View();
        }
    }
}
