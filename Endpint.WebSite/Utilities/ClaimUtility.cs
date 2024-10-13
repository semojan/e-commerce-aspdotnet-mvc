using _04_06_01_ecommerce.Domain.Entities.Users;
using System.Security.Claims;

namespace Endpint.WebSite.Utilities
{
    public class ClaimUtility
    {
        public static int? GetUserId (ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity.FindFirst(ClaimTypes.NameIdentifier) != null){
                    int userId = int.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                    return userId;
                }
                return null;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}