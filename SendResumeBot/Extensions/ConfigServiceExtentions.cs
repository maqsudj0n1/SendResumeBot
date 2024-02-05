using SendResumeBot;

namespace IHMA_INSON_bot.Extensions
{
    public static class ConfigServiceExtentions
    {
        public static void ConfigureConfigs(this IServiceCollection services)
        {
            services.AddSingleton(AppSettings.Instance.Culture);
            services.AddSingleton(AppSettings.Instance.Jwt);
            services.AddSingleton(AppSettings.Instance.Cookie);
        }
    }
}
