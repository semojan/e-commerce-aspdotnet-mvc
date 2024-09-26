namespace _04_06_01_ecommerce.Application.Services.Users.Commands.RegisterUser
{
    public class RequestRegisterUserDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }

        public List<RolesInRegisterUserDto> Roles { get; set; }
    }
}
