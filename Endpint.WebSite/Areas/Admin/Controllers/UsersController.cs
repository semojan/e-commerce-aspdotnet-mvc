using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using Bugeto_Store.Application.Services.Users.Commands.EditUser;
using Bugeto_Store.Application.Services.Users.Commands.RemoveUser;
using Bugeto_Store.Application.Services.Users.Commands.RgegisterUser;
using Bugeto_Store.Application.Services.Users.Commands.UserSatusChange;
using Bugeto_Store.Application.Services.Users.Queries.GetRoles;
using Bugeto_Store.Application.Services.Users.Queries.GetUsers;
=======
using _04_06_01_ecommerce.Application.Services.Users.Commands.RegisterUser;
using _04_06_01_ecommerce.Application.Services.Users.Commands.RemoveUser;
using _04_06_01_ecommerce.Application.Services.Users.Queries.GetRoles;
using _04_06_01_ecommerce.Application.Services.Users.Queries.GetUsers;
>>>>>>> parent of 0d74087 (edit user added)
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
<<<<<<< HEAD
        private readonly IUserSatusChangeService _userSatusChangeService;
        private readonly IEditUserService _editUserService;
        public UsersController(IGetUsersService getUsersService
            , IGetRolesService getRolesService
            , IRegisterUserService registerUserService
            , IRemoveUserService removeUserService
            , IUserSatusChangeService userSatusChangeService
            , IEditUserService editUserService)
=======


        public UsersController(
            IGetUsersService getUsersService, 
            IGetRolesService getRolesService,
            IRegisterUserService registerUserService,
            IRemoveUserService removeUserService)
>>>>>>> parent of 0d74087 (edit user added)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
<<<<<<< HEAD
            _userSatusChangeService = userSatusChangeService;
            _editUserService = editUserService;
=======
>>>>>>> parent of 0d74087 (edit user added)
        }


        public IActionResult Index(string serchkey, int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = serchkey,
            }));
        }





        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                roles = new List<RolesInRegisterUserDto>()
                   {
                        new RolesInRegisterUserDto
                        {
                             Id= RoleId
                        }
                   },
                Password = Password,
                RePasword = RePassword,
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }
<<<<<<< HEAD

        [HttpPost]
        public IActionResult UserSatusChange(long UserId)
        {
            return Json(_userSatusChangeService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId, string Fullname)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                Fullname = Fullname,
                UserId = UserId,
            }));
        }

=======
            
>>>>>>> parent of 0d74087 (edit user added)
    }
}
