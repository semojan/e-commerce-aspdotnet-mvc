using _04_06_01_ecommerce.Application.Services.Users.Commands.RegisterUser;
using _04_06_01_ecommerce.Common.Dto;
using Endpint.WebSite.Models.ViewModels.Aithentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.RegularExpressions;
using _04_06_01_ecommerce.Application.Services.Users.Commands.LoginUser;
using Azure.Core;

namespace Endpint.WebSite.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly ILoginUserService _loginUserService;

        public AuthenticationController(IRegisterUserService registerUserService,
            ILoginUserService loginUserService)
        {
            _registerUserService = registerUserService;
            _loginUserService = loginUserService;
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupViewModel request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.RePassword))
            {
                return Json(new ResultDto()
                {
                    Success = false,
                    Message = "لطفا موارد خواسته شده را وارد کنید."
                });
            } 
            if (User.Identity.IsAuthenticated == true)
            {
                return Json(new ResultDto()
                {
                    Success = false,
                    Message = "در حال حاضر نمیتوانید ثبت نام مجدد انجام دهید."
                });
            }
            if (request.Password != request.RePassword)
            {
                return Json(new ResultDto()
                {
                    Success = false,
                    Message = "رمز عبور و تکرار آن برابر نیستند."
                });
            }
            if (request.Password.Length < 8)
            {
                return Json(new ResultDto()
                {
                    Success = false,
                    Message = "رمز عبور باید حداقل 8 کارکتر باشد."
                });
            }

            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";

            var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return Json(new ResultDto { Success = false, Message = "ایمیل خودرا به درستی وارد نمایید" });
            }


            var signeupResult = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = request.Email,
                Fullname = request.FullName,
                Password = request.Password,
                RePassword = request.RePassword,
                Roles = new List<RolesInRegisterUserDto>()
                {
                     new RolesInRegisterUserDto { Id = 3 },
                }
            });

            if (signeupResult.Success == true)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,signeupResult.Data.UserId.ToString()),
                    new Claim(ClaimTypes.Email, request.Email),
                    new Claim(ClaimTypes.Name, request.FullName),
                    new Claim(ClaimTypes.Role, "Customer"),
                };


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(signeupResult);
        }

        [HttpGet]
        public IActionResult Login (string returnUrl = "/")
        {
            ViewBag.url = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email,  string Password, string url = "/")
        {
            var signupResult = _loginUserService.Execute(Email, Password);
            if (signupResult.Success == true)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,signupResult.Data.UserId.ToString()),
                    new Claim(ClaimTypes.Email, Email),
                    new Claim(ClaimTypes.Name, signupResult.Data.Name),
                    new Claim(ClaimTypes.Role, signupResult.Data.Roles ),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(signupResult);
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

    }
}
