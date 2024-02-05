using GenericServices.Setup;
using NetCore.AutoRegisterDi;
using SendResumeBot.BizLogicLayer.Services;
using SendResumeBot.Models;
using System.Reflection;

namespace IHMA_INSON_bot.Extensions
{
    public static class GenericServiceExtentions
    {
        public static void ConfigureGenericServices(this IServiceCollection services)
        {
            services.GenericServicesSimpleSetup<EfCoreContext>(
                Assembly.GetAssembly(typeof(UserDto)), //Service layer
                Assembly.GetAssembly(typeof(EfCoreContext)) //Data layer
            );

            services.RegisterAssemblyPublicNonGenericClasses(
                Assembly.GetAssembly(typeof(UserDto)), //Service layer
                Assembly.GetAssembly(typeof(EfCoreContext)) //Data layer
            )
            .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
        }
    }
}
