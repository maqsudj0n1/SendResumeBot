using SendResumeBot.BizLogicLayer.Models;
using SendResumeBot.DataLayer.Repositories;
using StatusGeneric;
using WEBASE.Models;

namespace SendResumeBot.BizLogicLayer.Services
{
    public interface IUserService : IStatusGeneric
    {
        PagedResult<UserListDto> GetList(TableSortFilterPageOptions dto);
        UserDto Get();
        UserDto Get(int id);
        HaveId<long> Create(CreateUserDto dto);
        void Update(UpdateUserDlDto dto);
        void Delete(int id);
    }
}
