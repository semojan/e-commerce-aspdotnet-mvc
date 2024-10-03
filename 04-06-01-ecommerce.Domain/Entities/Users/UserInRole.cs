using _04_06_01_ecommerce.Domain.Entities.Commons;

namespace _04_06_01_ecommerce.Domain.Entities.Users
{
    public class UserInRole : BaseEntity
    {
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
