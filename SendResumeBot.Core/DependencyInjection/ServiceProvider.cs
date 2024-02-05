using Microsoft.EntityFrameworkCore;
using SendResumeBot.Core.Security;
using WEBASE.DependencyInjection;

namespace SendResumeBot;

public class ServiceProvider : BaseServiceProvider<IAuthService>
{
    public static DbContext Context { get => GetService<DbContext>(); }
}
