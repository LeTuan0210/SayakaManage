using DataModels.Entities;
using Microsoft.AspNetCore.Identity;

namespace DataServices
{
    public class ApplicationUser : IdentityUser
    {
        public string UserFullname { get; set; }
        public string? Position { get; set; }
        public Guid? RestaurantId { get; set; }
        public RestaurantInfo? Restaurant { get; set; }
    }
}
