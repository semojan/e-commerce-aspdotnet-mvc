namespace _04_06_01_ecommerce.Application.Services.Users.Queries.GetUsers
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
