using _04_06_01_ecommerce.Domain.Entities.Commons;

namespace _04_06_01_ecommerce.Domain.Entities.Users
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
