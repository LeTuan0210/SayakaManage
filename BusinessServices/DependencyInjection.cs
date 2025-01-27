using BusinessServices.AutoMapperProfile;
using BusinessServices.Extensions;
using BusinessServices.Repositories;
using BusinessServices.Repositories;
using BusinessServices.Repositories;
using BusinessServices.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessServices
{
    public static class DependencyInjection
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SystemPromotionMapperProfile).Assembly);
            services.AddScoped<SeedData>();

            // Promotion

            services.AddScoped<ISystemPromotionServerServices, SystemPromotionServerServices>();
            services.AddScoped<ISystemPromotionClientServices, SystemPromotionClientServices>();
            services.AddScoped<ISystemPromotionBaseServices, SystemPromotionBaseServices>();

            // Menu Services

            services.AddScoped<IMenuBaseServices, MenuBaseServices>();
            services.AddScoped<IMenuServerServices, MenuServerServices>();
            services.AddScoped<IMenuClientServices, MenuClientServices>();

            // Resrautant Services

            services.AddScoped<IRestaurantBaseServices, RestaurantBaseServices>();
            services.AddScoped<IRestaurantServerServices, RestaurantServerServices>();
            services.AddScoped<IRestaurantClientServices, RestaurantClientServices>();

            // Restaurant Area Services

            services.AddScoped<IRestaurantAreaBaseServices, RestaurantAreaBaseServices>();
            services.AddScoped<IRestaurantAreaServerServices, RestaurantAreaServerServices>();
        }
    }
}
