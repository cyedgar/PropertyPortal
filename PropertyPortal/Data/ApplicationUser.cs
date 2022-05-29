using Microsoft.AspNetCore.Identity;

namespace PropertyPortal.Data
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdministrator { get; set; }
    }
}
