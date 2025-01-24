using DataServices.Interfaces;
using DataServices.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DataServices
{
    public static class DependencyInjection
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<ISystemPromotionDataServices, SystemPromotionDataServices>();
        }
    }
}
