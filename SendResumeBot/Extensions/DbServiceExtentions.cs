using Microsoft.EntityFrameworkCore;
using SendResumeBot;
using SendResumeBot.DataLayer.EfCode;
using SendResumeBot.Models;
using WEBASE.EF;

namespace IHMA_INSON_bot.Extensions
{
    public static class DbServiceExtentions
    {
        public static void ConfigureDbServices(this IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<EfCoreContext, PgSqlContext>(options =>
            {
                options.UseNpgsql(AppSettings.Instance.Database.PgSql.ConnectionString);
#if DEBUG
                options.EnableSensitiveDataLogging(true);
#endif
            });
            services.AddScoped<BaseDbContext>(x => x.GetService<EfCoreContext>());
        }
    }
}
