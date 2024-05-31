using SalonAuto.Features.Interfaces.Managers;
using SalonAuto.Features.Managers;
using Logic.Extensions;

namespace SalonAuto.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddLogicServices();

            services.AddTransient<ICenterManager, CenterManager>();
        }
    }
}
