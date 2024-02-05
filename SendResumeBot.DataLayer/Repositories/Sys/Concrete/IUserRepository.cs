using IHMA_INSON_bot.DataLayer.EfClasses;
using SendResumeBot.DataLayer.EfClasses;
using WEBASE.EF;

namespace SendResumeBot.DataLayer.Repositories
{
    public interface IUserRepository : IBaseEntityRepository<long, User, CreateUserDlDto, UpdateUserDlDto>
    {
    }
}
