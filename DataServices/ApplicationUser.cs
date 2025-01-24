using Microsoft.AspNetCore.Identity;

namespace DataServices
{
    public class ApplicationUser : IdentityUser
    {
        public string UserFullname { get; set; }
    }
}
