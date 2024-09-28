using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _04_06_01_ecommerce.Application.Services.Users.Commands.ChangeStatusUser;
using _04_06_01_ecommerce.Application.Services.Users.Commands.EditUserService;
using _04_06_01_ecommerce.Application.Services.Users.Commands.RegisterUser;
using _04_06_01_ecommerce.Application.Services.Users.Commands.RemoveUser;
using _04_06_01_ecommerce.Application.Services.Users.Queries.GetRoles;
using _04_06_01_ecommerce.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IChangeStatusUserService _changeStatusUserService;
        private readonly IEditUserService _editUserService;


        public UsersController(
            IGetUsersService getUsersService, 
            IGetRolesService getRolesService,
            IRegisterUserService registerUserService,
            IRemoveUserService removeUserService,
            IChangeStatusUserService changeStatusUserService,
            IEditUserService editUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _changeStatusUserService = changeStatusUserService;
            _editUserService = editUserService;
        }

        [HttpGet]
        public IActionResult Index(String SearchKey, int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto
            {
                SearchKey = SearchKey,
                Page = page
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var result = _getRolesService.Execute();

            ViewBag.Roles = new SelectList(result.Data, "Id", "Name");
            //ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Email, string FullName, int RoleId, string Password, string RePassword)
        {
            try
            {
                var result = _registerUserService.Execute(new RequestRegisterUserDto()
                {
                    Fullname = FullName,
                    Email = Email,
                    Roles = new List<RolesInRegisterUserDto>()
                    {
                        new RolesInRegisterUserDto() {
                            Id = RoleId,
                        }
                    },
                    Password = Password,
                    RePassword = RePassword
                });

                return Json(result);
            }catch(Exception ex)
            {
                return Json(new { isSuccess = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Delete(int UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }
            
        [HttpPost]
        public IActionResult ChangeStatus(int UserId)
        {
            return Json(_changeStatusUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(int UserId, string FullName)
        {
            return Json(_editUserService.Execute(new RequestEditUserDto()
            {
                FullName = FullName,
                UserId = UserId
            }));
        }
    }
}
