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
        public DbSet<ZaloPromotion> ZaloPromotions { get; set; } = default!;
        public DbSet<ZaloPromotionButton> ZaloPromotionButtons { get; set; } = default!;
        public DbSet<ZaloPromotionElement> ZaloPromotionElements { get; set; } = default!;
        public DbSet<MemberTransaction> MemberTransactions { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MemberInfo>()
                .HasMany(x => x.memberOrders)
                .WithOne(x => x.member)
                .HasForeignKey(k => k.memberId);
        }
    }
}
