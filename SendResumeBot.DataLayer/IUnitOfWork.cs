
using Microsoft.EntityFrameworkCore.Storage;
using SendResumeBot.DataLayer.Repositories;
using SendResumeBot.Models;

namespace SendResumeBot.DataLayer
{
    public interface IUnitOfWork
    {
        EfCoreContext Context { get; }
        IDbContextTransaction CurrentTransaction { get; }
        TRepository GetRepository<TRepository>();

        #region Repositories
        IUserRepository UserRepository { get; }
        

        #endregion

        IDbContextTransaction BeginTransaction();
        void Save();
        void Commit();
        void Rollback();
    }
}
