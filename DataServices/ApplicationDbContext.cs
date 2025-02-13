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
        public DbSet<MemberInfo> MemberInfos { get; set; } = default!;
        public DbSet<ZaloToken> ZaloTokens { get; set; } = default!;
        public DbSet<CustomerOrder> CustomerOrders { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Config for Member and Favourite Restaurant

            //builder.Entity<MemberFavouriteRestaurant>()
            //    .HasKey(k => new { k.restaurantInfoId, k.memberInfoId });

            //builder.Entity<MemberFavouriteRestaurant>()
            //    .HasOne(member => member.memberInfo)
            //    .WithMany(member => member.favouriteRestaurant)
            //    .HasForeignKey(m => m.memberInfoId);

            //builder.Entity<MemberFavouriteRestaurant>()
            //    .HasOne(restaurant => restaurant.restaurantInfo)
            //    .WithMany(restaurant => restaurant.favouriteMember)
            //    .HasForeignKey(r => r.restaurantInfoId);

            builder.Entity<MemberInfo>()
                .HasMany(x => x.memberOrders)
                .WithOne(x => x.member)
                .HasForeignKey(k => k.memberId);
        }
    }
}
