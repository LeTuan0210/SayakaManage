using DataModels.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataServices
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<RestaurantArea> RestaurantAreas { get; set; } = default!;
        public DbSet<RestaurantInfo> RestaurantInfos { get; set; } = default!;
        public DbSet<RestaurantMenu> RestaurantMenus { get; set; } = default!;
        public DbSet<SystemPromotion> SystemPromotions { get; set; } = default!;
    }
}
