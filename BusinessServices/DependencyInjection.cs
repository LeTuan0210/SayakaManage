using BusinessServices.AutoMapperProfile;
using BusinessServices.Repositories.SystemPromotionServices;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessServices
{
    public static class DependencyInjection
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SystemPromotionMapperProfile).Assembly);

            // Promotion

            services.AddScoped<ISystemPromotionServerServices, SystemPromotionServerServices>();
            services.AddScoped<ISystemPromotionClientServices, SystemPromotionClientServices>();
            services.AddScoped<ISystemPromotionBaseServices, SystemPromotionBaseServices>();

            // 
        }
    }
}
